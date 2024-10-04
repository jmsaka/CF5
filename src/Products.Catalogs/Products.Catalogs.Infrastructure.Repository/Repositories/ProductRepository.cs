namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id, bool tracking = true)
    {
        return tracking
        ? await _context.Products.FindAsync(id)
        : await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> GetIfExistsByNameOrDescriptionAsync(string searchTerm)
    {
        var product = await _context.Products
            .Where(p => p.Name.Equals(searchTerm) || p.Description.Equals(searchTerm))
            .FirstOrDefaultAsync();

        return product != null;
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        bool result = false;
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            result = true;
        }
        return result;
    }
}
