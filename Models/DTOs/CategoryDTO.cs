namespace Models.DTOs
{
    public class CategoryDTO : DTO<Category>
    {
        public required string Name { get; set; }
        public int DisplayOrder { get; set; }

        public static CategoryDTO FromModel(Category model)
        {
            return new CategoryDTO
            {
                Name = model.Name,
                DisplayOrder = model.DisplayOrder
            };
        }

        public override void ToModel(Category model)
        {
            model.Name = Name;
            model.DisplayOrder = DisplayOrder;
        }

        public override Category ToModel()
        {
            return new Category
            {
                Name = Name,
                DisplayOrder = DisplayOrder
            };
        }
    }
}