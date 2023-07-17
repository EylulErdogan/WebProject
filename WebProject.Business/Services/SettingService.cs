using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebProject.Data.Abstract;
using WebProject.Entities;

namespace WebProject.Business.Services
{
	public class SettingService : ISettingService
	{
		private ISettingDal _settingDal;
		IMemoryCache _memoryCache;

		public SettingService(ISettingDal settingDal, IMemoryCache memoryCache)
		{
			_settingDal = settingDal;
			_memoryCache = memoryCache;
		}

		public IList<Setting> GetSettings()
		{
			var cacheData = _memoryCache.Get("settings");
			if (cacheData == null)
			{
				var data = _settingDal.GetAll();
				_memoryCache.Set("settings", data,TimeSpan.FromMinutes(5));
				return data;
			}
			return (IList<Setting>)cacheData;
		}

		public Setting GetSetting(string name)
		{
			var cacheData = _memoryCache.Get("setting_" + name);
			if (cacheData == null)
			{
				var data = _settingDal.Get(x => x.Id == name);
				_memoryCache.Set(name, data);
				return data;
			}
			return cacheData as Setting;
		}
	}

	public interface ISettingService
	{
		public IList<Setting> GetSettings();
		public Setting GetSetting(string name);
	}
}
