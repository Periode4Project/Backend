using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend
{
    public class ConfigFile
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string MapQuestToken { get; set; }
    }
}
