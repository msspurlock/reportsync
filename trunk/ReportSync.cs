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


        public ReportSync()
        {
            InitializeComponent();
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
                rptDestTree.Nodes.Clear();
                destDS = new Dictionary<string, string>();
                loadTreeNode(ROOT_FOLDER, rptDestTree.Nodes, destRS, destDS);
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
            try
            {
                checkTreeNodes(rptSourceTree.Nodes, false);
                saveTreeNodes(rptSourceTree.Nodes);
                MessageBox.Show("Report files downloaded successfully.","Download complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download failed." + ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
                }
                else
                {
                    node.Checked = checkTreeNodes(node.Nodes, false);
                    isChecked = isChecked || node.Checked;
                }
            }
            return isChecked;
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
                        var reportDef = sourceRS.GetReportDefinition(ROOT_FOLDER + node.FullPath.Replace("\\", "/"));
                        XmlDocument rdl = new XmlDocument();
                        rdl.Load(new MemoryStream(reportDef));
                        rdl.Save(destPath+ ".rdl");
                    }
                }
                
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                var destPath = ROOT_FOLDER;
                if(!String.IsNullOrEmpty(txtLocalPath.Text))
                    destPath = txtLocalPath.Text;
                checkTreeNodes(rptSourceTree.Nodes, false);
                syncTreeNodes(destPath, rptSourceTree.Nodes);
                rptDestTree.Nodes.Clear();
                destDS = new Dictionary<string, string>();
                loadTreeNode(ROOT_FOLDER, rptDestTree.Nodes, destRS, destDS);
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
                        destRS.CreateFolder(node.Text, destPath, null);
                        var childPath = destPath;
                        if (destPath.Equals(ROOT_FOLDER))
                            childPath = ROOT_FOLDER + node.Text;
                        else
                            childPath = destPath + PATH_SEPERATOR + node.Text;
                        syncTreeNodes(childPath, node.Nodes);
                    }
                    else
                    {
                        var sourcePath = ROOT_FOLDER + node.FullPath.Replace("\\", PATH_SEPERATOR);
                        var reportDef = sourceRS.GetReportDefinition(sourcePath);
                        uploadReport(destPath, node.Text, reportDef);
                    }
                }
            }
        }

        private void uploadReport(string destinationPath, string reportName, byte[] reportDef)
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(txtLocalPath.Text, "*.rdl", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var fullPath = file.Replace(txtLocalPath.Text, "");
                int breakAt = fullPath.LastIndexOf('\\');
                var filePath = fullPath.Substring(0, breakAt).Replace("\\", PATH_SEPERATOR); ;
                var fileName = fullPath.Substring(breakAt+1, fullPath.Length - 4); //remove the .rdl
                var reportPath = uploadPath;
                if (!reportPath.EndsWith("/"))
                    reportPath += filePath;
                else
                    reportPath += "/" + filePath;
                XmlDocument report = new XmlDocument();
                report.Load(file);
                var reportDef = Encoding.Default.GetBytes(report.OuterXml);
                uploadReport(reportPath, fileName, reportDef);
            }
        }
    }
}
