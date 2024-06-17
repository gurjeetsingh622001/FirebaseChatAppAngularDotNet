using Services.fbInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin.Auth;
using Services.RequestDto;
using Google.Cloud.Firestore;

namespace Services.fbServices
{
    public class fbUserServices : IfbUserServices
    {
        FirestoreDb db;
        public fbUserServices() {
             db = FirestoreDb.Create("webapichatapp");

        }
        public async Task<UserRecord> CreateUser(UserRequestDto user)
        {
            try
            {
                UserRecordArgs args = new UserRecordArgs()
                {
                    Email = user.Email,
                    EmailVerified = false,
                    PhoneNumber = user.PhoneNumber,
                    Password = user.Password,
                    DisplayName = user.DisplayName,
                    PhotoUrl = "http://www.example.com/12345678/photo.png",
                    Disabled = false,
                };

                var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
                var userDetails = await AddUserDetails(user);
                Console.WriteLine($"Successfully created new user: {userRecord.Uid}");
                return userRecord;
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception("Error creating user in Firebase Authentication.", ex);
            }
        }
        public async Task<UserRecord> AddUserDetails(UserRequestDto user)
        {
            try
            {
                DocumentReference docRef = db.Collection("cities").Document("LA");
                Dictionary<string, object> city = new Dictionary<string, object>
                                                  {
                                                      { "name", "Los Angeles" },
                                                      { "state", "CA" },
                                                      { "country", "USA" }
                                                  };
                await docRef.SetAsync(city);
                UserRecordArgs args = new UserRecordArgs()
                {
                    Email = user.Email,
                    EmailVerified = false,
                    PhoneNumber = user.PhoneNumber,
                    Password = user.Password,
                    DisplayName = user.DisplayName,
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
