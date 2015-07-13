using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Jquery_Programming
{
    public partial class Chapter4_Selector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //OpenMicrosoftWord(@"D:\SR_ECD.docx");
            try
            {
                Label1.Text = Server.HtmlEncode("<script>alert('test')</script>");      
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Open specified word document.
        /// </summary>
        static void OpenMicrosoftWord(string file)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WINWORD.EXE";
            startInfo.Arguments = file;
            Process.Start(startInfo);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string msg = this.txtStartDate.Text;
            string s = "I have received a payment from AGD. How do I find out which invoices the payment is meant for?";
            if (s.Contains(msg))
            {
                lblMsg.Text = "found";
            }
            else
            {
                lblMsg.Text = "not found";
            }
        }
    }
}