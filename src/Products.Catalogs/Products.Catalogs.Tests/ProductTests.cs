namespace Products.Catalogs.Tests;

public class ProductTests
{
    private readonly Mock<IProductRepository> _mockRepo;

    public ProductTests()
    {
        _mockRepo = new Mock<IProductRepository>();
    }

    [Fact]
    public void CreateProduct_ShouldAddNewProduct()
    {
        // Arrange
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Laptop",
            Description = "A powerful gaming laptop",
            Price = 1500.99m,
            StockQuantity = 10
        };

        _mockRepo.Setup(repo => repo.AddProduct(It.IsAny<Product>())).Returns(product);

        // Act
        var result = _mockRepo.Object.AddProduct(product);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Laptop", result.Name);
        Assert.Equal(1500.99m, result.Price);
    }

    [Fact]
    public void GetProductById_ShouldReturnProduct()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product
        {
            Id = productId,
            Name = "Smartphone",
            Description = "A brand new smartphone",
            Price = 699.99m,
            StockQuantity = 25
        };

        _mockRepo.Setup(repo => repo.GetProductById(productId)).Returns(product);

        // Act
        var result = _mockRepo.Object.GetProductById(productId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(productId, result.Id);
        Assert.Equal("Smartphone", result.Name);
    }

    [Fact]
    public void UpdateProduct_ShouldUpdateExistingProduct()
    {
        // Arrange
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Headphones",
            Description = "Wireless headphones",
            Price = 99.99m,
            StockQuantity = 50
        };

        _mockRepo.Setup(repo => repo.UpdateProduct(It.IsAny<Product>())).Returns(product);

        // Act
        product.Price = 89.99m; // Atualizando o preço
        var updatedProduct = _mockRepo.Object.UpdateProduct(product);

        // Assert
        Assert.NotNull(updatedProduct);
        Assert.Equal(89.99m, updatedProduct.Price);
    }

    [Fact]
    public void DeleteProduct_ShouldRemoveProduct()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _mockRepo.Setup(repo => repo.DeleteProduct(productId)).Returns(true);

        // Act
        var isDeleted = _mockRepo.Object.DeleteProduct(productId);

        // Assert
        Assert.True(isDeleted);
    }
}

