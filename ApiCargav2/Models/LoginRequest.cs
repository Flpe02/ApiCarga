using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;

namespace ApiCargav2.Models
{
    public class LoginRequest
    {
        private string username;

        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string value)
        {
            username = value;
        }

        private string password;

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            password = value;
        }
    }
}