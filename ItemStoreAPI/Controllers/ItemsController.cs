
using AutoMapper;
using ItemStore.Domain.Entities;
using ItemStore.Service;
using ItemStoreAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ItemStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService itemsService;
        private readonly IMapper mapper;
        private readonly ILogger<ItemsController> logger;

        public ItemsController(IItemsService itemsService, IMapper mapper, ILogger<ItemsController> logger)
        {
            this.itemsService = itemsService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemModel>> GetAll()
        {
            logger.LogInformation("Getting all items.");
            var items = mapper.Map<IEnumerable<ItemModel>>(itemsService.GetAll());
            logger.LogDebug("Finished getting all items.");
            return Ok(items);
        }

        [HttpPost]
        public ActionResult<ItemModel> CreateItem([FromBody]CreateItemModel item)
        {
            logger.LogDebug("Creating item: {0}", item);
            var theItem = mapper.Map<Item>(item);
            if (theItem is not null)
            {
                var createdItem = itemsService.AddItem(theItem);
                logger.LogDebug($"Created item: {createdItem}");
                return Ok(mapper.Map<ItemModel>(createdItem));
            }
            logger.LogDebug("Item could not be created for some reason. Returning status code 500.");
            return StatusCode(500, "An error occurred. Please try again later.");
        }

        [HttpPatch]
        public ActionResult<ItemModel> UpdateItem([FromBody] UpdateItemModel updateItem)
        {
            var theItem = mapper.Map<Item>(updateItem);
            if (theItem is not null)
            {
                var updatedItem = itemsService.Update(theItem);
                return Ok(mapper.Map<ItemModel>(updatedItem));
            }
            return StatusCode(500, "An error occurred. Please try again later.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem([FromRoute][Required]int id)
        {
            logger.LogDebug($"Attempting to delete item with id {id}");
            if (itemsService.Delete(id))
            {
                logger.LogDebug($"Item with id {id} deleted successfully.");
                return NoContent();
            }
            else
            {
                logger.LogDebug($"Item with id {id} not found.");
                return NotFound();
            }
        }
    }
}
