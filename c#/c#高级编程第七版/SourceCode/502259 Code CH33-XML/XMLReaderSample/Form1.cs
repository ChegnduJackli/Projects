#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

#endregion

//XmlReader读取文档的性能高
//XmlDocument要求内存比较多

namespace XMLSample
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //每个节点类型
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            //XmlReader是一个抽象类
            XmlReader rdr = XmlReader.Create("books.xml");
            while (rdr.Read())
            {
                richTextBox1.AppendText(rdr.NodeType.ToString() + "\r\n");
            }

        }
        //每个节点的名称
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                    richTextBox1.AppendText(rdr.Name + "\r\n");
            }
        }
        //每个节点的纯文本，不包括特性
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Text)
                    richTextBox1.AppendText(rdr.Value + "\r\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlCSVReader rdr = new XmlCSVReader("addresses.csv");
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Text)
                    richTextBox1.AppendText(rdr.Value + "\r\n");
            }
        }
        //rdr.ReadElementContentAsDecimal()
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    if (rdr.Name == "price")
                    {
                        decimal price = rdr.ReadElementContentAsDecimal(); //转换失败抛异常。这种转换方式效率比较高
                        //rdr.ReadElementContentAsDouble etc。有很多类似的。
                        richTextBox1.AppendText("Current Price = " + price + "\r\n");
                        price += price * (decimal).25;
                        richTextBox1.AppendText("New Price = " + price + "\r\n\r\n");
                    }
                    else if (rdr.Name == "title")
                        richTextBox1.AppendText(rdr.ReadElementContentAsString() + "\r\n");
                }
            }
        }
        // 读取纯文本<book>conent</book>
        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("books.xml");
            while (!rdr.EOF)
            {
                //if we hit an element type, try and load it in the listbox
                //if (rdr.MoveToContent() == XmlNodeType.Element && rdr.Name == "title")
                //{
                //    richTextBox1.AppendText(rdr.ReadElementString() + "\r\n");
                //}
                XmlNodeType xType = rdr.MoveToContent();
                if (xType == XmlNodeType.Element)
                {
                    LoadTextBox(rdr);
                }
                else
                {
                    //otherwise move on
                    rdr.Read();
                }
            }
        }

        private void LoadTextBox(XmlReader xdr)
        {

            try
            {
                //ReadElementString 读取纯文本<book>conent</book>
                //<book public='a' /> //这个不能读取，会抛异常
                richTextBox1.AppendText(xdr.ReadElementString() + "\r\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message + "\r\n");
            }
        }
        //特性
        //<book genre="autobiography" publicationdate="1991" ISBN="1-861003-11-0">
        //genre ='', 这个就是特性
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader tr = XmlReader.Create("books.xml");
            //Read in node at a time        
            while (tr.Read())
            {
                //check to see if it's a NodeType element
                //if (tr.NodeType == XmlNodeType.Element)
                if (tr.NodeType == XmlNodeType.Element && tr.HasAttributes)
                {
                    //if it's an element, then let's look at the attributes.
                    for (int i = 0; i < tr.AttributeCount; i++)
                    {
                        richTextBox1.AppendText(tr.GetAttribute(i) + "\r\n");
                    }
                }
            }
        }
        //xsd架构验证xml
        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, "books.xsd");
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(settings_ValidationEventHandler);
            XmlReader rdr = XmlReader.Create("books.xml", settings);
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Text)
                    richTextBox1.AppendText(rdr.Value + "\r\n");
            }
        }

        void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
        //创建新的xml，并且写入节点
        private void button9_Click(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            
            XmlWriter writer = XmlWriter.Create("newbook.xml", settings);
            writer.WriteStartDocument(); //从现在开始写入xml
            //Start creating elements and attributes
            writer.WriteStartElement("book");
            writer.WriteAttributeString("genre", "Mystery");
            writer.WriteAttributeString("publicationdate", "2001");
            writer.WriteAttributeString("ISBN", "123456789");
            writer.WriteElementString("title", "Case of the Missing Cookie");
            writer.WriteStartElement("author");
            writer.WriteElementString("name", "Cookie Monster");
            writer.WriteEndElement();
            writer.WriteElementString("price", "9.99");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            //clean up
            writer.Flush();
            writer.Close();
        }
    }
}