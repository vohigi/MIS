using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MIS.Models;

namespace MIS.ViewModels
{
    public class OwnerPageViewModel
    {
        public User Owner { get; set; }
        public virtual string Email { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string TaxId { get; set; }
        public virtual string Gender { get; set; }
        public virtual System.DateTime BirthDate { get; set; }
        public virtual Msps Msp { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public List<Declarations> Declarations { get; set; }
        public List<User> UserList { get; set; }
    }
}