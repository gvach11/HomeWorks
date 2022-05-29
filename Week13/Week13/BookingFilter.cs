using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Week13
{
    public class BookingFilter : Attribute, IAuthorizationFilter
    {
        private IConfiguration _config;
        public BookingFilter(IConfiguration config)
        {
            _config = config;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var appSwitchfo = _config.GetSection("Switches").GetChildren().FirstOrDefault(x =>
						 x.Key == "BookingNotAllowed");
            if (bool.Parse(appSwitchfo.Value))
            {
                context.Result = new ViewResult() { ViewName = "BookingNotAllowed" };
            }
        }
    }
}
