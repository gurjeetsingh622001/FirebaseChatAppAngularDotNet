using FirebaseAdmin.Auth;
using Services.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Services.fbInterface
{
    public interface IfbUserServices
    {
        public Task<UserRecord> CreateUser(UserRequestDto user);
        public Task<WriteResult> AddUserDetails(UserRequestDto user, string UserUid);
        public bool UpdateUser(string username);
        public bool getUsers(string username);
        public bool DeleteUsers(string username);
    }

}
