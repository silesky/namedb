using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using NameDb.Model;
using System.Collections.Generic;
using NameDb.Model.Entities;
using NameDb.Repositories;
namespace NameDb.Controllers
{
  // top level class

  [Route("api/[controller]")]

  public class ContactController : Controller
  {
    private ContactRepository _contactRepository;
    public ContactController(NameDbContext dbContext)
    {
      // pass dbContext from this constructor to ContactRepository's constructor, and use it new a reference (so I can call the methods on it)
      _contactRepository = new NameDb.Repositories.ContactRepository(dbContext);
    }
    [HttpGet("")]
    public IEnumerable<Contact> GetAll() {
      return _contactRepository.GetAll().AsEnumerable();
    }

    [HttpGet("{id:guid}")] // hits on api/contact
    public ActionResult Get(Guid id) {
      // it's confusing, but I can't use "NameDbContext", because it's not a static class -- it needs to be instantiated.
      return new ObjectResult(_contactRepository.Get(id));
    }

  }
}



