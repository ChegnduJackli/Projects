using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CallCMD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.labMessage.Text = "";
            this.rbChrome.Checked = true;
            BindData();
        }
        private void BindData()
        {
            this.listBoxURL.DataSource = FileDAL.GetURL();
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
                string url = this.listBoxURL.SelectedItem.ToString();
                string browserPath = GetBrowser();
                RunCMD(browserPath,url );
                //ProcessStartInfo sInfo = new ProcessStartInfo(browserPath, url);
                //Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }
        private string GetBrowser()
        {
            string browserURL = Browsers.IEPath;
            if (rbChrome.Checked)
            {
                browserURL = Browsers.ChromePath;
            }
            else if (rbFireFox.Checked)
            {
                browserURL = Browsers.FireFoxPath;
            }
            return browserURL;
        }
    }
}
