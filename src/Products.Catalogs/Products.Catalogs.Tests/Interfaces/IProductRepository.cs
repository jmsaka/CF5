namespace Products.Catalogs.Tests.Interfaces;

public interface IProductRepository
{
    Product AddProduct(Product product);
    Product GetProductById(Guid id);
    Product UpdateProduct(Product product);
    bool DeleteProduct(Guid id);
}
