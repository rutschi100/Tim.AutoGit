using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tim.AutoGit
{
    public class Configuration
    {
        public List<string> Repos { get; set; } = new List<string>();
        public Configuration()
        {
            var configRoot = ConfigHelper.GetConfiguration();

            var repos = configRoot.GetSection("Repos").GetChildren();

            foreach (var item in repos)
            {
                Repos.Add(item.Value);
            }
        }



        private class ConfigHelper
        {
            private static readonly string CONFIGURATION_FILE = "jsconfig.json";

            public static IConfigurationRoot GetConfiguration()
            {
                var root = default(IConfigurationRoot);

                var configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), CONFIGURATION_FILE));
                root = configurationBuilder.Build();

                return root;
            }
        }
    }
}
