using System;
using System.IO;
using GIT_Worker;

namespace Tim.AutoGit
{
    class Program
    {
        private static StreamWriter logFile;

        static void Main()
        {
            CreateLogFile();
            Log("Start Application---------------------------------");
            Configuration configuration = new Configuration();

            foreach (var item in configuration.Repos)
            {
                Log($"Start with {item}");
                
                GitBash gitBash = new GitBash(item);

                var result = gitBash.StageAllAndCommit();
                Log(result);
                Log($"End of {item}");
            }
            Log("Close Application---------------------------------");
            logFile.Close();
        }

        static void Log(string text)
        {
            Console.WriteLine(text);
            logFile.WriteLine($"{DateTime.Now} \t {text}");
        }

        static void CreateLogFile()
        {
            var fileName = Directory.GetCurrentDirectory() + @"/AutoGit.log";
            if (!File.Exists(fileName))
            {
                var file = File.Create(fileName);
                file.Close();
                logFile = new StreamWriter(fileName, true);
            }
            else
            {
                logFile = new StreamWriter(fileName, true);
            }
        }

    }
}
