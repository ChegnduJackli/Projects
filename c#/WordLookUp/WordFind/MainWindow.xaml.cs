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

namespace WordFind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> languageList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BindDDL();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string txtFrom = this.txtWord.Text.Trim();
            if (txtFrom.Length == 0)
            {
                this.txtWord.Text = "Please input text to translate.";
                this.txtWord.Focus();
                this.txtWord.SelectAll();
                return;
            }
            string strTranslatedText = null;
            string languageFrom = this.LanguageFrom.SelectedValue.ToString();
            string languageTo = this.LanguageTo.SelectedValue.ToString() ;

            try
            {
                TranslatorServices.LanguageServiceClient client = new TranslatorServices.LanguageServiceClient();
                client = new TranslatorServices.LanguageServiceClient();
                strTranslatedText = client.Translate("6CE9C85A41571C050C379F60DA173D286384E0F2", txtFrom, languageFrom, languageTo);
                txtbResult.Text = strTranslatedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindDDL()
        {
            languageList = GetLanguageList();
            DataContext = this;
        }
        private List<string> GetLanguageList()
        {
            return new List<string> { "en", "zh-CHS","ja" };
        }
    }
}
