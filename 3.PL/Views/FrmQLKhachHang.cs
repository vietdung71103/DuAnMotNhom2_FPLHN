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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3.PL.Views
{
    public partial class FrmQLKhachHang : Form
    {
        IQLKhachHangServices _iql;
        Guid _getID;
        public FrmQLKhachHang()
        {
            InitializeComponent();
            _iql = new QLKhachHangServices();
            LoadData();
            LoadCBB();
        }
        //public Guid Id { get; set; }
        //public string Ma { get; set; }
        //public string Ten { get; set; }
        //public string GioiTinh { get; set; }
        //public string DiaChi { get; set; }
        //public string Sdt { get; set; }
        //public DateTime NgaySinh { get; set; }
        void LoadCBB()
        {
            cbb_gioitinh.Items.Add("Nam");
            cbb_gioitinh.Items.Add("Nữ");
        }
        void ResetForm()
        {
            LoadData();
            tbt_makh.Text = "";
            tbt_tenkh.Text = "";
            tbt_sdt.Text = "";
            tbt_diachi.Text = "";
            cbb_gioitinh.Text = "";
         
        }

        void LoadData()
        {
            dtg_show.ColumnCount = 8;
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã khách hàng";
            dtg_show.Columns[3].Name = "Tên khách hàng";
            dtg_show.Columns[4].Name = "Giới tính";
            dtg_show.Columns[5].Name = "Địa chỉ";
            dtg_show.Columns[6].Name = "Sdt";
            dtg_show.Columns[7].Name = "Ngày sinh";
            dtg_show.Rows.Clear();
            foreach (var x in _iql.GetListKhachHang())
            {
                dtg_show.Rows.Add(x.Id, stt++, x.Ma, x.Ten, x.GioiTinh, x.DiaChi, x.Sdt, x.NgaySinh);
            }
        }
        private string VietHoaChuDau(string text)
        {
            var temp = text.ToLower();
            return temp.Substring(0, 1).ToUpper() + temp.Substring(1, temp.Length - 1);
        }
        private string MaKhachHang(string ten)
        {
            string[] arrTen = ten.Split(' ');
            string ma = "KH_"; //VietHoaChuDau(arrTen[arrTen.Length - 1]);
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
            //var ma = _iql.GetListKhachHang().Where(c => c.Ma == tbt_makh.Text);
            //if(ma != null)
            //{
            //    MessageBox.Show("Mã không được phép trùng");
            //    return;
            //}
            if (tbt_tenkh.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng");
                return;
            }
            if (tbt_tenkh.Text.Length < 8)
            {
                MessageBox.Show("Tên khách hàng phải có ít nhất 8 kí tự");
                return;
            }
            if (tbt_sdt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 kí tự");
                return;
            }
            if (!tbt_sdt.Text.All(char.IsNumber))
            {
                MessageBox.Show("Số điện thoại phải là số !");
                return;
            }
            if (cbb_gioitinh.Text == "")
            {
                MessageBox.Show("Phải chọn giới tính !");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {

                //int ma = _iql.GetListKhachHang().Count + 1;
                MessageBox.Show(_iql.Add(new KhachHang()
                {
                    Ma = MaKhachHang(tbt_tenkh.Text),
                    Ten = tbt_tenkh.Text,
                    GioiTinh = cbb_gioitinh.Text,
                    DiaChi = tbt_diachi.Text,
                    Sdt = tbt_sdt.Text,
                    NgaySinh = dtp_ngaysinh.Value

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
            DialogResult result = MessageBox.Show("Bạn có muốn sửa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if(_iql.GetListKhachHang().Any(c=>c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy");
                }
                else
                {
                    foreach (var x in _iql.GetListKhachHang().Where(c=>c.Id == _getID))
                    {
                        x.Ten = tbt_tenkh.Text;
                        x.GioiTinh = cbb_gioitinh.Text;
                        x.DiaChi = tbt_diachi.Text;
                        x.Sdt = tbt_sdt.Text;
                        x.NgaySinh = dtp_ngaysinh.Value;
                        MessageBox.Show(_iql.Update(x));
                    }
                    ResetForm();
                }
            }
            else
            {
                return;
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var xoa = _iql.GetListKhachHang().Where(c => c.Id == _getID).FirstOrDefault();
            DialogResult result = MessageBox.Show("Bạn có muốn xoá không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_iql.GetListKhachHang().Any(c => c.Id == _getID) == false)
                {
                    MessageBox.Show("Không tìm thấy");
                }
                else
                {
                    MessageBox.Show(_iql.Delete(xoa));
                    ResetForm();
                }
            }
        }

        private void tbt_timkiem_TextChanged(object sender, EventArgs e)
        {
            dtg_show.ColumnCount = 8;
            int stt = 1;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Mã khách hàng";
            dtg_show.Columns[3].Name = "Tên khách hàng";
            dtg_show.Columns[4].Name = "Giới tính";
            dtg_show.Columns[5].Name = "Địa chỉ";
            dtg_show.Columns[6].Name = "Sdt";
            dtg_show.Columns[7].Name = "Ngày sinh";
            dtg_show.Rows.Clear();
            foreach (var x in _iql.GetListKhachHang().Where(c=>c.Ten.ToLower().Contains(tbt_timkiem.Text)))
            {
                dtg_show.Rows.Add(x.Id, stt++, x.Ma, x.Ten, x.GioiTinh, x.DiaChi, x.Sdt, x.NgaySinh);
            }
        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 || rd >= _iql.GetListKhachHang().Count) return;
            _getID = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value));
            tbt_makh.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            tbt_tenkh.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
            cbb_gioitinh.Text = Convert.ToString(dtg_show.Rows[rd].Cells[4].Value);
            tbt_diachi.Text = Convert.ToString(dtg_show.Rows[rd].Cells[5].Value);
            tbt_sdt.Text = Convert.ToString(dtg_show.Rows[rd].Cells[6].Value);
            dtp_ngaysinh.Text = Convert.ToString(dtg_show.Rows[rd].Cells[7].Value);
        }
    }
}
