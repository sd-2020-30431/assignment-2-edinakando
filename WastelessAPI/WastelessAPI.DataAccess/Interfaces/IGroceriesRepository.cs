using System;
using System.Collections.Generic;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Interfaces
{
    public interface IGroceriesRepository
    {
        public void Save(Groceries groceries);
        public IList<GroceryItem> GetUserItemsExpiringInNearFuture(Int32 userId);
        public IList<Groceries> GetGroceries(Int32 userId);
        public void Consume(int itemId);
        void UpdateNotification(int itemId);
        IList<GroceryItem> GetUserNotifications(int userId);
        void Edit(IList<GroceryItem> groceries);
    }
}