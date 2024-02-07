using System.ComponentModel.DataAnnotations;

namespace ItemStoreAPI.Model
{
    public class CreateItemModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
