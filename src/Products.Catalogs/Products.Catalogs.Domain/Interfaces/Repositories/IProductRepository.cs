namespace Products.Catalogs.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<ICollection<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id, bool tracking = true);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> GetIfExistsByNameOrDescriptionAsync(string searchTerm);
}