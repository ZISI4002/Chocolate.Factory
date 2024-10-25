using Chocolate.Factory.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Models
{
    public class ConfigurationInfo
    {
        public DatabaseType DatabaseType { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
