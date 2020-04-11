
using System;
using WastelessAPI.Application.Models.Groceries;

namespace WastelessAPI.Application.Observer
{
    public class PushNotificationObserver : IObserver
    {
        public void Update(Int32 userId, GroceryItem item)
        {
            //TODO: send notification to client
        }
    }
}
