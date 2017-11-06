using System;

namespace solcast.cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var location = new Location
            {
                Latitude = 32,
                Longitude = -97
            };
            try
            {
                var getTask = Power.Forecast(location);
                getTask.Wait();
                Console.WriteLine(getTask.Result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
