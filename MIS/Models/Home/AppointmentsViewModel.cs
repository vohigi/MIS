using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using MIS.Models;
namespace MIS.ViewModels
{
  public class AppointmentsViewModel
  {

    public virtual User User { get; set; }
    public virtual List<Appointments> Appointments { get; set; }
  }
}