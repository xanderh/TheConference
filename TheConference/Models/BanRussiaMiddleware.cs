using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheConference.Models
{
    public class BanRussiaMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _bannedIp = { "192.168.0.1" };

        public BanRussiaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (context.Connection.RemoteIpAddress.ToString().StartsWith("2.60") && context.Connection.RemoteIpAddress.ToString().StartsWith("2.61") && context.Connection.RemoteIpAddress.ToString().StartsWith("2.62") && context.Connection.RemoteIpAddress.ToString().StartsWith("2.63"))
            {
                context.Response.StatusCode = 401;
            } else
            {
                await _next(context);

            }

        }
    }
}
