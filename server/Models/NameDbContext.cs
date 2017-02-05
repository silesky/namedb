using Microsoft.EntityFrameworkCore;
using NameDb.Model.Entities;

namespace NameDb.Model
{
  public class NameDbContext : DbContext
  {
    public NameDbContext() { }
    public NameDbContext(DbContextOptions<NameDbContext> options)
    : base(options)
    { 
      
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

    }
    public DbSet<User> User { get; set; }
    public DbSet<FirstMeeting> FirstMeeting { get; set; }
    public DbSet<Contact> Contact { get; set; }

  }
}