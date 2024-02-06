namespace ItemStoreAPI.Model
{
    public class ItemModel
    {
        /// <summary>
        /// A unique identifier for this item.
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// This item's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// This item's description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The date that this item was created.
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.MinValue;
    }
}
