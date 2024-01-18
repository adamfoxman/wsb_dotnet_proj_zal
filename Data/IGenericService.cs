namespace proj_zal.Data;

public interface IGenericService<T> where T : class
{
    Task<T?> GetAsync(Guid? id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> AddAsync(T? entity);
    Task<T?> UpdateAsync(T? entity);
    Task<T?> DeleteAsync(Guid? id);
}