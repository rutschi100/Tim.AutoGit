using System.Collections.Generic;

namespace Tim.AutoGit.Config
{
    internal interface IConfiguration
    {
        public List<string> Repos { get; set; }
    }
}