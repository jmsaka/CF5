namespace Products.Catalogs.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Product>>> Get([FromQuery] Guid? id)
    {
        ICollection<Product> result;

        try
        {
            var query = new GetProductsQuery(id);
            result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);

        if (productId is null)
        {
            BadRequest("Product already exists");
        }
        return CreatedAtAction(nameof(Get), new { id = productId }, productId);
    }

    [HttpPatch()]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result)
        {
            BadRequest("Product not found");
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        bool result = await _mediator.Send(new DeleteProductCommand() { Id = id });

        if (!result)
        {
            BadRequest("Product not found");
        }

        return Ok(result);
    }
}