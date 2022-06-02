using Common;
using StackExchange.Redis;

ConsoleMenuHelper.Builder consoleMenuBuilder = new ConsoleMenuHelper.Builder();
FileHelper helper = new FileHelper();

var targetDirectory = @"D:\temp";

Console.WriteLine($"Select one of the following files for processing \nWe display files inside [{targetDirectory}] directory [Move between files with arrow keys]");
var allAvalibleXlsxFlie = helper.GetAvalibleFiles(targetDirectory, "xlsx");
var consoleHelper = consoleMenuBuilder
    .AddX(0)
    .AddY(2)
    .AddOptionPerLine(1)
    .AddSpacingPerLine(10)
    .AddOptions(allAvalibleXlsxFlie.ToArray())
    .ToConsoleMenueHelper();

var selectedFileDirectory = consoleHelper.MultipleChoice(true);
string connectionString = "127.0.0.1:6379";

using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString))
{
    ISubscriber sub = redis.GetSubscriber();
    helper.ReadExcle(selectedFileDirectory, (value) =>
    {
        if (value is not null)
            sub.Publish("data", value);
    });

}

Console.ReadKey();






