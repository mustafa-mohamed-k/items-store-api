
using AutoMapper;
using ItemStore.Service;
using ItemStoreAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ItemStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService itemsService;
        private readonly IMapper mapper;

        public ItemsController(IItemsService itemsService, IMapper mapper)
        {
            this.itemsService = itemsService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemModel>> GetAll()
        {
            var items = mapper.Map<IEnumerable<ItemModel>>(itemsService.GetAll());
            return Ok(items);
        }
    }
}
