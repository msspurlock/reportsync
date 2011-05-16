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
        ReportingService2005 sourceRS;
        ReportingService2005 destRS;

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
                    sourceRS.Credentials = new System.Net.NetworkCredential(txtSourceUser.Text, txtSourcePassword.Text);
                }
                else
                {
                    sourceRS.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
            
                rptSourceTree.Nodes.Clear();
                loadTreeNode("/", rptSourceTree.Nodes, sourceRS);
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
                destRS.Credentials = new System.Net.NetworkCredential(txtDestUser.Text, txtDestPassword.Text);
            }
            else
            {
                destRS.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
            try
            {
                rptDestTree.Nodes.Clear();
                loadTreeNode("/", rptDestTree.Nodes, destRS);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading failed." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadTreeNode(string path, TreeNodeCollection nodes, ReportingService2005 rs)
        {
            CatalogItem[] items = rs.ListChildren(path, false);
            foreach (var item in items)
            {
                TreeNode t = new TreeNode();
                t.Text = item.Name;
                if (item.Type == ItemTypeEnum.DataSource)
                { 
                    //rs.getD
                }
                if (item.Type != ItemTypeEnum.Model && item.Type != ItemTypeEnum.DataSource)
                {    
                    nodes.Add(t);
                }
                if (item.Type == ItemTypeEnum.Folder)
                    loadTreeNode(item.Path, t.Nodes, rs);
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
                var destPath = txtDest.Text + "\\" + node.FullPath;
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
                        var reportDef = sourceRS.GetReportDefinition("/" + node.FullPath.Replace("\\", "/"));
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
                var destPath = "/";
                if(!String.IsNullOrEmpty(txtDest.Text))
                    destPath = txtDest.Text;
                checkTreeNodes(rptSourceTree.Nodes, false);
                syncTreeNodes(destPath, rptSourceTree.Nodes);
                rptDestTree.Nodes.Clear();
                loadTreeNode("/", rptDestTree.Nodes, destRS);
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
                        syncTreeNodes(destPath + "/" + node.Text, node.Nodes);
                    }
                    else
                    {

                        var sourcePath = "/" + node.FullPath.Replace("\\", "/");
                        var reportDef = sourceRS.GetReportDefinition(sourcePath);
                        var reportDss = sourceRS.GetItemDataSources(sourcePath);
                        foreach (var reportDs in reportDss)
                        {
                            //ds.Name
                        }
                        destRS.CreateReport(node.Text, destPath, true, reportDef, null);
                        //set the datasource
                        //DataSourceReference reference = new DataSourceReference();//creates new instance from DataSourceReference 
                        //reference.Reference = "/ds";
                        //DataSource[] dataSources = new DataSource[1];
                        //DataSource ds = new DataSource();
                        //ds.Item = (DataSourceDefinitionOrReference)reference;
                        //ds.Name = "ds";
                        //dataSources[0] = ds;
                        //destRS.SetItemDataSources(destPath, dataSources);
                    }
                }
            }
        }

        private void btnDest_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgDest.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDest.Text = dlgDest.SelectedPath;
            }
        }

        private void rptDestTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtDest.Text = "/" + e.Node.FullPath.Replace("\\", "/");
        }
    }
}
