using FirebaseAdmin.Auth;
using Services.fbServices;
using Services.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AdminSeed
{
    public class AdminSeed
    {
        private static readonly fbUserServices _fbUserServices;

        static AdminSeed()
        {
            _fbUserServices = new fbUserServices();  
        }
        public static async Task<UserRecord> createAdmin()
        {
            try
            {
                UserRecord existingUser;
                UserRequestDto args = new UserRequestDto()
                {
                    Email = "admin@gmail.com",
                    PhoneNumber = "+320340567890",
                    Password = "admin@123",
                    DisplayName = "John Doe",
                    PhotoUrl = "http://www.example.com/12345678/photo.png",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Address = "123 Main Street, Anytown, USA",
                    Role = Role.admin,
                    IsActive = true,
                };
                try
                {
                    existingUser = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(args.Email);
                }
                catch (FirebaseAuthException ex) when (ex.AuthErrorCode == AuthErrorCode.UserNotFound)
                {
                    existingUser = null;
                }

                if (existingUser != null)
                {
                    Console.WriteLine("User already exists with the email: " + args.Email);
                    return existingUser;
                }


                var user_ = await _fbUserServices.CreateUser(args);
                return user_;
            }
            catch (Exception ex)
            {
                throw new Exception("",ex);
            }
        }
    }
}
