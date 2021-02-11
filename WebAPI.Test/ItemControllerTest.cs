using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Controllers;
using Xunit;

namespace WebAPI.Test
{
    public class ItemControllerTest
    {
        private readonly Mock<IItemService> _mock;
        private readonly ItemController _controller;

        private List<Item> items;
        public ItemControllerTest()
        {
            _mock = new Mock<IItemService>();
            _controller = new ItemController(_mock.Object);

            items = new List<Item>()
            {
                new Item {Id=1, Code = "0001", Name = "Notebook", Price = 6300 },
                new Item {Id=2,Code = "0002", Name = "Keyboard", Price = 230 },
                new Item {Id=3, Code = "0003", Name = "Mouse", Price = 150 }
            };
        }
        [Fact]
        public void GetList_ActionExecutes_ReturnOkResultWithUser()
        {
            _mock.Setup(x => x.GetList()).Returns(items);
            var result = _controller.GetList();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnItem = Assert.IsAssignableFrom<List<Item>>(okResult.Value);
            Assert.Equal(3, returnItem.ToList().Count);
        }

        [Theory]
        [InlineData(0)]
        public void GetItem_IdInValid_ReturnNotFound(int itemId)
        {
            Item item = null;
            _mock.Setup(x => x.GetById(itemId)).Returns(item);
            var result = _controller.GetItemById(itemId);
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public void GetItemById_IdValid_ReturnOkResult(int itemId)
        {
            Item item = items.First(x => x.Id == itemId);
            _mock.Setup(x => x.GetById(itemId)).Returns(item);
            var result = _controller.GetItemById(itemId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnItem = Assert.IsAssignableFrom<Item>(okResult.Value);
            Assert.Equal(itemId, returnItem.Id);
            Assert.Equal(item.Name, returnItem.Name);
        }

        [Fact]
        public void Add_ActionExecutes_ReturnCreatedAtAction()
        {
            Item item = items.First();
            _mock.Setup(x => x.Add(item));
            var result = _controller.Add(item);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnItem = Assert.IsAssignableFrom<Item>(okResult.Value);
            _mock.Verify(x => x.Add(item), Times.Once);
            Assert.IsType<OkObjectResult>(result);   
        }

    }
}



