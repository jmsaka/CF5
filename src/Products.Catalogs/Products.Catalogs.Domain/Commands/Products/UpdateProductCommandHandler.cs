namespace Products.Catalogs.Domain.Commands.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productFromDb = await _repository.GetByIdAsync(request.Id, tracking: false);
        if (productFromDb is null)
        {
            return false; 
        }

        var product = _mapper.Map<Product>(request);
        await _repository.UpdateAsync(product);
        return true;
    }
}
