using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;
using NameDb.Model;
using System.Collections.Generic;

namespace NameDb.Controllers
{
  // top level class

  [Route("api/[controller]")]

  public class ContactController : Controller
  {
    private NameDbContext _webApiNameDbContext;
    public ContactController(NameDbContext NameDbContext)
    {
      _webApiNameDbContext = NameDbContext;
    }

    [HttpGet("")]
    public IActionResult Get() {
      Console.WriteLine("hit!");
      return new ObjectResult(null);
      // I need to be able to create and return an object here... that's what the Dto does.
    }
  }
}



