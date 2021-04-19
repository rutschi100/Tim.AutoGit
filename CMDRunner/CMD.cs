using System;
using System.Diagnostics;
using System.Text;

namespace CMDRunner
{
    public class CMD : ICMD
    {
        /// <summary>
        ///     Führt ein Kommando auf dem CMD aus.
        /// </summary>
        /// <param name="command">Befehl</param>
        /// <param name="workingDirectory">Wo der Befehl ausgeführt werden soll</param>
        /// <returns>Konsole-Ergebnis</returns>
        public string CommandOutput(string command,
            string workingDirectory = null)
        {
            try
            {
                var procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardError =
                    procStartInfo.RedirectStandardInput = procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                if (null != workingDirectory)
                {
                    procStartInfo.WorkingDirectory = workingDirectory;
                }

                var proc = new Process
                {
                    StartInfo = procStartInfo
                };
                proc.Start();

                var sb = new StringBuilder();
                proc.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e) { sb.AppendLine(e.Data); };
                proc.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e) { sb.AppendLine(e.Data); };

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
                return sb.ToString();
            }
            catch (Exception objException)
            {
                return $"Error in command: {command}, {objException.Message}";
            }
        }
    }
}