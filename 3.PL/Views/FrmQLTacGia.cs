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

namespace _3.PL.Views
{
    public partial class FrmQLTacGia : Form
    {
        IQLTacGiaServices _iql;
        Guid _getID;
        public FrmQLTacGia()
        {
            InitializeComponent();
            _iql = new QLTacGiaServices();
            LoadData();

        }
        void LoadData()
        {
            dtg_show.ColumnCount = 4;
            dtg_show.Rows.Clear();
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible =false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã";
            dtg_show.Columns[3].Name = "Tên";
            foreach (var x in _iql.GetListTacGia())
            {
                dtg_show.Rows.Add(x.Id,stt++,x.Ma,x.Ten);
            }
        }
        void ResetForm()
        {
            LoadData();
            tbt_matg.Text = "";
            tbt_tentg.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbt_tentg.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            int ma = _iql.GetListTacGia().Count() + 1;
            DialogResult result = MessageBox.Show("Bạn có muốn thêm ?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                MessageBox.Show(_iql.Add(new TacGia()
                {
                    Ten = tbt_tentg.Text,
                    Ma = "TG0" +ma
                }));
                ResetForm();
            }
            else
            {
                return;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (tbt_tentg.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn sửa ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if(_iql.GetListTacGia().Any(c=>c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy!");
                }
                else
                {
                    foreach (var x in _iql.GetListTacGia().Where(c=>c.Id == _getID))
                    {
                        x.Ten = tbt_tentg.Text;
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var xoa = _iql.GetListTacGia().FirstOrDefault(c => c.Id == _getID);
            if (tbt_tentg.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_iql.GetListTacGia().Any(c => c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy!");
                }
                else
                {
                    foreach (var x in _iql.GetListTacGia().Where(c=>c.Id == _getID))
                    {
                        MessageBox.Show(_iql.Delete(xoa));
                        ResetForm();
                    }
                }
            }
            else
            {
                return;
            }
        }

      

        private void tbt_timkiem_TextChanged(object sender, EventArgs e)
        {
            dtg_show.ColumnCount = 4;
            dtg_show.Rows.Clear();
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã";
            dtg_show.Columns[3].Name = "Tên";
            foreach (var x in _iql.GetListTacGia().Where(c=>c.Ten.ToLower().Contains(tbt_timkiem.Text)))
            {
                dtg_show.Rows.Add(x.Id, stt++, x.Ma, x.Ten);
            }
        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _iql.GetListTacGia().Count) return;
            _getID = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value));
            tbt_matg.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            tbt_tentg.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
        }
    }
}
