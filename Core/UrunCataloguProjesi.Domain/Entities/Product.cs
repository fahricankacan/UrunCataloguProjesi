namespace UrunCataloguProjesi.Domain.Entities
{
    public class Product : BaseEntity, IEntity
    {
        public Guid BrandId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }


    }
}
