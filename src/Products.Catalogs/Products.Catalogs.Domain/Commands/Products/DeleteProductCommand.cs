namespace Products.Catalogs.Domain.Commands.Products;

public class DeleteProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
