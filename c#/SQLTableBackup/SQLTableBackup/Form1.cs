using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                int success = 0;
                int error = 0;
                Log4.LogInstance.FileLogInstance().WriteLog("Begin to back up tables.");
                foreach (string tb in this.listTargetTable.Items)
                {
                    try
                    {
                        DataSet ds = tableDAL.GetTableData(tb);
                        string fileName = "Table/" + tb + ".xml";
                        ds.WriteXml(fileName, XmlWriteMode.IgnoreSchema);
                        Log4.LogInstance.FileLogInstance().WriteLog(tb);
                        success++;
                    }
                    catch(Exception ex)
                    {
                        Log4.LogInstance.FileLogInstance().ErrorLog(tb+" table back up failed");
                        Log4.LogInstance.FileLogInstance().ErrorLog(ex);
                        error++;
                    }
                }
                Log4.LogInstance.FileLogInstance().WriteLog("Success:" + success +"  "+ "Failed:" + error);

                if (error == 0)
                {
                    MessageBox.Show("Back up all tables successfully.");
                }
                else
                {
                    MessageBox.Show(string.Format("Have {0} tables back up failed,Please check error log",error));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }
        //restore table
        private void btnRestore_Click(object sender, EventArgs e)
        {
            bool result = false;
            int success = 0;
            int error = 0;

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

                Log4.LogInstance.FileLogInstance().WriteLog("Begin to Restore tables.");

                foreach (string table in this.listTargetTable.Items)
                {
                    //DataSet ds = tableDAL.GetTableData(tb);
                    try
                    {
                        DataSet ds = new DataSet(table);

                        string fileName = "Table/" + table + ".xml";
                        ds.ReadXml(fileName);
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            result = tableDAL.RetoreDataTable(table, ds.Tables[0]);
                        }
                        else
                        {
                            result = tableDAL.RetoreDataTable(table);
                        }
                        if (!result)
                        {
                            error++;
                            Log4.LogInstance.FileLogInstance().ErrorLog(table + "table restore failed");
                        }
                        else
                        {
                            success++;
                            Log4.LogInstance.FileLogInstance().WriteLog(table);
                        }
                    }
                    catch(Exception ex)
                    {
                        Log4.LogInstance.FileLogInstance().ErrorLog(table + "table restore failed");
                        Log4.LogInstance.FileLogInstance().ErrorLog(ex);
                        error++;
                    }
                }

                if (error == 0)
                {
                    MessageBox.Show("Restore all tables successfully.");
                }
                else
                {
                    MessageBox.Show(string.Format("Have {0} tables Restore failed,Please check error log", error));
                }

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
