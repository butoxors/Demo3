using Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Helpers.Json
{
    public static class JsonHelper
    {
        private static string path = $@"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)}\..\..\..\user.json";

        public static UserModel GetUserModel()
        {
            UserModel model = JsonConvert.DeserializeObject<UserModel>(File.ReadAllText(path));

            return model;
        }
    }
}
