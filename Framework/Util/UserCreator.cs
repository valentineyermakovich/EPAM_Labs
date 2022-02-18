using System;
using System.Collections.Generic;
using System.Text;
using Framework.Model;

namespace Framework.Util
{
    class UserCreator
    {
        public static string email = TestDataReader.GetTestsSettings().user.Email;
        public static string password = TestDataReader.GetTestsSettings().user.Password;

        public static User WithCredentialsFromProperty()
        {
            return new User(email, password);
        }

        public static User WithEmptyEmail()
        {
            return new User("", password);
        }

        public static User WithEmptyPassword()
        {
            return new User(email, "");
        }
    }
}
