﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Repositories
{
    public class GroceriesRepository
    {
        private readonly WastelessDbContext _context;

        public GroceriesRepository(WastelessDbContext context)
        {
            _context = context;
        }

        public void Save(Groceries groceries)
        {
            _context.GroceryLists.Add(groceries);
            _context.SaveChanges();
        }

        public IList<GroceryItem> GetUserItemsExpiringInNearFuture(Int32 userId)
        {
            Int32 MAX_DAYS_TILL_EXPIRATION = 5;
            return _context.GroceryItems.Where(item => item.GroceryList.UserId == userId && 
                                                        item.ConsumptionDate == DateTime.MinValue &&
                                                        item.ExpirationDate > DateTime.Now &&
                                                        item.ExpirationDate < DateTime.Now.AddDays(MAX_DAYS_TILL_EXPIRATION))
                                        .ToList();
        }

        public IList<Groceries> GetGroceries(Int32 userId)
        {
            return _context.GroceryLists
                             .Include(list => list.Items)
                             .Where(list => list.UserId == userId).ToList();
        }

        public void Consume(int itemId)
        {
            var item = _context.GroceryItems.Where(item => item.Id == itemId).FirstOrDefault();
            item.ConsumptionDate = DateTime.Now;
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
