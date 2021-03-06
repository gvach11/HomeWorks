using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Week13.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Week13.Controllers
{
    [TypeFilter(typeof(BookingFilter))]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("/app")]
        public ActionResult Appointment()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(Microsoft.AspNetCore.Http.IFormCollection Collection)
        {
            string filepath = @"C:\Week13.json";
            if (!System.IO.File.Exists(filepath))
            {
                var myfile = System.IO.File.Create(filepath);
                myfile.Close();
            }
            if (ModelState.IsValid){
                AppointmentModel appointment = new AppointmentModel();
                appointment.FirstName = Collection["FirstName"].ToString();
                appointment.LastName = Collection["LastName"].ToString();
                appointment.Doctor = Collection["Doctor"].ToString();
                appointment.Time = Collection["Time"].ToString();

                //string appstring = JsonConvert.SerializeObject(appointment);
                //System.IO.File.AppendAllText(filepath, appstring + "\n");

                if (ValidateDate((appointment.Time)))
                {
                    string appstring = JsonConvert.SerializeObject(appointment);
                    System.IO.File.AppendAllText(filepath, appstring + "\n");
                }
                else
                {
                    return Json(new { status = "error", message = "Invalid Time" });
                }
            }
            return RedirectToAction("Appointment");
        }
        [HttpGet]
        public ActionResult ViewApps()
        {
            string filepath = @"C:\Week13.json";
            string readfile = System.IO.File.ReadAllText(filepath);
            //JArray convert = JArray.Parse(readfile);
            ViewData["responsedata"] = readfile;
            return View();
        }

        public bool ValidateDate(string time)
        {
            DateTime now = DateTime.ParseExact(time, "H:m", null);
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0);
            if (end.Hour >= now.Hour && now.Hour >= start.Hour)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
