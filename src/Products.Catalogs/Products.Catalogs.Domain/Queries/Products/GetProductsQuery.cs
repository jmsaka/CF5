namespace Products.Catalogs.Domain.Queries.Products;

public class GetProductsQuery : IRequest<ICollection<Product>>
{
    public GetProductsQuery(Guid? id)
    {
        Id = id;
    }

    public Guid? Id { get; set; }
}
