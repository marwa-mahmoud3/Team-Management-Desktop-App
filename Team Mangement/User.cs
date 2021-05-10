using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Mangement
{
    class User
    {
        public User() { }
        public string UserName { get; set; }
        public string Passward { get; set; }
        public string Email { get; set; }
        public User(string userName, string passward, string email)
        {
            UserName = userName;
            Passward = passward;
            Email = email;
        }
        public User(string userName, string pass)
        {
            UserName = userName;
            Passward = pass;
        }
        public void GetDetails()
        {
            Console.WriteLine($" UserName : {UserName}, Email : {Email} ");
        }

    }
}
