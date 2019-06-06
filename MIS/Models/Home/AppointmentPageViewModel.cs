using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MIS.Models;

namespace MIS.ViewModels
{
    public class AppointmentPageViewModel
    {
        public User User { get; set; }

        public IEnumerable<Appointments> Appointments
        {
            get; set;
        }

    }
}