namespace Powbot.Logs.Processors;

public interface IProcessor
{
    Task StartAsync();
    Task StopAsync();
}