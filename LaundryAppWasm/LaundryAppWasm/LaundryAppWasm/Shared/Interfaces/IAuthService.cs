using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppWasm.Shared.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
        Task Logout();
        Task<bool> IsUserAuthenticated();
    }
}
