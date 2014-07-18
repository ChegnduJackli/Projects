using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XMLSampleUse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTime.Text = "";
            DateTime dt1 = DateTime.Now;
            string fileName = "DatabaseConfig.xml";
            string node_DB = "DatabaseName";
            string node_Table = "TableName";
            XMLUtil xmlUtil = new XMLUtil();
            List<string> nodeList = new List<string>();
            string value = xmlUtil.GetValue(fileName, node_DB);

            this.textBox1.Text = value;

            nodeList = xmlUtil.GetList(fileName, node_Table);
            foreach (string s in nodeList)
            {
                this.richTextBox1.Text += s + "\r\n";
            }
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            txtTime.Text = ts.Milliseconds.ToString(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTime.Text = "";
            DateTime dt1 = DateTime.Now;
            XmlDocument _doc = new XmlDocument();
            string fileName = "DatabaseConfig.xml";
            _doc.Load(fileName);
            XmlNode node = _doc.SelectSingleNode("/Database/DatabaseName");
            this.textBox1.Text = node.InnerText;
            XmlNodeList nodeList = _doc.SelectNodes("/Database/TableName");
            //另一种方法，推荐使用上面一种
           // XmlNodeList nodeList = _doc.GetElementsByTagName("TableName");
            foreach (XmlNode n in nodeList)
            {
                this.richTextBox1.Text += n.InnerText+"\r\n";
            }
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            txtTime.Text = ts.Seconds.ToString(); 

        }
    }
}
