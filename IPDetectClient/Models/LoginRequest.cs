using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace IPDectect.Client.Models
{
    public class LoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string MacAddress { get; set; }
    }
}