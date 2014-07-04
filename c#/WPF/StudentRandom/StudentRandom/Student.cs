using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace StudentRandom
{
    public partial class Student : Form
    {
        Dictionary<int, string> stuList = new Dictionary<int, string>();
        DictionaryDAL dictionaryDAL = new DictionaryDAL();

         string fileName = string.Empty;

        private Timer timer;

        public Student()
        {
            InitializeComponent();
            // this.txtName.ReadOnly = true;
            // this.txtID.ReadOnly = true;

            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnStart.Focus();

        }
        private void Init()
        {
            fileName = ConfigurationManager.AppSettings["FileName"];
            stuList = dictionaryDAL.GetStuList(fileName);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.txtID.Text = string.Empty;
            this.txtName.Text = string.Empty;
       
            try
            {
                Init();
                int interval = ToInt(this.txtInterval.Text.Trim());
                timer = new Timer();
                timer.Interval = interval;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Enabled = true;
                timer.Start();

                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
                this.btnStop.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        void GetRandomKey()
        {
            Random rnd = new Random();

            List<int> keyList= stuList.Keys.ToList();
            int r = rnd.Next(keyList.Count);
            int indexKey = keyList[r];

            this.txtID.Text = indexKey.ToString();
            this.txtName.Text = stuList[indexKey];
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                GetRandomKey();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private int ToInt(string value)
        {
            int i;
            if (Int32.TryParse(value, out i))
            {
                if (i > 0)
                {
                    return i;
                }
                else
                {
                    throw new ApplicationException("Number should be greater than zero.");
                }
            }
            else
            {
                throw new ApplicationException("Invalid number");
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();

            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnStart.Focus();
        }
    }
}
