using System;
using System.Collections.Generic;

namespace MIS.Models
{
  public partial class Employees
  {
    public Employees()
    {
      Declarations = new HashSet<Declarations>();
    }

    public string EmployeeId { get; set; }
    public int? MspId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string TaxId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }

    public virtual Msps Msp { get; set; }
    public virtual User User { get; set; }

    public virtual ICollection<Declarations> Declarations { get; set; }
  }
}
