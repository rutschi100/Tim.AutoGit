using System;
using GIT_Worker;

namespace Tim.AutoGit
{
    class Program
    {
        static void Main()
        {
            Configuration configuration = new Configuration();

            foreach (var item in configuration.Repos)
            {
                GitBash gitBash = new GitBash(item);

                gitBash.StageAllAndCommit();
            }

        }
    }
}
