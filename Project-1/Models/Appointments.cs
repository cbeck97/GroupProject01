using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_1.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentID {get; set;}
        public DateTime AppointmentTime {get; set;}

        [DefaultValue(true)]
        public Boolean IsAvailable {get; set;}

        /*
        public int aptID
        public string day
        public int time

        public bool IsAvailable(day, time)
        {
            if SQL QUERY TO CHECK IF ANY APTS MEET CRITERIA

            return True or False
        }
         */

    }
}
