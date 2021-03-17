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
        private readonly ILogger<HomeController> _logger;
        private SignUpContext _context { get; set; }

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

        // 1st part of form for choosing time
        [HttpGet]
        public IActionResult SignUp()
        {
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
            Appointments appointments = _context.Appointments.Where(x => x.AppointmentID == id).FirstOrDefault();
            return View("SignUpForm", new SignUpAppointmentsViewModel
            {
                SignUps = new SignUp(),
                Appointments = _context.Appointments.Where(x => x.AppointmentID == appointments.AppointmentID).FirstOrDefault(),
            });
        }


        // 2nd part of form with group info
        [HttpGet]
        public IActionResult SignUpForm(Appointments appointments)
        {
            return View(); //pass appointment info to prepopulate sign up form
        }

        [HttpPost]
        public IActionResult SignUpForm(SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                _context.SignUp.Add(signUp);
                _context.SaveChanges();
                return View("ViewAppointments");
            }
            return View();
        }


        public IActionResult ViewAppointments()
        {
            //need viewmodel for signUps and appointments
            //IEnumerable<SignUp> signUps 
            //_context.ViewModel.Where(x => x.Appointments.IsAvailable != true) and also return signups

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
