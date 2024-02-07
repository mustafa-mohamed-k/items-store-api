using System.ComponentModel.DataAnnotations;

namespace ItemStoreAPI.Model
{
    public class UpdateItemModel
    {
        /// <summary>
        /// The new name to set for the item.
        /// </summary>
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the item to update.
        /// </summary>
        [Required]
        public int Id { get; set; } = 0;

        /// <summary>
        /// The new description to set for the item.
        /// </summary>
        public string Description {  get; set; } = string.Empty;
    }
}
