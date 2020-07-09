using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static Google.Apis.Auth.GoogleJsonWebSignature;
namespace IvySurvey.OauthLayer
{
    public class AuthenticateUser
    {
        private UserManager<IdentityUser> UserManager;
        private SignInManager<IdentityUser> SignInManager;

        public AuthenticateUser(UserManager<IdentityUser> user, SignInManager<IdentityUser> signIn)
        {
            this.UserManager = user;
            this.SignInManager = signIn;
        }
        public async Task<string> VerifyUser(string Access_token)
        {
            try
            {
                var Payload = await GoogleJsonWebSignature.ValidateAsync(Access_token, new ValidationSettings()
                {
                    Audience = new[] { "782740102672-mfc1do9oq50mpedecc92fmiu981ks69n.apps.googleusercontent.com" },
                });
                if (Payload.Email != "")
                {
                    return await GetTheUser(Payload.Email);
                }
                else
                {
                    return "invalid verify";
                }
            }
            catch (InvalidJwtException je)
            {
                return "invalid";
            }
        }
        public async Task<string> RegisterTheUser(IdentityUser user)
        {
            var result = await UserManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return await SignInTheUser(user);
            }
            else
            {
                return "invalid";
            }
        }

        public async Task<string> GetTheUser(string Email)
        {
            var user = new IdentityUser()
            {
                UserName = Email,
                Email = Email
            };
            var RegisteredUser = UserManager.Users.FirstOrDefault(u => u.Email == user.Email);
            if (RegisteredUser!=null)
            {
                return await SignInTheUser(user);


                // return RegisteredUser.Email+"Remail";

            }
            else
            {
                return await RegisterTheUser(user);

                // return RegisteredUser.Email+"Remail";

            }
        }
        public async Task<string> SignInTheUser(IdentityUser user)
        {
              
            try
            {
                await SignInManager.SignInAsync(user, true);
                return IssueUserToken(user.Email);
            }
            catch (Exception e)
            {
                return "invalid";
            }
        }


        public string IssueUserToken(string Email)
        {
            var claims = new[]
          {
              new Claim(JwtRegisteredClaimNames.Sub,"some_id"),
              new Claim(ClaimTypes.Role,"Admin"),
              new Claim("Email",Email)
          };
            var secretbyte = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            var key = new SymmetricSecurityKey(secretbyte);
            var algorithm = SecurityAlgorithms.HmacSha256;
            var sigincred = new SigningCredentials(key, algorithm);
            var token = new JwtSecurityToken(
                "https://localhost:5001",
                "https://localhost:5001",
                claims, notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(4),
                sigincred);
            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenJson;
        }
    }
}