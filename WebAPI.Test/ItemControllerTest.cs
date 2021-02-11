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
        private readonly Mock<IItemService> _mockRepo;
        private readonly ItemController _controller;

        private List<Item> items;
        public ItemControllerTest()
        {
            _mockRepo = new Mock<IItemService>();
            _controller = new ItemController(_mockRepo.Object);

            items = new List<Item>()
            {
                new Item { Code = "0001", Name = "Notebook", Price = 6300 },
                new Item { Code = "0002", Name = "Keyboard", Price = 230 },
                new Item { Code = "0003", Name = "Mouse", Price = 150 }
            };
        }
        [Fact]
        public void GetList_ActionExecutes_ReturnOkResultWithUser()
        {
            _mockRepo.Setup(x => x.GetList()).Returns(items);
            var result = _controller.GetList();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnItem = Assert.IsAssignableFrom<List<Item>>(okResult.Value);
            Assert.Equal(3, returnItem.ToList().Count);
        }

    }
}



