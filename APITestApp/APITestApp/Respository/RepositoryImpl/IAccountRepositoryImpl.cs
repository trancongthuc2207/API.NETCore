using APITestApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APITestApp.Respository.RepositoryImpl
{
    public class IAccountRepositoryImpl : IAccountRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInModel;
        private readonly IConfiguration configuration;

        public IAccountRepositoryImpl(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInModel, 
            IConfiguration configuration) {
            this.userManager = userManager;
            this.signInModel = signInModel;
            this.configuration = configuration;
        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await signInModel.PasswordSignInAsync
                (model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return String.Empty;
            }

            var authClaims = new List<Claim> { 
                new Claim(ClaimTypes.Email,model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new AppUser { 
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                UserName = model.Email,
                Password = model.Password,
            };

            return await userManager.CreateAsync(user, model.Password);
        }
    }
}
