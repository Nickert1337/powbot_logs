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
            mainPanel = new Panel();
            logsTxt = new RichTextBox();
            logControlsPanel = new Panel();
            killOsrsBttn = new Button();
            restartOsrsBttn = new Button();
            installApkBttn = new Button();
            streamToFileCheck = new CheckBox();
            scrollDownBttn = new Button();
            clearBufferBttn = new Button();
            autoScrollCheck = new CheckBox();
            autoRefreshCheck = new CheckBox();
            refreshLogsBttn = new Button();
            copyLogsBttn = new Button();
            leftPanel = new Panel();
            uiTimer = new System.Windows.Forms.Timer(components);
            devicesPanel.SuspendLayout();
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
            devicesList.Location = new Point(5, 5);
            devicesList.Name = "devicesList";
            devicesList.Size = new Size(195, 240);
            devicesList.TabIndex = 0;
            devicesList.SelectedIndexChanged += devicesList_SelectedIndexChanged;
            // 
            // refreshBttn
            // 
            refreshBttn.Dock = DockStyle.Bottom;
            refreshBttn.Location = new Point(5, 251);
            refreshBttn.Name = "refreshBttn";
            refreshBttn.Size = new Size(195, 23);
            refreshBttn.TabIndex = 1;
            refreshBttn.Text = "Refresh devices";
            refreshBttn.UseVisualStyleBackColor = true;
            refreshBttn.Click += refreshBttn_Click;
            // 
            // devicesPanel
            // 
            devicesPanel.Controls.Add(devicesList);
            devicesPanel.Controls.Add(refreshBttn);
            devicesPanel.Dock = DockStyle.Top;
            devicesPanel.Location = new Point(0, 0);
            devicesPanel.Name = "devicesPanel";
            devicesPanel.Padding = new Padding(5);
            devicesPanel.Size = new Size(205, 279);
            devicesPanel.TabIndex = 2;
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
            logControlsPanel.Controls.Add(streamToFileCheck);
            logControlsPanel.Controls.Add(scrollDownBttn);
            logControlsPanel.Controls.Add(clearBufferBttn);
            logControlsPanel.Controls.Add(autoScrollCheck);
            logControlsPanel.Controls.Add(autoRefreshCheck);
            logControlsPanel.Controls.Add(refreshLogsBttn);
            logControlsPanel.Controls.Add(copyLogsBttn);
            logControlsPanel.Dock = DockStyle.Bottom;
            logControlsPanel.Location = new Point(0, 280);
            logControlsPanel.Name = "logControlsPanel";
            logControlsPanel.Padding = new Padding(5);
            logControlsPanel.Size = new Size(205, 349);
            logControlsPanel.TabIndex = 4;
            logControlsPanel.Visible = false;
            // 
            // killOsrsBttn
            // 
            killOsrsBttn.Location = new Point(5, 287);
            killOsrsBttn.Name = "killOsrsBttn";
            killOsrsBttn.Size = new Size(195, 23);
            killOsrsBttn.TabIndex = 10;
            killOsrsBttn.Text = "Mass kill OSRS";
            killOsrsBttn.UseVisualStyleBackColor = true;
            killOsrsBttn.Click += killOsrsBttn_Click;
            // 
            // restartOsrsBttn
            // 
            restartOsrsBttn.Location = new Point(5, 316);
            restartOsrsBttn.Name = "restartOsrsBttn";
            restartOsrsBttn.Size = new Size(195, 23);
            restartOsrsBttn.TabIndex = 9;
            restartOsrsBttn.Text = "Mass (re)start OSRS";
            restartOsrsBttn.UseVisualStyleBackColor = true;
            restartOsrsBttn.Click += restartOsrsBttn_Click;
            // 
            // installApkBttn
            // 
            installApkBttn.Location = new Point(5, 258);
            installApkBttn.Name = "installApkBttn";
            installApkBttn.Size = new Size(195, 23);
            installApkBttn.TabIndex = 8;
            installApkBttn.Text = "Mass install APK";
            installApkBttn.UseVisualStyleBackColor = true;
            installApkBttn.Click += installApkBttn_Click;
            // 
            // streamToFileCheck
            // 
            streamToFileCheck.AutoSize = true;
            streamToFileCheck.Location = new Point(5, 113);
            streamToFileCheck.Name = "streamToFileCheck";
            streamToFileCheck.Size = new Size(197, 19);
            streamToFileCheck.TabIndex = 7;
            streamToFileCheck.Text = "Automatically stream logs to file";
            streamToFileCheck.UseVisualStyleBackColor = true;
            streamToFileCheck.CheckedChanged += streamToFileCheck_CheckedChanged;
            // 
            // scrollDownBttn
            // 
            scrollDownBttn.Location = new Point(106, 34);
            scrollDownBttn.Name = "scrollDownBttn";
            scrollDownBttn.Size = new Size(94, 23);
            scrollDownBttn.TabIndex = 6;
            scrollDownBttn.Text = "Scroll down";
            scrollDownBttn.UseVisualStyleBackColor = true;
            scrollDownBttn.Click += scrollDownBttn_Click;
            // 
            // clearBufferBttn
            // 
            clearBufferBttn.Location = new Point(5, 34);
            clearBufferBttn.Name = "clearBufferBttn";
            clearBufferBttn.Size = new Size(94, 23);
            clearBufferBttn.TabIndex = 5;
            clearBufferBttn.Text = "Clear buffer";
            clearBufferBttn.UseVisualStyleBackColor = true;
            clearBufferBttn.Click += clearBufferBttn_Click;
            // 
            // autoScrollCheck
            // 
            autoScrollCheck.AutoSize = true;
            autoScrollCheck.Location = new Point(5, 88);
            autoScrollCheck.Name = "autoScrollCheck";
            autoScrollCheck.Size = new Size(164, 19);
            autoScrollCheck.TabIndex = 4;
            autoScrollCheck.Text = "Automatically scroll down";
            autoScrollCheck.UseVisualStyleBackColor = true;
            autoScrollCheck.CheckedChanged += autoScrollCheck_CheckedChanged;
            // 
            // autoRefreshCheck
            // 
            autoRefreshCheck.AutoSize = true;
            autoRefreshCheck.Location = new Point(5, 63);
            autoRefreshCheck.Name = "autoRefreshCheck";
            autoRefreshCheck.Size = new Size(139, 19);
            autoRefreshCheck.TabIndex = 2;
            autoRefreshCheck.Text = "Automatically refresh";
            autoRefreshCheck.UseVisualStyleBackColor = true;
            autoRefreshCheck.CheckedChanged += autoRefreshCheck_CheckedChanged;
            // 
            // refreshLogsBttn
            // 
            refreshLogsBttn.Location = new Point(106, 5);
            refreshLogsBttn.Name = "refreshLogsBttn";
            refreshLogsBttn.Size = new Size(94, 23);
            refreshLogsBttn.TabIndex = 3;
            refreshLogsBttn.Text = "Refresh logs";
            refreshLogsBttn.UseVisualStyleBackColor = true;
            refreshLogsBttn.Click += refreshLogsBttn_Click;
            // 
            // copyLogsBttn
            // 
            copyLogsBttn.Location = new Point(5, 5);
            copyLogsBttn.Name = "copyLogsBttn";
            copyLogsBttn.Size = new Size(94, 23);
            copyLogsBttn.TabIndex = 1;
            copyLogsBttn.Text = "Copy logs";
            copyLogsBttn.UseVisualStyleBackColor = true;
            copyLogsBttn.Click += copyLogsBttn_Click;
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
            mainPanel.ResumeLayout(false);
            logControlsPanel.ResumeLayout(false);
            logControlsPanel.PerformLayout();
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
    }
}