using UrunCataloguProjesi.Domain.Entities;

namespace UrunCataloguProjesi.Application.Repostories
{
    public interface IWriteRepository<T> where T : BaseEntity, IEntity, new()
    {
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}
