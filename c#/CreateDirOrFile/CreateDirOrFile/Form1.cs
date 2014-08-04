using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateDirOrFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string filePath = this.txtPath.Text.Trim();
            if (filePath.Length == 0)
            {
                MessageBox.Show("please input path!");
                return;
            }

            try
            {
                //this is a file 
                if (filePath.IndexOf(".") > 0)
                {
                    string folder = Path.GetDirectoryName(filePath);

                    CreateFolder(folder);

                    CreateFile(filePath);
                }
                else //this is a directory
                {
                    CreateFolder(filePath);
                }
                MessageBox.Show("Create " + filePath + " succesfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
        }
        private void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
