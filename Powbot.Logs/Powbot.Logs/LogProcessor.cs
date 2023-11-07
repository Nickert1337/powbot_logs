using System.Text;
using System.Text.RegularExpressions;

namespace Powbot.Logs;

public class LogProcessor
{
    private Regex _messageRegex;
    private string? _lastProcessedMessage;
    private List<Regex> _blacklistRegexes = new List<Regex>();

    private StringBuilder _log = new StringBuilder();
    private StringBuilder _lastDelta = new StringBuilder();
    
    public LogProcessor(string messageRegex)
    {
        _messageRegex = new Regex(messageRegex);
        
        LoadBlacklist();
    }

    private void LoadBlacklist()
    {
        const string blacklistFilePath = "blacklisted_lines.ini";
        if (!File.Exists(blacklistFilePath))
        {
            File.Create(blacklistFilePath);
            return;
        }

        try
        {
            var blacklistedLines = File.ReadAllLines(blacklistFilePath);
            foreach (var blacklistLine in blacklistedLines)
            {
                _blacklistRegexes.Add(new Regex(blacklistLine));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not load blacklist lines:\r\n{ex}", "LogProcessor load failure", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private int GetLastProcessedIndex(string[] lines)
    {
        for (var i = lines.Length - 1; i > 0; i--)
        {
            if (lines[i].Equals(_lastProcessedMessage))
            {
                return i;
            }
        }

        return 0;
    }
    
    public void Process(string logs)
    {
        if (string.IsNullOrEmpty(logs))
        {
            return;
        }

        var lines = logs.Split(Environment.NewLine,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (!lines.Any())
        {
            return;
        }

        var startingIndex = string.IsNullOrEmpty(_lastProcessedMessage) ? 0 : GetLastProcessedIndex(lines);

        for (var i = startingIndex; i < lines.Length; i++)
        {
            var line = lines[i];
            if (_blacklistRegexes.Any(r => r.IsMatch(line)))
            {
                continue;
            }
            
            _log.AppendLine(line);
            _lastDelta.AppendLine(line);
        }
        
        _lastProcessedMessage = lines.LastOrDefault();
    }

    public void Clear()
    {
        _log.Clear();
        _lastDelta.Clear();
        _lastProcessedMessage = default;
    }

    public string GetLogs()
    {
        return _log.ToString();
    }

    public string ConsumeDelta()
    {
        var delta = _lastDelta.ToString();
        _lastDelta.Clear();
        return delta;
    }
}