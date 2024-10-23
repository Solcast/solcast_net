using Solcast.Clients;

namespace Solcast.Examples
{
    public class PvPowerSitesExample
    {
        public static async Task RunPvPowerSitesExample()
        {
            try
            {
                var pvPowerSiteClient = new PvPowerSiteClient();
                var response = await pvPowerSiteClient.GetPvPowerSite("ba75-e17a-7374-95ed");

                Console.WriteLine("PV Power Site Data:");
                Console.WriteLine(response.RawResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PvPowerSitesExample: {ex.Message}");
            }
        }
    }
}
