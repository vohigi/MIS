using System;
using System.Collections.Generic;

namespace MIS.Models
{
  public partial class Declarations
  {
    public int DeclarationId { get; set; }
    public string UserId { get; set; }
    public string EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime CreateDate { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }

    public virtual User Employee { get; set; }
    public virtual User User { get; set; }
  }
}
