using APITestApp.Models;
using Microsoft.AspNetCore.Identity;

namespace APITestApp.Respository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
