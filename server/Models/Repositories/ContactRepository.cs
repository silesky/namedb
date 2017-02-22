using System;
using NameDb.Model.Entities;
using System.Collections.Generic;
using System.Linq;

// this file is just a bunch of database helper methods to be used by your controller, so I can use _contactRepository.getAll() , etc
public interface IContactRepository
{
  IEnumerable<Contact> GetAll();
  Contact Get(Guid myguid);

  //  void Update(Contact mycontact)

}

namespace NameDb.Repositories
{
  public class ContactRepository : IContactRepository
  {
    // this context is supposed to get get passed in by your controller
    // create the data context

    private readonly NameDb.Model.NameDbContext _nameDbContextRef;

    public ContactRepository(NameDb.Model.NameDbContext passedInContextFromController)
    {
      // ContactRepository's constructor gets called from the ContactController's constructor, and the dbContext gets handed off straight away.
      _nameDbContextRef = passedInContextFromController;
    }
    public IEnumerable<Contact> GetAll()
    {
      return _nameDbContextRef.Contact;
    }
    public Contact Get(Guid myguid)
    {
       return _nameDbContextRef.Contact.FirstOrDefault(el => el.ContactId == myguid);
    }
  }
}
