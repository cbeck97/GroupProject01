using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project_1.Models
{
    public class SignUp
    {
        public SignUp()
        {
        }
        [Key]
        
        public int SubmissionID {get; set;}
        public string GroupName {get; set;}
        public int GroupSize {get; set;}
        public string EmailAddress {get; set;}
        //[RegularExpression("^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$)"]
        public string PhoneNumber {get; set;}
        [ForeignKey("Appointments")]
        public int? AppointmentID {get; set;}


    }
}
