using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Contact = NameDb.Model.Entities.Contact;
namespace NameDb.Model
{
  public static class DbInitializer
  {
    // dbContext = bridge to your db
    public static void Initalize(NameDbContext context)
    {
      context.Database.EnsureCreated();
      if (context.Contact.Any())
      {
        // do nothing if not seeded
        return;
      }
      Console.WriteLine("Adding Seed Data...");

      Console.WriteLine("Added Seed data!");
    }
  }
}