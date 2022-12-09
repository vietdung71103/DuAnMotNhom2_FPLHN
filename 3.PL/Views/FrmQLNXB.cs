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
    public partial class FrmQLNXB : Form
    {
        IQLNXBServices _services;
        Guid _getID;
        public FrmQLNXB()
        {
            InitializeComponent();
            _services = new QLNXBServices();
            LoadData();
        }
        void ResetForm()
        {
            LoadData();

            tbt_ma.Text = "";
            tbt_ten.Text = "";
        }
        void LoadData()
        {
            dtg_show.Rows.Clear();
            dtg_show.ColumnCount = 4;
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã sách";
            dtg_show.Columns[3].Name = "Tên sách";
            foreach (var x in _services.GetListNXB())
            {
                dtg_show.Rows.Add(x.Id, stt++, x.Ma, x.Ten);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string VietHoaChuDau(string text)
        {
            var temp = text.ToLower();
            return temp.Substring(0, 1).ToUpper() + temp.Substring(1, temp.Length - 1);
        }
        private string MaSanPham(string ten)
        {
            string[] arrTen = ten.Split(' ');
            string ma = "SP_"; //VietHoaChuDau(arrTen[arrTen.Length - 1]);
            for (int i = 0; i < arrTen.Length; i++)
            {
                ma += VietHoaChuDau(arrTen[i]).Substring(0, 1);
            }
            Random rand = new Random();
            int z = rand.Next(1000, 9999);
            var so = z.ToString();
            return ma + so;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            int ma = _services.GetListNXB().Count + 1;
            if(tbt_ten.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_services.Add(new NXB()
                {
                    Ma = "MNXB0" +ma,
                    Ten = tbt_ten.Text
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
            if (tbt_ten.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                    foreach (var x in _services.GetListNXB().Where(c => c.Id == _getID))
                    {

                        x.Ten = tbt_ten.Text;
                        MessageBox.Show(_services.Update(x));
                        ResetForm();
                    }

                
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (tbt_ten.Text == "")
            {
                MessageBox.Show("Chưa nhập tên");
            }
            var xoa = _services.GetListNXB().Where(c => c.Id == _getID).FirstOrDefault();
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

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _services.GetListNXB().Count) return;
            _getID = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value));
            tbt_ma.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            tbt_ten.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
        }

        private void tbt_timkiem_TextChanged(object sender, EventArgs e)
        {
            dtg_show.Rows.Clear();
            dtg_show.ColumnCount = 4;
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã sách";
            dtg_show.Columns[3].Name = "Tên sách";
            foreach (var x in _services.GetListNXB().Where(c=>c.Ten.ToLower().Contains(tbt_timkiem.Text)))
            {
                dtg_show.Rows.Add(x.Id, stt++, x.Ma, x.Ten);
            }
        }
    }
}
