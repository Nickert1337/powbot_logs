using SharpAdbClient;

namespace Powbot.Logs.Extensions;

public static class DeviceDataExtensions
{
    public static string? GetLogcatLogs(this DeviceData device, AdbClient adbClient)
    {
        var cor = new ConsoleOutputReceiver();
        adbClient.ExecuteRemoteCommand(
            "logcat -d ActivityManager:I com.jagex.oldscape.android/com.jagex.android.MainActivity",
            device, cor);
        return cor.ToString();
    }
    
    public static void ClearLogcatLogs(this DeviceData device, AdbClient adbClient)
    {
        adbClient.ExecuteRemoteCommand(
            "logcat -c",
            device, new ConsoleOutputReceiver());
    }
}