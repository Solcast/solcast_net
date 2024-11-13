import json
import os
import re
import requests
import yaml
import argparse


def load_openapi_spec(path_or_url):
    """
    Load OpenAPI specification from a local file or a URL.

    :param path_or_url: Path to the local file or URL of the OpenAPI spec.
    :return: The content of the OpenAPI spec.
    """
    if path_or_url.startswith('http://') or path_or_url.startswith('https://'):
        # It's a URL
        response = requests.get(path_or_url)
        response.raise_for_status()  # Raise an error for bad status codes
        return yaml.safe_load(response.text)
    elif os.path.isfile(path_or_url):
        # It's a local file
        with open(path_or_url, 'r') as file:
            return yaml.safe_load(file)
    else:
        raise ValueError("The provided path_or_url is neither a valid URL nor a local file path.")


def generate_api_response_class():
    """Generates the ApiResponse class."""
    api_response_code = """
namespace Solcast.Utilities
{
    public class ApiResponse<T>(T data, string rawResponse)
    {
        public T Data { get; set; } = data;
        public string RawResponse { get; set; } = rawResponse;
    }
}
"""
    return api_response_code


def resolve_reference(spec, ref):
    """Resolve $ref in the OpenAPI/Swagger spec."""
    parts = ref.lstrip('#/').split('/')
    result = spec
    for part in parts:
        result = result[part]
    return result


def get_endpoint_details(spec, endpoint, method):
    """Extract details for a given endpoint and method."""
    paths = spec.get('paths', {})
    endpoint_info = paths.get(endpoint, {}).get(method, {})

    # Handle Swagger 2.0 and OpenAPI 3.0 differences
    parameters = []
    if 'parameters' in endpoint_info:
        parameters = endpoint_info.get('parameters', [])
    elif 'requestBody' in endpoint_info:
        request_body = endpoint_info.get('requestBody', {})
        if request_body and 'content' in request_body:
            # Only handles the first content type for simplicity
            content = list(request_body['content'].values())[0]
            parameters = [{'name': 'body', 'in': 'body', 'schema': content['schema']}]

    # Resolve references for parameters
    resolved_parameters = []
    for param in parameters:
        if '$ref' in param:
            resolved_param = resolve_reference(spec, param['$ref'])
            resolved_parameters.append(resolved_param)
        else:
            resolved_parameters.append(param)

    return resolved_parameters


def map_openapi_type_to_csharp(openapi_type=None, format=None, schema=None, spec=None):
    """Map OpenAPI types to C# types, including body schemas with $ref."""
    if schema and spec:
        if '$ref' in schema:
            resolved_schema = resolve_reference(spec, schema['$ref'])
            return resolved_schema.get('title', schema['$ref'].split('/')[-1])
        elif 'type' in schema:
            openapi_type = schema['type']
            format = schema.get('format')

    if not openapi_type:
        openapi_type = "string"

    if openapi_type == "number":
        if format == "float":
            return "float?"
        elif format == "double":
            return "double?"
        else:
            return "double?"
    elif openapi_type == "integer":
        return "int?"
    elif openapi_type == "boolean":
        return "bool?"
    elif openapi_type == "array":
        if schema:
            items = schema.get('items', {})
            item_type = map_openapi_type_to_csharp(items.get('type'), items.get('format'), items, spec)
            return f"List<{item_type}>"
        else:
            return "List<string>"  # Default to List<string> if no schema information is available
    elif openapi_type == "object" and schema:
        return schema.get('title', "Dictionary<string, object>")
    else:
        return "string"


def to_pascal_case(string):
    """Convert a string to PascalCase."""
    return re.sub(r'(_|-)+', ' ', string).title().replace(' ', '')


def to_camel_case(string):
    """Convert a string to camelCase."""
    return string[0].lower() + to_pascal_case(string)[1:]


def generate_csharp_class_with_usings(class_name, methods, required_usings):
    """Generates a C# class that contains multiple methods and the necessary 'using' statements."""

    # Combine necessary usings into the header
    usings = "\n".join([f"using {u};" for u in order_namespaces(required_usings)])

    class_template = f"""
{usings}

namespace Solcast.Clients
{{
    public class {class_name} : BaseClient
    {{
        public {class_name}()
        {{
        }}{methods}
    }}
}}
"""
    return class_template


# Base Client Generation
def generate_base_client():
    """Generates the base client class."""
    base_client_code = """
using System;
using System.Net.Http;

namespace Solcast.Clients
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _httpClient;

        protected BaseClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }
    }
}
"""
    return base_client_code


# Specific Client Generation
def generate_specific_client_class(class_name, methods, required_usings):
    """Generates a specific client class that inherits from the base client."""
    usings = "\n".join([f"using {u};" for u in order_namespaces(required_usings)])

    class_template = f"""
{usings}

namespace Solcast.Clients
{{
    public class {class_name} : BaseClient
    {{
        public {class_name}()
        {{
        }}

{methods}
    }}
}}
"""
    return class_template


def order_namespaces(namespaces, app_namespace="Solcast"):
    """
    Orders a set of namespaces according to the recommended sequence:
    1. System namespaces
    2. Third-party namespaces (non-System, non-application specific)
    3. Application-specific namespaces
    4. Alias and static using directives (handled separately)

    Args:
        namespaces (set): A set of namespace strings.

    Returns:
        list: An ordered list of namespaces.
    """
    # Separate namespaces into categories
    system_namespace = [ns for ns in namespaces if ns == "System"]
    system_namespaces = sorted([ns for ns in namespaces if ns.startswith("System.")])
    third_party_namespaces = sorted([ns for ns in namespaces if not ns.startswith("System") and not ns.startswith(app_namespace)])
    app_specific_namespaces = sorted([ns for ns in namespaces if ns.startswith(app_namespace)])
    alias_and_static = sorted([ns for ns in namespaces if "static" in ns or "=" in ns])

    # Combine all categories in the recommended order
    ordered_namespaces = system_namespace + system_namespaces + \
        third_party_namespaces + app_specific_namespaces + alias_and_static
    # print(ordered_namespaces)
    # import pdb; pdb.set_trace()

    return ordered_namespaces


def generate_csharp_method_with_usings(endpoint, method, parameters, spec, response_type=None, context=""):
    """Generates a C# method for the given endpoint, method, and parameters, and returns necessary 'using' statements."""

    required_usings = {"System", "System.Net.Http", "System.Threading.Tasks", "System.Collections.Generic", "System.Linq", "Solcast.Utilities"}
    if response_type:
        required_usings.update({"Solcast.Utilities"})

    # Default response type if not provided
    response_type = response_type or "string"

    # Include context in the function name if provided
    last_segment = endpoint.split('/')[-1]
    context_prefix = to_pascal_case(context) if context else ""
    function_name = f"{method.capitalize()}{context_prefix}{to_pascal_case(last_segment)}"

    # Separate parameters into required, optional, and body
    required_params = [param for param in parameters if param.get('required', False) and param['in'] != 'body']
    optional_params = [param for param in parameters if not param.get('required', False) and param['in'] != 'body']
    body_param = next((param for param in parameters if param['in'] == 'body'), None)

    # Generate XML comments for the method
    method_description = spec.get('paths', {}).get(endpoint, {}).get(method, {}).get('description', "")
    xml_comment = generate_xml_comment(method_description)
    param_comments = "\n"
    for param in parameters:
        param_name = to_camel_case(param['name'])
        param_description = param.get('description', "")
        param_comments += f"        /// <param name=\"{param_name}\">{param_description}</param>\n"

    # Build method signature with XML comments
    method_signature = f"{xml_comment}{param_comments}        public async Task<ApiResponse<{response_type}>> {function_name}(\n"
    param_list = []

    # Add required parameters to signature
    for param in required_params:
        param_name = to_camel_case(param['name'])
        param_type = map_openapi_type_to_csharp(param.get('type'), param.get('format'), param.get('schema'), spec)
        param_list.append(f"            {param_type} {param_name}")

    # Add body parameter to signature if present
    if body_param:
        body_type = map_openapi_type_to_csharp(None, None, body_param['schema'], spec)
        param_list.append(f"            {body_type} body")
        required_usings.add("Newtonsoft.Json")

    # Add optional parameters to signature
    for param in optional_params:
        param_name = to_camel_case(param['name'])
        param_type = map_openapi_type_to_csharp(param.get('type'), param.get('format'), param.get('schema'), spec)
        param_list.append(f"            {param_type} {param_name} = null")

        if param_type == "List<string>":
            required_usings.add("System.Collections.Generic")

    # Complete the method signature
    method_signature += ",\n".join(param_list) + "\n        )"

    # Start building the method body
    method_body = "\n        {\n"
    method_body += "            var parameters = new Dictionary<string, string>();\n"

    # Add required parameters to the query string
    for param in required_params:
        param_name = to_camel_case(param['name'])
        method_body += f"            parameters.Add(\"{param_name}\", {param_name}.ToString());\n"

    # Add optional parameters to the query string
    for param in optional_params:
        param_name = to_camel_case(param['name'])
        param_type = map_openapi_type_to_csharp(param.get('type'), param.get('format'), param.get('schema'), spec)

        if param_type in ["double?", "int?", "float?", "bool?"]:
            method_body += f"            if ({param_name}.HasValue) parameters.Add(\"{param_name}\", {param_name}.Value.ToString());\n"
        elif param_type == "List<string>":
            method_body += f"            if ({param_name} != null && {param_name}.Any()) parameters.Add(\"{param_name}\", string.Join(\",\", {param_name}));\n"
        else:
            method_body += f"            if ({param_name} != null) parameters.Add(\"{param_name}\", {param_name}.ToString());\n"

    # Add JSON body parameter handling if present
    if body_param:
        method_body += """
            var jsonContent = JsonConvert.SerializeObject(body);
            var requestBody = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        """

    # Convert the endpoint to a constant from SolcastUrls
    endpoint_constant = to_pascal_case('_'.join(endpoint.strip('/').split('/')[1:]))

    # Add request execution and response handling
    method_body += """
            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.""" + (to_pascal_case(method) + "Async") + f"""(SolcastUrls.{endpoint_constant} + $"?{{queryString}}"{", requestBody" if body_param else ""});

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {{
                throw new UnauthorizedAccessException("Invalid API key.");
            }}

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();\n"""

    # Add conditional deserialization based on the 'format' parameter
    if response_type:
        required_usings.add("Newtonsoft.Json")
        method_body += """
            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<""" + response_type + """>(rawContent);
                return new ApiResponse<""" + response_type + """>(data, rawContent);
            }
            return new ApiResponse<""" + response_type + """>(null, rawContent);
        }"""
    else:
        method_body += "            return new ApiResponse<string>(null, rawContent);\n        }"

    return method_signature + method_body, required_usings


def extract_endpoints_from_spec(spec, endpoint_groups):
    """Extracts endpoint URLs and operation IDs or summaries from the OpenAPI spec, filtering by endpoint groups."""
    endpoint_details = {group: {} for group in endpoint_groups}
    paths = spec.get('paths', {})

    for endpoint, methods in paths.items():
        # Determine which endpoint group this endpoint belongs to
        group = next((group for group in endpoint_groups if endpoint.startswith(group)), None)
        if not group:
            continue

        for method, details in methods.items():
            if method == 'parameters':
                continue
            # Prefer operationId, but fall back to summary if available
            operation_id = details.get('operationId', None)
            summary = details.get('summary', None)
            key = operation_id if operation_id else summary
            if key:
                # Convert operation ID or summary to a PascalCase constant name
                constant_name = generate_constant_name_from_url(endpoint)
                endpoint_details[group][constant_name] = endpoint.strip('/')

    return endpoint_details


def generate_constant_name_from_url(url):
    """Generates a constant name from the endpoint URL."""
    # Remove leading and trailing slashes, split by slashes, and join using PascalCase
    parts = url.strip('/').split('/')
    return ''.join(to_pascal_case(part) for part in parts[1:])


def generate_solcast_urls_class_from_spec(endpoint_details):
    """Generates the SolcastUrls class with dynamically extracted endpoints from the spec, grouped by endpoint groups."""
    base_url = os.getenv("SOLCAST_API_BASE_URL", "https://api.solcast.com.au")
    urls_code = '''
namespace Solcast
{
    public static class SolcastUrls
    {
        public static readonly string BaseUrl = "''' + base_url + '''";

'''
    for group, endpoints in endpoint_details.items():
        # Add a comment for the endpoint group
        group_comment = f"        // {' '.join(group.strip('/').split('/')[-1].split('_'))} data endpoints"
        urls_code += f"\n{group_comment}\n"

        for constant_name, endpoint in endpoints.items():
            urls_code += f'        public static readonly string {constant_name} = "{endpoint}";\n'

    urls_code += """
    }
}
"""
    return urls_code


def generate_xml_comment(description):
    """Generate an XML comment from a multi-line description string with each line prefixed by ///."""
    if description:
        # Split the description into lines and prefix each with "///"
        comment_lines = "\n".join(f"        /// {line}" for line in description.splitlines())
        return f"\n\n        /// <summary>\n{comment_lines}\n        /// </summary>"
    return "\n"


# Generate Models for Requests and Responses
def generate_csharp_model_class(class_name, properties, required_properties, spec):
    """Generates a C# class for a model (request or response), with appropriate using statements."""
    class_code = f"public class {class_name}\n{{\n"
    required_usings = {"Newtonsoft.Json"}

    for prop_name, prop_info in properties.items():
        description = prop_info.get('description', "")
        xml_comment = generate_xml_comment(description)

        # Check if the property is a $ref to another definition
        if '$ref' in prop_info:
            resolved_schema = resolve_reference(spec, prop_info['$ref'])
            prop_type = resolved_schema.get('title', prop_info['$ref'].split('/')[-1])
        elif 'type' in prop_info and prop_info['type'] == 'array' and 'items' in prop_info:
            # Check if it's an array of objects
            items_info = prop_info['items']
            if '$ref' in items_info:
                resolved_schema = resolve_reference(spec, items_info['$ref'])
                nested_class_name = resolved_schema.get('title', items_info['$ref'].split('/')[-1])
                prop_type = f"List<{nested_class_name}>"
                # Ensure the correct reference is used
                prop_type = f"List<{nested_class_name}>" if nested_class_name != "Dictionary<String,Object>" else "List<Dictionary_String_Object_>"
            else:
                # Handle array of primitive types
                item_type = map_openapi_type_to_csharp(items_info.get('type'), items_info.get('format'), items_info, spec)
                prop_type = f"List<{item_type}>"
        elif 'type' in prop_info and prop_info['type'] == 'object':
            # Handle properties that are complex objects
            # Map directly to a dictionary if the schema allows for arbitrary properties
            if prop_info.get('additionalProperties'):
                prop_type = "IDictionary<string, object>"
                required_usings.add("System.Collections.Generic")
            else:
                # Map to a nested class or dictionary if additionalProperties not defined
                prop_type = "Dictionary<string, object>"
        else:
            prop_type = map_openapi_type_to_csharp(prop_info.get('type'), prop_info.get('format'), prop_info)

        if prop_type.startswith("List<") or "Dictionary<" in prop_type:
            required_usings.add("System.Collections.Generic")

        # if "?" in prop_type or "Dictionary<" in prop_type:
        #     required_usings.add("System")

        prop_required = prop_name in required_properties
        prop_code = f"{xml_comment}    [JsonProperty(\"{prop_name}\")]\n    public {prop_type} {to_pascal_case(prop_name)} {{ get; set; }} {'// Required' if prop_required else ''}\n"
        class_code += prop_code

#     class_code += """
#     [JsonExtensionData]
#     public IDictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
# """

    class_code += "}\n"

    return class_code, required_usings


def generate_models(spec):
    """Generates all request and response models from OpenAPI definitions."""
    models = {"requests": [], "responses": []}
    all_required_usings = set()

    # Handle Swagger 2.0 and OpenAPI 3.0 schema paths
    if spec.get('swagger') == '2.0':
        definitions = spec.get('definitions', {})
    else:
        definitions = spec.get('components', {}).get('schemas', {})

    for definition_name, definition in definitions.items():
        class_code, required_usings = generate_csharp_model_class(
            definition_name,
            definition.get('properties', {}),
            definition.get('required', []),
            spec
        )
        all_required_usings.update(required_usings)

        # Classify as request or response based on naming convention (could be improved with additional logic)
        if "request" in definition_name.lower():
            models["requests"].append((class_code, required_usings))
        else:
            models["responses"].append((class_code, required_usings))

    return models, all_required_usings


def generate_model_class_with_usings(class_code, required_usings):
    """Generates the complete C# class code with necessary using statements."""
    usings = "\n".join([f"using {u};" for u in order_namespaces(required_usings)])
    return f"{usings}\n\n{class_code}"


def save_model_class_to_file(class_code, required_usings, folder_path, file_name):
    """Save the generated class with usings to a file, creating the folder structure if necessary."""
    os.makedirs(folder_path, exist_ok=True)
    complete_class_code = generate_model_class_with_usings(class_code, required_usings)
    file_path = os.path.join(folder_path, file_name)

    with open(file_path, 'w') as file:
        file.write(complete_class_code)

    print(f"Saved generated code for {file_name} to {file_path}")


def get_response_type(spec, endpoint, method):
    """Extract the response type from the OpenAPI spec."""
    paths = spec.get('paths', {})
    endpoint_info = paths.get(endpoint, {}).get(method, {})
    responses = endpoint_info.get('responses', {})

    # Handle Swagger 2.0 and OpenAPI 3.0 response schemas
    response_schema = None
    if '200' in responses:
        response = responses['200']
        if spec.get('swagger') == '2.0':
            response_schema = response.get('schema', {})
        else:
            response_content = response.get('content', {})
            response_schema = list(response_content.values())[0].get('schema', {}) if response_content else {}

    if response_schema and '$ref' in response_schema:
        return response_schema['$ref'].split('/')[-1]

    return None


def generate_client_class_with_methods(spec, endpoint_group):
    """Generates a client class for all endpoints in a group (e.g., /data/historic/)."""

    # Extract the class name from the endpoint group
    class_name = f"{to_pascal_case(endpoint_group.strip('/').split('/')[-1])}Client"

    methods = []
    all_required_usings = set()

    paths = spec.get('paths', {})
    for endpoint, path_info in paths.items():
        if not endpoint.startswith(endpoint_group):
            continue

        for http_method, method_info in path_info.items():
            if http_method not in ['get', 'post', 'put', 'delete', 'patch']:
                continue

            response_type = get_response_type(spec, endpoint, http_method)
            parameters = get_endpoint_details(spec, endpoint, http_method)
            method_code, required_usings = generate_csharp_method_with_usings(endpoint, http_method, parameters, spec, response_type)
            methods.append(method_code)
            all_required_usings.update(required_usings)

    # Combine all methods into a single string, correctly formatted
    methods_code = "".join(f"{method}" for method in methods)

    # Generate the complete class code with usings and methods
    class_code = generate_csharp_class_with_usings(class_name, methods_code, all_required_usings)
    return class_code


def load_unmetered_locations(file_path):
    """Load unmetered locations from a JSON file."""
    with open(file_path, 'r') as file:
        return json.load(file)


def generate_unmetered_locations_class(locations):
    """Generates the UnmeteredLocations.cs file content."""
    # Base namespace and class definition
    class_code = """
using System.Collections.Generic;

namespace Solcast
{
    public static class UnmeteredLocations
    {
        public static readonly Dictionary<string, Location> Locations = new Dictionary<string, Location>
        {
"""

    # Add each location as a dictionary entry
    for location in locations:
        location_code = f"""            {{
                "{location['name']}", new Location
                {{
                    Latitude = {location['latitude']},
                    Longitude = {location['longitude']},
                    ResourceId = "{location['resourceId']}"
                }}
            }},
"""
        class_code += location_code

    # Close the dictionary and class definition
    class_code += """
        };

        public static List<string> LoadTestLocationNames()
        {
            return new List<string>(Locations.Keys);
        }

        public static (List<double> Latitudes, List<double> Longitudes) LoadTestLocationCoordinates()
        {
            var latitudes = new List<double>();
            var longitudes = new List<double>();

            foreach (var location in Locations.Values)
            {
                latitudes.Add(location.Latitude);
                longitudes.Add(location.Longitude);
            }

            return (latitudes, longitudes);
        }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ResourceId { get; set; }
    }
}
"""
    return class_code


def save_class_to_file(class_code, folder_path, file_name):
    """Save the generated class to a file, creating the folder structure if necessary."""
    os.makedirs(folder_path, exist_ok=True)
    file_path = os.path.join(folder_path, file_name)

    with open(file_path, 'w') as file:
        file.write(class_code)

    print(f"Saved generated code for {file_name} to {file_path}")


def get_class_name_from_endpoint_group(endpoint_group):
    """Infer the class name based on the endpoint group."""
    return to_pascal_case(endpoint_group.strip("/").split("/")[-1]) + "Client"


def generate_aggregation_client_class(spec, endpoint_suffix='/aggregations'):
    """Generates a client class for all endpoints ending with '/aggregations'."""
    class_name = "AggregationClient"
    methods = []
    all_required_usings = set()

    paths = spec.get('paths', {})
    for endpoint, path_info in paths.items():
        if not endpoint.endswith(endpoint_suffix):
            continue

        # Determine the context (e.g., live, forecast) from the endpoint
        context = ''
        if 'live' in endpoint:
            context = 'live'
        elif 'forecast' in endpoint:
            context = 'forecast'

        for http_method, method_info in path_info.items():
            if http_method not in ['get', 'post', 'put', 'delete', 'patch']:
                continue

            response_type = get_response_type(spec, endpoint, http_method)
            parameters = get_endpoint_details(spec, endpoint, http_method)
            method_code, required_usings = generate_csharp_method_with_usings(endpoint, http_method, parameters, spec, response_type, context)
            methods.append(method_code)
            all_required_usings.update(required_usings)

    # Combine all methods into a single string, correctly formatted
    methods_code = "".join(f"        {method}" for method in methods)

    # Generate the complete class code with usings and methods
    class_code = generate_csharp_class_with_usings(class_name, methods_code, all_required_usings)
    return class_code


if __name__ == "__main__":
    # Setup argument parser
    parser = argparse.ArgumentParser(description="Generate SDK classes from Solcast OpenAPI spec.")

    # Add command-line arguments
    parser.add_argument(
        '--dev',
        action='store_true',
        help="Use the development OpenAPI spec (https://dev-api.solcast.com.au/openapi/v1/openapi.json)"
    )
    parser.add_argument(
        '--path',
        type=str,
        help="Specify the path or URL to the OpenAPI spec"
    )

    # Parse arguments
    args = parser.parse_args()

    # Default OpenAPI spec path (production)
    openapi_spec_path = 'https://api.solcast.com.au/openapi/v1/openapi.json'

    # Override if --dev is specified
    if args.dev:
        print("Using development OpenAPI spec...")
        openapi_spec_path = 'https://dev-api.solcast.com.au/openapi/v1/openapi.json'

    # Override if --path is provided
    if args.path:
        print(f"Using custom OpenAPI spec path: {args.path}")
        openapi_spec_path = args.path

    # Default unmetered locations file path
    json_file_path = 'unmetered_locations.json'

    # Load the OpenAPI spec and unmetered locations
    spec = load_openapi_spec(openapi_spec_path)
    locations = load_unmetered_locations(json_file_path)

    # Define the endpoint groups and their corresponding client class names
    endpoint_groups = [
        '/data/live/',
        '/data/forecast/',
        '/data/historic/',
        # '/data/historic_forecast/',
        '/data/tmy/',
        # '/data/geographic/',
        '/resources/pv_power_site',
    ]

    # Generate and save UnmeteredLocations class
    unmetered_locations_code = generate_unmetered_locations_class(locations)
    save_class_to_file(unmetered_locations_code, os.path.join('src', 'Solcast', 'Utilities'), 'UnmeteredLocations.cs')

    # Extract endpoint details for SolcastUrls
    endpoint_details = extract_endpoints_from_spec(spec, endpoint_groups)

    # Generate and save SolcastUrls class dynamically from spec
    solcast_urls_code = generate_solcast_urls_class_from_spec(endpoint_details)
    save_class_to_file(solcast_urls_code, os.path.join('src', 'Solcast', 'Utilities'), 'SolcastUrls.cs')

    # Generate and save base client
    base_client_code = generate_base_client()
    save_class_to_file(base_client_code, os.path.join('src', 'Solcast', 'Clients'), 'BaseClient.cs')

    # Generate and save the ApiResponse class
    api_response_code = generate_api_response_class()
    save_class_to_file(api_response_code, os.path.join('src', 'Solcast', 'Utilities'), 'ApiResponse.cs')

    # Generate and save specific clients
    for endpoint_group in endpoint_groups:
        client_class_code = generate_client_class_with_methods(spec, endpoint_group)
        save_class_to_file(client_class_code, os.path.join('src', 'Solcast', 'Clients'), f'{get_class_name_from_endpoint_group(endpoint_group)}.cs')

    # Generate and save models
    models, all_required_usings = generate_models(spec)
    for model_type, classes in models.items():
        for class_code, required_usings in classes:
            save_model_class_to_file(class_code, required_usings, os.path.join('src', 'Solcast', 'Models', to_pascal_case(model_type)), f"{class_code.split()[2]}.cs")

    # Generate and save AggregationClient class
    aggregation_client_code = generate_aggregation_client_class(spec)
    save_class_to_file(aggregation_client_code, os.path.join('src', 'Solcast', 'Clients'), 'AggregationClient.cs')

    print(f"Code generation complete for {openapi_spec_path}")
