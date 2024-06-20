using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.fbInterface;
using Newtonsoft.Json;
using System.Net;
using Google.Apis.Http;

namespace Services.fbServices
{
    public class fbAuthService : IfbAuthService
    {

        public async Task<string> SignInWithEmailPasswordAsync(string email, string password)
        {
            try
            {
                var apiKey = "AIzaSyDePMb8WlMmU-V2Cd-leiTk5qe767zqSNo";
                var authUri = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}";

                var client = new HttpClient();
                var requestData = new
                {
                    email = email,
                    password = password,
                    returnSecureToken = true
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(authUri, content);
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseData);

                if (responseObject.TryGetValue("idToken", out var idToken))
                {
                    return idToken;
                }
                else
                {
                    throw new Exception("Failed to retrieve ID token.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error signing in with email and password.", ex);
            }
        }

         
    }
}
