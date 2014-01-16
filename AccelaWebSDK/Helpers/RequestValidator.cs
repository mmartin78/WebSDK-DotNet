using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public static class RequestValidator
    {
        public static void ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new Exception("Please provide an authentication token");
        }
    }
}
