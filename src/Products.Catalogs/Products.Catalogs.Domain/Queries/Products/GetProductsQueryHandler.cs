namespace Products.Catalogs.Domain.Queries.Products;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ICollection<Product>>
{
    private readonly IProductRepository _repository;

    public GetProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == null)
        {
            return await _repository.GetAllAsync();
        }

        var product = await _repository.GetByIdAsync(request.Id.Value);
        return product != null ? [product] : new List<Product>();
    }
}
