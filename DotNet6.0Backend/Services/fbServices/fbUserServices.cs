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
                var userDetails = await AddUserDetails(user,userRecord.Uid);
                Console.WriteLine($"Successfully created new user: {userRecord.Uid}");
                return userRecord;
            }
            catch (FirebaseAuthException ex)
            {
                throw new Exception("Error creating user in Firebase Authentication.", ex);
            }
        }
        public async Task<WriteResult> AddUserDetails(UserRequestDto user ,string UserUid)
        {
            try
            {
                DocumentReference UserDetailsDocRef = db.Collection("UserDetails").Document(UserUid);
                UserDetailDto userDetail = new UserDetailDto
                {
                    PhotoUrl = user.PhotoUrl,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = Timestamp.FromDateTime(DateTime.SpecifyKind(user.DateOfBirth, DateTimeKind.Utc)),
                    Address = user.Address,
                    Role = user.Role,
                    IsActive = user.IsActive,
                };
                WriteResult result = await UserDetailsDocRef.SetAsync(userDetail);
                return result;
            }
            catch (Exception ex)
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
