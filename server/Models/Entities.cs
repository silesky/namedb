using System.Collections.Generic;
using System;
namespace NameDb.Model.Entities
{
  public class User
  {
    public Guid UserId { get; set; }
    public string Email { get; set; }

    public virtual List<Contact> Contacts { get; set; } // (collection nav.property) all the contacts I have altogether. 
    public virtual List<FirstMeeting> FirstMeeting { get; set; }
  }

  // User -< Contact | User -< FirstMeeting | FirstMeeting -< Contact

  // Contact.UserId { <-- foreign key
  // public Contact Contact {.. <--  navigation property that's a reference to many related titles (ie. "collection navigation property")

// user: seth
// pw: farlookthere

  public class FirstMeeting
  {
    public Guid FirstMeetingId { get; set; }
    public Guid UserId { get; set; }
    public string FirstMeetingName { get; set; }
    public string FirstMeetingDate { get; set; }
    public virtual User User { get; set; }
    public virtual List<Contact> Contacts { get; set; } // all the contacts I made at John's party
  }

  public class Contact

  {
    public Guid ContactId { get; set; }
    public Guid FirstMeetingId { get; set; }
    public Guid UserId { get; set; }
    public virtual FirstMeeting FirstMeeting { get; set; }   //  (reference nav. property) this is the counterpart to List<Contact> Contacts
   
    public virtual User User { get; set; }
    public string Name { get; set; }

  }
}