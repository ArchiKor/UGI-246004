using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class User
    {
       readonly string login;
        public string Login => login;
        
        public User(string userlogin) 
        {
            foreach (var ch in userlogin)
                if (!char.IsDigit(ch) || !char.IsLetter(ch))
                    throw new ArgumentException($"{userlogin}: логин должен состять только из букв или цифр");
                else
                    login = userlogin;

            Logger.LogInfo($"пользователь {login} создан");


        }
        ~User()
        {
            Logger.LogInfo($"пользователь {login} удалён из памяти");
        }

        public string GetInfo() => $"Пользователь {Login}";

    }
}
