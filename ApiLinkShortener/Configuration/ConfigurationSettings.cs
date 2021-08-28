using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener.Configuration
{
    public static class ConfigurationSettings
    {
        public static dynamic DataBase()
        {
            var str = File.ReadAllText("Configuration/DBConfig.json");
            var json = JsonConvert.DeserializeObject(str);
            return json;
        }
    }
}
