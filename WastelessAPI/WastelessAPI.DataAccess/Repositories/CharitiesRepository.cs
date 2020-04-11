using System;
using System.Collections.Generic;
using System.Linq;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Repositories
{
    public class CharitiesRepository
    {
        private readonly WastelessDbContext _context;
        public CharitiesRepository(WastelessDbContext context)
        {
            _context = context;
        }

        public IList<Charity> GetAll()
        {
            return _context.Charities.ToList();
        }

        public void Donate(Donation donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();
        }
    }
}