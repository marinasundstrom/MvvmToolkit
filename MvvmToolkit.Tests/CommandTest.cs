using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xunit;

namespace MvvmToolkit.Tests
{
    public class CommandTest
    {
        [Fact(DisplayName = "Is executed")]
        public async Task IsExecuted()
        {
            bool executed = false;

            var command = new Command(() =>
            {
                executed = true;
            });

            await command.Execute();

            Assert.True(executed);
        }

        [Fact(DisplayName = "Async action is executed on calling thread")]
        public void IsExecutedOnCallingThread()
        {
            bool executed = false;

            Thread mainThread = Thread.CurrentThread;
            Thread commandThread = null;

            var command = new Command(() =>
            {
                commandThread = Thread.CurrentThread;
                executed = true;
            });

            (command as ICommand).Execute(null);

            Assert.True(executed);
            Assert.Equal(mainThread, commandThread);

            executed = false;

            command.Execute();

            Assert.True(executed);
            Assert.Equal(mainThread, commandThread);
        }
    }
}
