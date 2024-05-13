using Backend;
using Backend.DB;
using Microsoft.AspNetCore.Mvc;
using WebApi.DB;

[Route("api/[controller]")]
[ApiController]
public class ProviderController : ControllerBase
{
    private readonly IUserService _userService;


    public ProviderController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("providers")]
    public List<ProviderModel> GetAllProviders()
    {
        List<ProviderModel> providerModels = new List<ProviderModel>();
        _userService.GetAllProvider().ForEach(provider =>
        {
            providerModels.Add(new ProviderModel(provider));
        });
        return providerModels;
    }

    [HttpDelete("delprovider/{providerId}")]
    public IActionResult DeleteProvider(int providerId)
    {
        _userService.DeleteProvider(providerId);
        return Ok("Поставщик успешно удален.");
    }
}