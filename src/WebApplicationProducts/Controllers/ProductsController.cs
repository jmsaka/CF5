namespace WebApplicationProducts.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }
        catch (Exception)
        {
            return RedirectToAction("Index", "Home");
        }
        
    }

    [HttpGet("[controller]/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost("[controller]/save")]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        if (ModelState.IsValid)
        {
            if (string.IsNullOrEmpty(product.Id))
            {
                await _productService.CreateProductAsync(product);
            }
            else
            {
                await _productService.UpdateProductAsync(product);
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpDelete("[controller]/delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
