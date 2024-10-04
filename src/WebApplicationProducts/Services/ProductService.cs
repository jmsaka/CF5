using Newtonsoft.Json;

namespace WebApplicationProducts.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("/api/products");
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Product>>(responseData);
    }

    public async Task<Product> GetProductByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"/api/products?id={id}");
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Product>>(responseData).FirstOrDefault();
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/products", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var response = await _httpClient.PatchAsync($"/api/products", JsonContent.Create(product));
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"/api/products/{id}");
        return response.IsSuccessStatusCode;
    }
}