using System;
using Xunit;
using CarsLib;

namespace CarsTests
{
    public class CarsTest
    {
              Cars car1;
              Cars car2;

        public CarsTest()
        {
            this.car1 = new Cars("XTX111","Holden","Cruze", 2010, 0);
            this.car2 = new Cars("ABC111","Toyota","Corolla", 2016, 0);
            
        }
        
        [Theory]
        [InlineData (150, 150)]
        [InlineData (50, 50)]
        [InlineData (170, 150)]
        [InlineData (-10, 0)]
        [InlineData (0, 0)]

            public void increaseSpeedTest (int increaseamount, int expected) {
            car1.increaseSpeed (increaseamount);
            Assert.Equal (expected, car1.Speed);
        }

        [Theory]
        [InlineData (-5, 0)]
        [InlineData (50, 0)]
        [InlineData (0, 0)]

        public void DecreaseSpeedTest(int deceleratedSpeed, int expected) 
        {
            car1.DecreaseSpeed (deceleratedSpeed);
            Assert.Equal (expected, car1.Speed);
        }

        [Fact]

        public void GetAgeTest()
        {
            Assert.Equal (5, car2.GetAge());
            //Assert.Equal (1, car2.GetAge());s
        } 


    }
}