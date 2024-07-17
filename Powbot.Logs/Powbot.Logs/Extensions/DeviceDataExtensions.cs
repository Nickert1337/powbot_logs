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

    public static void StopApp(this DeviceData device, AdbClient adbClient, string applicationName)
    {
        adbClient.ExecuteRemoteCommand(
            $"am force-stop {applicationName}",
            device, new ConsoleOutputReceiver());
    }

    public static void StartApp(this DeviceData device, AdbClient adbClient, string applicationName)
    {
        adbClient.ExecuteRemoteCommand(
            $"am start -n {applicationName}",
            device, new ConsoleOutputReceiver());
    }
}