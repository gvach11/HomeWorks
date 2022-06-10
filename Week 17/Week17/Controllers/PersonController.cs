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
using Week17.Domain;
using Week17.Data;
using Microsoft.EntityFrameworkCore;

namespace Week17.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonContext _context;
        public PersonController(PersonContext context)
        {
            _context = context;
        }

        private readonly string _filePath = Directory.GetCurrentDirectory() + "\\Week17.json";


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
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            
            var personValidator = new PersonValidator();
            ValidationResult result = personValidator.Validate(person);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }


            return CreatedAtAction("GetPersons", new { id = person.Id }, person);
        }

        //Reading the whole file
        [HttpGet ("getdata")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {

            return await _context.Persons.ToListAsync();
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

        //Delete

        [HttpDelete ("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            var personList = new List<Person>();
            var linesRead = System.IO.File.ReadLines(_filePath);
            foreach (var line in linesRead)
            {
                var jsonLine = JsonConvert.DeserializeObject<Person>(line);
                personList.Add(jsonLine);

            }

            try
            {
                personList.RemoveAt(id);
                System.IO.File.WriteAllText(_filePath, String.Empty);
                foreach (Person person in personList)
                {
                    var person2string = JsonConvert.SerializeObject(person);
                    System.IO.File.AppendAllText(_filePath, person2string + "\n");
                }
                string readfile = System.IO.File.ReadAllText(_filePath);
                return Ok(readfile);
            }
            catch (System.InvalidOperationException)
            {
                return NotFound($"The file does not containt index#{id}");
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateById(int id)
        {
            var personList = new List<Person>();
            var linesRead = System.IO.File.ReadLines(_filePath);
            foreach (var line in linesRead)
            {
                var jsonLine = JsonConvert.DeserializeObject<Person>(line);
                personList.Add(jsonLine);

            }
            try
            {
                personList[id].Firstname = "ChangedName";
                System.IO.File.WriteAllText(_filePath, String.Empty);
                foreach (Person person in personList)
                {
                    var person2string = JsonConvert.SerializeObject(person);
                    System.IO.File.AppendAllText(_filePath, person2string + "\n");
                }
                string readfile = System.IO.File.ReadAllText(_filePath);
                return Ok(readfile);
            }
            catch (System.InvalidOperationException)
            {
                return NotFound($"The file does not containt index#{id}");
            }

        }

    }
}
