using System.Collections.Generic;

namespace NameDb.Model
{
  public class User
  {
    public int UserId { get; set; }
    public int Email { get; set; }

    public List<Contact> Contacts { get; set; } // (collection nav.property) all the contacts I have altogether. 

  }

  // User -< Contact | User -< FirstMeeting | FirstMeeting -< Contact

  // Contact.UserId { <-- foreign key
  // public Contact Contact {.. <--  navigation property that's a reference to many related titles (ie. "collection navigation property")

// user: seth
// pw: farlookthere

  public class FirstMeeting
  {
    public int FirstMeetingId { get; set; }
    public int UserId { get; set; }
    public string FirstMeetingName { get; set; }
    public string FirstMeetingDate { get; set; }

    public List<Contact> Contacts { get; set; } // all the contacts I made at John's party
  }

  public class Contact
  {

    public int ContactId { get; set; } // foreign key
    public int UserId { get; set; }
    public int FirstMeetingId { get; set; }
    public FirstMeeting FirstMeeting { get; set; }   //  (reference nav. property) this is the counterpart to List<Contact> Contacts
    public string Name { get; set; }

  }
}