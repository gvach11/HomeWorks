using System.Collections.Generic;
using System.Linq;
using Week17.Data;
using Week17.Domain;
using Week17.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Week17_tests
{


	public class UserServiceFake : IUserService
	{
        public readonly List<Person> _persons;

        public UserServiceFake()
        {
            _persons = new List<Person>()
            {
                new Person() { Id = 1,
                    Firstname = "Test", Lastname="Test", JobPosition = "Test", Salary = 100, WorkExperince = 10, 
                    CreateDate = System.DateTime.Now.Date, Password = "test1", Username = "test1", 
                    PersonAddress = new Address{
                                            City = "test",
                                            Country = "test",
                                            HomeNumber = 10},
                    Role = "Admin", Token = null},
                                new Person() { Id = 2,
                    Firstname = "Test", Lastname="Test", JobPosition = "Test", Salary = 100, WorkExperince = 10,
                    CreateDate = System.DateTime.Now.Date, Password = "test1", Username = "test2",
                    PersonAddress = new Address{
                                            City = "test",
                                            Country = "test",
                                            HomeNumber = 10},
                    Role = "User", Token = null},
                                                new Person() { Id = 3,
                    Firstname = "Test", Lastname="Test", JobPosition = "Test", Salary = 100, WorkExperince = 10,
                    CreateDate = System.DateTime.Now.Date, Password = "test1", Username = "test3",
                    PersonAddress = new Address{
                                            City = "test",
                                            Country = "test",
                                            HomeNumber = 10},
                    Role = "Admin", Token = null},


            };
        }

        public string GenerateToken(Person User)
        {
            return "fake token";
        }

        public IEnumerable<Person> GetAll()
        {
            return _persons;
        }

        public Person GetById(int id)
        {
            var person = _persons.Find(x => x.Id == id);
            return person;
        }

        public Person Login(string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				return null;

			var user = _persons.SingleOrDefault(x => x.Username == username);

			if (user == null)
				return null;

			if (password != user.Password)
				return null;

			return user;
		}
	}
}
