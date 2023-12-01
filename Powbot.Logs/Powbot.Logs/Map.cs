namespace Powbot.Logs;

public class Map
{
    public class Strings
    {
        public const string MessageRegex = "^(\\d+-\\d+ \\d+:\\d+:\\d+.\\d+)  \\d+  \\d+ (.*?)$";
        public const string LogsFolderName = "logs";
        public const string LogsFileName = "{0}_logs.txt";
        public const string IniFileName = "settings.ini";
    }

    public class Ini
    {
        public const string ColorSchemeSection = "ColorScheme";
        public const string ColorSchemeMode = "Mode";
    }
}