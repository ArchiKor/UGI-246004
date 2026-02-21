using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class WebService
    {
        static List<User> users;

        static WebService()
        {
            users = new List<User>();
        }

        public static void LogIn(User user)
        {
            users.Add(user);
            Logger.LogInfo($"Присоединился {user.Login} к сервису");
        }

        public static void LogOut(User user)
        { 
            users.Remove(user);
            Logger.LogInfo($"Отсоединился {user.Login} от сервиса");
        }

        public static string[] GetUserNames()
        {
            var userNames = new string[users.Count];

            for (int i = 0; i < users.Count; i++)
                userNames[i] = users[i].Login;

            return userNames;
        }

    }

}
