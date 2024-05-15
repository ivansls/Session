using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP02
{
    internal class UserInfo
    {
        public string login;
        public string password;
        public string role;

        public UserInfo(string login, string password, string role)
        {
            this.login = login;
            this.password = password;
            this.role = role;
        }
    }
}
