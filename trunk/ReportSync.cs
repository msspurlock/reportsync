using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportSync.ReportService;
using System.Xml;
using System.IO;
using System.Web;
using System.Threading;

namespace ReportSync
{
    public partial class ReportSync : Form
    {
        const string ROOT_FOLDER = "/";
        const string PATH_SEPERATOR = "/";

        ReportingService2005 sourceRS;
        ReportingService2005 destRS;

        Dictionary<string, string> sourceDS;
        Dictionary<string, string> destDS;

        string uploadPath = ROOT_FOLDER;
        List<string> existingPaths;

        int selectedNodeCount;

        int processedNodeCount;

        public ReportSync()
        {
            InitializeComponent();
            bwDownload.DoWork += new DoWorkEventHandler(bwDownload_DoWork);
            bwDownload.ProgressChanged += new ProgressChangedEventHandler(bwDownload_ProgressChanged);
            bwDownload.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwDownload_RunWorkerCompleted);

            bwUpload.DoWork += new DoWorkEventHandler(bwUpload_DoWork);
            bwUpload.ProgressChanged +=new ProgressChangedEventHandler(bwUpload_ProgressChanged);
            bwUpload.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwUpload_RunWorkerCompleted);

            bwSync.DoWork += new DoWorkEventHandler(bwSync_DoWork);
            bwSync.ProgressChanged +=new ProgressChangedEventHandler(bwSync_ProgressChanged);
            bwSync.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSync_RunWorkerCompleted);
        }

        void bwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbSource.Value = e.ProgressPercentage;
        }

        void bwUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDest.Value = e.ProgressPercentage;
        }

        void bwSync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbSource.Value = e.ProgressPercentage;
            pbDest.Value = e.ProgressPercentage;
        }

        void bwSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            unCheckTreeNodes(rptSourceTree.Nodes);
            loadDestTree();
            MessageBox.Show("Sync completed successfully.", "Sync complete");
        }

        void bwSync_DoWork(object sender, DoWorkEventArgs e)
        {
            var destPath = ROOT_FOLDER;
            if (!String.IsNullOrEmpty(uploadPath))
                destPath = uploadPath;
            syncTreeNodes(destPath, rptSourceTree.Nodes);
            bwSync.ReportProgress(100);
        }

        void bwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadDestTree();
            MessageBox.Show("Upload completed successfully.", "Upload complete");
        }

        void bwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            var files = Directory.GetFiles(txtLocalPath.Text, "*.rdl", SearchOption.AllDirectories);
            selectedNodeCount = files.Length;
            processedNodeCount = 0;
            foreach (var file in files)
            {
                var fullPath = file.Replace(txtLocalPath.Text, "").TrimStart('\\');
                int breakAt = fullPath.LastIndexOf('\\');
                string filePath;
                if (breakAt == -1)
                    filePath = String.Empty;
                else
                    filePath = fullPath.Substring(0, breakAt).Replace("\\", PATH_SEPERATOR); ;
                var fileName = fullPath.Substring(breakAt + 1, fullPath.Length - 5 - breakAt); //remove the .rdl
                var reportPath = uploadPath;
                if (reportPath.EndsWith(PATH_SEPERATOR))
                    reportPath += filePath.TrimStart('/');
                else
                    reportPath += "/" + filePath.TrimStart('/');
                reportPath = reportPath.TrimEnd('/');
                XmlDocument report = new XmlDocument();
                report.Load(file);
                var reportDef = Encoding.Default.GetBytes(report.OuterXml);
                if (!existingPaths.Contains(reportPath))
                {
                    EnsureDestDir(reportPath);
                    existingPaths.Add(reportPath);
                }
                uploadReport(reportPath, fileName, reportDef);
                processedNodeCount++;
                bwUpload.ReportProgress(processedNodeCount * 100 / selectedNodeCount);
            }
            bwUpload.ReportProgress(100);
        }

        void bwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            unCheckTreeNodes(rptSourceTree.Nodes);
            MessageBox.Show("Report files downloaded successfully.", "Download complete");

        }

        void bwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                processedNodeCount = 0;
                saveTreeNodes(rptSourceTree.Nodes);
                bwDownload.ReportProgress(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                sourceRS = new ReportService.ReportingService2005();
                string reportServerURI = "http://localhost:8080/ReportServer";
                if (!String.IsNullOrEmpty(txtSourceUrl.Text))
                {
                    reportServerURI = txtSourceUrl.Text;
                }

                sourceRS.Url = reportServerURI + "/ReportService2005.asmx";

                if (!String.IsNullOrEmpty(txtSourceUser.Text))
                {
                    var userName = txtSourceUser.Text;
                    var nameParts = userName.Split('\\', '/');
                    if(nameParts.Length > 2)
                    {
                        MessageBox.Show("Incorrect source user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (nameParts.Length == 2)
                    {
                        userName = nameParts[1];
                        sourceRS.Credentials = new System.Net.NetworkCredential(userName, txtSourcePassword.Text, nameParts[0]);
                    }
                    else
                    {
                        sourceRS.Credentials = new System.Net.NetworkCredential(userName, txtSourcePassword.Text);
                    }                    
                }
                else
                {
                    sourceRS.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
            
                rptSourceTree.Nodes.Clear();
                sourceDS = new Dictionary<string, string>();
                loadTreeNode(ROOT_FOLDER, rptSourceTree.Nodes, sourceRS, sourceDS);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loading failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDestLoad_Click(object sender, EventArgs e)
        {
            destRS = new ReportService.ReportingService2005();
            string reportServerURI = "http://localhost:8080/ReportServer";
            if (!String.IsNullOrEmpty(txtDestUrl.Text))
            {
                reportServerURI = txtDestUrl.Text;
            }

            destRS.Url = reportServerURI + "/ReportService2005.asmx";

            if (!String.IsNullOrEmpty(txtDestUser.Text))
            {
                var userName = txtDestUser.Text;
                var nameParts = userName.Split('\\', '/');
                if (nameParts.Length > 2)
                {
                    MessageBox.Show("Incorrect destination user name","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nameParts.Length == 2)
                {
                    userName = nameParts[1];
                    destRS.Credentials = new System.Net.NetworkCredential(userName, txtDestPassword.Text, nameParts[0]);
                }
                else
                {
                    destRS.Credentials = new System.Net.NetworkCredential(userName, txtDestPassword.Text);
                }             
            }
            else
            {
                destRS.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
            try
            {
                loadDestTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadTreeNode(string path, TreeNodeCollection nodes, ReportingService2005 rs, Dictionary<string, string> dataSources)
        {
            CatalogItem[] items = rs.ListChildren(path, false);
            foreach (var item in items)
            {
                TreeNode t = new TreeNode();
                t.Text = item.Name;
                if (item.Type == ItemTypeEnum.DataSource)
                {
                    if(!dataSources.ContainsKey(item.Name))
                        dataSources.Add(item.Name, item.Path);
                }
                if (item.Type != ItemTypeEnum.Model && item.Type != ItemTypeEnum.DataSource)
                {    
                    nodes.Add(t);
                }
                if (item.Type == ItemTypeEnum.Folder)
                    loadTreeNode(item.Path, t.Nodes, rs, dataSources);
                else
                {
                    
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            selectedNodeCount = 0;
            checkTreeNodes(rptSourceTree.Nodes, false);
            bwDownload.RunWorkerAsync();
        }

        private bool checkTreeNodes(TreeNodeCollection nodes, bool parentChecked)
        {
            var isChecked = parentChecked;
            foreach (TreeNode node in nodes)
            {
                if (node.Checked || parentChecked)
                {
                    checkTreeNodes(node.Nodes, true);
                    node.Checked = true;
                    isChecked = true;
                    selectedNodeCount++;
                }
                else
                {
                    node.Checked = checkTreeNodes(node.Nodes, false);
                    node.Tag = true;
                    isChecked = isChecked || node.Checked;
                }
            }
            return isChecked;
        }

        private void unCheckTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.Tag != null)
                {
                    node.Checked = false;
                }
                unCheckTreeNodes(node.Nodes);
            }
        }

        private void saveTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                var destPath = txtLocalPath.Text + "\\" + node.FullPath;
                if (node.Checked)
                {
                    if (node.Nodes.Count > 0)
                    {
                        //check if dir exists
                        if (!Directory.Exists(destPath))
                            Directory.CreateDirectory(destPath);
                        saveTreeNodes(node.Nodes);
                    }
                    else
                    {
                        var itemPath = ROOT_FOLDER + node.FullPath.Replace("\\", "/");
                        var itemType = sourceRS.GetItemType(itemPath);
                        if (itemType == ItemTypeEnum.Resource)
                        {
                            //Download the resource
                            string resourceType;
                            var contents = sourceRS.GetResourceContents(itemPath, out resourceType);
                            File.WriteAllBytes(destPath, contents);
                            continue;
                        }
                        var reportDef = sourceRS.GetReportDefinition(itemPath);
                        XmlDocument rdl = new XmlDocument();
                        rdl.Load(new MemoryStream(reportDef));
                        rdl.Save(destPath+ ".rdl");
                    }
                    processedNodeCount++;
                    bwDownload.ReportProgress(processedNodeCount * 100 / selectedNodeCount);
                }
                
            }
        }

        private void loadDestTree()
        {
            uploadPath = ROOT_FOLDER;
            rptDestTree.Nodes.Clear();
            destDS = new Dictionary<string, string>();
            loadTreeNode(ROOT_FOLDER, rptDestTree.Nodes, destRS, destDS);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                selectedNodeCount = 0;
                checkTreeNodes(rptSourceTree.Nodes, false);
                existingPaths = new List<string>();
                bwSync.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sync failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void syncTreeNodes(string destPath, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    if (node.Nodes.Count > 0)
                    {
                        var childPath = destPath;
                        if (destPath.Equals(ROOT_FOLDER))
                            childPath = ROOT_FOLDER + node.Text;
                        else
                            childPath = destPath + PATH_SEPERATOR + node.Text;
                        syncTreeNodes(childPath, node.Nodes);
                    }
                    else
                    {
                        if (!existingPaths.Contains(destPath))
                        {
                            EnsureDestDir(destPath);
                            existingPaths.Add(destPath);
                        }
                        var itemPath = ROOT_FOLDER + node.FullPath.Replace("\\", PATH_SEPERATOR);
                        var itemType = sourceRS.GetItemType(itemPath);
                        if (itemType == ItemTypeEnum.Resource)
                        {
                            //Download the resource
                            string resourceType;
                            var contents = sourceRS.GetResourceContents(itemPath, out resourceType);
                            uploadResource(destPath, node.Text, resourceType, contents);
                            continue;
                        }
                        var reportDef = sourceRS.GetReportDefinition(itemPath);
                        uploadReport(destPath, node.Text, reportDef);
                    }
                    processedNodeCount++;
                    bwSync.ReportProgress(processedNodeCount * 100 / selectedNodeCount);
                }
            }
        }

        private void uploadResource(string destinationPath, string resourceName, string resourceType, byte[] contents)
        {
            destRS.CreateResource(resourceName, destinationPath, true, contents, resourceType, null);
        }

        private void uploadReport(string destinationPath, string reportName, byte[] reportDef)
        {
            try
            {
                //Create report
                destRS.CreateReport(reportName, destinationPath, true, reportDef, null);

                //Link datasources
                var reportPath = destinationPath;
                if (reportPath.EndsWith("/"))
                    reportPath += reportName;
                else
                    reportPath += "/" + reportName;
                var reportDss = destRS.GetItemDataSources(reportPath);
                List<DataSource> dataSources = new List<DataSource>();
                foreach (var reportDs in reportDss)
                {

                    if (destDS.ContainsKey(reportDs.Name))
                    {
                        DataSourceReference reference = new DataSourceReference();
                        reference.Reference = destDS[reportDs.Name];
                        var ds = new DataSource();
                        ds.Item = (DataSourceDefinitionOrReference)reference;
                        ds.Name = reportDs.Name;
                        dataSources.Add(ds);
                    }
                }
                destRS.SetItemDataSources(reportPath, dataSources.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show("Upload "+ reportName + " failed." + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDest_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgDest.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtLocalPath.Text = dlgDest.SelectedPath;
            }
        }

        private void rptDestTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            uploadPath = ROOT_FOLDER + e.Node.FullPath.Replace("\\", PATH_SEPERATOR);
        }

        private void EnsureDestDir(string path)
        { 
            try
            {
                destRS.ListChildren(path, false);
            }
            catch (Exception)
            { 
                //ensure parent folder
                var breatAt = path.LastIndexOf(PATH_SEPERATOR);
                var folder = path.Substring(breatAt + 1);
                var parent = path.Substring(0, breatAt);
                if (String.IsNullOrEmpty(parent))
                    parent = ROOT_FOLDER;
                EnsureDestDir(parent);
                destRS.CreateFolder(folder,parent, null);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            existingPaths = new List<string>();
            if (String.IsNullOrEmpty(txtLocalPath.Text))
            {
                MessageBox.Show("Please select the folder to upload.");
                return;
            }
            bwUpload.RunWorkerAsync();
        }

        private void ReportSync_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!chkSaveSource.Checked)
                Properties.Settings.Default.SourcePassword = "";
            if (!chkSaveDest.Checked)
                Properties.Settings.Default.DestPassword = "";
            Properties.Settings.Default.Save();
        }
    }
}
