
using System;
using WastelessAPI.Application.Models.Groceries;

namespace WastelessAPI.Application.Observer
{
    public class PushNotificationObserver : IObserver
    {
        public static GroceryItem currentItem { get; set; }
        public void Update(Int32 userId, GroceryItem item)
        {
            currentItem = item;
        }

        public GroceryItem GetItem()
        {
            return currentItem;
        }
    }
}
