using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Javascript权威指南
{
    public partial class DateTimeTicks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long ticks = DateTime.Now.AddSeconds(15).Ticks;
            string s = ticks.ToString();
            string g = long.MaxValue.ToString();
            string n = Int64.MaxValue.ToString();
            var dt = new DateTime(System.Convert.ToInt64(s));
            if (dt < DateTime.Now)
            {
                throw new ApplicationException("You die!");
            }
            DateTime dt1 = DateTime.Parse("24/03/2016").AddDays(getCD());

        }
        private int getCD()
        {
            int paymentTermCD = 0;
            string strPaymentTermCode = "30D";
            if (strPaymentTermCode.IndexOf("D") > 0)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\d+");
                System.Text.RegularExpressions.Match match = regex.Match(strPaymentTermCode);
                paymentTermCD = Convert.ToInt32(match.Value.Trim());
            }
            return paymentTermCD;
        }
    }
}