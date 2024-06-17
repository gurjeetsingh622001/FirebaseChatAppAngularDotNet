using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using Services.fbInterface;
using Services.RequestDto;
using System;
using System.Net;
using System.Net.Http;

namespace ChatAppFirebase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IfbUserServices _fbUserServices;
        public UserController(IfbUserServices _fbUserService) { 
            _fbUserServices = _fbUserService;
        }
        [HttpPost]
        public Task<UserRecord> CreateUser(UserRequestDto user)
        {
            var user_ =  _fbUserServices.CreateUser(user);
            return user_;
        }
    }
}
