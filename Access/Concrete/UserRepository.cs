
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
using Entities.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User, AppDbContext>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository( AppDbContext context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            return _context.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
