using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task23_11
{
    public class User : IAccount
    {
        private static int _idCounter = 1;

        private int _id;
        public string Fullname { get; set; }
        public string Email { get; set; }

        private string _password;

        public int Id()
        {
            return _id;
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (PasswordChecker(value))
                    _password = value;
                else
                    Console.WriteLine("Password does not meet requirements.");
            }
        }

        public User(string fullname, string email, string password)
        {
            Fullname = fullname;
            Email = email;
            _id = _idCounter++;
            Password = password;
        }

        public bool PasswordChecker(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;


            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                if (char.IsLower(c))
                    hasLower = true;
                if (char.IsDigit(c))
                    hasDigit = true;

                if (hasUpper && hasDigit && hasLower)
                    return true;
            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id()}, Fullname: {Fullname}, Email: {Email}");
        }
    }
}
