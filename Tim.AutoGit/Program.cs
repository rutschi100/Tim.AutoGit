using System;
using System.IO;
using GIT_Worker;

namespace Tim.AutoGit
{
    internal static class Program
    {
        private static StreamWriter _logFile;

        private static void Main()
        {
            CreateLogFile();
            Log("Start Application---------------------------------");
            var configuration = new Configuration();

            foreach (var item in configuration.Repos)
            {
                Log($"Start with {item}");

                var gitBash = new GitBash(item);

                var result = gitBash.StageAllAndCommit();
                Log(result);
                Log($"End of {item}");
            }

            Log("Close Application---------------------------------");
            _logFile.Close();
        }

        private static void Log(string text)
        {
            Console.WriteLine(text);
            _logFile.WriteLine($"{DateTime.Now} \t {text}");
        }

        private static void CreateLogFile()
        {
            var fileName = Directory.GetCurrentDirectory() + @"/AutoGit.log";
            if (!File.Exists(fileName))
            {
                var file = File.Create(fileName);
                file.Close();
                _logFile = new StreamWriter(fileName, true);
            }
            else
            {
                _logFile = new StreamWriter(fileName, true);
            }
        }
    }
}