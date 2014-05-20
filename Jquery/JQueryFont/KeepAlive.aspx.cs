using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KeepAlive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.keepAlive();
    }
    private void keepAlive()
    {
        //figure out the full url of the logout page configured in web.config + the return url which is the current page        
        String logoutUrl = "Default.aspx";
        String minutesToWarning = "0.1", minutesBeforeLoggedOut = "5";
        //figure out how many minutes before time out the user wants to get warned.         

        String script = @"        
            <script type='text/javascript'>            
                var minutesToWarning = " + minutesToWarning + @";            
                var minutesBeforeLoggedOut = " + minutesBeforeLoggedOut + @";            
                var loginUrl  = '" + logoutUrl + @"'; 
                setWindowTimeout();
            </script>        
            ";
        if (!ClientScript.IsClientScriptBlockRegistered("WarnTimeOut"))
            ClientScript.RegisterClientScriptBlock(typeof(Page), "WarnTimeOut", script);
    }
}