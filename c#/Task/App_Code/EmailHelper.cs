using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Net.Mail;

/// <summary>
/// Summary description for EmailHelper
/// </summary>
public class EmailHelper
{
	public EmailHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public static void SendEmail(string fromUser,List<string> EmailTolist,string bodyMessage)
    {
        try
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            //client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("", "");

            MailAddress from = new MailAddress("lideng@ncs.com.sg");
            MailMessage message = new MailMessage();
            message.From = from;

            foreach (string email in EmailTolist)
            {
                message.To.Add(new MailAddress(email));
            } 
            message.Body = "Date: " + DateTime.Now.ToShortDateString() + "<br />" + "<br />"; ;
            message.Body += bodyMessage;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            
            client.Send(message);
            message.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}