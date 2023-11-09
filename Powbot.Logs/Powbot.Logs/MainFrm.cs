using Powbot.Logs.Controls;
using SharpAdbClient;

namespace Powbot.Logs
{
    public partial class MainFrm : Form
    {
        public AdbServer Server = new AdbServer();
        public AdbClient Client = new AdbClient();

        private DeviceData? _selectedDevice;

        private LogProcessor _logProcessor = new LogProcessor("^(\\d+-\\d+ \\d+:\\d+:\\d+.\\d+)  \\d+  \\d+ (.*?)$");


        public MainFrm()
        {
            InitializeComponent();

            StartAdb();
        }

        public StartServerResult StartAdb()
        {
            var path = getPowAdbPath();
            return Server.StartServer(path, restartServerIfNewer: true);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Text = $"Powbot Logs - {Application.ProductVersion}";
            logsTxt.ReadOnly = true;
        }

        private void copyLogsBttn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_logProcessor.GetLogs());
        }

        private void refreshBttn_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void devicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDeviceSerial = devicesList?.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedDeviceSerial) || !selectedDeviceSerial.Contains(']'))
            {
                return;
            }

            selectedDeviceSerial = selectedDeviceSerial.Remove(0, selectedDeviceSerial.IndexOf(']') + 1);

            _selectedDevice = Client.GetDevices()
                .FirstOrDefault(device => device.Serial.Equals(selectedDeviceSerial));

            RefreshSelectedDevice();
        }

        private void timelineSlider_ValueChanged(object sender, EventArgs e)
        {

        }

        private string getPowAdbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".powbot\\android\\platform-tools\\adb.exe");
        }

        public void RefreshDeviceList()
        {
            devicesList.Items.Clear();
            foreach (var device in Client.GetDevices())
            {
                devicesList.Items.Add($"[{device.State}]{device.Serial}");
            }
        }

        public void RefreshSelectedDevice()
        {
            logsTxt.Clear();
            _logProcessor.Clear();

            if (_selectedDevice == null)
            {
                SetDeviceDetailsVisible(false);
                return;
            }

            SetDeviceDetailsVisible(true);
        }

        public void SetDeviceDetailsVisible(bool state)
        {
            mainPanel.Visible = state;
            logControlsPanel.Visible = state;
        }

        private void refreshLogsBttn_Click(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void autoRefreshCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uiTimer_Tick(object sender, EventArgs e)
        {
            if (!autoRefreshCheck.Checked)
            {
                return;
            }

            RefreshLogs();
        }

        private void RefreshLogs()
        {
            if (_selectedDevice == null)
            {
                return;
            }
            
            try
            {
                var cor = new ConsoleOutputReceiver();
                Client.ExecuteRemoteCommand(
                    "logcat -d ActivityManager:I com.jagex.oldscape.android/com.jagex.android.MainActivity",
                    _selectedDevice, cor);
                _logProcessor.Process(cor.ToString()!);
            }
            catch
            {
                //Ignore this error, usually happens if the connection is fucked (new instance started/adb crashed etc.)
                return;
            }

            var delta = _logProcessor.ConsumeDelta();
            if (string.IsNullOrEmpty(delta))
            {
                return;
            }

            logsTxt.AppendText(delta);

            if (autoScrollCheck.Checked)
            {
                logsTxt.SelectionStart = logsTxt.Text.Length;
                logsTxt.ScrollToCaret();
            }
        }

        private void ClearLogsBuffer()
        {
            try
            {
                Client.ExecuteRemoteCommand(
                    "logcat -c",
                    _selectedDevice, new ConsoleOutputReceiver());
            }
            catch
            {
                //Ignore this error, usually happens if the connection is fucked (new instance started/adb crashed etc.)
            }
        }
        
        private void autoScrollCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (autoScrollCheck.Checked)
            {
                logsTxt.SelectionStart = logsTxt.Text.Length;
                logsTxt.ScrollToCaret();
            }
        }

        private void clearBufferBttn_Click(object sender, EventArgs e)
        {
            logsTxt.Clear();
            _logProcessor.Clear();
            ClearLogsBuffer();
        }
    }
}