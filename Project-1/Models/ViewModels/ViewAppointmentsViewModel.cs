using System;
using System.Collections;
using System.Collections.Generic;

namespace Project_1.Models.ViewModels
{
    public class ViewAppointmentsViewModel
    {
        public ViewAppointmentsViewModel()
        {
        }
        public IEnumerable<SignUp> SignUps { get; set; }
        public IEnumerable<Appointments> Appointments { get; set; }
    }
}
