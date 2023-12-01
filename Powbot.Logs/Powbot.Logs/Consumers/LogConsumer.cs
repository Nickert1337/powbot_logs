using Powbot.Logs.Extensions;
using Powbot.Logs.Processors;
using SharpAdbClient;

namespace Powbot.Logs.Consumers;

public class LogConsumer : ProcessorBase
{
    public DeviceData Device { get; set; }
    private AdbClient _adbClient { get; set; }

    private LogProcessor _logProcessor { get; set; }

    public LogConsumer(DeviceData device, AdbClient adbClient)
    {
        Device = device;
        _adbClient = adbClient;
        _logProcessor = new LogProcessor(Map.Strings.MessageRegex);
    }

    private string ReplaceInvalidChars(string filename)
    {
        return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));    
    }
    
    private string GetLogsFilePath()
    {
        return Path.Combine(Map.Strings.LogsFolderName, string.Format(Map.Strings.LogsFileName, ReplaceInvalidChars(Device.Serial)));
    }
    
    protected override Task ProcessAsync()
    {
        var logs = Device.GetLogcatLogs(_adbClient);
        if (logs == null)
        {
            return Task.CompletedTask;
        }
                
        _logProcessor.Process(logs);
        var delta = _logProcessor.ConsumeDelta();
        if (string.IsNullOrEmpty(delta))
        {
            return Task.CompletedTask;
        }
        
        var logsPath = GetLogsFilePath();
        var directoryName = Path.GetDirectoryName(logsPath);
        if (directoryName == null)
        {
            return Task.CompletedTask;
        }
        
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        try
        {
            using var fs = new FileStream(logsPath, FileMode.Append);
            using var writer = new StreamWriter(fs);
            writer.Write(delta);
        }
        catch
        {
            //Could not access file, ignore for now
        }

        return Task.CompletedTask;
    }
}