using Microsoft.AspNetCore.Mvc;
using TestAPI.Dtos;
using TestAPI.Entities;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }


        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            return this.repository.GetItems().Select(item => item.AsDto());
        }


        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = this.repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }


        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                id = Guid.NewGuid(),
                name = itemDto.name,
                price = itemDto.price,
                createdDate = DateTimeOffset.Now
            };

            this.repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.id }, item.AsDto());
        }


        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = this.repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                name = itemDto.name,
                price = itemDto.price
            };
            this.repository.UpdateItem(updatedItem);
            return NoContent();
        }


        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = this.repository.GetItem(id);

            if(existingItem == null) 
            { 
                return NotFound();
            }

            this.repository.DeleteItem(id);

            return NoContent();
        }
    }
}
