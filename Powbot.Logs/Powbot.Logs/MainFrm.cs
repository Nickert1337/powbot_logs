using Powbot.Logs.Consumers;
using Powbot.Logs.Controls;
using Powbot.Logs.Extensions;
using SharpAdbClient;

namespace Powbot.Logs
{
    public partial class MainFrm : Form
    {
        public AdbServer Server = new AdbServer();
        public AdbClient Client = new AdbClient();

        private DeviceData? _selectedDevice;

        private LogProcessor _logProcessor = new LogProcessor(Map.Strings.MESSAGE_REGEX);

        private List<DeviceData> _devices { get; set; }
        private List<LogConsumer> _deviceLogConsumers { get; set; } = new List<LogConsumer>();


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

            _selectedDevice = _devices
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
            _devices = Client.GetDevices();

            devicesList.Items.Clear();
            foreach (var device in _devices)
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
            //Continuously check for new devices and start streaming those
            if (streamToFileCheck.Checked)
            {
                foreach (var deviceData in _devices)
                {
                    if (_deviceLogConsumers.Any(dlc => dlc.Device.Equals(deviceData)))
                    {
                        continue;
                    }

                    var consumer = new LogConsumer(deviceData, Client);
                    consumer.StartAsync();
                    _deviceLogConsumers.Add(consumer);
                }
            }

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
                var logs = _selectedDevice.GetLogcatLogs(Client);
                if (logs == null)
                {
                    return;
                }

                _logProcessor.Process(logs);
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
                ScrollDown();
            }
        }

        private void ClearLogsBuffer()
        {
            if (_selectedDevice == null)
            {
                return;
            }

            try
            {
                _selectedDevice.ClearLogcatLogs(Client);
            }
            catch
            {
                //Ignore this error, usually happens if the connection is fucked (new instance started/adb crashed etc.)
            }
        }

        private void ScrollDown()
        {
            logsTxt.SelectionStart = logsTxt.Text.Length;
            logsTxt.ScrollToCaret();
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

        private void scrollDownBttn_Click(object sender, EventArgs e)
        {
            ScrollDown();
        }

        private void streamToFileCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (streamToFileCheck.Checked || !_deviceLogConsumers.Any())
            {
                return;
            }
            
            foreach (var consumer in _deviceLogConsumers)
            {
                consumer.StopAsync();
            }

            _deviceLogConsumers.Clear();
        }
    }
}