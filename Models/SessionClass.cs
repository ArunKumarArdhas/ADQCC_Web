using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ADQCC_New.Models
{
    public class SessionExpireActionFilter : Attribute, IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionExpireActionFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {

            var session = _httpContextAccessor.HttpContext!.Session.Get("LoginAccount");
            if (session == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Account" }));
            }
        }
        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}