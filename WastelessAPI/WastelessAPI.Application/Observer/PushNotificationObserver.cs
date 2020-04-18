
using System;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.DataAccess.Interfaces;

namespace WastelessAPI.Application.Observer
{
    public class PushNotificationObserver : IObserver
    {
        private IGroceriesRepository _groceriesrepository { get; set; }

        public PushNotificationObserver(IGroceriesRepository groceriesRepository)
        {
            _groceriesrepository = groceriesRepository;
        }

        public void Update(Int32 userId, GroceryItem item)
        {
            _groceriesrepository.UpdateNotification(item.Id);
        }
    }
}
