using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public void Add(Item product)
        {
            _repository.Add(product);
        }

        public void Delete(Item product)
        {
            _repository.Delete(product);
        }

        public Item GetById(int itemId)
        {
            return _repository.Get(i => i.Id == itemId);
        }

        public List<Item> GetList()
        {
            return _repository.GetList().ToList();
        }

        public void Update(Item product)
        {
            _repository.Update(product);
        }
    }
}
