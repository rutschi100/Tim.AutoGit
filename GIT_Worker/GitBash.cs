using System;
using System.Globalization;
using System.IO;
using CMDRunner;

namespace GIT_Worker
{
    public class GitBash : IGitBash
    {
        public GitBash(ICMD cmd)
        {
            CMD = cmd;
        }

        private ICMD CMD { get; }
        public string RepositoryPath { get; set; }

        /// <summary>
        ///     Applies all changes and executes a commit at the same time.
        ///     If no comment is given, the current date is selected.
        /// </summary>
        /// <param name="comment">Commit Comment</param>
        /// <returns>Console result</returns>
        public string StageAllAndCommit(string comment = null)
        {
            if (!Directory.Exists(RepositoryPath))
            {
                throw new Exception($"Pfad existiert nicht: {RepositoryPath}");
            }

            var result = StartRepoIfNOtExists();

            if (string.IsNullOrEmpty(comment))
            {
                var date = DateTime.Today.ToString(CultureInfo.InvariantCulture);
                date = date[..10];
                result += "\n" + CMD.CommandOutput($"git add * && git commit -m {date}", RepositoryPath);
                return result;
            }

            result += "\n" + CMD.CommandOutput(comment, RepositoryPath);
            return result;
        }

        private string StartRepoIfNOtExists()
        {
            if (Directory.Exists(RepositoryPath + @"\.git")) return null;
            return CMD.CommandOutput("git init", RepositoryPath);
        }
    } //---End of Class
}