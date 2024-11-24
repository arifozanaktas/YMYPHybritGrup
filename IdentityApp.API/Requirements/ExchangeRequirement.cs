using Microsoft.AspNetCore.Authorization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

namespace IdentityApp.API.Requirements
{
    public class ExchangeRequirement : IAuthorizationRequirement
    {
        public int ThresholdAge { get; set; }
    }

    public class ExchangeRequirementHandler : AuthorizationHandler<ExchangeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ExchangeRequirement requirement)
        {
            var birthDate = context.User.Claims.FirstOrDefault(x => x.Type == "birth_date");


            if (birthDate is null)
            {
                context.Fail(new AuthorizationFailureReason(this,
                    "Kullanıcının doğum tarihi bilgisi olmadığından dolayı istek yapmaya yetkili değildir"));

                return Task.CompletedTask;
            }

            var userBirthDate = Convert.ToDateTime(birthDate.Value);
            var today = DateTime.Now;

            var age = today.Year - userBirthDate.Year;

            //fast fail
            if (age <= requirement.ThresholdAge)
            {
                context.Fail();
                return Task.CompletedTask;
            }


            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}