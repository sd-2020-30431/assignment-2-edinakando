using System;

namespace WastelessAPI.Application.Models.Groceries
{
    public class GroceryItem
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 Calories { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? ConsumptionDate { get; set; }

        public GroceryItem(){ }
        public GroceryItem(DataAccess.Models.GroceryItem item)
        {
            Id = item.Id;
            Name = item.Name;
            Calories = item.Calories;
            Quantity = item.Quantity;
            PurchaseDate = item.PurchaseDate.Date;
            ExpirationDate = item.ExpirationDate.Date;
            ConsumptionDate = item.ConsumptionDate == DateTime.MinValue ? null : item.ConsumptionDate;
        }
    }
}