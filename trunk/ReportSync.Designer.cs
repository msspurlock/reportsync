namespace ReportSync
{
    partial class ReportSync
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSync));
            this.btnSourceLoad = new System.Windows.Forms.Button();
            this.rptSourceTree = new System.Windows.Forms.TreeView();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dlgDest = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDest = new System.Windows.Forms.Button();
            this.btnDestLoad = new System.Windows.Forms.Button();
            this.rptDestTree = new System.Windows.Forms.TreeView();
            this.btnSync = new System.Windows.Forms.Button();
            this.lblDestPass = new System.Windows.Forms.Label();
            this.lblDestUser = new System.Windows.Forms.Label();
            this.lblDestUrl = new System.Windows.Forms.Label();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.pbSource = new System.Windows.Forms.ProgressBar();
            this.chkSaveSource = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSrcUrl = new System.Windows.Forms.Label();
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.txtSourceUser = new System.Windows.Forms.TextBox();
            this.txtSourcePassword = new System.Windows.Forms.TextBox();
            this.grpDest = new System.Windows.Forms.GroupBox();
            this.pbDest = new System.Windows.Forms.ProgressBar();
            this.chkSaveDest = new System.Windows.Forms.CheckBox();
            this.txtDestUrl = new System.Windows.Forms.TextBox();
            this.txtDestUser = new System.Windows.Forms.TextBox();
            this.txtDestPassword = new System.Windows.Forms.TextBox();
            this.lblDest = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.bwUpload = new System.ComponentModel.BackgroundWorker();
            this.bwSync = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpSource.SuspendLayout();
            this.grpDest.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSourceLoad
            // 
            this.btnSourceLoad.Location = new System.Drawing.Point(173, 55);
            this.btnSourceLoad.Name = "btnSourceLoad";
            this.btnSourceLoad.Size = new System.Drawing.Size(55, 20);
            this.btnSourceLoad.TabIndex = 4;
            this.btnSourceLoad.Text = "Load";
            this.btnSourceLoad.UseVisualStyleBackColor = true;
            this.btnSourceLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // rptSourceTree
            // 
            this.rptSourceTree.CheckBoxes = true;
            this.rptSourceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptSourceTree.Location = new System.Drawing.Point(3, 101);
            this.rptSourceTree.Name = "rptSourceTree";
            this.rptSourceTree.Size = new System.Drawing.Size(232, 355);
            this.rptSourceTree.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(307, 6);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(65, 21);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDest
            // 
            this.btnDest.Location = new System.Drawing.Point(274, 6);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(24, 21);
            this.btnDest.TabIndex = 6;
            this.btnDest.Text = "...";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // btnDestLoad
            // 
            this.btnDestLoad.Location = new System.Drawing.Point(170, 55);
            this.btnDestLoad.Name = "btnDestLoad";
            this.btnDestLoad.Size = new System.Drawing.Size(57, 20);
            this.btnDestLoad.TabIndex = 11;
            this.btnDestLoad.Text = "Load";
            this.btnDestLoad.UseVisualStyleBackColor = true;
            this.btnDestLoad.Click += new System.EventHandler(this.btnDestLoad_Click);
            // 
            // rptDestTree
            // 
            this.rptDestTree.CheckBoxes = true;
            this.rptDestTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptDestTree.Location = new System.Drawing.Point(3, 101);
            this.rptDestTree.Name = "rptDestTree";
            this.rptDestTree.Size = new System.Drawing.Size(232, 355);
            this.rptDestTree.TabIndex = 13;
            this.rptDestTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.rptDestTree_NodeMouseClick);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(439, 6);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(41, 21);
            this.btnSync.TabIndex = 13;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lblDestPass
            // 
            this.lblDestPass.AutoSize = true;
            this.lblDestPass.Location = new System.Drawing.Point(3, 59);
            this.lblDestPass.Name = "lblDestPass";
            this.lblDestPass.Size = new System.Drawing.Size(53, 13);
            this.lblDestPass.TabIndex = 16;
            this.lblDestPass.Text = "Password";
            // 
            // lblDestUser
            // 
            this.lblDestUser.AutoSize = true;
            this.lblDestUser.Location = new System.Drawing.Point(3, 33);
            this.lblDestUser.Name = "lblDestUser";
            this.lblDestUser.Size = new System.Drawing.Size(29, 13);
            this.lblDestUser.TabIndex = 17;
            this.lblDestUser.Text = "User";
            // 
            // lblDestUrl
            // 
            this.lblDestUrl.AutoSize = true;
            this.lblDestUrl.Location = new System.Drawing.Point(3, 7);
            this.lblDestUrl.Name = "lblDestUrl";
            this.lblDestUrl.Size = new System.Drawing.Size(20, 13);
            this.lblDestUrl.TabIndex = 18;
            this.lblDestUrl.Text = "Url";
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.rptSourceTree);
            this.grpSource.Controls.Add(this.panel2);
            this.grpSource.Controls.Add(this.pbSource);
            this.grpSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSource.Location = new System.Drawing.Point(0, 0);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(238, 482);
            this.grpSource.TabIndex = 19;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source SSRS web service";
            // 
            // pbSource
            // 
            this.pbSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbSource.Location = new System.Drawing.Point(3, 456);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(232, 23);
            this.pbSource.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSource.TabIndex = 22;
            // 
            // chkSaveSource
            // 
            this.chkSaveSource.AutoSize = true;
            this.chkSaveSource.Checked = true;
            this.chkSaveSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveSource.Location = new System.Drawing.Point(174, 32);
            this.chkSaveSource.Name = "chkSaveSource";
            this.chkSaveSource.Size = new System.Drawing.Size(51, 17);
            this.chkSaveSource.TabIndex = 22;
            this.chkSaveSource.Text = "Save";
            this.chkSaveSource.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "User";
            // 
            // lblSrcUrl
            // 
            this.lblSrcUrl.AutoSize = true;
            this.lblSrcUrl.Location = new System.Drawing.Point(6, 7);
            this.lblSrcUrl.Name = "lblSrcUrl";
            this.lblSrcUrl.Size = new System.Drawing.Size(20, 13);
            this.lblSrcUrl.TabIndex = 19;
            this.lblSrcUrl.Text = "Url";
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceUrl.Location = new System.Drawing.Point(35, 4);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(193, 20);
            this.txtSourceUrl.TabIndex = 1;
            this.txtSourceUrl.Text = global::ReportSync.Properties.Settings.Default.SourceUrl;
            // 
            // txtSourceUser
            // 
            this.txtSourceUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceUser.Location = new System.Drawing.Point(67, 29);
            this.txtSourceUser.Name = "txtSourceUser";
            this.txtSourceUser.Size = new System.Drawing.Size(100, 20);
            this.txtSourceUser.TabIndex = 2;
            this.txtSourceUser.Text = global::ReportSync.Properties.Settings.Default.SourceUser;
            // 
            // txtSourcePassword
            // 
            this.txtSourcePassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourcePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourcePassword.Location = new System.Drawing.Point(67, 55);
            this.txtSourcePassword.Name = "txtSourcePassword";
            this.txtSourcePassword.PasswordChar = '*';
            this.txtSourcePassword.Size = new System.Drawing.Size(100, 20);
            this.txtSourcePassword.TabIndex = 3;
            this.txtSourcePassword.Text = global::ReportSync.Properties.Settings.Default.SourcePassword;
            // 
            // grpDest
            // 
            this.grpDest.Controls.Add(this.rptDestTree);
            this.grpDest.Controls.Add(this.panel3);
            this.grpDest.Controls.Add(this.pbDest);
            this.grpDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDest.Location = new System.Drawing.Point(0, 0);
            this.grpDest.Name = "grpDest";
            this.grpDest.Size = new System.Drawing.Size(238, 482);
            this.grpDest.TabIndex = 20;
            this.grpDest.TabStop = false;
            this.grpDest.Text = "Destination SSRS web service";
            // 
            // pbDest
            // 
            this.pbDest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbDest.Location = new System.Drawing.Point(3, 456);
            this.pbDest.Name = "pbDest";
            this.pbDest.Size = new System.Drawing.Size(232, 23);
            this.pbDest.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDest.TabIndex = 23;
            // 
            // chkSaveDest
            // 
            this.chkSaveDest.AutoSize = true;
            this.chkSaveDest.Checked = true;
            this.chkSaveDest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveDest.Location = new System.Drawing.Point(174, 32);
            this.chkSaveDest.Name = "chkSaveDest";
            this.chkSaveDest.Size = new System.Drawing.Size(51, 17);
            this.chkSaveDest.TabIndex = 22;
            this.chkSaveDest.Text = "Save";
            this.chkSaveDest.UseVisualStyleBackColor = true;
            // 
            // txtDestUrl
            // 
            this.txtDestUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestUrl.Location = new System.Drawing.Point(27, 4);
            this.txtDestUrl.Name = "txtDestUrl";
            this.txtDestUrl.Size = new System.Drawing.Size(200, 20);
            this.txtDestUrl.TabIndex = 8;
            this.txtDestUrl.Text = global::ReportSync.Properties.Settings.Default.DestUrl;
            // 
            // txtDestUser
            // 
            this.txtDestUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestUser.Location = new System.Drawing.Point(65, 30);
            this.txtDestUser.Name = "txtDestUser";
            this.txtDestUser.Size = new System.Drawing.Size(100, 20);
            this.txtDestUser.TabIndex = 9;
            this.txtDestUser.Text = global::ReportSync.Properties.Settings.Default.DestUser;
            // 
            // txtDestPassword
            // 
            this.txtDestPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestPassword.Location = new System.Drawing.Point(65, 55);
            this.txtDestPassword.Name = "txtDestPassword";
            this.txtDestPassword.PasswordChar = '*';
            this.txtDestPassword.Size = new System.Drawing.Size(100, 20);
            this.txtDestPassword.TabIndex = 10;
            this.txtDestPassword.Text = global::ReportSync.Properties.Settings.Default.DestPassword;
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Location = new System.Drawing.Point(7, 9);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(57, 13);
            this.lblDest.TabIndex = 21;
            this.lblDest.Text = "Local path";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(378, 6);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(55, 21);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "LocalPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLocalPath.Location = new System.Drawing.Point(68, 6);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(197, 20);
            this.txtLocalPath.TabIndex = 5;
            this.txtLocalPath.Text = global::ReportSync.Properties.Settings.Default.LocalPath;
            // 
            // bwDownload
            // 
            this.bwDownload.WorkerReportsProgress = true;
            // 
            // bwUpload
            // 
            this.bwUpload.WorkerReportsProgress = true;
            // 
            // bwSync
            // 
            this.bwSync.WorkerReportsProgress = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.txtLocalPath);
            this.panel1.Controls.Add(this.lblDest);
            this.panel1.Controls.Add(this.btnDownload);
            this.panel1.Controls.Add(this.btnSync);
            this.panel1.Controls.Add(this.btnDest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 36);
            this.panel1.TabIndex = 22;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpDest);
            this.splitContainer1.Size = new System.Drawing.Size(480, 482);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSrcUrl);
            this.panel2.Controls.Add(this.chkSaveSource);
            this.panel2.Controls.Add(this.btnSourceLoad);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSourcePassword);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtSourceUser);
            this.panel2.Controls.Add(this.txtSourceUrl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 85);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDestUrl);
            this.panel3.Controls.Add(this.chkSaveDest);
            this.panel3.Controls.Add(this.btnDestLoad);
            this.panel3.Controls.Add(this.lblDestPass);
            this.panel3.Controls.Add(this.txtDestUrl);
            this.panel3.Controls.Add(this.txtDestPassword);
            this.panel3.Controls.Add(this.txtDestUser);
            this.panel3.Controls.Add(this.lblDestUser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 85);
            this.panel3.TabIndex = 24;
            // 
            // ReportSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 518);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportSync";
            this.Text = "ReportSync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportSync_FormClosed);
            this.grpSource.ResumeLayout(false);
            this.grpDest.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceUrl;
        private System.Windows.Forms.Button btnSourceLoad;
        private System.Windows.Forms.TextBox txtSourceUser;
        private System.Windows.Forms.TextBox txtSourcePassword;
        private System.Windows.Forms.TreeView rptSourceTree;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.FolderBrowserDialog dlgDest;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.Button btnDest;
        private System.Windows.Forms.TextBox txtDestUrl;
        private System.Windows.Forms.TextBox txtDestUser;
        private System.Windows.Forms.TextBox txtDestPassword;
        private System.Windows.Forms.Button btnDestLoad;
        private System.Windows.Forms.TreeView rptDestTree;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label lblDestPass;
        private System.Windows.Forms.Label lblDestUser;
        private System.Windows.Forms.Label lblDestUrl;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.Label lblSrcUrl;
        private System.Windows.Forms.GroupBox grpDest;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.CheckBox chkSaveSource;
        private System.Windows.Forms.CheckBox chkSaveDest;
        private System.Windows.Forms.ProgressBar pbSource;
        private System.Windows.Forms.ProgressBar pbDest;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.ComponentModel.BackgroundWorker bwUpload;
        private System.ComponentModel.BackgroundWorker bwSync;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

