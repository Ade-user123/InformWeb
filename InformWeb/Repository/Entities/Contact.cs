using System;
using System.ComponentModel.DataAnnotations;


namespace InformWeb.Repository.Entities
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
