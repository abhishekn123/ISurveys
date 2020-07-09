using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Google.Apis.Auth;
using IvySurvey.Models;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using Microsoft.AspNetCore.Identity;
using IvySurvey.OauthLayer;

namespace IvySurvey.Controllers
{
      
     public class AuthController : Controller
    {
         
          AuthenticateUser AuthenticateUser ;

          public AuthController(UserManager<IdentityUser> user,SignInManager<IdentityUser> signIn)
          {
             this.AuthenticateUser= new AuthenticateUser(user, signIn);
          }


        [HttpGet]
       public ActionResult Index()
       {
           return View();
       }
       [HttpGet]
       public ActionResult SigninwithGoogle()
       {
           return View();
       }
        //   [HttpPost]
        // public async  Task<ActionResult> GoogleAuth([FromBody]GoogleRequest response)
        // {
            
        // }
       [HttpPost]
       [AllowAnonymous]
       public async Task<ActionResult> Authenticate([FromBody]GoogleRequest request)
      {
          try{
             var result = await AuthenticateUser.VerifyUser(request.access_token);
             if(result=="invalid")
             {
                 return BadRequest("UnAuthorized Access");
             }
          return Ok(result);
          }
          catch(Exception e)
          {
           return BadRequest(e);
          };
         }
    }
}