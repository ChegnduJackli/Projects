using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace EnglishDictionary
{
    public partial class AllWords : Form
    {
        DAL dataAccess = new DAL();
        public AllWords()
        {
            InitializeComponent();
        }

        private void AllWords_Load(object sender, EventArgs e)
        {
            BindGV();
        }
        private void BindGV()
        {
            DataTable dt = dataAccess.GetAllWords();
            this.dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string words = this.txtWords.Text.Trim();
            if (words.Length == 0)
            {
                return;
            }
            try
            {
                DataTable dt = dataAccess.GetDescByWords(words);
                this.dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            BindGV();
        }

    }
}
