using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace Wrox.ProCSharp.Threading
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BackgroundWorkerWindow : Window
    {
        //异步事件模式的一种方案
        private BackgroundWorker backgroundWorker;

        public BackgroundWorkerWindow()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            backgroundWorker.DoWork += OnDoWork;
            backgroundWorker.RunWorkerCompleted += OnWorkCompleted;
            backgroundWorker.ProgressChanged += OnProgessChanged;
        }

        private void OnCalculate(object sender, RoutedEventArgs e)
        {

            this.buttonCalculate.IsEnabled = false;
            this.textResult.Text = String.Empty;
            this.buttonCancel.IsEnabled = true;
            this.progressBar.Value = 0;
            //需要传递参数到OnDoWork方法中
            backgroundWorker.RunWorkerAsync(Tuple.Create(int.Parse(textX.Text), int.Parse(textY.Text)));
           
        
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            var t = e.Argument as Tuple<int, int>;

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                backgroundWorker.ReportProgress((i+1) * 10);
                if (backgroundWorker.CancellationPending) //判断是否取消任务
                {
                    e.Cancel = true;
                    return;
                }           
            }
            e.Result = t.Item1 + t.Item2;
        }
        //工作完成后自动触发这个事件
        //如果取消了任务，不能访问e.Result属性，会不抛出异常。所以必须判断是否有取消操作
        private void OnWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.textResult.Text = "Canceled";
            }
            else
            {
                this.textResult.Text = e.Result.ToString();
            }

            this.buttonCalculate.IsEnabled = true;
            this.buttonCancel.IsEnabled = false;
            this.progressBar.Value = 100;
        }

        private void OnProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            lblPercent.Content = this.progressBar.Value  +"%";
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.backgroundWorker.CancelAsync();
        }
    }
}
