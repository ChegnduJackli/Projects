using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace GetAllFileName
{
    public partial class Form1 : Form
    {
        private string folderName;

        private string FilePath = GetAppFolder();
        private string FileName = string.Empty;
        private string Order_Asc = "Ascending ";
        private string Order_Desc = "Descending ";

        public Form1()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            this.cmbOrder.Items.Clear();
            this.cmbOrder.Items.Add(Order_Asc);
            this.cmbOrder.Items.Add(Order_Desc);
            this.cmbOrder.SelectedIndex = 0;
        }
        private void InitFile()
        {
            FileName = System.IO.Path.Combine(FilePath, @"Result.txt");
            if (System.IO.File.Exists(FileName))
            {
                System.IO.File.Delete(FileName);
            }
        }
        private static string GetAppFolder()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    folderName = folderBrowserDialog1.SelectedPath;

                    this.cmbFolder.Text = folderName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WriteList(List<string> list)
        {
            foreach (string s in list)
            {
                WriteFile(s);
            }
        }
        private void WriteFile(string str)
        {
            using (StreamWriter sw = new StreamWriter(FileName, true))
            {
                sw.WriteLine(str);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.lblMsg.Text = "";
            this.txtPath.Text = "";

            folderName = this.cmbFolder.Text.Trim();
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("Please select direcotry first.");
                return;
            }
            try
            {
                InitFile();
                DirectoryInfo d = new DirectoryInfo(folderName);
                FileInfo[] Files = d.GetFiles("*.*"); //Getting Text files

                List<string> fileList = new List<string>();
                foreach (FileInfo file in Files)
                {
                    fileList.Add(file.Name);
                }
                List<string> list = new List<string>();
                if (cmbOrder.Text == Order_Asc)
                {
                    list = fileList.OrderBy(p => p).ToList();
                }
                else
                {
                    list = fileList.OrderByDescending(p => p).ToList();
                }

                WriteList(list);

                lblMsg.Text = "Total "+list.Count+" filenames generate successfully.";
                if (list.Count > 0)
                {
                    txtPath.Text = FileName;
                }
                lblMsg.ForeColor = Color.Blue;
                label2.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (FileName.Length == 0)
            {
                MessageBox.Show("No file generated");
                return;
            }

            Process.Start("notepad.exe", FileName);
        }
    }
}
