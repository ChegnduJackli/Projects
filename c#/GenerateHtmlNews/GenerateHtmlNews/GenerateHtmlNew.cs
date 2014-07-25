using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerateHtmlNews
{
    public class GenerateHtmlNew
    {
        public string Generate()
        {

            string htmlFileName = @"C:\Users\lideng\Desktop\GIT\Project\c#\GenerateHtmlNews\GenerateHtmlNews\Htmls\" + DateTime.Now.ToString("yyyyMMddhhMMss") + ".html";
            string filePath = @"C:\Users\lideng\Desktop\GIT\Project\c#\GenerateHtmlNews\GenerateHtmlNews\HtmlTemplate\NewsTemplate.htm";

            HtmlTemplate htmlTemplate = new HtmlTemplate();
            string text = @"A webservice will not be able to redirect on the page level since it's not a webpage.
                            The solution I have provided by using XSLT should work for your client. 
                            It's basically 2 URLs, one is the GetData.asmx as you described, 
                            the other one would be something like GetHtml.ashx?record=ABC, 
                            the handler is responsible to retrieve the XML data and transform into HTML string,
                            once it's done, it will create the HTML file type for your client to download. 
                            In this way you don't even need to save any static HTML files on your server.<img src='../Images/01.jpg' width='200' height='200'/>";
            string content = System.IO.File.ReadAllText(filePath);

            content = content.Replace(htmlTemplate.Title, "I am a good man");
            content = content.Replace(htmlTemplate.Author, "Jack");
            content = content.Replace(htmlTemplate.PublishedDate, DateTime.Now.ToString());
            content = content.Replace(htmlTemplate.Content, text);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(htmlFileName))
            {
                file.Write(content);
            }
            string html = string.Empty;

            return html;
        }
    }
    class HtmlTemplate
    {
        internal string Title = @"{@NewTitle}";
        internal string Author = "{@Author}";
        internal string PublishedDate = "{@Date}";
        internal string Content = "{@Content}";
    }
}