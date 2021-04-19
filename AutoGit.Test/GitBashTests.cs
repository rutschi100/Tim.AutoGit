using System.IO;
using CMDRunner;
using GIT_Worker;
using NUnit.Framework;
using SimpleInjector;

namespace AutoGit.Test
{
    public class GitBashTests
    {
        public const string TestFolderPath = @"UnitTestFolder";
        public Container Container { get; set; }
        public IGitBash GitBash { get; set; }

        [SetUp]
        public void SetUp()
        {
            Container = new Container();
            Container.Register<ICMD, CMD>(Lifestyle.Singleton);
            Container.Register<IGitBash, GitBash>(Lifestyle.Transient);
            Container.Verify();

            GitBash = Container.GetInstance<IGitBash>();
        }

        [SetUp]
        public void CreateNewTestFolder()
        {
            if (Directory.Exists(TestFolderPath))
            {
                Directory.Delete(TestFolderPath, true);
            }

            Directory.CreateDirectory(TestFolderPath);
            GitBash.RepositoryPath = TestFolderPath;
        }

        [Test]
        public void StageAllAndCommitTest_Initalition()
        {
            var result = GitBash.StageAllAndCommit();
            Assert.True(result.Contains("Initialized empty Git repository in"));
        }
    }
}