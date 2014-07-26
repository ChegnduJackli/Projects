using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SQLTableBackup
{
    public partial class Form1 : Form
    {
        DAL.TableDAL tableDAL = new DAL.TableDAL();
        List<string> Target_Table_List = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.listSourceTable.DataSource = tableDAL.GetAllTableName();
        }
        //back up table
        private void btnBackup_Click(object sender, EventArgs e)
        {
            List<string> tableNameList = new List<string>();

            try
            {
                if (this.listTargetTable.Items.Count == 0)
                {
                    MessageBox.Show("Please select table first.");
                    return;
                }
                DialogResult d = MessageBox.Show("Are you sure you want to back up tables?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }

                
                foreach (string tb in this.listTargetTable.Items)
                {
                    if (!tableNameList.Contains(tb))
                    {
                        tableNameList.Add(tb);
                    }
                }
                tableDAL.BackUpTableList(tableNameList);
                MessageBox.Show("back up table successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        //restore table
        private void btnRestore_Click(object sender, EventArgs e)
        {

            List<string> tableNameList = new List<string>();

            try
            {
                if (this.listTargetTable.Items.Count == 0)
                {
                    MessageBox.Show("Please select table first.");
                    return;
                }

                DialogResult d = MessageBox.Show("Are you sure you want to restore tables?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }

                foreach (string table in this.listTargetTable.Items)
                {
                    if (!tableNameList.Contains(table))
                    {
                        tableNameList.Add(table);
                    }
                }

                tableDAL.RetoreDataTableList(tableNameList);

                MessageBox.Show("Restore tables successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        //from source to target
        private void btnToTarget_Click(object sender, EventArgs e)
        {
            var sourceItems = this.listSourceTable.SelectedItems;
            if (sourceItems.Count == 0)
            {
                MessageBox.Show("Please select table first.");
                return;
            }
            foreach( string tb in this.listSourceTable.SelectedItems)
            {
                if (!this.listTargetTable.Items.Contains(tb))
                {
                    Target_Table_List.Add(tb);
                }
            }
            SetTargetList();
        }
        //remove target
        private void btnRemoveTarget_Click(object sender, EventArgs e)
        {
            foreach (string tb in this.listTargetTable.SelectedItems)
            {
                Target_Table_List.Remove(tb);
            }
            SetTargetList();
        }
        //clear target tables
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            Target_Table_List.Clear();
            SetTargetList();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            Target_Table_List = tableDAL.GetAllTableName();
            SetTargetList();
        }

        private void SetTargetList()
        {
            this.listTargetTable.DataSource = null;
            this.listTargetTable.DataSource = Target_Table_List;
        }
        
    }
}
