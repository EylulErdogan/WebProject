using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Helpers;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	public class UserService : IUserService
	{
		private readonly IUserDal _userDal;

		public UserService(IUserDal userDal)
		{
			_userDal = userDal;
		}


		public string ChangeGuidKey(User user)
		{
			var key = Guid.NewGuid().ToString();
			user.LoginGuidKey =key;
			_userDal.Update(user);
			return key;
		}

		public User GetUserDataWithEmailAndPassword(string email, string password)
		{
			var md5Password = StringHelper.ToMd5(password);
			return _userDal.Get(x => x.Email == email && x.Password == md5Password);
		}

		public User GetUserDataWithGuidKey(string guid)
		{
			return _userDal.Get(x => x.LoginGuidKey == guid);
		}

		public void ResetUserGuidKey(string guid)
		{
			var user = GetUserDataWithGuidKey(guid);
			user.LoginGuidKey = null;
			_userDal.Update(user);
		}
	}

	public interface IUserService
	{
		string ChangeGuidKey(User user);
		User GetUserDataWithEmailAndPassword(string email, string password);
		User GetUserDataWithGuidKey(string guid);
		void ResetUserGuidKey(string guid);
	}
}
