using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Week17.Domain;
using Week17.Data;
using Microsoft.AspNetCore.Authorization;
using Week17.Services;
using Week17.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Week17.Controllers
{


    [Authorize]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonContext _context;
        private IUserService _userService;
        public PersonController(PersonContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


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

        //Login


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {

            var user = _userService.Login(username, password);

            if (user == null)
                return BadRequest(new { message = "Username or Password is incorrect" });
            string tokenString = _userService.GenerateToken(user);
            var userId = _context.Persons
                        .Where(x => x.Username == username)
                        .Select(x => x.Id)
                        .SingleOrDefault();
            var currentrecord = _context.Persons.Find(userId);
            currentrecord.Token = tokenString;
            _context.Persons.Update(currentrecord);
            _context.SaveChanges();
            

            return Ok();


        }



        //Registration
        [HttpPost ("register")]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            
            var personValidator = new PersonValidator();
            ValidationResult result = personValidator.Validate(person);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.FirstOrDefault());
            }

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();


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
                        
                    }) ;
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
        [AllowAnonymous]
        [HttpGet ("getdatabyparam")]
        public IQueryable<Object> GetPersonByName(string name)
        {

            return (from p in _context.Persons
                    join a in _context.Addresses on p.Id equals a.PersonId
                    where p.Firstname == name
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
        [Authorize(Roles = Role.Admin)]
        [HttpDelete ("delete/{id}")]
        public async Task<ActionResult<Person>> DeleteById(int id)
        {
            var currentRecord = _context.Persons.Find(id);
            _context.Persons.Remove(currentRecord);
            _context.SaveChanges();
            return Ok(currentRecord);
        }

        //Update
        [Authorize(Roles = Role.Admin)]
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
