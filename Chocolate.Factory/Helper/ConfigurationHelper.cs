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
        private static string _fileDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ChocolateFactory");
        private static string _filePath = Path.Combine( _fileDirectory,"chocolate.factory.settings");//  %AppData%\ChocolateFactory
        private static ConfigurationInfo _configuration;

        public static void Write(ConfigurationInfo config)
        {
            /*
             * JSON
             */
            string text = JsonConvert.SerializeObject(config);
            if (Directory.Exists(_fileDirectory) == false)
            {
                Directory.CreateDirectory(_fileDirectory);
            }

            File.WriteAllText(_filePath, text);
            _configuration = null;

        }

        public static ConfigurationInfo Read()
        {
            if (_configuration != null)
            {
                return _configuration;
            }

            if (Directory.Exists(_fileDirectory)== false || File.Exists(_filePath) == false)
            {
                return null;
            }
           

            string text = File.ReadAllText(_filePath);

            _configuration = JsonConvert.DeserializeObject<ConfigurationInfo>(text);

            return _configuration;
        }




    }
}
