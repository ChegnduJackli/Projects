using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        public delegate int CalcFibolaqi(int n);

        public Form1()
        {
            InitializeComponent();

            this.progressBar1.Maximum = 20;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Step = 1;
        
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.txtNumber.Text.Length == 0)
            {
                return;
            }
            int number = int.Parse(this.txtNumber.Text);
            this.progressBar1.Value = 0;
            this.txtResult.Text = string.Empty;
           // this.txtResult.Text = FibonacciRecursion(number).ToString();
            
            CalcFibolaqi c = FibonacciRecursion;
            IAsyncResult ar = c.BeginInvoke(number, null, null);
            while (!ar.IsCompleted)
            {
                for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++)
                {
                    this.progressBar1.Value = i;
                    Thread.Sleep(50);
                }
            }
            int result = c.EndInvoke(ar);
            this.txtResult.Text = result.ToString();
            /*
            MyThread mythread = new MyThread(number);
            mythread.Run();

            this.txtResult.Text = mythread.result.ToString();
             * */
            
        }
        delegate void updateTextBoxDelegate(string newText);
        private void UpdateTextBox(string newText)
        {
            if (txtResult.InvokeRequired)
            {
                updateTextBoxDelegate del = new updateTextBoxDelegate(UpdateTextBox);
                txtResult.Invoke(del, new object[] { newText });
            }
            else
            {
                txtResult.Text = newText;
            }
        }
        private void CaclCompleted(IAsyncResult ar)
        {
            //this.txtResult.Text;
            if (ar == null) throw new ArgumentNullException("ar");
            CalcFibolaqi c = ar.AsyncState as CalcFibolaqi;
            int result = c.EndInvoke(ar);
            //this.txtResult.Text = result.ToString();
            updateTextBoxDelegate d = UpdateTextBox;
            d(result.ToString());
        }
        //1，1，2，3，5，8，13，21。。。。。。。。。
        private  int FibonacciRecursion(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n must be > 0.");

            if (n == 1 || n == 2)
                return 1;

            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }
    }
    //试图用其他的方法
    class MyThread
    {
        private int number;
        public int result { get;set;}
        public MyThread(int n)
        {
            this.number = n;
        }
        public void Run()
        {
           result= FibonacciRecursion1(number);
        }
        private int FibonacciRecursion1(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n must be > 0.");

            if (n == 1 || n == 2)
                return 1;

            return FibonacciRecursion1(n - 1) + FibonacciRecursion1(n - 2);
        }
    }
}
