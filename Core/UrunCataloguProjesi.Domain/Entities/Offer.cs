namespace UrunCataloguProjesi.Domain.Entities
{
    public class Offer : BaseEntity, IEntity
    {
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
