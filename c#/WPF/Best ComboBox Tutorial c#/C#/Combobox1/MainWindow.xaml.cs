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

//http://www.cnblogs.com/lzhp/archive/2012/09/11/2673810.html
namespace Combobox1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person p;
        public MainWindow()
        {
            InitializeComponent();
            //p = new Person();
            //p.Age = Convert.ToInt32(txtAge.Text);
            ////准备binding 设置其源为刚刚创建的对象，并指定其访问路径为对象的Age字段，
            ////
            //Binding binding = new Binding();
            //binding.Source = p;
            //binding.Path = new PropertyPath("Age");

            this.txtAge.SetBinding(TextBox.TextProperty, 
                new Binding("Age") { Source =p= new Person() 
                {Age=Convert.ToInt32(this.txtAge.Text) } });
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            p.Age += 1;
        }
    }
}
