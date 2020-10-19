using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proarch.TechBatchTask.Core.Application.Usecases;
using Proarch.TechBatchTask.Core.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proarch.TechBatchTask.Presentaion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemUsecase _itemUsecase;
        public ItemController(IItemUsecase itemUsecase)
        {
            _itemUsecase = itemUsecase;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Item
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult> PostItemAsync(ItemModel item)
        {
            var clientId = await _itemUsecase.AddItemAsync(item).ConfigureAwait(true);
            if (clientId == 0)
            {
                return BadRequest("client is already existed with this Name or Id");
            }
            return Created("created new client", new { url = "https//localhost:44399/client/" + clientId });
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
