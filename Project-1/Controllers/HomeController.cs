using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_1.Models;
using Project_1.Models.ViewModels;

namespace Project_1.Controllers
{
    public class HomeController : Controller
    {
        //create context and logger
        private readonly ILogger<HomeController> _logger;
        private SignUpContext _context { get; set; }

        //set context and logger
        public HomeController(ILogger<HomeController> logger, SignUpContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // 1st part of form for choosing day and time
        [HttpGet]
        public IActionResult SignUp()
        {
            //pass appointments as ienumerables for each day of week
            return View(new DayViewModel()
            {
                Monday = _context.Appointments
                    .Where(x => x.AppointmentDay == "Monday" && x.IsAvailable),
                Tuesday = _context.Appointments
                    .Where(x => x.AppointmentDay == "Tuesday" && x.IsAvailable),
                Wednesday = _context.Appointments
                    .Where(x => x.AppointmentDay == "Wednesday" && x.IsAvailable),
                Thursday = _context.Appointments
                    .Where(x => x.AppointmentDay == "Thursday" && x.IsAvailable),
                Friday = _context.Appointments
                    .Where(x => x.AppointmentDay == "Friday" && x.IsAvailable)
            });
        }

        
        [HttpPost]
        public IActionResult SignUp(int id)
        {
            //pushes a string for the appt day and time and also passes the appt id 
            Appointments appointments = _context.Appointments.Where(x => x.AppointmentID == id).FirstOrDefault();
            string output = $"{appointments.AppointmentDay}, {appointments.AppointmentTime}:00 - {appointments.AppointmentTime + 1}:00";
            ViewData["output"] = output;
            ViewData["id"] = id;
            return View("Schedule");
        }


        // 2nd part of form with group info
        [HttpGet]
        public IActionResult Schedule(Appointments appointments)
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Schedule(SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                //change the appointment to not available
                Appointments appointments = _context.Appointments.Where(x => x.AppointmentID == signUp.AppointmentID).FirstOrDefault();
                appointments.IsAvailable = false;

                //update context for new signup and appointment
                _context.Update(appointments);

                _context.SignUp.Add(signUp);
                _context.SaveChanges();

                //passes a new viewmodel to view appts view
                return View("ViewAppointments", new ViewAppointmentsViewModel
                {
                    SignUps = _context.SignUp,
                    Appointments = _context.Appointments
                });
            }
            return View();
        }

        //view appts uses viewappointmentsviewmodel 
        public IActionResult ViewAppointments()
        {
            return View(new ViewAppointmentsViewModel
            {
                SignUps = _context.SignUp,
                Appointments = _context.Appointments
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
