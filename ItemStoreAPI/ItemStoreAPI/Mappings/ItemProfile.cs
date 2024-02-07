using AutoMapper;
using ItemStore.Domain.Entities;
using ItemStoreAPI.Model;

namespace ItemStoreAPI.Mappings
{
    public class ItemProfile: Profile
    {
        public ItemProfile() 
        {
            CreateMap<Item, ItemModel>();
            CreateMap<ItemModel, Item>();

            CreateMap<Item, CreateItemModel>();
            CreateMap<CreateItemModel, Item>();

            CreateMap<UpdateItemModel,  Item>();
        }
    }
}
