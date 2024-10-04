namespace Products.Catalogs.Domain.Commands.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid?>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Guid?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.GetIfExistsByNameOrDescriptionAsync(request.Name))
        {
            return null; 
        }

        var product = _mapper.Map<Product>(request);
        await _repository.AddAsync(product);
        return product.Id;
    }
}
