using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AssignmentNet105_Client.Services
{
	public class SessionServices
	{
		public static Account GetAccountFromSession(ISession session, string key)
		{
			//Bước 1: lấy string data từ session ở dạng json
			string jsonData = session.GetString(key);
			if (jsonData == null) return new Account(){ Status = 404};
			//Nếu dữ liệu null tạo mới 1 list rỗng
			//Bước 2: Convert về list
			var user = JsonConvert.DeserializeObject<Account>(jsonData);
			return user;
		}
		//Ghi dữ liệu từ 1 list vào session
		public static void SetAccountToSession(ISession session, string key, object values)
		{
			var jsonData = JsonConvert.SerializeObject(values);
			session.SetString(key, jsonData);
		}
    }
}
