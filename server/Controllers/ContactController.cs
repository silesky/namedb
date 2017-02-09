using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
    [HttpGet("")] 
    public IEnumerable<Contact> GetAll() {
      return NameDbContextReference.Contact.AsEnumerable();
    }

    [HttpGet("{id:guid}")] // hits on api/contact
    public ActionResult Get(Guid id) {
      // it's confusing, but I can't use "NameDbContext", because it's not a static class -- it needs to be instantiated. 
      Contact contact = NameDbContextReference.Contact.FirstOrDefault(el => el.ContactId == id);
      return new ObjectResult(contact);


    }

  }
}



