using Microsoft.AspNetCore.Mvc;

namespace HorizonCalender.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiBaseController : ControllerBase;