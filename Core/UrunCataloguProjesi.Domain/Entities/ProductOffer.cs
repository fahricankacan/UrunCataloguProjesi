namespace UrunCataloguProjesi.Domain.Entities
{
    public class ProductOffer : BaseEntity, IEntity
    {
        public Guid ProductId { get; set; }
        public Guid OfferId { get; set; }
        public bool DealDone { get; set; }
    }
}
