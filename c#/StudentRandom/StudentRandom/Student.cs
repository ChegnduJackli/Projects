using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace StudentRandom
{
    public partial class Student : Form
    {
        Dictionary<int, string> stuList = new Dictionary<int, string>();
        DictionaryDAL dictionaryDAL = new DictionaryDAL();
        string fileName = "Student.txt";
        private Timer timer;

        public Student()
        {
            InitializeComponent();
          // this.txtName.ReadOnly = true;
           // this.txtID.ReadOnly = true;
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            //init list
            stuList.Clear();
            stuList = dictionaryDAL.GetStuList(fileName);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.txtID.Text = string.Empty;
            this.txtName.Text = string.Empty;
       
            try
            {
            
                int interval = ToInt(this.txtInterval.Text.Trim());
                timer = new Timer();
                timer.Interval = interval;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Enabled = true;
                timer.Start();

                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
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
            GetRandomKey();
        }

        private int ToInt(string value)
        {
            int i;
            if (Int32.TryParse(value, out i))
            {
                return i;
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
        }
    }
}
