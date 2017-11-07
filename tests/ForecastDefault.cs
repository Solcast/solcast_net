namespace solcast.tests
{
    public static class ForecastDefault
    {
        public static int Count => (7 * 24 * 60) / 30;  // 7 days * Hours in Day * Minutes in Hour divided by default interval (30 minutes)
    }
}