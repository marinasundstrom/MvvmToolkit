using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using Xunit;

namespace MvvmToolkit.Tests;

public class CommandGenericTest
{
    [Fact(DisplayName = "Is executed")]
    public async Task IsExecuted()
    {
        int result = -1;

        var command = new Command<int>((value) =>
        {
            result = value;
        });

        (command as ICommand).Execute(42);

        Assert.Equal(42, result);

        result = -1;

        await command.Execute(42);

        Assert.Equal(42, result);
    }

    [Fact(DisplayName = "Async action is executed on calling thread")]
    public void IsExecutedOnCallingThread()
    {
        int result = -1;

        Thread mainThread = Thread.CurrentThread;
        Thread commandThread = null;
        var command = new Command<int>((value) =>
        {
            commandThread = Thread.CurrentThread;
            result = value;
        });

        (command as ICommand).Execute(42);

        Assert.Equal(42, result);
        Assert.Equal(mainThread, commandThread);

        result = -1;

        command.Execute(42);

        Assert.Equal(42, result);
        Assert.Equal(mainThread, commandThread);
    }
}
