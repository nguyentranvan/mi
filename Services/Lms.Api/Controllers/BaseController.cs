using MI.Constant.Lib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MI.Controller.Lib
{
    public abstract class MIController : ControllerBase
    {
        public string Session => string.IsNullOrEmpty(HttpContext.Request.Headers["log-session"]) ? "" : Convert.ToString(HttpContext.Request.Headers["log-session"]);
        public string ClientIps
        {
            get
            {
                var clientIps = (HttpContext.Request.Headers.ContainsKey("X-Forwarded-For") ? HttpContext.Request.Headers["X-Forwarded-For"].ToString() : HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString()).Split(',', StringSplitOptions.RemoveEmptyEntries);
                return JsonConvert.SerializeObject(clientIps);
            }
        }

        public bool IsAuthenticated => HttpContext.User.Identity.IsAuthenticated;
        public Guid UserId
        {
            get
            {
                var context = HttpContext.User.FindFirst(AuthClaim.UserId);
                if (context == null) return Guid.Empty;
                return Guid.Parse(context.Value);
            }
        }
        public string UserName
        {
            get
            {
                var context = HttpContext.User.FindFirst(AuthClaim.UserName);
                if (context == null) return string.Empty;
                return context.Value;
            }
        }
        public string DisplayName
        {
            get
            {
                var context = HttpContext.User.FindFirst(AuthClaim.DisplayName);
                if (context == null) return string.Empty;
                return context.Value;
            }
        }
        public string Email
        {
            get
            {
                var context = HttpContext.User.FindFirst(AuthClaim.Email);
                if (context == null) return string.Empty;
                return context.Value;
            }
        }
    }

}
