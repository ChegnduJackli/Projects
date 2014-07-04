using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Configuration;
using System.Timers;
using System.Windows.Threading;

namespace WordLookUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, string> stuList = new Dictionary<int, string>();
        DictionaryDAL dictionaryDAL = new DictionaryDAL();
        string fileName = string.Empty;
        private Timer timer;


        public MainWindow()
        {
            InitializeComponent();
            this.btnStart.IsEnabled = true;
            this.btnStop.IsEnabled = false;
            this.btnStart.Focus();
        }

        //private void btnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string words = this.txtWord.Text.Trim();
        //        if (words.Length == 0)
        //        {
        //            //MessageBox.Show("Please input word.");
        //            return;
        //        }
        //        this.txtbResult.Text = TranslateText(words);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //public string TranslateText(string input,string languagePair = "zh-CN|en")
        //{
        //    string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
        //    WebClient webClient = new WebClient();
        //    webClient.Encoding = System.Text.Encoding.UTF8;
        //    string result = webClient.DownloadString(url);
        //    result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
        //    result = result.Substring(result.IndexOf(">") + 1);
        //    result = result.Substring(0, result.IndexOf("</span>"));
        //    return result.Trim();
            
        //   // Translator
        //}
        private void Init()
        {
            fileName = ConfigurationManager.AppSettings["FileName"];
            stuList = dictionaryDAL.GetStuList(fileName);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this.txtID.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.LblResult.Text = string.Empty;

            try
            {
                Init();
                int interval = 20;
                timer = new Timer();
                timer.Interval = interval;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Start();

                this.btnStart.IsEnabled = false;
                this.btnStop.IsEnabled = true;
                this.btnStop.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Action action = delegate()
                {
                    GetRandomKey();
                };

                Dispatcher.Invoke(DispatcherPriority.Normal, action);
                // GetRandomKey();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetRandomKey()
        {
            Random rnd = new Random();
            List<int> keyList = stuList.Keys.ToList();
            int r = rnd.Next(keyList.Count);
            int indexKey = keyList[r];
            this.txtID.Text = indexKey.ToString();
            this.txtName.Text = stuList[indexKey];
        }


        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Dispose();

            this.btnStart.IsEnabled = true;
            this.btnStop.IsEnabled = false;
            this.btnStart.Focus();
            string result = "Congratulations" + Environment.NewLine;
            result += this.txtName.Text + " is choosed";
            LblResult.Text = result;
        }
    }
}
