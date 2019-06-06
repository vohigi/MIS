using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MIS.Models;

namespace MIS.ViewModels
{
    public class AppointmentPageViewModel
    {
        public User User { get; set; }
        public User Doctor { get; set; }

        public System.DateTime MeetingData { get; set; }
        public string Status { get; set; }

        public Declarations Declaration { get; set; }
    }
}