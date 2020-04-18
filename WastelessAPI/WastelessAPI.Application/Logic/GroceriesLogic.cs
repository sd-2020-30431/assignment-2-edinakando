using System;
using System.Collections.Generic;
using System.Linq;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.DataAccess.Interfaces;

namespace WastelessAPI.Application.Logic
{
    public class GroceriesLogic
    {
        private readonly IGroceriesRepository _groceriesRepository;

        public GroceriesLogic(IGroceriesRepository groceriesRepository)
        {
            _groceriesRepository = groceriesRepository;
        }

        public void Save(Groceries groceries)
        {
            _groceriesRepository.Save(new DataAccess.Models.Groceries
            {
                Name = groceries.Name,
                Items = groceries.Items.Select(item =>
                    new DataAccess.Models.GroceryItem
                    {
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Calories = item.Calories,
                        PurchaseDate = item.PurchaseDate,
                        ExpirationDate = item.ExpirationDate,
                        ConsumptionDate = item.ConsumptionDate
                    }).ToList()
            }); ;

        }

        public void Edit(IList<GroceryItem> groceries)
        {
            _groceriesRepository.Edit(groceries.Select(item => new DataAccess.Models.GroceryItem {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity,
                Calories = item.Calories,
                PurchaseDate = item.PurchaseDate,
                ExpirationDate = item.ExpirationDate,
                ConsumptionDate = item.ConsumptionDate
            }).ToList());
        }

        public IList<GroceryItem> GetExpirationNotification(int userId)
        {
            return _groceriesRepository.GetUserNotifications(userId)?.Select(item => new GroceryItem
            {
                Name = item.Name,
                Quantity = item.Quantity,
                Calories = item.Calories,
                PurchaseDate = item.PurchaseDate,
                ExpirationDate = item.ExpirationDate,
                ConsumptionDate = item.ConsumptionDate
            }).ToList();
        }

        public IList<Groceries> GetGroceries(int userId)
        {
            IList<DataAccess.Models.Groceries> groceries = _groceriesRepository.GetGroceries(userId);

            return groceries.Select(list => new Groceries
            {
                Name = list.Name,
                Items = list.Items?.Select(item => new GroceryItem(item))?.ToList()
            })?.ToList();
        }
    }
}