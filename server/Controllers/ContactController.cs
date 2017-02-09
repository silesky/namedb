using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;
using NameDb.Model;
using System.Collections.Generic;
using NameDb.Model.Entities;
namespace NameDb.Controllers
{
  // top level class

  [Route("api/[controller]")]

  public class ContactController : Controller
  {
    private NameDbContext NameDbContextReference;
    public ContactController(NameDbContext NameDbContext)
    {
      // default constructor gets instantiated, and the DbContext gets passed in. I need to be able to save this to a variable.
      NameDbContextReference = NameDbContext;
    }

    [HttpGet("")] // hits on api/contact
    public IEnumerable<Contact> GetAll() {
      Console.WriteLine("hit!");
      // it's confusing, but I can't use "NameDbContext", because it's not a static class -- it needs to be instantiated. 
      return NameDbContextReference.Contact.AsEnumerable();
      // I need to be able to create and return an object here... that's what the Dto does (if I don't want to use the TimerDto directly).
    }
  }
}



