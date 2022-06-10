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

        //Reading the table
        [HttpGet ("getdata")]
        public IQueryable<Object> GetPersons()
        {
            
            return (from p in _context.Persons
                    join a in _context.Addresses on p.Id equals a.PersonId
                    select new
                    {
                        id = p.Id,
                        create_date = p.CreateDate,
                        first_name = p.Firstname,
                        last_name = p.Lastname,
                        job_position = p.JobPosition,
                        salary = p.Salary,
                        work_experience = p.WorkExperince,
                        country = a.Country,
                        city = a.City,
                        home_number = a.HomeNumber
                        
                    }) ; //ამის უფრო მარტივი სინტაქსი არ არსებობს, select * -ის ვარიანტში რომ იყოს
                         //დაჯოინებული თეიბლიდან? ვერ ვნახე და ხელით მაგიტომ დავწერე :D მარტო პერსონი რო მომქონდა
                         //ადრესში null-ებს აბრუნებდა.
        }

        //Reading a certain line
        [HttpGet ("getdata/{id}")]
        public IQueryable<Object> GetPersonById(int id)
        {
            return (from p in _context.Persons
                    join a in _context.Addresses on p.Id equals a.PersonId
                    where p.Id == id
                    select new
                    {
                        id = p.Id,
                        create_date = p.CreateDate,
                        first_name = p.Firstname,
                        last_name = p.Lastname,
                        job_position = p.JobPosition,
                        salary = p.Salary,
                        work_experience = p.WorkExperince,
                        country = a.Country,
                        city = a.City,
                        home_number = a.HomeNumber

                    });
        }

        //Filter
        [HttpGet ("getdatabyparam")]
        public IQueryable<Object> GetPersonByName([FromQuery] Person person)
        {

            return (from p in _context.Persons
                    join a in _context.Addresses on p.Id equals a.PersonId
                    where p.Firstname == person.Firstname
                    select new
                    {
                        id = p.Id,
                        create_date = p.CreateDate,
                        first_name = p.Firstname,
                        last_name = p.Lastname,
                        job_position = p.JobPosition,
                        salary = p.Salary,
                        work_experience = p.WorkExperince,
                        country = a.Country,
                        city = a.City,
                        home_number = a.HomeNumber

                    });
        }

        //Delete

        [HttpDelete ("delete/{id}")]
        public async Task<ActionResult<Person>> DeleteById(int id)
        {
            var currentRecord = _context.Persons.Find(id);
            _context.Persons.Remove(currentRecord);
            _context.SaveChanges();
            return Ok(currentRecord);
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Person>> UpdateById(int id, string fname)
        {
            var currentRecord = _context.Persons.Find(id);
            currentRecord.Firstname = fname;
            _context.Persons.Update(currentRecord);
            _context.SaveChanges();
            return Ok(currentRecord);

        }

    }
}
