using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WastelessAPI.DataAccess.Models
{
    [Table("grocery_lists")]
    public class Groceries
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }

        public IList<GroceryItem> Items { get; set; }

        [Column("user_id")]
        public Int32 UserId { get; set; }
    }
}
