using FreeCourse.IdentityServer.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName); //kullanıcı adı da olabilir ancak akılda kalan emaildir

            if (existUser == null)//böyle bir email yok ise
            {
                var errors = new Dictionary<string, object>(); 
                errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" }); //list olmasının sebebi Shared/FreeCourse.Shared>Dtos>Response içinde Errors property'si List<> yapıda olduğu için
                context.Result.CustomResponse = errors;

                return; //direkt olarak return diye dönebiliriz yukarıdan zorunlu değil
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(existUser,context.Password);
            //if bloguna uğramadı yani kullanıcı varsa Resource Ownerdan gelen şifreyi al
            //IdentityServer içinde Program.cs'de tanımlanan "email" ve "password"  

            if (passwordCheck==false) //password doğru değil ise
            {

                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });
                context.Result.CustomResponse = errors;
                return;
            }

            //email/username ve password doğru ise token üretmek için bunu kodu yazmamız gerek
            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password); 
        }
    }
}
