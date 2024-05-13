using Backend;
using Backend.DB;
using Microsoft.AspNetCore.Mvc;
using WebApi.DB;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IUserService _userService;


    public ProductController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("products")]
    public List<ProductModel> GetAllProducts()
    {
        List<ProductModel> productModels = new List<ProductModel>();
        _userService.GetAllProduct().ForEach(product =>
        {
            productModels.Add(new ProductModel(product));
        });
        return productModels;
    }

    [HttpDelete("delproduct/{productId}")]
    public IActionResult DeleteProduct(int productId)
    {
        _userService.DeleteProduct(productId);
        return Ok("Пользователь успешно удален.");
    }
}