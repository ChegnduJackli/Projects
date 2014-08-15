using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using CoumnName;

namespace EnglishDictionary
{
    public partial class Dictionary : Form
    {
        DAL dataAccess = new DAL();

        public Dictionary()
        {
            InitializeComponent();
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
                if (dt.Rows.Count > 0)
                {
                    rtbContent.Text = dt.Rows[0][CoumnName.Words.DESCRIPTION].ToString();
                }
                else
                {
                    rtbContent.Text = "this word does not exist.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string words = this.txtWords.Text.Trim();
            if (words.Length == 0)
            {
                return;
            }
            try
            {

                Entity.WordsEntity word = new Entity.WordsEntity();
                word.Word = words;
                word.AddTime = DateTime.Now;
                word.Description = this.rtbContent.Text.Trim();

                DataTable dt = dataAccess.GetDescByWords(words);

                int result = 0;
                if (dt.Rows.Count > 0)
                {
                    string content = dt.Rows[0][CoumnName.Words.DESCRIPTION].ToString();
                    if (word.Description != content)
                    {
                        result = dataAccess.UpdateWord(word);
                    }
                }
                else
                {

                    result = dataAccess.AddWord(word);
                }

                if (result > 0)
                {
                    MessageBox.Show("Add or update successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 词库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllWords form = new AllWords();
            form.ShowDialog();
        }

        private void 背单词ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 文章库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
