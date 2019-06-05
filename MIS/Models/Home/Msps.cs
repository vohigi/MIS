using System;
using System.Collections.Generic;

namespace MIS.Models
{
  public partial class Msps
  {
    public Msps()
    {
      User = new HashSet<User>();
    }

    public int MspId { get; set; }
    public string Name { get; set; }
    public string Edrpou { get; set; }
    public string Address { get; set; }

    public virtual ICollection<User> User { get; set; }
  }
}
