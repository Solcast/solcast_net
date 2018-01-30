using System;
using ServiceStack.Text;
using Xunit;

namespace Solcast.Tests
{
    public class UnixTimeTests
    {
        [Fact]
        public void TestUnixTimeAgainstServiceStack()
        {
            var timestamp = DateTime.UtcNow;            
            var ticks = timestamp.ToUnixTime();

            var serviceStackTime = ticks.FromUnixTime();
            var customTime = ticks.UnixTimeSecondToDateTime();       
            Assert.True(DateTime.Compare(timestamp, serviceStackTime) == DateTime.Compare(timestamp, customTime));
        }
    }
}