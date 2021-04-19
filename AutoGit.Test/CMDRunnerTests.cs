using CMDRunner;
using NUnit.Framework;
using SimpleInjector;

namespace AutoGit.Test
{
    public class CMDRunnerTests
    {
        private Container Container { get; set; }
        private ICMD CMD { get; set; }

        [SetUp]
        public void SetUp()
        {
            Container = new Container();
            Container.Register<ICMD, CMD>();
            Container.Verify();

            CMD = Container.GetInstance<ICMD>();
        }

        [Test]
        public void CommandOutputTest()
        {
            var result = CMD.CommandOutput("ping 127.0.0.1");
            Assert.True(result.Contains("Ping wird ausgeführt für 127.0.0.1 mit 32 Bytes Daten:"));
        }
    }
}