using Microsoft.EntityFrameworkCore;
using NameDb.Model.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL;

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
   protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasPostgresExtension("uuid-ossp");
    }
    public DbSet<User> User { get; set; }
    public DbSet<FirstMeeting> FirstMeeting { get; set; }
    public DbSet<Contact> Contact { get; set; }

  }
}