using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace MessageEntity
{
    public class Message
    {
        private readonly string userName;
        private readonly string content;
        private readonly DateTime postDate;

        public Message(string userName, string content)
        {
            this.userName = userName;
            this.content = content;
            this.postDate = DateTime.Now;
        }
        public string UserName
        {
            get { return userName; }
        }

        public string Content
        {
            get { return content; }
        }

        public DateTime PostDate
        {
            get { return postDate; }
        }

        public override string ToString()
        {
            return String.Format("{0}[{1}]：\r\n{2}\r\n", userName, postDate, content);
        }
    }

    public class StateObject
    {
        public Socket workSocket = null;
        public const int BUFFER_SIZE = 1024;
        public byte[] buffer = new byte[BUFFER_SIZE];
        public StringBuilder sb = new StringBuilder();
    }
}
