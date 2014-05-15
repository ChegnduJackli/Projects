using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Account
{
    public partial class Form1 : Form
    {
        AccoutDAL accountDAL = new AccoutDAL();
        public Form1()
        {
            InitializeComponent();
            this.txtUser.Focus();
            this.lblMsg.Text = "";
            ShowTotal();
            BindData();
        }
        private void BindData()
        {
            decimal total = 0.00m;
            DataTable dt = accountDAL.GetAllAccount();
            this.dataGridView1.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dt.Rows[i][1]);
            }

            this.lblTotal.Text = total.ToString();

            //DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            //Deletelink.UseColumnTextForLinkValue = true;
            //Deletelink.HeaderText = "Delete";
            //Deletelink.DataPropertyName = "lnkColumn";
            //Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            //Deletelink.Text = "Delete";
            //dataGridView1.Columns.Add(Deletelink);
        }
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUser.Text.Trim().Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.txtAmount.Focus();
                    this.lblMsg.Text = "";
                }
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtAmount.Text.Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (IsDouble(this.txtAmount.Text.Trim()))
                    {
                        this.txtDesc.Focus();
                    }
                }
            }
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            string user = this.txtUser.Text.Trim();
            string desc = this.txtDesc.Text.Trim();
            string sAmount = this.txtAmount.Text.Trim();
            if (user.Length == 0 || sAmount.Length == 0)
            {
                this.lblMsg.Text = "请填写信息.";
                this.lblMsg.ForeColor = Color.Red;
                return;
            }
            if (!IsDouble(sAmount))
            {
                this.lblMsg.Text = "数目须为数字.";
                this.lblMsg.ForeColor = Color.Red;
                return;
            }
            try
            {
                double amount = Convert.ToDouble(sAmount);

                if (accountDAL.AddAccount(user, amount, desc))
                {
                    this.lblMsg.Text = "添加成功";
                    this.txtUser.Focus();
                    Clear();
                    BindData();
                }
            }
            catch (Exception ex)
            {
                this.txtUser.Focus();
                this.txtUser.SelectAll();
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            this.txtUser.Text = "";
            this.txtAmount.Text = "";
            this.txtDesc.Text = "";
        }

        private bool IsDouble(string value)
        {
            double defaultValue = 0.00;
            if (Double.TryParse(value, out defaultValue))
            {
                return true;
            }
            return false;
        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex ==-1)
        //    {
        //        return;
        //    }

        //    object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //    if (value is DBNull) { return; }
        //    if (value.ToString() == "Delete")
        //    {
        //        string userName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //        //弹出提示窗口，点击确定则删除数据，否则取消。
        //        DialogResult showup = MessageBox.Show(userName+" 您确定要删除吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        //        //下面判断点击确认后，是否有异常，如果有异常则显示添加数据不成功。
        //        if (showup == DialogResult.OK)
        //        {
        //            try
        //            {
        //                if (accountDAL.DeleteAccount(userName))
        //                {
        //                    MessageBox.Show("已成功删除您选择的数据！");
        //                    BindData();
        //                }
        //            }
        //            catch
        //            {
        //                MessageBox.Show("对不起，未成功删除数据！");
        //            }
        //        }
        //    }
        //}

        private void ChkShow_CheckedChanged(object sender, EventArgs e)
        {
            ShowTotal();
        }
        private void ShowTotal()
        {
            if (this.ChkShow.Checked)
            {
                this.lblTotal.Visible = true;
                this.label4.Visible = true;
            }
            else
            {
                this.lblTotal.Visible = false;
                this.label4.Visible = false;
            }
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null || dataGridView1.CurrentRow == null)
            {
                return;
            }
            if (this.dataGridView1.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("确定删除选中的记录? ", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        int icount = 0;
                        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                        {
                            string userName = row.Cells[1].Value.ToString();
                            if (accountDAL.DeleteAccount(userName))
                            {
                                icount++;
                            }
                        }
                        MessageBox.Show("已成功删除"+icount+"条数据！");
                        BindData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "提示");
                    }  
                }
            }
        }
    }
}
