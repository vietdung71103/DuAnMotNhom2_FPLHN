using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3.PL.Views
{
    public partial class FrmQLTheLoai : Form
    {
        IQLTheLoaiServices _iql;
        Guid _getID;
        public FrmQLTheLoai()
        {
            InitializeComponent();
            _iql = new QLTheLoaiServices();
            LoadData();
        }
        void LoadData()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Rows.Clear();
            int stt = 1;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "STT";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Name = "Ma";
            dataGridView1.Columns[3].Name = "Ten";
            foreach (var x in _iql.GetListTheLoai())
            {
                dataGridView1.Rows.Add(x.Id, stt++, x.Ma, x.Ten);
            }
        }
        void ResetForm()
        {
            LoadData();
            tbt_matl.Text = "";
            tbt_ten.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(tbt_ten.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                int ma = _iql.GetListTheLoai().Count + 1;
                MessageBox.Show(_iql.Add(new TheLoai()
                {
                    Ma = "TL0" + ma,
                    Ten = tbt_ten.Text
                }));
                ResetForm();
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbt_ten.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if(_iql.GetListTheLoai().Any(c=>c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy ");
                }
                else
                {
                    foreach (var x in _iql.GetListTheLoai().Where(c=>c.Id == _getID))
                    {
                        x.Ten =  tbt_ten.Text;
                        x.Ma = tbt_matl.Text;
                        MessageBox.Show(_iql.Update(x));
                        
                        ResetForm();
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbt_ten.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            var xoa = _iql.GetListTheLoai().FirstOrDefault(c => c.Id == _getID);
            DialogResult result = MessageBox.Show("Bạn có muốn xoá?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_iql.GetListTheLoai().Any(c => c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy ");
                }
                else
                {
                    foreach (var x in _iql.GetListTheLoai().Where(c => c.Id == _getID))
                    {
                        MessageBox.Show(_iql.Delete(xoa));
                    }
                    ResetForm();
                }
            }
            else
            {
                return;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 4;
            dataGridView1.Rows.Clear();
            int stt = 1;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "STT";
            dataGridView1.Columns[2].Name = "Ma";
            dataGridView1.Columns[3].Name = "Ten";
            foreach (var x in _iql.GetListTheLoai().Where(c=>c.Ten.ToLower().Contains(textBox5.Text)))
            {
                dataGridView1.Rows.Add(x.Id, stt++, x.Ma, x.Ten);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _iql.GetListTheLoai().Count) return;
            _getID = Guid.Parse(Convert.ToString(dataGridView1.Rows[rd].Cells[0].Value));
            tbt_matl.Text = Convert.ToString(dataGridView1.Rows[rd].Cells[2].Value);
            tbt_ten.Text = Convert.ToString(dataGridView1.Rows[rd].Cells[3].Value);
        }
    }
}
