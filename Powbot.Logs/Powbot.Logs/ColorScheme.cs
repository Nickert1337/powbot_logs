namespace Powbot.Logs;

public class ColorScheme
{
    public Color PanelBackgroundColor { get; set; }
    public Color PanelForeColor { get; set; }

    public Color ButtonBackgroundColor { get; set; }
    public Color ButtonForeColor { get; set; }

    public Color TextboxBackgroundColor { get; set; }
    public Color TextboxForeColor { get; set; }


    public static ColorScheme Dark =>
        new()
        {
            PanelBackgroundColor = Color.FromArgb(32, 32, 32),
            PanelForeColor = Color.White,
            ButtonBackgroundColor = Color.FromArgb(64, 64, 64),
            ButtonForeColor = Color.White,
            TextboxBackgroundColor = Color.FromArgb(48, 48, 48),
            TextboxForeColor = Color.White
        };
}