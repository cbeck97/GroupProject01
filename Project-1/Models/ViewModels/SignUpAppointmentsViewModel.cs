using System;
using System.Collections;
using System.Collections.Generic;

namespace Project_1.Models.ViewModels
{
    public class SignUpAppointmentsViewModel
    {
        public SignUpAppointmentsViewModel()
        {
        }

        //Create Lists for Controller handling signups and appointments
        public SignUp SignUps { get; set; }
        public Appointments Appointments { get; set; }
    }
}
