using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Week14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "\\Week14.json";

        [HttpPost ("register")]
        public IActionResult Register([FromQuery]Person person)
        {
            var newPerson = new Person
            {
                CreateDate = DateTime.Now,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                JobPosition = person.JobPosition,
                Salary = person.Salary,
                WorkExperince = person.WorkExperince,
                PersonAddress = new Address
                {
                    City = person.PersonAddress.City,
                    Country = person.PersonAddress.Country,
                    HomeNumber = person.PersonAddress.HomeNumber
                }
            };

            if (!System.IO.File.Exists(_filePath))
            {
                var myfile = System.IO.File.Create(_filePath);
                myfile.Close();

            }
            string personString = JsonConvert.SerializeObject(newPerson);
            System.IO.File.AppendAllText(_filePath, personString + "\n");
            return Ok(person);
        }
    }
}
