using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $ext_rootnamespace$.$safeprojectname$.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExampleController : ControllerBase
  {
    private readonly ILogger<ExampleController> _logger;

    public ExampleController(ILogger<ExampleController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok();
    }
  }
}
