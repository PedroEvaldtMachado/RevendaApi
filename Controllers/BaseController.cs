using Microsoft.AspNetCore.Mvc;

namespace RevendaApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
}
