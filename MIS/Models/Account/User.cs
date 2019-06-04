using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
namespace MIS.Models
{
  public class User : IdentityUser
  {
    public virtual Employees Employees { get; set; }
    public virtual Declarations Declarations { get; set; }
  }
};
