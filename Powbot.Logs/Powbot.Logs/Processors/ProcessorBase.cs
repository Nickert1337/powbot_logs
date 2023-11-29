namespace Powbot.Logs.Processors;


public abstract class ProcessorBase : IProcessor
{
    private int _delay { get; set; }
    private Task _task { get; set; }
    private CancellationTokenSource _cts { get; set; }

    public ProcessorBase(int delay = 1000)
    {
        _delay = delay;
    }

    public virtual async Task StartAsync()
    {
        _cts = new CancellationTokenSource();
        _task = Task.Run(async () => await RunAsync());
        await Task.CompletedTask;
    }

    public virtual Task StopAsync()
    {
        _cts?.Cancel();
        return Task.CompletedTask;
    }
        
    protected abstract Task ProcessAsync();

    private async Task RunAsync()
    {
        while (!_cts.IsCancellationRequested)
        {
            try
            {
                await ProcessAsync();
            }
            catch (Exception)
            {
                // Do nothing, just exit the loop
            }

            await Task.Delay(_delay, _cts.Token);
        }
    }
}