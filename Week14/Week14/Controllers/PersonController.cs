using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Week14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "\\Week14.json";

        

        //Validator start
        public class PersonValidator : AbstractValidator<Person>
        {
            public PersonValidator()
            {
                RuleFor(Person => Person.CreateDate.Day).LessThanOrEqualTo(DateTime.Now.Day);
                RuleFor(Person => Person.Firstname).Length(0, 50);
                RuleFor(Person => Person.Lastname).Length(0, 50);
                RuleFor(Person => Person.JobPosition).Length(0, 50);
                RuleFor(Person => Person.Salary).InclusiveBetween(0, 10000);
                RuleFor(Person => Person.WorkExperince).NotNull();
                RuleFor(Person => Person.PersonAddress).NotNull().WithMessage("Address is mandatory!");
                RuleFor(Person => Person.PersonAddress.City).NotNull().WithMessage("City is mandatory!");
                RuleFor(Person => Person.PersonAddress.Country).NotNull().WithMessage("Country is mandatory!");
                RuleFor(Person => Person.PersonAddress.HomeNumber).NotNull().WithMessage("Home Number is mandatory!");
            }
        }

        //Validator End

        //Registration
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

            var personValidator = new PersonValidator();
            ValidationResult result = personValidator.Validate(newPerson);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            if (!System.IO.File.Exists(_filePath))
            {
                var myfile = System.IO.File.Create(_filePath);
                myfile.Close();

            }
            string personString = JsonConvert.SerializeObject(newPerson);
            System.IO.File.AppendAllText(_filePath, personString + "\n");
            string readfile = System.IO.File.ReadAllText(_filePath);    
            return Ok(readfile);
        }

        //Reading the whole file
        [HttpGet ("getdata")]
        public IActionResult GetData()
        {
            string readfile = System.IO.File.ReadAllText(_filePath);
            return Ok(readfile);
        }

        //Reading a certain line
        [HttpGet ("getdata/{id}")]
        public IActionResult GetDataById(int id)
        {
            try
            {
                string readline = System.IO.File.ReadLines(_filePath).Skip(id).Take(1).First();
                return Ok(readline);
            }
            catch (System.InvalidOperationException)
            {
                return NotFound($"The file does not containt index#{id}");
            }

            
        }

        //Filter
        [HttpGet ("getdatabyparam")]
        public IActionResult GetDataByQuery([FromQuery] Person person)
        {
            var personList = new List<Person>();
            var linesRead = System.IO.File.ReadLines(_filePath);
            foreach (var line in linesRead)
            {
                var jsonLine = JsonConvert.DeserializeObject<Person>(line);
                personList.Add(jsonLine);

            }
            var result = personList.Where(x => x.Salary == person.Salary);
            if (result.Count() == 0)
            {
                return Ok("No Results Found");
            }
            return Ok(result);
            

        }
    }
}
