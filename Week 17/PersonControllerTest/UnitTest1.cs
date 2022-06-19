using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week17.Domain;
using Week17.Data;
using Week17.Services;
using Week17.Helpers;
using Microsoft.Extensions.Options;
using Week17.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using NUnit;

namespace Week17_tests
{
    [TestClass]
    internal class Week17ControllerTest
    {
        private readonly PersonContext _context;
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        public PersonController _controller;
        public Week17ControllerTest(PersonContext context, IUserService userService,
        IOptions<AppSettings> appSettings, PersonController controller)
        {
            _context = context;
            _userService = userService;
            _appSettings = appSettings.Value;
            _controller = controller;
        }

        [TestMethod]
        public void LoginTest(string username, string password)
        {
            //arrange
            Person person = new Person();
            person.Username = "test1";
            person.Password = "test1";

            //act
            var okresult = _controller.Login(person);

            //assert
            Xunit.Assert.IsType<OkResult>(okresult);
        }
    }
}
