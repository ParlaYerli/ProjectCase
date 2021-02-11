using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IItemService
    {
        List<Item> GetList();
        Item GetById(int productId);
        void Add(Item product);
        void Delete(Item product);
        void Update(Item product);
    }
}
