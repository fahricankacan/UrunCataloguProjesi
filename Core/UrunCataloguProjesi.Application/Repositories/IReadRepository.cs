using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Application.Repostories
{
    public interface IReadRepository<T> where T : BaseEntity, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
    }
}
