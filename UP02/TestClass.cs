using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP02
{
    public class TestClass
    {
        public bool TestPassword(string password, string login)
        {
            if (password.Length > 20 || password.Length < 5)
            {
                return false;
            }
            else
            {
                if (password.Contains(login))
                {
                    return false;
                }
                else
                {
                    if (password.Any(char.IsUpper) && password.Any(char.IsLower))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }

}
