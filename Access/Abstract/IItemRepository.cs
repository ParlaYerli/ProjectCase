using DataAccess.Abstract.EntityFramework;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IItemRepository : IEntityRepository<Item>
    {
    }
}
