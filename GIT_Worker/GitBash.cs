using System;
using System.Globalization;
using System.IO;
using CMDRunner;

namespace GIT_Worker
{
    public class GitBash
    {
        private readonly string _repoPath;

        public GitBash(string repoPath)
        {
            this._repoPath = repoPath;
        }

        /// <summary>
        ///     Applies all changes and executes a commit at the same time.
        ///     If no comment is given, the current date is selected.
        /// </summary>
        /// <param name="comment">Commit Comment</param>
        /// <returns>Console result</returns>
        public string StageAllAndCommit(string comment = null)
        {
            var result = StartRepoIfNOtExists();

            if (string.IsNullOrEmpty(comment))
            {
                var date = DateTime.Today.ToString(CultureInfo.InvariantCulture);
                date = date.Substring(0, 10);
                result += "\n" + CMD.CommandOutput($"git add * && git commit -m {date}", _repoPath);
                return result;
            }

            result += "\n" + CMD.CommandOutput(comment, _repoPath);
            return result;
        }

        private string StartRepoIfNOtExists()
        {
            if (!Directory.Exists(_repoPath + @"\.git"))
            {
                return CMD.CommandOutput("git init", _repoPath);
            }

            return null;
        }
    } //---End of Class
}