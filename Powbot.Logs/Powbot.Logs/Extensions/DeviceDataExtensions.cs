using SharpAdbClient;
using SharpAdbClient.DeviceCommands;

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

	public static void ClearCache(this DeviceData device, AdbClient adbClient)
	{
		adbClient.ExecuteRemoteCommand(
			$"pm trim-caches 999G",
			device, new ConsoleOutputReceiver());
	}

    public static void ClearPowApk(this DeviceData device, AdbClient adbClient)
    {
        adbClient.ExecuteRemoteCommand(
            $"find /sdcard/Android/data/com.jagex.oldscape.android -type f -name '*.apk' -exec rm {{}} \\;",
            device, new ConsoleOutputReceiver());
    }
    
    public static void UnistallButKeepData(this DeviceData device, AdbClient adbClient, string applicationName)
    {
        adbClient.ExecuteRemoteCommand($"pm uninstall -k {applicationName}", device, new ConsoleOutputReceiver());
    }
}