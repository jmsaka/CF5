namespace Products.Catalogs.Domain.Commands.Products;

public class CreateProductCommand : IRequest<Guid?>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
