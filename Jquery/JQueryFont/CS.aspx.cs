using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public partial class _Default : System.Web.UI.Page 
{
    protected string Values;
    protected void Post(object sender, EventArgs e)
    {
        string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
       JavaScriptSerializer serializer =new JavaScriptSerializer();
       this.Values = serializer.Serialize(textboxValues);
       char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
       string text = "one\ttwo three:four,five six seven";
       string[] words = text.Split(delimiterChars);
    }
}