using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    class User
    {
        public static User logined;
        public string login;
        public string password;
        public string name;
        public string type;
        public User(string login, string password, string name, string type)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.type = type;
        }


    }
}
