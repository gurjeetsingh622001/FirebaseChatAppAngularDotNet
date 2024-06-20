using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.fbInterface
{
    public interface IfbAuthService
    {
        public Task<string> SignInWithEmailPasswordAsync(string email, string password);
    }
}
