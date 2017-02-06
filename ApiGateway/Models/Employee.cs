using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGateway.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Designation { get; set; }
        public int PayLevel { get; set; }
    }
}