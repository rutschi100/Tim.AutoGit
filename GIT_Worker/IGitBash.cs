namespace GIT_Worker
{
    public interface IGitBash
    {
        public string RepositoryPath { get; set; }

        /// <summary>
        ///     Applies all changes and executes a commit at the same time.
        ///     If no comment is given, the current date is selected.
        /// </summary>
        /// <param name="comment">Commit Comment</param>
        /// <returns>Console result</returns>
        string StageAllAndCommit(string comment = null);
    }
}