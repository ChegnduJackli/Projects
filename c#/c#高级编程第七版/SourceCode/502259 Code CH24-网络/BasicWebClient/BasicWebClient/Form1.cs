using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;
using System;

namespace BasicWebClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();

            System.Net.WebClient client = new WebClient();
            Stream strm = client.OpenRead("http://www.reuters.com");
            StreamReader sr = new StreamReader(strm);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }

            strm.Close();
        }

        private void btnWebRequest_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            WebRequest wrq = WebRequest.Create("http://www.reuters.com");
            WebResponse wrs = wrq.GetResponse();
            Stream strm = wrs.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }
            strm.Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            WebRequest wrq = WebRequest.Create("http://www.reuters.com");
            HttpWebRequest hwrq = (HttpWebRequest)wrq;
            listBox1.Items.Add("Request Timeout (ms)=" + wrq.Timeout);
            listBox1.Items.Add("Request Keep Alive (ms)=" + hwrq.KeepAlive);
            listBox1.Items.Add("Request AllowAutoRedirect (ms)=" + hwrq.AllowAutoRedirect); ;

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();

            WebRequest wrq = WebRequest.Create("http://www.reuters.com");
            NetworkCredential myCred = new NetworkCredential("userName", "password");
            wrq.Credentials = myCred;
            WebResponse wrs = wrq.GetResponse();
            WebHeaderCollection whc = wrs.Headers;
            for (int i = 0; i < whc.Count; i++)
            {
                listBox1.Items.Add(string.Format("Header {0}:{1}", whc.GetKey(i), whc[i]));
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            WebRequest wrq = WebRequest.Create("http://www.reuters.com");
            wrq.BeginGetResponse(new System.AsyncCallback(OnResponse), wrq);
        }
        private void OnResponse(System.IAsyncResult ar)
        {
            listBox1.Items.Clear();
            string data = string.Empty;

            try
            {
                HttpWebRequest myrequest = (HttpWebRequest)ar.AsyncState;
                using (HttpWebResponse response = (HttpWebResponse)myrequest.EndGetResponse(ar))
                {
                    System.IO.Stream responseStream = response.GetResponseStream();
                    using (var reader = new System.IO.StreamReader(responseStream))
                    {
                        data = reader.ReadToEnd();
                    }
                    responseStream.Close();
                }
                listBox1.Items.Add(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}