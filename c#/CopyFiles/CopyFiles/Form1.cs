using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CopyFiles
{
    public partial class Form1 : Form
    {
        string RootSourceFileName = string.Empty;

        int FileToTalCount = 0;
        int CurrentFileCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceFolderName = this.cmbFolderFrom.Text.Trim();
                string targetFolderName = this.cmbFolderTo.Text.Trim();
                if (sourceFolderName.Length == 0 || targetFolderName.Length == 0)
                    return;

                // If the destination directory doesn't exist, create it. 
                if (!Directory.Exists(targetFolderName))
                {
                    Directory.CreateDirectory(targetFolderName);
                }
                DirectoryInfo dirInfo = new DirectoryInfo(targetFolderName);
                Empty(dirInfo);

                RootSourceFileName = sourceFolderName;
                int fCount = Directory.GetFiles(sourceFolderName, "*", SearchOption.AllDirectories).Length;
                FileToTalCount = this.progressBar1.Maximum = fCount;
                this.progressBar1.Minimum = 0;
                CurrentFileCount = 0;

                if (sourceFolderName.Length > 0 && targetFolderName.Length > 0)
                {
                   // DirectoryCopy(sourceFolderName, targetFolderName);
                    Thread thread = new Thread(() => DirectoryCopy(sourceFolderName, targetFolderName));
                    thread.Start();
                }
                this.btnStart.Enabled = false;
               // MessageBox.Show("Congratulations,Copy Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }
        private void Empty(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        private void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();


            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            //CurrentFileCount += files.Length;

            foreach (FileInfo file in files)
            {
                string fileName = file.Name;
           
                if (sourceDirName != RootSourceFileName)
                {
                   string  temfileName = file.FullName.Replace(RootSourceFileName, "_").Replace("\\","_");
                   if (temfileName.StartsWith("_"))
                    {
                        fileName = temfileName.Substring(2);
                    }
                }
                string temppath = Path.Combine(destDirName, fileName);
                if (File.Exists(temppath)) File.Delete(temppath);
                file.CopyTo(temppath, true);

                CurrentFileCount++;
                ReportProgressBar();
            }

            // If copying subdirectories, copy them and their contents to new location. 
           // if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    //string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, destDirName);
                }
            }
        }
        private void ReportProgressBar()
        {
            if (this.progressBar1.Value <= this.progressBar1.Maximum)
            {
                //Thread.Sleep(100);
                this.Invoke(new Action(() => this.progressBar1.Value = CurrentFileCount));
                //this.Invoke(new Action(() => this.lblMsg.Text = (CurrentFileCount / FileToTalCount) * 100 + "%"));

                this.Invoke((MethodInvoker)delegate
                {
                    lblMsg.Text = ((int)((float)CurrentFileCount / (float)FileToTalCount * 100)).ToString() + "%Completed";
                });
                //lblMsg.Invoke(new MethodInvoker(delegate
                //    {
                //        lblMsg.Text = ((int)((float)CurrentFileCount / (float)FileToTalCount * 100)).ToString() + "%Completed";

                //    }));

                if (CurrentFileCount == FileToTalCount)
                {
                    MessageBox.Show("Copy Done!", "Info", MessageBoxButtons.OK);
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.btnStart.Enabled = true;
                    });

               
                }
            }
        }
    }
}
