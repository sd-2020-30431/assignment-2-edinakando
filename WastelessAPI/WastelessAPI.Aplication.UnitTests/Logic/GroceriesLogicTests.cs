using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.DataAccess.Interfaces;

namespace WastelessAPI.Application.UnitTests.Logic
{
    public class GroceriesLogicTests
    {
        [Test]
        public void GetGroceriesShouldReturnMappedListOfGroceries()
        {
            //Arrange 
            var groceriesRepositoryMock = new Mock<IGroceriesRepository>();
            int userId = 1;
            var groceries = new List<DataAccess.Models.Groceries>()
            {
                new DataAccess.Models.Groceries
                {
                    Id = 1,
                    Name = "List1",
                    UserId = userId,
                    Items = new List<DataAccess.Models.GroceryItem>()
                    {
                        new DataAccess.Models.GroceryItem { Name = "grocery1"},
                        new DataAccess.Models.GroceryItem { Name = "grocery2"},
                        new DataAccess.Models.GroceryItem { Name = "grocery3"}
                    }
                },
                 new DataAccess.Models.Groceries
                {
                    Id = 2,
                    Name = "List2",
                    UserId = userId,
                    Items = new List<DataAccess.Models.GroceryItem>()
                    {
                        new DataAccess.Models.GroceryItem { Name = "grocery1"},
                        new DataAccess.Models.GroceryItem { Name = "grocery2"},
                        new DataAccess.Models.GroceryItem { Name = "grocery3"}
                    }
                }
            };
            var groceriesExpected = new List<Groceries>()
            {
                 new Groceries
                 {
                    Name = "List1",
                    Items = new List<GroceryItem>()
                    {
                        new GroceryItem { Name = "grocery1"},
                        new GroceryItem { Name = "grocery2"},
                        new GroceryItem { Name = "grocery3"}
                    }
                 },
                 new Groceries
                 {
                    Name = "List2",
                    Items = new List<GroceryItem>()
                    {
                        new GroceryItem { Name = "grocery1"},
                        new GroceryItem { Name = "grocery2"},
                        new GroceryItem { Name = "grocery3"}
                    }
                 }
            };

            groceriesRepositoryMock.Setup(m => m.GetGroceries(userId)).Returns(groceries);
            var groceriesLogic = new GroceriesLogic(groceriesRepositoryMock.Object);

            //Act
            var groceriesActual = groceriesLogic.GetGroceries(userId);

            //Assert
            Assert.IsTrue(groceriesExpected.SequenceEqual(groceriesActual, new GroceriesModelComparer()));
        }
    }

    public class GroceriesModelComparer : IEqualityComparer<Groceries>
    {
        public Boolean Equals(Groceries x, Groceries y)
        {
            if (x.Name == y.Name)
            {
                return true;
            }

            return false;
        }

        public Int32 GetHashCode(Groceries obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
