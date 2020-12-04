using System;
using Xunit;
using models;

namespace test
{
    public class UnitTest1
    {
        
        [Theory]
        [InlineData("What Women Want", 1)]
        [InlineData("What Women", 0)]
        [InlineData("Matt Damon", 0)]
        public void TestNumActor(string value, int expected)
        {
            Movie poop = new Movie();
            poop.setConnectionString();
            int result = poop.NumActor(value);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("What Women Want", 20)]
        [InlineData("Young Guns", 32)]
        [InlineData("Matt Damon", 0)]
        public void TestGetAge(string value, int expected)
        {
            Movie poop = new Movie();
            poop.setConnectionString();
            int result = poop.GetAge(value);
            Assert.Equal(result, expected);
        }
    }
}
