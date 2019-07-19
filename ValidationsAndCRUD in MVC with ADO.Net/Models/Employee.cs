using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ValidationsAndCRUD_in_MVC_with_ADO.Net.Models
{
    public class Employee
    {
        [Display(Name = "id")]
        public int id { get; set; }

        [Required(ErrorMessage = " Name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = " Salary is required.")]
        public double salary { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        //[Display(Name = "contact")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string contact { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = " Address is required.")]
        public string adderess { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = " Email ID is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid emailId.")]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter valid emailId.")]
        public string emailId { get; set; }
    }
}