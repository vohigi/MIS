using System.ComponentModel.DataAnnotations;

namespace MIS.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string TaxId { get; set; }
        public virtual string Gender { get; set; }
        public virtual System.DateTime BirthDate { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}