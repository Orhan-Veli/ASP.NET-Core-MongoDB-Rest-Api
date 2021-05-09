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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            await _customerService.Create(customer);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
            await _customerService.Delete(objectId);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
            var result = await _customerService.GetById(objectId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _customerService.GetAll();
            return Ok(results);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }
            var updatedResult = await _customerService.Update(customer);
            return Ok(updatedResult);
        }
    }
}
