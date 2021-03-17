using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project_1.Models
{
    public class SignUp
    {
        public SignUp()
        {
        }
        //SignUp Data Table
        [Key]
        public int SubmissionID {get; set;}
        [Required]
        public string GroupName {get; set;}
        [Required]
        [DefaultValue(1)]
        public int GroupSize {get; set;}
        [Required]
        public string EmailAddress {get; set;}
        //[RegularExpression("^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$)"]
        public string PhoneNumber {get; set;}
        [ForeignKey("Appointments")]
        public int? AppointmentID {get; set;}


    }
}
