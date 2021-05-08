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
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        [HttpPut("Create")]
        public async Task<IActionResult> Create([FromBody] Writer writer)
        {
            if (writer == null)
            {
                return BadRequest();
            }
            await _writerService.Create(writer);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
            await _writerService.Delete(objectId);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
            var result = await _writerService.GetById(objectId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _writerService.GetAll();
            return Ok(results);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Writer writer)
        {
            if (writer == null)
            {
                return NotFound();
            }
            var updatedResult = await _writerService.Update(writer);
            return Ok(updatedResult);
        }
    }
}
