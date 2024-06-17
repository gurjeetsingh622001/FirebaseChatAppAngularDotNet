using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.fbInterface
{
    public interface IfbUserServices
    {
        public Task<UserRecord> CreateUser(string username);
        public bool UpdateUser(string username);
        public bool getUsers(string username);
        public bool DeleteUsers(string username);
    }

}
