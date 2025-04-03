using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp009
{
    public class AuthService
    {
        private readonly List<User> _users = new()
        {
            new User { Username = "admin", Password = "admin123",  IsAdmin = true},
            new User { Username = "user", Password = "user123",  IsAdmin = true}
        };

        public bool Authenticate(string username, string password)
        {
            return _users.Any(u => u.Username == username && u.Password == password);
        }   
    }
}
