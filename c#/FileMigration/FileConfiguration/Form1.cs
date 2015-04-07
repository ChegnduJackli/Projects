using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileConfiguration
{
    public partial class Form1 : Form
    {
        private string Flag_Upload = "@UPLOAD";
        private string Flag_DOWNLOAD = "@DOWNLOAD";

        private string SYSTEM_AGD = "AGD";
        private string SYSTEM_MBS = "MBS";
        private string SYSTEM_OSS = "OSS";
        private string SYSTEM_Helpdesk = "Helpdesk";
        private string SYSTEM_Vendors = "Vendors";
        private string SYSTEM_SR = "SR";
        private string SYSTEM_ASSB = "ASSB";

        string SB_Script = string.Empty;
        string Split_Flag = "==";


        private AutoCompleteStringCollection DataSource;

        public Form1()
        {
            InitializeComponent();
            LoadComponent();
        }
        public void LoadComponent()
        {
            combFlag.Items.Add(Flag_Upload);
            combFlag.Items.Add(Flag_DOWNLOAD);
            combFlag.SelectedIndex = 0;

            combSystem.Items.Add(SYSTEM_AGD);
            combSystem.Items.Add(SYSTEM_MBS);
            combSystem.Items.Add(SYSTEM_OSS);
            combSystem.Items.Add(SYSTEM_Helpdesk);
            combSystem.Items.Add(SYSTEM_Vendors);
            combSystem.Items.Add(SYSTEM_SR);
            combSystem.Items.Add(SYSTEM_ASSB);
            combSystem.SelectedIndex = 0;

            DataSource = FileHelper.ReadFileByLine(Common.DATA_SYSTEM_HELPDESK); 

            this.txtTemplate.Text = "#@Flag==Source file == PRD file == back up file. (@Date@ means parameters,with today date)";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string flag = this.combFlag.Text;
            string source = this.txtSource.Text.Trim();
            string prdFile = this.txtPRD.Text.Trim();
            string backUpFile = this.txtBackUp.Text.Trim();
            string sbAppend = rtbScript.Text.Trim();
          

            if ((flag ==Flag_Upload) && source.Length == 0 || prdFile.Length == 0 || backUpFile.Length == 0)
            {
                MessageBox.Show("Please input the field", "Information", MessageBoxButtons.OK);
                return;
            }
            else if (flag == Flag_DOWNLOAD && prdFile.Length == 0)
            {
                MessageBox.Show("Please input the prd field for download", "Information", MessageBoxButtons.OK);
                return;
            }
            if (flag == Flag_Upload)
            {
                SB_Script = Environment.NewLine+ flag + Split_Flag + source + Split_Flag + prdFile + Split_Flag + backUpFile;
            }
            else
            {
                SB_Script = Environment.NewLine + flag + Split_Flag + prdFile;
            }
            rtbScript.Text += SB_Script;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtbScript.Text.Length > 0)
                {
                    FileHelper.WriteFile(rtbScript.Text.Trim());

                    MessageBox.Show("Write file successfully.");
                }
                else
                {
                    MessageBox.Show("No data to write.");
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private void combSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSource = null;
            if (this.combSystem.Text == SYSTEM_Helpdesk)
            {
                DataSource = FileHelper.ReadFileByLine(Common.DATA_SYSTEM_HELPDESK); 
            }
            else if (this.combSystem.Text == SYSTEM_OSS)
            {
                DataSource = FileHelper.ReadFileByLine(Common.DATA_SYSTEM_OSS);
            }
            else if (this.combSystem.Text == SYSTEM_AGD)
            {
                DataSource = FileHelper.ReadFileByLine(Common.DATA_SYSTEM_AGD);
            }

            SetTextBoxDataSource(txtPRD);
        }
        private void SetTextBoxDataSource(TextBox tb)
        {
            tb.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb.AutoCompleteCustomSource = DataSource;
        }

        private void txtPRD_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPRD.Text.Length> 0)
            {
                string prdDirectory = System.IO.Path.GetDirectoryName(this.txtPRD.Text.Trim());
                string prdFileName = System.IO.Path.GetFileName(this.txtPRD.Text.Trim());
                this.txtBackUp.Text = prdDirectory + @"\backup\@Date\" + prdFileName;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtSource.Text = string.Empty;
            this.txtPRD.Text = string.Empty;
            this.txtBackUp.Text = string.Empty;
        }
    }


}
