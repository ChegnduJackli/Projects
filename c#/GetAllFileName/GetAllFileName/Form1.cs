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
        private string Recursion_Y = "Yes";
        private string Recursion_N = "No";
        private List<string> fileList = new List<string>();
        private int FileCount = 0;
        private int DirCount = 1; //current directory is 1

        public Form1()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            this.cmbRecursion.Items.Clear();
            this.cmbRecursion.Items.Add(Recursion_N);
            this.cmbRecursion.Items.Add(Recursion_Y);
            this.cmbRecursion.SelectedIndex = 0;
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

            FileCount = 0;
            DirCount = 1;
            fileList.Clear();

            folderName = this.cmbFolder.Text.Trim();
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("Please select directory first.");
                return;
            }

            try
            {
                InitFile();
                //DirectoryInfo d = new DirectoryInfo(folderName);
                //FileInfo[] Files = d.GetFiles("*.*"); //Getting all files
        
                //foreach (FileInfo file in Files)
                //{
                //    fileList.Add(file.Name);
                //}
                //List<string> list = new List<string>();

                if (cmbRecursion.Text == Recursion_Y)
                {
                    GetFileNameByRecursion(folderName);
                }
                else
                {
                    GetFileNameByFolder(folderName);
                }

                WriteList(fileList);

                lblMsg.Text = "Total " + FileCount + " filenames generate successfully.";

                if (DirCount > 0)
                {
                    lblMsg.Text += "\n" + "Total " + DirCount + " directories generate successfully";
                }

                if (fileList.Count > 0)
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

        private void GetFileNameByFolder(string path)
        {
            DirectoryInfo d = new DirectoryInfo(folderName);
            FileInfo[] Files = d.GetFiles("*.*"); //Getting all files

            foreach (FileInfo file in Files)
            {
                fileList.Add(file.Name);
                FileCount++;
            }
        }

        private void GetFileNameByRecursion(string path)
        {

            if (Directory.Exists(path) == false) return ;

            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.*"); //Getting all files

            foreach (FileInfo file in Files)
            {
                fileList.Add(file.Name);
                FileCount++;
            }
            foreach (DirectoryInfo folder in d.GetDirectories())
            {
                fileList.Add(Environment.NewLine + folder.FullName.Replace(this.cmbFolder.Text.Trim(), ""));
                DirCount++;
                GetFileNameByRecursion(folder.FullName);
            }


            //string[] strFileNames = Directory.GetFiles(path);
            //string[] strDirectories = Directory.GetDirectories(path);

            //foreach (string filename in strFileNames)
            //{
            //    fileList.Add(filename);
            //}
            //foreach (string dir in strDirectories)
            //{
            //    fileList.Add(Environment.NewLine + dir.Replace(path,"\\"));
            //    GetFileNameByRecursion(dir);
            //}
        }
    }
}
