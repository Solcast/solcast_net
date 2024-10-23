namespace Solcast.Examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide an argument: 'live', 'historic', 'forecast', 'tmy', 'aggregation', or 'pv_power_sites'.");
                return;
            }

            switch (args[0].ToLower())
            {
                case "live":
                    await LiveExample.RunLiveExample();
                    break;
                case "forecast":
                    await ForecastExample.RunForecastExample();
                    break;
                case "historic":
                    await HistoricExample.RunHistoricExample();
                    break;
                case "tmy":
                    await TmyExample.RunTmyExample();
                    break;
                case "aggregation":
                    await AggregationExample.RunAggregationExample();
                    break;
                case "pv_power_sites":
                    await PvPowerSitesExample.RunPvPowerSitesExample();
                    break;
                default:
                    Console.WriteLine("Unknown argument. Please use 'live', 'historic', 'forecast', 'tmy', 'aggregation', or 'pv_power_sites'.");
                    break;
            }
        }
    }
}
