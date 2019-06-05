using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace MIS.Models
{
  public class User : IdentityUser
  {
    public User()
    {
      DeclarationsE = new HashSet<Declarations>();
    }
    public virtual Declarations Declarations { get; set; }
    public virtual int? MspId { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string MiddleName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string TaxId { get; set; }
    public virtual string Gender { get; set; }
    public virtual DateTime BirthDate { get; set; }
    public virtual Msps Msp { get; set; }
    public virtual ICollection<Declarations> DeclarationsE { get; set; }

  }
};
