using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreeTimer
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
         int alarmCounter = 1;
        bool exitFlag = false;
        public Form1()
        {
            InitializeComponent();
        }
        int num = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
           //this.label1.Text = (++num).ToString();
            //Thread.Sleep(3000);

            timer1.Stop();

            // Displays a message box asking whether to continue running the timer.
            if (MessageBox.Show("Continue running?", "Count is: " + alarmCounter,
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Restarts the timer and increments the counter.
                alarmCounter += 1;
                timer1.Enabled = true;
                this.label1.Text = alarmCounter.ToString();
            }
            else
            {
                // Stops the timer.
                exitFlag = true;
                this.timer1.Stop();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.label1.Text = "Game Over";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);
            //timer1.Tick += timer1_Tick; //跟上面同样效果

            timer1.Start();

            // Runs the timer, and raises the event.
            //while (exitFlag == false)
            //{
            //    // Processes all the events in the queue.
            //    Application.DoEvents();
            //    //timer1.Dispose();
            //    this.label1.Text = "Game Over";
            //}
        }
    }
}
