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

        public IEnumerable<SignUp> SignUps { get; set; }
        public IEnumerable<Appointments> Appointments { get; set; }
    }
}
