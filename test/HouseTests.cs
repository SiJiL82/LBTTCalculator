using System;
using Xunit;
using LBTTCalculator;

namespace LBTTCalculator.Tests
{
    public class HouseTests
    {
        [Fact]
        public void HouseUnderLowestBand()
        {
            //arrange
            House house = new House();
            house.SetValue(30000);

            //act
            house.CalculateLBTTValue();
            double lbttValue = house.GetLBBTValue();
            
            //assert
            Assert.Equal(0, lbttValue);
        }

        [Fact]
        public void HouseInFirstBand()
        {
            //arrange
            House house = new House();
            house.SetValue(150000);

            //act
            house.CalculateLBTTValue();
            double lbttValue = house.GetLBBTValue();
            
            //assert
            Assert.Equal(100, lbttValue);
        }
    }
}
