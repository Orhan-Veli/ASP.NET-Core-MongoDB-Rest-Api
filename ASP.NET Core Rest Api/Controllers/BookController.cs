using ASP.NET_Core_With_Mongo_Db.Business.Abstract;
using ASP.NET_Core_With_Mongo_Db.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            await _bookService.Create(book);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
            await _bookService.Delete(objectId);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
            var result = await _bookService.GetById(objectId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _bookService.GetAll();
            return Ok(results);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            if (book == null)
            {
                return NotFound();
            }
            var updatedResult = await _bookService.Update(book);
            return Ok(updatedResult);
        }

    }
}
