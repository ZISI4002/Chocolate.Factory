using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocolate.Factory.Models;
using Newtonsoft.Json;

namespace Chocolate.Factory.Helper
{
    internal static class ConfigurationHelper
    {
        private const string _filePath = "chocolate.factory.settings";
        private static ConfigurationInfo _configuration;

        public static void Write(ConfigurationInfo config)
        {
            /*
             * JSON
             */
            string text = JsonConvert.SerializeObject(config);

            File.WriteAllText(_filePath, text);

        }

        public static ConfigurationInfo Read()
        {
            if (_configuration != null)
            {
                return _configuration;
            }
            if (File.Exists(_filePath)==false)
            {
                return null;
            }

            string text = File.ReadAllText(_filePath);

            _configuration = JsonConvert.DeserializeObject<ConfigurationInfo>(text);

            return _configuration;
        }




    }
}
