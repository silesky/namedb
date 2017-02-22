using System;
using System.Linq;
using System.Collections.Generic;
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

      var firstMeetingId = Guid.NewGuid(); // need to pre-generate guids to get around foreign key constrain error
      var userId =  Guid.NewGuid();

      var users = new List<User>() {
        new User{
          UserId = userId,
          Email = "john@email.com"}
          };
      foreach (User eachUser in users)
      {
        context.User.Add(eachUser);
      }
      context.SaveChanges()
      ;
      var firstMeetings = new List<FirstMeeting>() {
        new FirstMeeting{
          UserId = userId,
          FirstMeetingId = firstMeetingId,
          FirstMeetingName = "Ben's Party"

        }
      };
      foreach (FirstMeeting eachMeeting in firstMeetings)
      {
        context.FirstMeeting.Add(eachMeeting);
      };
      context.SaveChanges();
      var contacts = new List<Contact>() {
        new Contact{
          FirstMeetingId = firstMeetingId,
          UserId = userId,
          Name = "John"
          }
      };
      foreach (Contact eachContact in contacts)
      {
        context.Contact.Add(eachContact);
      };
      context.SaveChanges();


    }

  }
}
