using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener
{
    public class Config
    {
        public string BASE_URL;
    }
    public class Settings
    {
        public Config Config;
        public Settings()
        {
            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));
        }
    }
}
