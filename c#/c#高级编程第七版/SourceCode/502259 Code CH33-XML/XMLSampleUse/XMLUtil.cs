using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLSampleUse
{
    public class XMLUtil
    {
        //方法一
        public List<string> GetList(string filePath,string nodeRoot)
        {
            List<string> _nodeList = new List<string>();
            XmlReader reader = XmlReader.Create(filePath);
            while (!reader.EOF)
            {
                //if (reader.NodeType == XmlNodeType.Element && reader.Name==nodeRoot)
                //{
                //    _nodeList.Add(reader.Value);
                //}
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == nodeRoot)
                {
                    _nodeList.Add(reader.ReadElementString());
                }
                else
                {
                    //otherwise move on
                    reader.Read();
                }
            }
            return _nodeList;
        }
        public string GetValue(string filePath,string nodeRoot)
        {
            string nodeValue = string.Empty;
            XmlReader reader = XmlReader.Create(filePath);
            while (!reader.EOF)
            {
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == nodeRoot)
                {
                    nodeValue = reader.ReadElementString();
                    break;
                }
                else
                {
                    //otherwise move on
                    reader.Read();
                }
            }
            return nodeValue;
        }

        //方法二
        public List<string> GetNodeList(string filePath, string nodeRoot)
        {
            List<string> _nodeList = new List<string>();

            return _nodeList;
        }
    }
}
