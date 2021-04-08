using System;
using System.Collections.Generic;
using System.Text;

namespace Tim.AutoGit.Config
{
    interface IConfiguration
    {
        public List<string> Repos { get; set; }
    }
}
