using System;
using WastelessAPI.Application.Models.Groceries;

namespace WastelessAPI.Application.Observer
{
    public interface IObserver
    {
        void Update(Int32 userId, GroceryItem item);
    }
}
