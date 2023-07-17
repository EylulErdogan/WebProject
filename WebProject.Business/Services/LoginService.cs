using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	public class LoginService :ILoginService
	{
		 IUserDal _userDal;

		public LoginService(IUserDal userDal)
		{
			_userDal = userDal;
		}


		public User Login(string email, string password)
		{
			var output = _userDal.Get(x => x.Email == email && x.Password == password);
			if (output==null)
			{
				return null;
			}
			else
			{
				return output;
			}
		}
		public User Register(User user)
		{
			var exist = _userDal.Any(x => x.Email == user.Email);
			if (exist)
			{
				return null;
			}
			var output = _userDal.Add(user);
			if (output==null)
			{
				return null;
			}
			else
			{
				return output;
			}
		}
	}

	public interface ILoginService
	{
		User Login(string email, string password);
		User Register(User user);
	}
}
