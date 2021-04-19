namespace CMDRunner
{
    public interface ICMD
    {
        /// <summary>
        ///     Führt ein Kommando auf dem CMD aus.
        /// </summary>
        /// <param name="command">Befehl</param>
        /// <param name="workingDirectory">Wo der Befehl ausgeführt werden soll</param>
        /// <returns>Konsole-Ergebnis</returns>
        string CommandOutput(string command,
            string workingDirectory = null);
    }
}