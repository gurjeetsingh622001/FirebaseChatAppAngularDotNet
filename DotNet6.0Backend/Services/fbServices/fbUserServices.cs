using Services.fbInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin.Auth;

namespace Services.fbServices
{
    public class fbUserServices : IfbUserServices
    {
        FirebaseApp _firebaseApp;
        public fbUserServices() {
            
        }
        public async Task<UserRecord> CreateUser(string username)
        {
            try
            {
                UserRecordArgs args = new UserRecordArgs()
                {
                    Email = "user@example.com",
                    EmailVerified = false,
                    PhoneNumber = "+11234567890",
                    Password = "secretPassword",
                    DisplayName = "John Doe",
                    PhotoUrl = "http://www.example.com/12345678/photo.png",
                    Disabled = false,
                };

                var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
                Console.WriteLine($"Successfully created new user: {userRecord.Uid}");
                return userRecord;
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception("Error creating user in Firebase Authentication.", ex);
            }
        }

        public bool DeleteUsers(string username)
        {
            return true;
            throw new NotImplementedException();
        }

        public bool getUsers(string username)
        {
            return true;
            throw new NotImplementedException();
        }

        public bool UpdateUser(string username)
        {
            return true;
            throw new NotImplementedException();
        }
    }
}
