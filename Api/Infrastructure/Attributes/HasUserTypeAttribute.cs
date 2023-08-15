using Business.Dto.User;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text.Json;

namespace Api.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class HasUserTypeAttribute : ActionFilterAttribute
    {
        private readonly UserTypeEnum _userType;

        public HasUserTypeAttribute(UserTypeEnum userType)
        {
            _userType = userType;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContextUser = filterContext.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "user")?.Value;

            var currentUser = JsonSerializer.Deserialize<UserDto>(httpContextUser);

            if (currentUser == null || currentUser.UserType != _userType)
                filterContext.Result = new ObjectResult(null)
                {
                    Value = null,
                    StatusCode = StatusCodes.Status403Forbidden
                };

            base.OnActionExecuting(filterContext);
        }
    }
}
