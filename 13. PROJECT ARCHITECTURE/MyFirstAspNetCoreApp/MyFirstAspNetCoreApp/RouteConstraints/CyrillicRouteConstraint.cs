using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApp.RouteConstraints
{
    public class CyrillicRouteConstraint : IRouteConstraint
    {
        public CyrillicRouteConstraint()
        {

        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = values.FirstOrDefault(x => x.Key == routeKey);
            if (value.Value == null)
            {
                return false;
            }

            var allowedCharacters = "абвгдежзийклмнопрстуфхцчшщъьюя";

            foreach (var ch in value.Value.ToString())
            {
                if (!allowedCharacters.Contains(char.ToLower(ch)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
