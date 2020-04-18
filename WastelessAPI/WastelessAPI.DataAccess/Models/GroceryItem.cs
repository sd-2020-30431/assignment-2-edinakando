using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WastelessAPI.DataAccess.Models
{
    [Table("grocery_items")]
    public class GroceryItem
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 Calories { get; set; }
        
        [Column("purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [Column("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        [Column("consumption_date")]
        public DateTime? ConsumptionDate { get; set; }

        [Column("list_id")]
        public Int32 ListId { get; set; }
        public Groceries GroceryList { get; set; }

        [Column("notify_expiration")]
        public Boolean NotifyExpiration { get; set; }
    }
}