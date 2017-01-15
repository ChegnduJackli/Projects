using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Javascript权威指南
{
    public partial class Split : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string separtor = "@#$#@";
            string secureToken = "Y@#$#@vendorID@#$#@0000@#$#@2342423";
            string[] arr = secureToken.Trim().Split(new string[] { separtor }, StringSplitOptions.None);

            string status = arr[0].Trim();

            // vendorBLL.SingPassValidation(status);

            string vendorID = arr[1].Trim();
            string singPassID = arr[2].Trim();
            string easyID = arr[3].Trim();
            string a = "this is a testing";
            string a1 = string.Format(a, "23");
            string account = "12334-34223-23234-4-3-4-";
            string stemp = MaskAccountNo(account);
            string s ="";

        }

        public string MaskAccountNo(string accountNo)
        {
            int visibleNo = 4;
            char[] account = accountNo.ToCharArray();
            for (int i = account.Length - 1; i >= 0; i--)
            {
                if (visibleNo > 0)
                {
                    if (Char.IsDigit(account[i]))
                    {
                        visibleNo--;
                    }
                }
                else
                {
                    account[i] = 'X';
                }
            }

            return new string(account);
        }
    }
}