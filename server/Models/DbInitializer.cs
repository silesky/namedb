using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NameDb.Model.Entities;
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
      var users = new List<User>() {
        new User{
          UserId = Guid.NewGuid(),
          Email = "john@email.com"}
      };
      foreach (User eachUser in users)
      {
        context.User.Add(eachUser);
      }
      context.SaveChanges();

      var contacts = new List<Contact>() {
        new Contact{ContactId = Guid.NewGuid(), Name = "John" }
      };
      foreach (Contact eachContact in contacts)
      {
        context.Contact.Add(eachContact);
      };
      context.SaveChanges();
      
      var firstMeetings = new List<FirstMeeting>() {
        new FirstMeeting{FirstMeetingId = Guid.NewGuid(), FirstMeetingName = "Ben's Party"}
      };
      foreach (FirstMeeting eachMeeting in firstMeetings)
      {
        context.FirstMeeting.Add(eachMeeting);
      };
      context.SaveChanges();
    }

  }
}