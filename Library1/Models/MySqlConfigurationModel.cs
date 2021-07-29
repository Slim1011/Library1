using System;
using System.Collections.Generic;
using System.Text;

namespace General.Models
{
    public class MySqlConfigurationModel
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Charset { get; set; }
    }
}
