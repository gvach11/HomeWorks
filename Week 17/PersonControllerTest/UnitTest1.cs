using Week17.Domain;
using Week17.Data;
using Week17.Services;
using Week17.Helpers;
using Microsoft.Extensions.Options;
using Week17.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Week17_tests
{ 
    public class Week17ControllerTest
    {
        public readonly PersonController _controller;
        public IUserService _service;
        public readonly PersonContext _context;
        readonly AppSettings _appSettings;



        public Week17ControllerTest()
        {
            _service = new UserServiceFake();
            _context = new PersonContext();
            _controller = new PersonController(_context, _service, (IOptions<AppSettings>)_appSettings);//მოკლედ ეს ვერ
                                                                                //გავასწორე, Null reference -ზე გადის
                                                                                //და ვერ ვუქენი ვერაფერი, რანაირად გადავცე
                                                                                //ეგ პარამეტრი ისე რო იმუშაოს ვერ გავიგე,
                                                                                //რა აღარ ვცადე :D  ვერ ვტესტავ დანარჩენ
                                                                                //კოდსაც ამის გამო.
        }

        [Fact]
        public void LoginTest()
        {
            //arrange
            string x = "test1";
            string y = "test1";

            //act
            var okresult = _controller.Login(x, y);

            //assert
            Assert.IsType<OkResult>(okresult);
        }

        [Fact]
        public void GetByIdTest()
        {
            //arrange
            var id = 1;

            //act
            var result = _controller.GetPersonById(id);
           

            //assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void RegistrationTest()
        {
            //arrange
            var testPerson = new Person()
            {
                Id = 1,
                Firstname = "Test",
                Lastname = "Test",
                JobPosition = "Test",
                Salary = 100,
                WorkExperince = 10,
                CreateDate = System.DateTime.Now,
                Password = "test1",
                Username = "test1",
                PersonAddress = new Address
                {
                    City = "test",
                    Country = "test",
                    HomeNumber = 10
                }

            };
            //act
            var result = _controller.AddPerson(testPerson);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);

        }
        [Fact]
        public void GetAllTest()
        {
            var result = _controller.GetPersons();
            Assert.IsAssignableFrom<System.Linq.IQueryable<object>>(result);
        }

        [Fact]
        public void GetByNameTest()
        {
            var name = "test1";
            var result = _controller.GetPersonByName(name);
            Assert.IsAssignableFrom<System.Linq.IQueryable<object>>(result);

        }

        [Fact]
        public void DeleteTest()
        {
            var id = 5;
            var result = _controller.DeleteById(id);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void PutTest()
        {
            var id = 2;
            var result = _controller.UpdateById(id, "test");

            Assert.IsType<OkResult>(result);
        }
    }
}
