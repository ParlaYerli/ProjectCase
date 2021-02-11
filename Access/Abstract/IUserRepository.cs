using DataAccess.Abstract.EntityFramework;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        public User GetUser(string username, string password);
    }
}
