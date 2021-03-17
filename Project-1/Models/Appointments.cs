using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_1.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentID {get; set;}
        public string AppointmentDay {get; set;}
        public int AppointmentTime { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable {get; set;}

    }
}
