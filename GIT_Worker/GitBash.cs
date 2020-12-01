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
        /// Applies all changes and executes a commit at the same time.
        /// If no comment is given, the current date is selected.
        /// </summary>
        /// <param name="comment">Commit Comment</param>
        /// <returns>Console result</returns>
        public string StageAllAndCommit(string comment = null)
        {
            var result = StartRepoIfNOtExists();

            if (string.IsNullOrEmpty(comment))
            {
                string date = DateTime.Today.ToString();
                date = date.Substring(0, 10);
                result += "\n" + CMD.CommandOutput($"git add * && git commit -m {date}", repoPath);
                return result;
            }
            else
            {
                result += "\n" + CMD.CommandOutput(comment, repoPath);
                return result;
            }
        }

        private string StartRepoIfNOtExists()
        {
            if (! Directory.Exists(repoPath + @"\.git"))
            {
                return CMD.CommandOutput($"git init", repoPath);
            }
            return null;
        }


    }//---End of Class
}
