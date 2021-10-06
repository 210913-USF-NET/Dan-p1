using System;
using Xunit;
using Mods;

namespace Mods.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BeerShouldCreate()
        {
            Beer test = new Beer();

            Assert.NotNull(test);

        }

        [Fact]
        public void CustomerShouldCreate()
        {
            Customer test = new Customer();

            Assert.NotNull(test);

        }

        [Fact]
        public void OrderShouldCreate()
        {
            Order test = new Order();

            Assert.NotNull(test);

        }

        [Fact]
        public void StoreShouldCreate()
        {
            Store test = new Store();

            Assert.NotNull(test);

        }

        // [Theory]
        // [InlineData("")]
        // public void StoresShouldNotAllowInvalidName(string input)
        // {
        //     Store test = new Store();
            
        //     Assert.Throws<InputInvalidException>(() => test.Name = input);
        // }
    }
}
