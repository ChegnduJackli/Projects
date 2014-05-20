using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Email : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           Label1.Text = load();
        }
    }
    private string load()
    {
        string name = "lideng";
        System.Text.StringBuilder sbEmail = new System.Text.StringBuilder();
        sbEmail.Append("<table with='100%' cellpadding='2' cellspacing='2' border='0'>");
        sbEmail.Append("<tr><td>Dear sir "+name+ ",this is you email notification</td></tr>");
        sbEmail.Append("</table>");
        return sbEmail.ToString();
    }
    public  void Send(string toEmailAddress, string vendorName)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            //string emailAddress = ConfigurationManager.AppSettings["errReporting"];
            string strMessageBody = GetEmailBody(vendorName);
            string strSubject = "Vendor approved notification.";

            //MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["fromAddress"]);
            MailAddress fromAddress = new MailAddress("598754264@qq.com");
            // smtpClient.Host = ConfigurationManager.AppSettings["hostAddress"];
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;

            message.From = fromAddress;
            // To address collection of MailAddress
            message.To.Add(toEmailAddress);
            message.Subject = strSubject;
            message.IsBodyHtml = true;

            // Message body content
            message.Body = strMessageBody;
            // Send SMTP mail
            smtpClient.Send(message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private  string GetEmailBody(string userName)
    {
        try
        {
            string emailBody = string.Empty;
            System.Text.StringBuilder sbEmail = new System.Text.StringBuilder();
            sbEmail.Append("<table with='100%' cellpadding='2' cellspacing='2' border='0'>");
            sbEmail.Append("<tr><td>Dear " + userName + " sir,this is you email notification</td></tr>");
            sbEmail.Append("</table>");

            emailBody = sbEmail.ToString();

            return emailBody;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Send("598754264@qq.com", "lideng");
    }
}