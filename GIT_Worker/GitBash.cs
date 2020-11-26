using CMDRunner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GIT_Worker
{
    public class GitBash
    {
        private readonly string repoPath;

        public GitBash(string repoPath)
        {
            this.repoPath = repoPath;
        }

        /// <summary>
        /// Übernimmt alle Änderungen und führt zugleich ein Commit aus.
        /// Falls kein Kommentar angegeben wird, so wird das aktuelle Datum gewählt.
        /// </summary>
        /// <param name="comment">Commit-Kommentar</param>
        /// <returns>Konsole-Ergebnis</returns>
        public string StageAllAndCommit(string comment = null)
        {
            StartRepoIfNOtExists();

            if (string.IsNullOrEmpty(comment))
            {
                string date = DateTime.Today.ToString();
                date = date.Substring(0, 10);
                return CMD.CommandOutput($"git add * && git commit -m {date}", repoPath);
            }
            else
            {
                return CMD.CommandOutput(comment, repoPath);
            }
        }

        private void StartRepoIfNOtExists()
        {
            if (! Directory.Exists(repoPath + @"\.git"))
            {
                Console.WriteLine(CMD.CommandOutput($"git init", repoPath));
            }
        }


    }//---End of Class
}
