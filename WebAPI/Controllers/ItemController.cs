using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_service.GetList());
        }

        [HttpGet("getbyid/{itemId}")]
        public IActionResult GetItemById(int itemId)
        { 
            var item = _service.GetById(itemId);
            if (item==null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("add")]
        public IActionResult Add(Item product)
        {
            if (ModelState.IsValid)
            {
                _service.Add(product);
                return Ok(product);
            }
            return BadRequest(new { message = "Eksik bilgi girdiniz.Gerekli alanları doldurunuz." });
          
        }

        [HttpDelete("{itemId}")]
        public ActionResult Delete(int itemId)
        {
            var product =  _service.GetById(itemId);
            if (product == null)
            {
                return NotFound();
            }
             _service.Delete(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _service.Update(item);
            return Ok();
        }
    }
}
