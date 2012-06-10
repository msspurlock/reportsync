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
            this.chkSaveSource = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSrcUrl = new System.Windows.Forms.Label();
            this.grpDest = new System.Windows.Forms.GroupBox();
            this.chkSaveDest = new System.Windows.Forms.CheckBox();
            this.lblDest = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtDestUrl = new System.Windows.Forms.TextBox();
            this.txtDestUser = new System.Windows.Forms.TextBox();
            this.txtDestPassword = new System.Windows.Forms.TextBox();
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.txtSourceUser = new System.Windows.Forms.TextBox();
            this.txtSourcePassword = new System.Windows.Forms.TextBox();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.grpSource.SuspendLayout();
            this.grpDest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSourceLoad
            // 
            this.btnSourceLoad.Location = new System.Drawing.Point(170, 67);
            this.btnSourceLoad.Name = "btnSourceLoad";
            this.btnSourceLoad.Size = new System.Drawing.Size(55, 21);
            this.btnSourceLoad.TabIndex = 4;
            this.btnSourceLoad.Text = "Load";
            this.btnSourceLoad.UseVisualStyleBackColor = true;
            this.btnSourceLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // rptSourceTree
            // 
            this.rptSourceTree.CheckBoxes = true;
            this.rptSourceTree.Location = new System.Drawing.Point(6, 93);
            this.rptSourceTree.Name = "rptSourceTree";
            this.rptSourceTree.Size = new System.Drawing.Size(219, 347);
            this.rptSourceTree.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(305, 458);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(65, 20);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDest
            // 
            this.btnDest.Location = new System.Drawing.Point(272, 458);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(24, 20);
            this.btnDest.TabIndex = 6;
            this.btnDest.Text = "...";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // btnDestLoad
            // 
            this.btnDestLoad.Location = new System.Drawing.Point(175, 67);
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
            this.rptDestTree.Location = new System.Drawing.Point(6, 93);
            this.rptDestTree.Name = "rptDestTree";
            this.rptDestTree.Size = new System.Drawing.Size(226, 347);
            this.rptDestTree.TabIndex = 13;
            this.rptDestTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.rptDestTree_NodeMouseClick);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(437, 458);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(41, 20);
            this.btnSync.TabIndex = 13;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lblDestPass
            // 
            this.lblDestPass.AutoSize = true;
            this.lblDestPass.Location = new System.Drawing.Point(3, 71);
            this.lblDestPass.Name = "lblDestPass";
            this.lblDestPass.Size = new System.Drawing.Size(53, 13);
            this.lblDestPass.TabIndex = 16;
            this.lblDestPass.Text = "Password";
            // 
            // lblDestUser
            // 
            this.lblDestUser.AutoSize = true;
            this.lblDestUser.Location = new System.Drawing.Point(3, 45);
            this.lblDestUser.Name = "lblDestUser";
            this.lblDestUser.Size = new System.Drawing.Size(29, 13);
            this.lblDestUser.TabIndex = 17;
            this.lblDestUser.Text = "User";
            // 
            // lblDestUrl
            // 
            this.lblDestUrl.AutoSize = true;
            this.lblDestUrl.Location = new System.Drawing.Point(3, 19);
            this.lblDestUrl.Name = "lblDestUrl";
            this.lblDestUrl.Size = new System.Drawing.Size(20, 13);
            this.lblDestUrl.TabIndex = 18;
            this.lblDestUrl.Text = "Url";
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.chkSaveSource);
            this.grpSource.Controls.Add(this.label2);
            this.grpSource.Controls.Add(this.label1);
            this.grpSource.Controls.Add(this.lblSrcUrl);
            this.grpSource.Controls.Add(this.txtSourceUrl);
            this.grpSource.Controls.Add(this.rptSourceTree);
            this.grpSource.Controls.Add(this.txtSourceUser);
            this.grpSource.Controls.Add(this.txtSourcePassword);
            this.grpSource.Controls.Add(this.btnSourceLoad);
            this.grpSource.Location = new System.Drawing.Point(2, 6);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(232, 446);
            this.grpSource.TabIndex = 19;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source SSRS web service";
            // 
            // chkSaveSource
            // 
            this.chkSaveSource.AutoSize = true;
            this.chkSaveSource.Checked = true;
            this.chkSaveSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveSource.Location = new System.Drawing.Point(171, 44);
            this.chkSaveSource.Name = "chkSaveSource";
            this.chkSaveSource.Size = new System.Drawing.Size(51, 17);
            this.chkSaveSource.TabIndex = 22;
            this.chkSaveSource.Text = "Save";
            this.chkSaveSource.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "User";
            // 
            // lblSrcUrl
            // 
            this.lblSrcUrl.AutoSize = true;
            this.lblSrcUrl.Location = new System.Drawing.Point(3, 19);
            this.lblSrcUrl.Name = "lblSrcUrl";
            this.lblSrcUrl.Size = new System.Drawing.Size(20, 13);
            this.lblSrcUrl.TabIndex = 19;
            this.lblSrcUrl.Text = "Url";
            // 
            // grpDest
            // 
            this.grpDest.Controls.Add(this.chkSaveDest);
            this.grpDest.Controls.Add(this.lblDestUrl);
            this.grpDest.Controls.Add(this.txtDestUrl);
            this.grpDest.Controls.Add(this.txtDestUser);
            this.grpDest.Controls.Add(this.lblDestUser);
            this.grpDest.Controls.Add(this.txtDestPassword);
            this.grpDest.Controls.Add(this.lblDestPass);
            this.grpDest.Controls.Add(this.btnDestLoad);
            this.grpDest.Controls.Add(this.rptDestTree);
            this.grpDest.Location = new System.Drawing.Point(240, 6);
            this.grpDest.Name = "grpDest";
            this.grpDest.Size = new System.Drawing.Size(238, 446);
            this.grpDest.TabIndex = 20;
            this.grpDest.TabStop = false;
            this.grpDest.Text = "Destination SSRS web service";
            // 
            // chkSaveDest
            // 
            this.chkSaveDest.AutoSize = true;
            this.chkSaveDest.Checked = true;
            this.chkSaveDest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveDest.Location = new System.Drawing.Point(176, 44);
            this.chkSaveDest.Name = "chkSaveDest";
            this.chkSaveDest.Size = new System.Drawing.Size(51, 17);
            this.chkSaveDest.TabIndex = 22;
            this.chkSaveDest.Text = "Save";
            this.chkSaveDest.UseVisualStyleBackColor = true;
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Location = new System.Drawing.Point(5, 461);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(57, 13);
            this.lblDest.TabIndex = 21;
            this.lblDest.Text = "Local path";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(376, 458);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(55, 20);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtDestUrl
            // 
            this.txtDestUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestUrl.Location = new System.Drawing.Point(27, 16);
            this.txtDestUrl.Name = "txtDestUrl";
            this.txtDestUrl.Size = new System.Drawing.Size(205, 20);
            this.txtDestUrl.TabIndex = 8;
            this.txtDestUrl.Text = global::ReportSync.Properties.Settings.Default.DestUrl;
            // 
            // txtDestUser
            // 
            this.txtDestUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestUser.Location = new System.Drawing.Point(65, 42);
            this.txtDestUser.Name = "txtDestUser";
            this.txtDestUser.Size = new System.Drawing.Size(100, 20);
            this.txtDestUser.TabIndex = 9;
            this.txtDestUser.Text = global::ReportSync.Properties.Settings.Default.DestUser;
            // 
            // txtDestPassword
            // 
            this.txtDestPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestPassword.Location = new System.Drawing.Point(65, 67);
            this.txtDestPassword.Name = "txtDestPassword";
            this.txtDestPassword.PasswordChar = '*';
            this.txtDestPassword.Size = new System.Drawing.Size(100, 20);
            this.txtDestPassword.TabIndex = 10;
            this.txtDestPassword.Text = global::ReportSync.Properties.Settings.Default.DestPassword;
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceUrl.Location = new System.Drawing.Point(32, 16);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(193, 20);
            this.txtSourceUrl.TabIndex = 1;
            this.txtSourceUrl.Text = global::ReportSync.Properties.Settings.Default.SourceUrl;
            // 
            // txtSourceUser
            // 
            this.txtSourceUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceUser.Location = new System.Drawing.Point(64, 41);
            this.txtSourceUser.Name = "txtSourceUser";
            this.txtSourceUser.Size = new System.Drawing.Size(100, 20);
            this.txtSourceUser.TabIndex = 2;
            this.txtSourceUser.Text = global::ReportSync.Properties.Settings.Default.SourceUser;
            // 
            // txtSourcePassword
            // 
            this.txtSourcePassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourcePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourcePassword.Location = new System.Drawing.Point(64, 67);
            this.txtSourcePassword.Name = "txtSourcePassword";
            this.txtSourcePassword.PasswordChar = '*';
            this.txtSourcePassword.Size = new System.Drawing.Size(100, 20);
            this.txtSourcePassword.TabIndex = 3;
            this.txtSourcePassword.Text = global::ReportSync.Properties.Settings.Default.SourcePassword;
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "LocalPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLocalPath.Location = new System.Drawing.Point(66, 458);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(197, 20);
            this.txtLocalPath.TabIndex = 5;
            this.txtLocalPath.Text = global::ReportSync.Properties.Settings.Default.LocalPath;
            // 
            // ReportSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 483);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblDest);
            this.Controls.Add(this.grpDest);
            this.Controls.Add(this.grpSource);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnDest);
            this.Controls.Add(this.txtLocalPath);
            this.Controls.Add(this.btnDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportSync";
            this.Text = "ReportSync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportSync_FormClosed);
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.grpDest.ResumeLayout(false);
            this.grpDest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

