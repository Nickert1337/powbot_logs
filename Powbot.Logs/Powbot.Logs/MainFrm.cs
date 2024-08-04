using IniFileParser.Model;
using Powbot.Logs.Consumers;
using Powbot.Logs.Controls;
using Powbot.Logs.Extensions;
using SharpAdbClient;
using SharpAdbClient.DeviceCommands;

namespace Powbot.Logs
{
	public partial class MainFrm : Form
	{
		public AdbServer Server = new AdbServer();
		public AdbClient Client = new AdbClient();

		private DeviceData? _selectedDevice;

		private LogProcessor _logProcessor = new LogProcessor(Map.Strings.MessageRegex);

		private IniData _settings { get; set; }

		private List<DeviceData> _devices { get; set; }
		private List<LogConsumer> _deviceLogConsumers { get; set; } = new List<LogConsumer>();

		private const string OSRS_PACKAGE_NAME = "com.jagex.oldscape.android";
		private const string OSRS_ACTIVITY_NAME = "com.jagex.android.MainActivity";


		public MainFrm()
		{
			InitializeComponent();

			LoadSettingsIni();
			InitializeColorScheme();

			StartAdb();
		}

		private void LoadSettingsIni()
		{
			if (!File.Exists(Map.Strings.IniFileName))
			{
				return;
			}

			try
			{
				var parser = new IniFileParser.IniFileParser();
				_settings = parser.ReadFile(Map.Strings.IniFileName);
			}
			catch
			{
				MessageBox.Show($"Failed to read {Map.Strings.IniFileName}", "LoadSettingsIni failed",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void InitializeColorScheme()
		{
			if (_settings == null)
			{
				return;
			}

			var mode = _settings[Map.Ini.ColorSchemeSection][Map.Ini.ColorSchemeMode];
			if (string.IsNullOrEmpty(mode))
			{
				return;
			}

			switch (mode.ToLower())
			{
				case "dark":
					ChangeTheme(ColorScheme.Dark, Controls);
					break;
			}
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

			RefreshDeviceList();
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

		public void ChangeTheme(ColorScheme scheme, Control.ControlCollection container)
		{
			BackColor = scheme.PanelBackgroundColor;
			ForeColor = scheme.PanelForeColor;

			foreach (Control component in container)
			{
				switch (component)
				{
					case Panel:
						ChangeTheme(scheme, component.Controls);
						component.BackColor = scheme.PanelBackgroundColor;
						component.ForeColor = scheme.PanelForeColor;
						break;

					case Button:
						component.BackColor = scheme.ButtonBackgroundColor;
						component.ForeColor = scheme.ButtonForeColor;
						break;

					case TextBox:
					case RichTextBox:
					case ListBox:
						component.BackColor = scheme.TextboxBackgroundColor;
						component.ForeColor = scheme.TextboxForeColor;
						break;
				}
			}
		}

		private void OnClosed(object? sender, EventArgs e)
		{
			foreach (var consumer in _deviceLogConsumers)
			{
				consumer.StopAsync();
			}
		}

		private void installApkBttn_Click(object sender, EventArgs e)
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "APK files (*.apk)|*.apk|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 1;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}


				foreach (var device in _devices)
				{
					device.StopApp(Client, OSRS_PACKAGE_NAME);
					device.ClearCache(Client);
					device.ClearPowApk(Client);
					device.UnistallButKeepData(Client, OSRS_PACKAGE_NAME);
					using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
					{
						Client.Install(device, fileStream);
					}
				}
			}
		}

		private async void restartOsrsBttn_Click(object sender, EventArgs e)
		{
			foreach (var device in _devices)
			{
				device.StopApp(Client, OSRS_PACKAGE_NAME);
				device.StartApp(Client, $"{OSRS_PACKAGE_NAME}/{OSRS_ACTIVITY_NAME}");
			}
		}

		private void killOsrsBttn_Click(object sender, EventArgs e)
		{
			foreach (var device in _devices)
			{
				device.StopApp(Client, OSRS_PACKAGE_NAME);
			}
		}

		private void clearCacheBttn_Click(object sender, EventArgs e)
		{
			foreach (var device in _devices)
			{
				device.ClearCache(Client);
			}
		}
	}
}