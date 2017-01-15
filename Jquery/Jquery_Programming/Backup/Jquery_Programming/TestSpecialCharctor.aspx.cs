using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jquery_Programming
{
    public partial class TestSpecialCharctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //replace special chars to '-'.
        private string FilterSpecialChars(string str)
        {
            string result = str;
            char replaceChar = '-';
           // char[] SpecialChars = new char[] { '\\', ':', '*', '?', '/', '"', '<', '>', '|', '\0' }; //System.IO.Path.GetInvalidFileNameChars();
            char[] SpecialChars = System.IO.Path.GetInvalidFileNameChars();
            if (str.IndexOfAny(SpecialChars) >= 0)
            {
                foreach (char badChar in SpecialChars)
                {
                    result = result.Replace(badChar, replaceChar);
                }
            }
            return result;

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            string str = this.txtcont.Text.Trim();
            string result = str;
            char replaceChar = '-';
            // char[] SpecialChars = new char[] { '\\', ':', '*', '?', '/', '"', '<', '>', '|', '\0' }; //System.IO.Path.GetInvalidFileNameChars();
            //char[] SpecialChars = System.IO.Path.GetInvalidFileNameChars();
            char [] SpecialChars =new char[] { '[',']', '{', '}', '$', '\\', ';', '\'', '|', '"', '/', '<', '>', '?', '`', '&', '*', '(', ')' };

            bool isInclude = false;
            if (str.IndexOfAny(SpecialChars) >= 0)
            {
                foreach (char badChar in SpecialChars)
                {
                    result = result.Replace(badChar, replaceChar);
                    isInclude = true;
                    
                   
                }
            }
            if (isInclude)
            {
                this.lblResult.Text = "include special chars is true";
            }
            else
            {
                this.lblResult.Text = "Not include special chars";
            }
            lblcont.Text = result;
        }
    }
}