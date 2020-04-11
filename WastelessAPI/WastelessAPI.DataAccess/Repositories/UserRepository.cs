using System;
using System.Collections.Generic;
using System.Linq;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly WastelessDbContext _context;

        public UserRepository(WastelessDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public Boolean IsDuplicateUser(User user)
        {
            return _context.Users.Where(dbUser => dbUser.Email == user.Email).Any();
        }

        public User GetValidUser(User user)
        {
            return _context.Users.Where(dbUser => dbUser.Email == user.Email && dbUser.Password == user.Password).FirstOrDefault();
        }

        public IList<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
