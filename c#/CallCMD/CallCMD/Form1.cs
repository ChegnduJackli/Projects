using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Reflection;

namespace CallCMD
{
    public partial class Form1 : Form
    {
        string KeyName = "CMD Manager";
        string AssemblyLocation = Assembly.GetExecutingAssembly().Location;  // Or the EXE path.

        public Form1()
        {
            InitializeComponent();
            BindData();
            InitBox();
        }
        private void InitBox()
        {

            if (Util.IsAutoStartEnabled(KeyName, AssemblyLocation))
            {
                this.chkAutoStart.Checked = true;
            }
            else
            {
                this.chkAutoStart.Checked = false;
            }
        }
        private void BindData()
        {
            this.labMessage.Text = "";

            this.listBoxURL.DataSource = FileDAL.GetURL();
            this.chkListAllBrowsers.DataSource = Browsers.GetBrowserList();

            chkListAllBrowsers.DisplayMember = "BrowserName";
            chkListAllBrowsers.ValueMember = "BrowserPath";
            chkListAllBrowsers.SetItemCheckState(0, CheckState.Checked);
         
        }
        private void btnEnableProxy_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdFile = CMDConstant.ProxyEnable;
                RunCMD(CMDConstant.GetCMDPath(cmdFile));
                ShowMessage("Proxy enabled");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }

        private void btnDisableProxy_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdFile = CMDConstant.ProxyDisable;
                RunCMD(CMDConstant.GetCMDPath(cmdFile));
                ShowMessage("Proxy disabled");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }

        private void btnShutdownPC_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdFile = CMDConstant.ShutdownPC;
                RunCMD(CMDConstant.GetCMDPath(cmdFile));
                ShowMessage("PC will shutdown");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }

        private void btnRestartPC_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdFile = CMDConstant.RestartPC;
                RunCMD(CMDConstant.GetCMDPath(cmdFile));
                ShowMessage("PC will Restart");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }

        private void RunCMD(string cmd, string arg ="")
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = cmd;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.Arguments = arg;
                myProcess.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK);
            this.labMessage.Text = message;
        }

        private void btnCancelShutdown_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdFile = CMDConstant.CancelShutDownPC;
                RunCMD(CMDConstant.GetCMDPath(cmdFile));
                ShowMessage("PC cancel to shutdown");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }

        private void btnOpenURL_Click(object sender, EventArgs e)
        {
            try
            {
               // string url = this.listBoxURL.SelectedItem.ToString();
               List<string> browserList = GetBrowser();
               foreach (string weburl in this.listBoxURL.SelectedItems)
               {
                   foreach (string browserPath in browserList)
                   {
                       RunCMD(browserPath, weburl);
                   }
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }
        private List<string> GetBrowser()
        {

            List<string> browserList = new List<string>();
            foreach (var item in this.chkListAllBrowsers.CheckedItems)
            {
                var browser = (BrowserInfo)item;
                browserList.Add(browser.BrowserPath);
            }
            if (browserList.Count == 0)
            {
                throw new ApplicationException("At least select one browser.");
            }
            return browserList;
        }


        private void AutoStart(bool autoStart = true)
        {

            if (!autoStart)
            {
                // if has same keyName ,then delete
                if (Util.IsAutoStartEnabled(KeyName, AssemblyLocation))
                    Util.UnSetAutoStart(KeyName);
            }
            else
            {
                //delete first
                if (Util.IsAutoStartEnabled(KeyName, AssemblyLocation))
                    Util.UnSetAutoStart(KeyName);
                // Set Auto-start.
                Util.SetAutoStart(KeyName, AssemblyLocation);
            }
        }

        private void chkAutoStart_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAutoStart.Checked)
            {
                AutoStart(true);
            }
            else
            {
                AutoStart(false);
            }
        }
    }
}
