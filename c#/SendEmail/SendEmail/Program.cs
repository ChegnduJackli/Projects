using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var client = new SmtpClient("smtp.gmail.com", 465)
                //{
                //    Credentials = new NetworkCredential("sgdagdtesting@gmail.com", "_pass110"),
                //    EnableSsl = true,

                //};
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
               client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sgdagdtesting@gmail.com", "_pass110");
                client.EnableSsl = true;
                // Set 25 port, if you want to use 587 port, please change 25 5o 587
                //  client.Port = 25;

                // detect SSL/TLS automatically

               // client.Send("sgdagdtesting@gmail.com", "sgdagdtesting@gmail.com", "test", "testbody");



                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add("sgdagdtesting@gmail.com");
                message.Subject = "This is the Subject line";
                message.From = new System.Net.Mail.MailAddress("sgdagdtesting@gmail.com");
                message.Body = "This is the message body";
                client.Send(message);


                Console.WriteLine("Sent");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
