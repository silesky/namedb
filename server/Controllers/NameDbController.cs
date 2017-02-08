using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NameDb.Model;
namespace NameDb.Controllers {
  public abstract class NameDbController : Controller {
    public NameDbContext Context { get; set; }
    public NameDbController () {
      Context = new NameDbContext(new DbContextOptions<NameDbContext>());
    }
  }
}