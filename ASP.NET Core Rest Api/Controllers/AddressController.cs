using ASP.NET_Core_With_Mongo_Db.Business.Abstract;
using ASP.NET_Core_With_Mongo_Db.Business.Concrete;
using ASP.NET_Core_With_Mongo_Db.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace ASP.NET_Core_Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Address address)
        {
            if (address == null)
            {                
                return BadRequest();
            }
            await _addressService.Create(address);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
            await _addressService.Delete(objectId);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                return BadRequest();
            }
          var result = await _addressService.GetById(objectId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _addressService.GetAll();
            return Ok(results);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Address address)
        {
            if (address == null)
            {
                return NotFound();
            }
           var updatedResult = await _addressService.Update(address);
           return Ok(updatedResult);
        }

    }
}
