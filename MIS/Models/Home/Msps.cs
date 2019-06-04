using System;
using System.Collections.Generic;

namespace MIS.Models
{
  public partial class Msps
  {
    public Msps()
    {
      Employees = new HashSet<Employees>();
    }

    public int MspId { get; set; }
    public string Name { get; set; }
    public string Edrpou { get; set; }
    public string Address { get; set; }

    public virtual ICollection<Employees> Employees { get; set; }
  }
}
