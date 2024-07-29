namespace Powbot.Logs
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			devicesList = new ListBox();
			refreshBttn = new Button();
			devicesPanel = new Panel();
			panel1 = new Panel();
			streamToFileCheck = new CheckBox();
			autoScrollCheck = new CheckBox();
			autoRefreshCheck = new CheckBox();
			clearBufferBttn = new Button();
			scrollDownBttn = new Button();
			copyLogsBttn = new Button();
			refreshLogsBttn = new Button();
			mainPanel = new Panel();
			logsTxt = new RichTextBox();
			logControlsPanel = new Panel();
			killOsrsBttn = new Button();
			restartOsrsBttn = new Button();
			installApkBttn = new Button();
			leftPanel = new Panel();
			uiTimer = new System.Windows.Forms.Timer(components);
			devicesPanel.SuspendLayout();
			panel1.SuspendLayout();
			mainPanel.SuspendLayout();
			logControlsPanel.SuspendLayout();
			leftPanel.SuspendLayout();
			SuspendLayout();
			// 
			// devicesList
			// 
			devicesList.BorderStyle = BorderStyle.None;
			devicesList.Dock = DockStyle.Top;
			devicesList.FormattingEnabled = true;
			devicesList.ItemHeight = 15;
			devicesList.Location = new Point(5, 28);
			devicesList.Name = "devicesList";
			devicesList.Size = new Size(195, 165);
			devicesList.TabIndex = 0;
			devicesList.SelectedIndexChanged += devicesList_SelectedIndexChanged;
			// 
			// refreshBttn
			// 
			refreshBttn.Dock = DockStyle.Top;
			refreshBttn.Location = new Point(5, 5);
			refreshBttn.Name = "refreshBttn";
			refreshBttn.Size = new Size(195, 23);
			refreshBttn.TabIndex = 1;
			refreshBttn.Text = "Refresh devices";
			refreshBttn.UseVisualStyleBackColor = true;
			refreshBttn.Click += refreshBttn_Click;
			// 
			// devicesPanel
			// 
			devicesPanel.Controls.Add(panel1);
			devicesPanel.Controls.Add(devicesList);
			devicesPanel.Controls.Add(refreshBttn);
			devicesPanel.Dock = DockStyle.Top;
			devicesPanel.Location = new Point(0, 0);
			devicesPanel.Name = "devicesPanel";
			devicesPanel.Padding = new Padding(5);
			devicesPanel.Size = new Size(205, 423);
			devicesPanel.TabIndex = 2;
			// 
			// panel1
			// 
			panel1.Controls.Add(streamToFileCheck);
			panel1.Controls.Add(autoScrollCheck);
			panel1.Controls.Add(autoRefreshCheck);
			panel1.Controls.Add(clearBufferBttn);
			panel1.Controls.Add(scrollDownBttn);
			panel1.Controls.Add(copyLogsBttn);
			panel1.Controls.Add(refreshLogsBttn);
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(5, 223);
			panel1.Name = "panel1";
			panel1.Size = new Size(195, 195);
			panel1.TabIndex = 2;
			// 
			// streamToFileCheck
			// 
			streamToFileCheck.AutoSize = true;
			streamToFileCheck.Dock = DockStyle.Top;
			streamToFileCheck.Location = new Point(0, 130);
			streamToFileCheck.MaximumSize = new Size(180, 0);
			streamToFileCheck.MinimumSize = new Size(0, 60);
			streamToFileCheck.Name = "streamToFileCheck";
			streamToFileCheck.Size = new Size(180, 60);
			streamToFileCheck.TabIndex = 6;
			streamToFileCheck.Text = "Automatically log all emulator logs to seperate files";
			streamToFileCheck.UseVisualStyleBackColor = true;
			streamToFileCheck.CheckedChanged += streamToFileCheck_CheckedChanged;
			// 
			// autoScrollCheck
			// 
			autoScrollCheck.AutoSize = true;
			autoScrollCheck.Dock = DockStyle.Top;
			autoScrollCheck.Location = new Point(0, 111);
			autoScrollCheck.Name = "autoScrollCheck";
			autoScrollCheck.Size = new Size(195, 19);
			autoScrollCheck.TabIndex = 4;
			autoScrollCheck.Text = "Automatically scroll down";
			autoScrollCheck.UseVisualStyleBackColor = true;
			autoScrollCheck.CheckedChanged += autoScrollCheck_CheckedChanged;
			// 
			// autoRefreshCheck
			// 
			autoRefreshCheck.AutoSize = true;
			autoRefreshCheck.Dock = DockStyle.Top;
			autoRefreshCheck.Location = new Point(0, 92);
			autoRefreshCheck.Name = "autoRefreshCheck";
			autoRefreshCheck.Size = new Size(195, 19);
			autoRefreshCheck.TabIndex = 2;
			autoRefreshCheck.Text = "Automatically refresh";
			autoRefreshCheck.UseVisualStyleBackColor = true;
			autoRefreshCheck.CheckedChanged += autoRefreshCheck_CheckedChanged;
			// 
			// clearBufferBttn
			// 
			clearBufferBttn.Dock = DockStyle.Top;
			clearBufferBttn.Location = new Point(0, 69);
			clearBufferBttn.Name = "clearBufferBttn";
			clearBufferBttn.Size = new Size(195, 23);
			clearBufferBttn.TabIndex = 5;
			clearBufferBttn.Text = "Clear buffer";
			clearBufferBttn.UseVisualStyleBackColor = true;
			clearBufferBttn.Click += clearBufferBttn_Click;
			// 
			// scrollDownBttn
			// 
			scrollDownBttn.Dock = DockStyle.Top;
			scrollDownBttn.Location = new Point(0, 46);
			scrollDownBttn.Name = "scrollDownBttn";
			scrollDownBttn.Size = new Size(195, 23);
			scrollDownBttn.TabIndex = 7;
			scrollDownBttn.Text = "Scroll down";
			scrollDownBttn.UseVisualStyleBackColor = true;
			scrollDownBttn.Click += scrollDownBttn_Click;
			// 
			// copyLogsBttn
			// 
			copyLogsBttn.Dock = DockStyle.Top;
			copyLogsBttn.Location = new Point(0, 23);
			copyLogsBttn.Name = "copyLogsBttn";
			copyLogsBttn.Size = new Size(195, 23);
			copyLogsBttn.TabIndex = 1;
			copyLogsBttn.Text = "Copy logs";
			copyLogsBttn.UseVisualStyleBackColor = true;
			copyLogsBttn.Click += copyLogsBttn_Click;
			// 
			// refreshLogsBttn
			// 
			refreshLogsBttn.Dock = DockStyle.Top;
			refreshLogsBttn.Location = new Point(0, 0);
			refreshLogsBttn.Name = "refreshLogsBttn";
			refreshLogsBttn.Size = new Size(195, 23);
			refreshLogsBttn.TabIndex = 3;
			refreshLogsBttn.Text = "Refresh logs";
			refreshLogsBttn.UseVisualStyleBackColor = true;
			refreshLogsBttn.Click += refreshLogsBttn_Click;
			// 
			// mainPanel
			// 
			mainPanel.Controls.Add(logsTxt);
			mainPanel.Dock = DockStyle.Right;
			mainPanel.Location = new Point(206, 0);
			mainPanel.Name = "mainPanel";
			mainPanel.Padding = new Padding(5);
			mainPanel.Size = new Size(1028, 629);
			mainPanel.TabIndex = 3;
			mainPanel.Visible = false;
			// 
			// logsTxt
			// 
			logsTxt.BorderStyle = BorderStyle.None;
			logsTxt.Dock = DockStyle.Fill;
			logsTxt.Location = new Point(5, 5);
			logsTxt.Name = "logsTxt";
			logsTxt.ScrollBars = RichTextBoxScrollBars.Vertical;
			logsTxt.Size = new Size(1018, 619);
			logsTxt.TabIndex = 1;
			logsTxt.Text = "";
			// 
			// logControlsPanel
			// 
			logControlsPanel.Controls.Add(killOsrsBttn);
			logControlsPanel.Controls.Add(restartOsrsBttn);
			logControlsPanel.Controls.Add(installApkBttn);
			logControlsPanel.Dock = DockStyle.Bottom;
			logControlsPanel.Location = new Point(0, 550);
			logControlsPanel.Name = "logControlsPanel";
			logControlsPanel.Padding = new Padding(5);
			logControlsPanel.Size = new Size(205, 79);
			logControlsPanel.TabIndex = 4;
			logControlsPanel.Visible = false;
			// 
			// killOsrsBttn
			// 
			killOsrsBttn.Dock = DockStyle.Bottom;
			killOsrsBttn.Location = new Point(5, 5);
			killOsrsBttn.Name = "killOsrsBttn";
			killOsrsBttn.Size = new Size(195, 23);
			killOsrsBttn.TabIndex = 10;
			killOsrsBttn.Text = "Mass kill OSRS";
			killOsrsBttn.UseVisualStyleBackColor = true;
			killOsrsBttn.Click += killOsrsBttn_Click;
			// 
			// restartOsrsBttn
			// 
			restartOsrsBttn.Dock = DockStyle.Bottom;
			restartOsrsBttn.Location = new Point(5, 28);
			restartOsrsBttn.Name = "restartOsrsBttn";
			restartOsrsBttn.Size = new Size(195, 23);
			restartOsrsBttn.TabIndex = 9;
			restartOsrsBttn.Text = "Mass (re)start OSRS";
			restartOsrsBttn.UseVisualStyleBackColor = true;
			restartOsrsBttn.Click += restartOsrsBttn_Click;
			// 
			// installApkBttn
			// 
			installApkBttn.Dock = DockStyle.Bottom;
			installApkBttn.Location = new Point(5, 51);
			installApkBttn.Name = "installApkBttn";
			installApkBttn.Size = new Size(195, 23);
			installApkBttn.TabIndex = 8;
			installApkBttn.Text = "Mass install APK";
			installApkBttn.UseVisualStyleBackColor = true;
			installApkBttn.Click += installApkBttn_Click;
			// 
			// leftPanel
			// 
			leftPanel.Controls.Add(devicesPanel);
			leftPanel.Controls.Add(logControlsPanel);
			leftPanel.Dock = DockStyle.Left;
			leftPanel.Location = new Point(0, 0);
			leftPanel.Name = "leftPanel";
			leftPanel.Size = new Size(205, 629);
			leftPanel.TabIndex = 4;
			// 
			// uiTimer
			// 
			uiTimer.Enabled = true;
			uiTimer.Interval = 250;
			uiTimer.Tick += uiTimer_Tick;
			// 
			// MainFrm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1234, 629);
			Controls.Add(leftPanel);
			Controls.Add(mainPanel);
			Name = "MainFrm";
			Text = "Powbot logs terminal";
			Closed += OnClosed;
			Load += MainFrm_Load;
			devicesPanel.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			mainPanel.ResumeLayout(false);
			logControlsPanel.ResumeLayout(false);
			leftPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private ListBox devicesList;
        private Button refreshBttn;
        private Panel devicesPanel;
        private Panel mainPanel;
        private RichTextBox logsTxt;
        private Panel logControlsPanel;
        private Button copyLogsBttn;
        private CheckBox autoRefreshCheck;
        private Button refreshLogsBttn;
        private Panel leftPanel;
        private System.Windows.Forms.Timer uiTimer;
        private CheckBox autoScrollCheck;
        private Button clearBufferBttn;
        private Button scrollDownBttn;
        private CheckBox streamToFileCheck;
        private Button restartOsrsBttn;
        private Button installApkBttn;
        private Button killOsrsBttn;
		private Panel panel1;
	}
}