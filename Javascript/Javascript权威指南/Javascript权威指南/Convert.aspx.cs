using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Javascript权威指南
{
    public partial class Convert1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] arr1 = { "00" , "07D",  "10" , "10D",  "14D",  "15D",  "16" , "16D",  "21" ,  "21D",  "28" ,  "28D",  "30D",  
                              "40" , "40D",  "45" , "45D",  "45DAY", "50" , "50D",  "60D",  "7D" ,  "8"  ,  "8D" ,  "90" ,  "90D"
                            };

            foreach (string str in arr1)
            {
                Label1.Text += GetPaymentDay(str) + "<br />";
            }
            this.DropDownList1.DataSource = GetPaymentTermList();
            DropDownList1.DataTextField = "Value";
            DropDownList1.DataValueField = "Key";
            this.DropDownList1.DataBind();
            this.DropDownList1.SelectedValue = "30D";

            Label3.Text = isValidEmail("shawn.lee@monocoque.design").ToString();

         
        }

        public static Dictionary<string, string> GetPaymentTermList()
        {
            //00 07D 10D 14D 15D 16D 21D 28D 30D 40D 45D 50D 60D 8D 90D
            Dictionary<string, string> payment = new Dictionary<string, string>();
            payment.Add("00", "Due Immediately");
            payment.Add("7D", "7 Days");
            payment.Add("8D", "8 Days");
            payment.Add("10D", "10 Days");
            payment.Add("14D", "14 Days");
            payment.Add("15D", "15 Days");
            payment.Add("16D", "16 Days");
            payment.Add("21D", "21 Days");
            payment.Add("28D", "28 Days");
            payment.Add("30D", "30 Days");
            payment.Add("40D", "40 Days");

            payment.Add("45D", "45 Days");
            payment.Add("50D", "50 Days");
            payment.Add("60D", "60 Days");
            payment.Add("90D", "90 Days");

            return payment;
        }
        
        private bool isValidEmail(string Email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,6}|[0-9]{1,3})(\]?)$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
                return (true);
            else
                return (false);
        }

        //if has special chars then return true, other return false.
        private bool IsIncludeSpecialChars(string value)
        {
            string regular = @"^[a-zA-Z0-9\&\'\t\~\`\!\@\$\^\*\(\)\-_\=\{\}\:\;\<\>\,\.\/\|\[\]\<\>\s\\]";
            string invoiceregular = @"^[a-zA-Z0-9\t\~\`\!\@\$\^\*\(\)\-_\=\{\}\:\;\<\>\,\.\/\|\[\]\<\>\s\\]";            

            char[] arr = value.ToArray();
            for (int i = 0; i < value.Length; i++)
            {
                var x = arr[i];
                if (!Regex.IsMatch(x.ToString(), invoiceregular))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsContainSpace(string value)
        {
            return value.Contains(" ");
        }

        private bool IsAlphabetic(string value)
        {
            var IsAlphabetic = false;
    
            var ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890* ";
            for (int i = 0; i < value.Length; i++)
            {
                var c = value[i];
                if (ValidChars.IndexOf(c) >= 0)
                {
                    IsAlphabetic = true;
                    break;
                }
            }
            return IsAlphabetic;
        }

        private Boolean CheckForSpecialCharacter(string description)
        {
            string regular = @"[^\x20-\x7F]";
            bool bReturn = false;

            if (Regex.IsMatch(description, regular))
            {
                //special character matched
                bReturn = true;
            }
            return bReturn;
        }

        private string GetPaymentDay(string strPaymentTermCode)
        {
            string strReturnDesc = string.Empty;
            if (strPaymentTermCode == "00")
            {
                strReturnDesc = "00";
            }
            else if (strPaymentTermCode == "07D" || strPaymentTermCode == "7D")
            {
                strReturnDesc = "7D";
            }
            else
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\d+");
                System.Text.RegularExpressions.Match match = regex.Match(strPaymentTermCode);
                strReturnDesc = match.Value.Trim() + "D";
            }
            return strReturnDesc;
        }

           /* switch (strPaymentTermCode)
            {
                case "1D":
                    strReturnDesc = "1 Day";
                    break;
                case "7D":
                    strReturnDesc = "7 Days";
                    break;
                case "8D":
                    strReturnDesc = "8 Days";
                    break;
                case "14D":
                    strReturnDesc = "14 Days";
                    break;
                case "21D":
                    strReturnDesc = "21 Days";
                    break;
                case "28D":
                    strReturnDesc = "28 Days";
                    break;
                case "30D":
                    strReturnDesc = "30 Days";
                    break;
                case "40D":
                    strReturnDesc = "40 Days";
                    break;
                case "50D":
                    strReturnDesc = "50 Days";
                    break;
                case "60D":
                    strReturnDesc = "60 Days";
                    break;
                case "00":
                    strReturnDesc = "Due Immediately";
                    break;

                default:
                    if (strPaymentTermCode.IndexOf("D") > 0)
                    {
                        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\d+");
                        System.Text.RegularExpressions.Match match = regex.Match(strPaymentTermCode);
                        strReturnDesc = match.Value.Trim() + " Days";
                    }
                    break;
            }*/
        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Text = this.DropDownList1.SelectedItem.Text + " : " + this.DropDownList1.SelectedValue;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s =  TextBox1.Text;
            Label4.Text = IsIncludeSpecialChars(s).ToString() + "::" + CheckForSpecialCharacter(s) + ": "+ IsAlphabetic(s);
        }
    }
}