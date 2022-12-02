using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace _3.PL.Views
{
    public partial class FrmQLSach : Form
    {
        IQLSachServices _services;

        Guid _getID;
        public FrmQLSach()
        {
            InitializeComponent();
            _services = new QLSachServices();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ResetForm()
        {
            LoadData();
           
            txt_masach.Text = "";
            txt_tensach.Text = "";
        }
        void LoadData() {
            dtg_show.Rows.Clear();
            dtg_show.ColumnCount = 4;
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã sách";
            dtg_show.Columns[3].Name = "Tên sách";
            foreach (var x in _services.GetListSach())
            {
                dtg_show.Rows.Add(x.Id, stt++, x.Ma, x.Ten);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(txt_tensach.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            int ma = _services.GetListSach().Count + 1;
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_services.Add(new Sach()
                {
                    Ma ="MS0" + ma ,
                    Ten = txt_tensach.Text
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
            
                 DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (_services.GetListSach().Any(c => c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy");
                }
                else
                {
                    foreach (var x in _services.GetListSach().Where(c => c.Id == _getID))
                    {

                        x.Ten = txt_tensach.Text;
                        MessageBox.Show(_services.Update(x));
                        ResetForm();
                    }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var xoa = _services.GetListSach().Where(c => c.Id == _getID).FirstOrDefault();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xoá ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_services.Delete(xoa));
                ResetForm();
            }
            else
            {
                return;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dtg_show.Rows.Clear();
            dtg_show.ColumnCount = 4;
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã sách";
            dtg_show.Columns[3].Name = "Tên sách";
            foreach (var x in _services.GetListSach().Where(c=>c.Ten.ToLower().Contains(txt_timkiem.Text)))
            {
                dtg_show.Rows.Add(x.Id, stt++, x.Ma, x.Ten);
            }
        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _services.GetListSach().Count) return;
            _getID = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value));
            txt_masach.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            txt_tensach.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
        }

        
    }
}
