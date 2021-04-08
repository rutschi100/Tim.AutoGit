using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Tim.AutoGit
{
    public class Configuration
    {
        public Configuration()
        {
            var configRoot = ConfigHelper.GetConfiguration();

            var repos = configRoot.GetSection("Repos").GetChildren();

            foreach (var item in repos)
            {
                Repos.Add(item.Value);
            }
        }

        public List<string> Repos { get; set; } = new List<string>();


        private class ConfigHelper
        {
            private const string CONFIGURATION_FILE = "jsconfig.json";

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