using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace OpenURl
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> urlDic = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            BindBrowser();
            BindUrl();
        }
        private void BindBrowser()
        {
            this.chkListAllBrowsers.DataSource = Browsers.GetBrowserList();
            chkListAllBrowsers.DisplayMember = "BrowserName";
            chkListAllBrowsers.ValueMember = "BrowserPath";
            chkListAllBrowsers.SetItemCheckState(0, CheckState.Checked);
        }
        private void BindUrl()
        {
            //this.listboxUrl.DataSource = FileDAL.GetUrlList();
            urlDic = FileDAL.GetUrlAndDesc();
            var url = urlDic.Keys.ToArray();
            this.listboxUrl.DataSource = url;
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
        private void btnOpenURL_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> browserList = GetBrowser();
                foreach (string weburl in this.listboxUrl.SelectedItems)
                {
                    foreach (string browserPath in browserList)
                    {
                        Run(browserPath, weburl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception"); ;
            }
        }

        private void listboxUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rtbDesc.Text = string.Empty;

            string selectItem = this.listboxUrl.SelectedItem.ToString();
            if (urlDic.ContainsKey(selectItem))
            {
                this.rtbDesc.Text = urlDic[selectItem];
            }
        }
        private void Run(string cmd, string arg = "")
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
    }
}
