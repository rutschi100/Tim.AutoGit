using System;
using System.IO;
using CMDRunner;
using GIT_Worker;
using SimpleInjector;
using Tim.AutoGit.Config;

namespace Tim.AutoGit
{
    internal static class Program
    {
        private static StreamWriter _logFile;
        private static Container Container { get; } = new Container();

        private static void Main()
        {
            Init();

            CreateLogFile();
            Log("Start Application---------------------------------");
            var configuration = Container.GetInstance<IConfiguration>();

            foreach (var item in configuration.Repos)
            {
                Log($"Start with {item}");

                var gitBash = Container.GetInstance<IGitBash>();
                gitBash.RepositoryPath = item;


                var result = gitBash.StageAllAndCommit();
                Log(result);
                Log($"End of {item}");
            }

            Log("Close Application---------------------------------");
            _logFile.Close();
        }

        private static void Init()
        {
            Container.Register<IConfiguration, Configuration>(Lifestyle.Singleton);
            Container.Register<IGitBash, GitBash>(Lifestyle.Transient);
            Container.Register<ICMD, CMD>(Lifestyle.Singleton);
            Container.Verify();
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