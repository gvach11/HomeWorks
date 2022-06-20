using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Week17.Data;
using Week17.Domain;
using Week17.Helpers;
using Microsoft.Extensions.Options;


namespace Week17.Services
{

	public interface IUserService
	{
		Person Login(string username, string password);
		Person GetById(int id);
		IEnumerable<Person> GetAll();
        string GenerateToken(Person User);
	}

	public class UserService : IUserService
	{
		private readonly PersonContext _context;
        private readonly AppSettings _appSettings;

        public UserService(PersonContext context,IOptions<AppSettings> appSettings)
		{
			_context = context;
            _appSettings = appSettings.Value;
		}

        public IEnumerable<Person> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Person Login(string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
				return null;

			var user = _context.Persons.SingleOrDefault(x => x.Username == username);

			if (user == null)
				return null;

			if (password != user.Password)
				return null;

			return user;
		}

        public string GenerateToken(Person user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
