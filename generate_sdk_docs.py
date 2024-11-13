import argparse
import os
import pdb
import re
import subprocess
import hashlib

# Paths
SDK_PATH = "./src/Solcast/Clients"
OUTPUT_DOCS_PATH = "./docs"
CACHE_PATH = "./tmp/samples/cache"
SAMPLES_PATH = "./tmp/samples"
SOLCAST_PROJECT_PATH = "./src/Solcast/Solcast.csproj"

# Ensure the sample output and cache directories exist
os.makedirs(CACHE_PATH, exist_ok=True)
os.makedirs(SAMPLES_PATH, exist_ok=True)

# Parse arguments
parser = argparse.ArgumentParser(description="Generate documentation with optional caching.")
parser.add_argument("--use-cache", action="store_true", help="Use cached examples if available.")
args = parser.parse_args()

# Template for the temporary .csproj project file
CSPROJ_CONTENT = f"""
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="{SOLCAST_PROJECT_PATH}" />
  </ItemGroup>
</Project>
"""

# Template for the documentation header
DOC_HEADER = """# {client_name} Data API

{client_description}

---

"""

# Default values for parameters used in the examples
DEFAULT_VALUES = {
    "latitude": "-33.856784",
    "longitude": "151.215297",
    "outputParameters": {
        'default': '["dni", "ghi", "air_temp"]',
        'GetLiveAggregations': '["percentage", "pv_estimate"]',
        'GetForecastAggregations': '["percentage", "pv_estimate"]',
    },
    "period": '"PT30M"',
    "start": '"2024-06-01T06:00"',
    "end": '"2024-07-01T06:00"',
    "format": '"csv"',
    "resourceId": '"ba75-e17a-7374-95ed"',
    "collectionId": '"aust_state_total"',
    "aggregationId": '"vic"',
    "installDate": '"2023-01-01"',
    "capacity": "5.0f",
    "tilt": "30.0f",
    "azimuth": "180.0f",
    "terrainShading": "true",
    "hours": "24"
}

# Optional parameters for examples
EXAMPLE_OPTIONAL_PARAMS = {
    "Live": {
        "GetRadiationAndWeather": ["period", "format", "tilt", "azimuth"],
        "GetAdvancedPvPower": ["format"],
        "GetRooftopPvPower": ["format"],
    },
    "Forecast": {
        "GetRadiationAndWeather": ["period", "format", "tilt", "azimuth"],
        "GetAdvancedPvPower": ["format"],
        "GetRooftopPvPower": ["format"],
    },
    "Historic": {
        "GetRadiationAndWeather": ["start", "end", "format"],
        "GetAdvancedPvPower": ["start", "end", "format"],
        "GetRooftopPvPower": ["start", "end", "format"],
    },
    "Tmy": {
        "GetRadiationAndWeather": ["period", "format", "tilt", "azimuth"],
        "GetRooftopPvPower": ["format"],
        "GetAdvancedPvPower": ["format"],
    },
    "Aggregation": {
        "GetLiveAggregations": ["collectionId", "aggregationId", "outputParameters", "format"],
        "GetForecastAggregations": ["collectionId", "aggregationId", "outputParameters", "format"],
    },
    # Add more methods and their optional parameters as needed
}

# URL mapping for parameter links
URL_MAPPINGS = {
    "Forecast": "https://docs.solcast.com.au/#80627973-4183-4ebc-8a3d-1b2324fd1ed1",
    "Live": "https://docs.solcast.com.au/#a20936b9-a41c-4ff3-b169-5ad8c5f4960b",
    "Historic": "https://docs.solcast.com.au/#d2d99600-cd3b-4b33-96b3-02cabb25cd3d",
    "Tmy": "https://docs.solcast.com.au/#a4fced31-90e5-4173-a96b-96f5a46dd374",
    "Aggregation": "https://docs.solcast.com.au/#eacaa7d2-66d7-474f-82a2-eed6c77fae60",
    "PvPowerSite": "https://docs.solcast.com.au/#884f9f7d-2fc1-43fa-a976-0a7a431d8553",
    "LiveClient": {
        "GetRadiationAndWeather": "https://docs.solcast.com.au/#b9863910-c788-4e98-a3af-eb8da8f49647",
        "GetRooftopPvPower": "https://docs.solcast.com.au/#4c9fa796-82e5-4e8a-b811-85a8c9fb85db",
        "GetAdvancedPvPower": "https://docs.solcast.com.au/#9f3aed26-1078-4ff6-86e6-23a710c6fae7",
    },
    "TmyClient": {
        "GetRadiationAndWeather": "https://docs.solcast.com.au/#3e4b42f5-c6b2-44e5-8b0e-8710acec8b2e",
        "GetRooftopPvPower": "https://docs.solcast.com.au/#d4ec6726-9300-46ff-b3de-e6e06c4768df",
        "GetAdvancedPvPower": "https://docs.solcast.com.au/#029d48ee-397f-4621-87ab-922820280113",
    },
    "HistoricClient": {
        "GetRadiationAndWeather": "https://docs.solcast.com.au/#f75aa7c6-b1ee-476c-9659-3bfb8bc7a850",
        "GetRooftopPvPower": "https://docs.solcast.com.au/#a3218b9c-ce7f-4fdd-850d-5f1029ae75f6",
        "GetAdvancedPvPower": "https://docs.solcast.com.au/#359e01c2-ef0c-4f58-812f-47726b4c3881",
    },
    "GetLiveAggregations": "https://docs.solcast.com.au/#3b09628d-0f9d-4a01-aa53-9af460d6c66a",
    "GetForecastAggregations": "https://docs.solcast.com.au/#feeb0565-ac06-473a-8cd1-b1493c5bcabb",
    "GetPvPowerSite": "https://docs.solcast.com.au/#101c6f51-b039-47c3-80b4-2285b560afe6",
    "GetPvPowerSites": "https://docs.solcast.com.au/#317dbf7c-e33e-479a-b708-01f001c36020",
    "PostPvPowerSite": "https://docs.solcast.com.au/#20007e83-78a2-4daa-b38a-4766f6344859",
    "PutPvPowerSite": "https://docs.solcast.com.au/#5c585e3f-3367-4932-a4bd-f0f4880996ca",
    "PatchPvPowerSite": "https://docs.solcast.com.au/#692cd116-890a-4b2c-84a3-70c1e4dd30c9",
    "DeletePvPowerSite": "https://docs.solcast.com.au/#9692eaa6-9f45-4062-89d2-304dded3ca3a",
}

DESCRIPTIONS = {
    "Forecast": "Get irradiance, weather and power forecasts from the present time up to 14 days ahead for the requested location, derived from satellite (clouds and irradiance over non-polar continental areas, nowcasted for approx. four hours ahead) and numerical weather models (other data and longer horizons).",
    "Live": "Get irradiance weather and power estimated actuals for near real-time and past 7 days for the requested location, derived from satellite (clouds and irradiance over non-polar continental areas) and numerical weather models (other data).",
    "Historic": "Historical irradiance, weather and power data, from 2007 to 7 days ago at 1-2 km and 5 minutes resolution.",
    "Tmy": "TMY (Typical Meteorological Year) is a collation of historical weather data for a specified location for a one year period. The dataset is derived from a multi-year time series specifically selected so that it presents the unique weather phenomena for the location, and provides annual averages that are consistent with long term averages.",
    "PvPowerSite": "Allows management of detailed PV power site metadata used by the advanced_pv_power functions.",
    "Aggregation": "Get live or forecast aggregation data for up to 7 days of data at a time for a requested collection or aggregation.",
}

SKIP_EXAMPLES = [
    "GetPvPowerSites",
    "GetPvPowerSite",
]

SKIP_EXAMPLES_CODE = [
    "PostPvPowerSite",
    "PutPvPowerSite",
    "PatchPvPowerSite",
    "DeletePvPowerSite",
    "GetAggregations",
]

SKIP_METHODS_TABLE = [
    "GetAggregations",
]

METHOD_PATTERN = re.compile(r'public async Task<.*?> (?P<method_name>\w+)\((?P<params>.*?)\)', re.DOTALL)
PARAM_PATTERN = re.compile(r'(?P<type>[\w<>\[\]?]+)\s+(?P<name>\w+)(?:\s*=\s*(?P<default>[^,]*))?')

# Create the temporary .csproj project if it doesn't exist
def create_temp_project():
    csproj_path = os.path.join(SAMPLES_PATH, "TempProject.csproj")
    if not os.path.exists(csproj_path):
        with open(csproj_path, "w") as f:
            f.write(CSPROJ_CONTENT)
    return csproj_path

def get_url_for_method(client_name, method_name):
    # Check for a client-specific URL for the method
    client_mapping = URL_MAPPINGS.get(client_name)
    if isinstance(client_mapping, dict) and method_name in client_mapping:
        return client_mapping[method_name]
    
    # Check for a method-level URL
    if method_name in URL_MAPPINGS:
        return URL_MAPPINGS[method_name]
    
    # Fallback to a default URL if no specific mapping exists
    return "https://docs.solcast.com.au/"

def extract_summary(content):
    """Extract <summary> XML comments from a C# file content and format them into a single line without extra slashes or spaces."""
    summary_pattern = re.compile(r'/// <summary>\s*(.*?)\s*/// </summary>', re.DOTALL)
    summaries = {}
    
    # Find all summaries preceding methods
    for match in summary_pattern.finditer(content):
        summary = match.group(1).strip().replace("///", "").replace("\n", " ").replace("  ", " ")
        
        # Remove excess spaces between sentences
        summary = re.sub(r'\s*\.\s*\.\s*', '. ', summary)

        # Find the method name right after this summary
        method_match = METHOD_PATTERN.search(content, match.end())
        if method_match:
            method_name = method_match.group("method_name")
            summaries[method_name] = summary.strip()
    
    return summaries

def extract_param_descriptions(content):
    param_descriptions = {}
    xml_comments_pattern = re.compile(r'/// <param name="(\w+)">(.*?)</param>', re.DOTALL)
    for param_name, description in xml_comments_pattern.findall(content):
        param_descriptions[param_name] = description.strip()
    return param_descriptions

def generate_example_params(client_name, method_name, params):
    example_params = []
    optional_params_to_include = EXAMPLE_OPTIONAL_PARAMS.get(client_name, {}).get(method_name, [])
    
    for param_type, param_name, default_value in params:
        default_value = default_value.strip() if default_value and default_value.strip() else None
        is_required = default_value is None
        
        # Check if `param_name` has a method-specific default value
        if param_name in DEFAULT_VALUES:
            param_defaults = DEFAULT_VALUES[param_name]
            if isinstance(param_defaults, dict):
                # Use method-specific default if available; otherwise, use the general default
                example_value = param_defaults.get(method_name, param_defaults.get('default', default_value or "example_value"))
            else:
                example_value = param_defaults
        else:
            example_value = default_value or "example_value"
        
        # Add to example params if required or optional and included
        if is_required or param_name in optional_params_to_include:
            example_params.append(f"{param_name}: {example_value}")
    
    return ",\n    ".join(example_params)

# Create a hash of the example call to identify cached examples uniquely
def get_cache_filename(client_name, method_name, example_call):
    unique_key = f"{client_name}_{method_name}_{example_call}"
    cache_key = hashlib.md5(unique_key.encode()).hexdigest()
    return os.path.join(CACHE_PATH, f"{client_name}_{method_name}_{cache_key}.txt")

# Check cache for existing example output
def load_cached_example(client_name, method_name, example_call):
    if args.use_cache:
        cache_filename = get_cache_filename(client_name, method_name, example_call)
        if os.path.exists(cache_filename):
            with open(cache_filename, "r") as cache_file:
                return cache_file.read()
    return None

# Save example output to cache
def save_example_to_cache(client_name, method_name, example_call, output):
    cache_filename = get_cache_filename(client_name, method_name, example_call)
    with open(cache_filename, "w") as cache_file:
        cache_file.write(output)

def execute_csharp_example(client_name, method_name, example_call):
    if method_name in SKIP_EXAMPLES:
        return None

    # Check cache first
    cached_output = load_cached_example(client_name, method_name, example_call)
    if cached_output is not None:
        print(f" - {method_name} - loaded from cache")
        return cached_output

    temp_cs_file = os.path.join(SAMPLES_PATH, f"{client_name}_{method_name}.cs")
    with open(temp_cs_file, "w") as cs_file:
        cs_file.write(
            f"""
using System;
using System.Threading.Tasks;
using Solcast.Clients;

class Program
{{
    static async Task Main(string[] args)
    {{
        var client = new {client_name}();
        var response = await client.{method_name}({example_call});
        Console.WriteLine(response.RawResponse);
    }}
}}
"""
        )

    try:
        csproj_path = create_temp_project()
        result = subprocess.run(
            ["dotnet", "run", "--project", csproj_path, temp_cs_file],
            capture_output=True, text=True, check=True
        )
        output = result.stdout.strip()
        # Cache the output
        save_example_to_cache(client_name, method_name, example_call, output)
        print(f" - {method_name} - fetched via C# SDK")
        return output

    except subprocess.CalledProcessError as e:
        print(f"Error executing example for {method_name}: {e}")
        return None

    finally:
        os.remove(temp_cs_file)

def format_sample_output(example_output):
    if not example_output:
        return "No output generated for this example."
    
    # Split output into lines and process headers and rows
    rows = example_output.strip().splitlines()
    header = rows[0].split(",") if rows else []
    data_rows = [row.split(",") for row in rows[1:]]

    # Format the header row in Markdown table format
    header_row = "| " + " | ".join(header) + " |"
    separator_row = "| " + " | ".join(["---"] * len(header)) + " |"
    skip_row = " | ".join(["..."] * len(header))

    # Select the first two and last two rows for sample output
    if len(data_rows) > 4:
        sample_data = data_rows[:2] + [[skip_row]] + data_rows[-2:]
    else:
        sample_data = data_rows

    formatted_rows = ["| " + " | ".join(row) + " |" for row in sample_data]

    # Combine header, separator, and data rows
    table_output = "\n".join([header_row, separator_row] + formatted_rows)
    
    # Return formatted table output
    return f"**Sample Output:**\n\n{table_output}\n"

def generate_client_doc(client_name, client_file_path):
    clean_client_name = client_name.replace("Client", "")
    client_description = DESCRIPTIONS.get(clean_client_name, "No description available.")
    doc_content = DOC_HEADER.format(client_name=clean_client_name, client_description=client_description)

    with open(client_file_path, "r") as file:
        content = file.read()

    endpoint_summaries = extract_summary(content)
    param_descriptions = extract_param_descriptions(content)
    method_summary = []

    methods = list(METHOD_PATTERN.finditer(content))
    if not methods:
        return ""  # Skip clients with no methods

    print(f"Generating documentation for {clean_client_name}:")
    # Add the methods summary table immediately after the client description
    doc_content += f"\nThe module {client_name} has the following available methods:\n\n"
    doc_content += "| Endpoint                  | Purpose                                              | API Docs                                                                                                               |\n"
    doc_content += "|---------------------------|------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|\n"

    for method in methods:
        method_name = method.group("method_name")
        
        # Skip methods from appearing in the summary table if in SKIP_METHODS_TABLE
        if method_name in SKIP_METHODS_TABLE:
            print(f" - {method_name} - skipped from methods table")
            continue

        # Retrieve the summary for each method
        summary = endpoint_summaries.get(method_name, "No description available.")
        url = get_url_for_method(client_name, method_name)

        # Add each method to the summary table
        doc_content += f"| [{method_name}](#{method_name.lower()}) | {summary} | [details]({url}){{.md-button}} |\n"

    # Add a divider after the table
    doc_content += "\n---\n"

    # Continue with generating individual method documentation
    for method in methods:
        method_name = method.group("method_name")
        # Skip example code generation if method is in SKIP_EXAMPLES_CODE
        if method_name not in SKIP_EXAMPLES_CODE:
            params = PARAM_PATTERN.findall(method.group("params"))
            
            # Documentation for each method
            doc_content += f"\n### {method_name}\n"
            summary = endpoint_summaries.get(method_name, "No description available.")
            # doc_content += f"{summary}\n\n"

            # Parameters section with tooltips
            doc_content += "**Parameters:**\n"
            for param_type, param_name, default_value in params:
                default_value = default_value.strip() if default_value and default_value.strip() else None
                description = param_descriptions.get(param_name, "No description available.")
                is_required = default_value is None
                tooltip_text = f"({param_type}): {description} {'(Required)' if is_required else '(Optional)'}"
                doc_content += f"[{param_name}]({url} \"{tooltip_text}\"), "
            doc_content = doc_content.rstrip(", ")
            doc_content += "\n\n"

            example_params = generate_example_params(clean_client_name, method_name, params)
            example_call = f"{example_params}"
            example_code = f"""using Solcast.Clients;

var {client_name[0].lower() + client_name[1:]} = new {client_name}();
var response = await {client_name[0].lower() + client_name[1:]}.{method_name}(
    {example_call}
);
Console.WriteLine(response.RawResponse);
"""
            doc_content += "**Example Usage:**\n"
            doc_content += f"```csharp\n{example_code}\n```\n"

            # Generate sample output and format it, only if not in SKIP_EXAMPLES
            if method_name not in SKIP_EXAMPLES:
                example_output = execute_csharp_example(client_name, method_name, example_call)
                sample_output_formatted = format_sample_output(example_output)
                doc_content += sample_output_formatted + "\n---\n"
            else:
                print(f" - {method_name} - example response skipped")

    return doc_content

def generate_docs():
    os.makedirs(OUTPUT_DOCS_PATH, exist_ok=True)
    for client_file in os.listdir(SDK_PATH):
        if client_file.endswith("Client.cs"):
            client_name = client_file.replace(".cs", "")

            if client_name.lower() == "base":
                continue

            client_file_path = os.path.join(SDK_PATH, client_file)
            try:
                doc_content = generate_client_doc(client_name, client_file_path)
                if doc_content:
                    with open(os.path.join(OUTPUT_DOCS_PATH, f"{client_name.lower().replace('client', '')}.md"), "w") as doc_file:
                        doc_file.write(doc_content)
                    print(f"Done.\n")
            except Exception as e:
                print(f"Error processing {client_name}: {e}")

if __name__ == "__main__":
    generate_docs()
