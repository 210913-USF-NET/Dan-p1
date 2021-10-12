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
        public void CustomersShouldSetValidData()
        {
            //Arrange
            Customer test = new Customer();
            string testName = "test Customer";

            //Act
            test.Name = testName;

            //Assert
            Assert.Equal(testName, test.Name);
        }

        
        [Theory]
        [InlineData("")]
        public void CustomersShouldNotAllowInvalidName(string input)
        {
            //Arrange
            Customer test = new Customer();
            
            //Act & Assert
            //When I try to set the restaurant's name to an invalid data
            //We make sure that the program throws input invalid exception
            Assert.Throws<InputInvalidException>(() => test.Name = input);
        }

        [Fact]
        public void OrderShouldCreate()
        {
            Order test = new Order();

            Assert.NotNull(test);

        }

         [Fact]
        public void OrdersShouldSetValidData()
        {
            //Arrange
            Order test = new Order();
            int testQuantity = 33;

            //Act
            test.Quantity = testQuantity;

            //Assert
            Assert.Equal(testQuantity, test.Quantity);
        }

         [Theory]
        [InlineData(0)]
        public void OrdersShouldNotAllowInvalidQuantity(int input)
        {
            //Arrange
            Order test = new Order();
            
            //Act & Assert
            //When I try to set the restaurant's name to an invalid data
            //We make sure that the program throws input invalid exception
            Assert.Throws<InputInvalidException>(() => test.Quantity = input);
        }

        [Fact]
        public void StoreShouldCreate()
        {
            Store test = new Store();

            Assert.NotNull(test);

        }

        [Fact]
        public void LineItemShouldCreate()
        {
            LineItem test = new LineItem();

            Assert.NotNull(test);

        }

        [Fact]
        public void InventoryShouldCreate()
        {
            Inventory test = new Inventory();

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
