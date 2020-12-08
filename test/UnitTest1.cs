using System;
using Xunit;
using models;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void testExceptionMatt(){
            Movie poop = new Movie();
            poop.setConnectionString();
            Assert.Throws<Exception>(() => poop.NumActor("Matt Damon"));
        }
        
        [Theory]
        [InlineData("What Women Want", 1)]
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
        public void TestGetAge(string value, int expected)
        {
            Movie poop = new Movie();
            poop.setConnectionString();
            int result = poop.GetAge(value);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void testException(){
            Movie poop = new Movie();
            poop.setConnectionString();
            Assert.Throws<Exception>(() => poop.GetAge("Matt Damon"));
        }
    }
}
