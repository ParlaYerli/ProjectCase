using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class ItemRepository : EfEntityRepositoryBase<Item, AppDbContext>, IItemRepository
    {
    }
}
