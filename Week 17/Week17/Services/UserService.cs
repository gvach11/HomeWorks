using System.Collections.Generic;
using System.Linq;
using Week17.Data;
using Week17.Domain;

namespace Week17.Services
{

	public interface IUserService
	{
		Person Login(string username, string password);
		Person GetById(int id);
		IEnumerable<Person> GetAll();
	}

	public class UserService : IUserService
	{
		private readonly PersonContext _context;
		public UserService(PersonContext context)
		{
			_context = context;
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
	}
}
