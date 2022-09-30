using System;
using System.ComponentModel.DataAnnotations;

namespace VertexCore.ViewModels
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
       
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        [EmailAddress(ErrorMessage = "Please enter the right format like xyz@gmail.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        public string Zip { get; set; }
        [Required(ErrorMessage = "FirstName is Required")]
        [Phone]
        public string Phone { get; set; }
    }
}
