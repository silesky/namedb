using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NameDb.Model;
using NameDb.Model.Entities;
using System.Linq;
namespace NameDb.Controllers
{
  [Route("api/[controller]")]

  // [Route("api/[controller]")] + class MeetingController = api/meeting  routing
  public class MeetingController: Controller
  {
    private NameDbContext _nameDbContextRef;
    public MeetingController(NameDbContext NameDbContext)
    {
      _nameDbContextRef = NameDbContext;
    }

    [HttpGet("")]
    public IEnumerable<FirstMeeting> GetAll()
    {
      return _nameDbContextRef.FirstMeeting.AsEnumerable();
    }
  }
}
