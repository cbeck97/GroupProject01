using System;
using System.Collections.Generic;

namespace Project_1.Models.ViewModels
{
    public class DayViewModel
    {

        //Create IEnumerables for controller to make a list for available appointments display
        public IEnumerable<Appointments> Monday { get; set; }

        public IEnumerable<Appointments> Tuesday { get; set; }

        public IEnumerable<Appointments> Wednesday { get; set; }

        public IEnumerable<Appointments> Thursday { get; set; }

        public IEnumerable<Appointments> Friday { get; set; }

        public IEnumerable<Appointments> Saturday { get; set; }

        public IEnumerable<Appointments> Sunday { get; set; }

    }

}
