namespace RentHouse.DataAccess.Interface;

public interface IRepository<TEntity, TviewModel>
{
    public Task<int> CreateAsync(TEntity entity);

    

    public Task<int> UpdateAsync(long id,TEntity entity);


    public Task<int> DeleteAsync(long id);


    public Task<TviewModel?> GetByIdAsync(long id);

    public Task<long> CountAsync();
}
