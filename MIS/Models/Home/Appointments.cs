using System;
using System.Collections.Generic;

namespace MIS.Models
{
    public partial class Appointments
    {
        public Appointments(string employeeId, DateTime dateTime, string status)
        {
            this.EmployeeId = employeeId;
            this.DateTime = dateTime;
            this.Status = status;
        }

        public int AppointmentId { get; set; }
        public string UserId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }

        public virtual User Employee { get; set; }
        public virtual User User { get; set; }
    }
}
