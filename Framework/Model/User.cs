using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Model
{
    internal class User
    {
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"User[email = {Email}, password = {Password}]";
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(typeof(User).IsInstanceOfType(obj))) return false;
            User user = (User)obj;

            return Equals(Email, user.Email) &&
                Equals(Password, user.Password);
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode() + Password.GetHashCode();
        }
    }
}
