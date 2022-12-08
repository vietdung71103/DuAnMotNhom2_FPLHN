using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BUS.IServices;
using _1.DAL.Models;
using _2.BUS.Services;

namespace _3.PL.Views
{
    public partial class FrmQuenMatKhau : Form
    {
        IQLNhanVienServices _iql;
        string email;
        List<NhanVien> _lst;
        private string hemail = "duongnbph22612@fpt.edu.vn";
        private string haha = "Gửi mail Từ Phần Mềm quản lý cửa hàng bán sách";
        private string hihi;
        private string a;
        private string tk;
        public FrmQuenMatKhau()
        {
            InitializeComponent();
            _iql = new QLNhanVienServices();
            email = tk;
            _lst = new List<NhanVien>();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = _iql.GetListNV().Where(c=>c.Email == tbt_email.Text).Select(c=>c.Email).FirstOrDefault();
                if (nv == tbt_email.Text)
                {
                    email = tbt_email.Text;
                    a = ramdomMK();
                    hihi = "Mã xác nhận của bạn là: " + a;
                    guiMail(tbt_email.Text);
                    MessageBox.Show("Gửi email thành công", "Thông báo");
                    foreach (var x in _iql.GetListNV().Where(c => c.Email == tbt_email.Text))
                    {
                        x.Password = a;
                        _iql.Update(x);
                    }
                   
                   
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message), "Lỗi");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = _iql.GetListNV().Where(c => c.Email == email).Select(c => c.Password).FirstOrDefault();
                if(tbt_mxn.Text == nv)
                {
                    if(tbt_mk.Text == tbt_nhaplaimk.Text)
                    {
                        var nvn = _iql.GetListNV().Where(c => c.Email == tbt_email.Text);
                        foreach (var x in nvn)
                        {
                            
                            x.Password = tbt_nhaplaimk.Text;
                            _iql.Update(x);
                            MessageBox.Show("Đã đổi mật khẩu");
                            
                        }
                        Login frm = new Login();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu phải trùng nhau");
                    }
                }
                else
                {
                    MessageBox.Show("Mã xác nhận không chính xác");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Lỗi");
            }
        }
        public string ramdomMK()
        {
            Random r = new Random();
            var x = r.Next(0, 1000000);
            string s = x.ToString("000000");
            return s;
        }
        public void guiMail(string text)
        {
            MailMessage mess = new MailMessage(hemail, email, haha, hihi);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("huynqph22527@fpt.edu.vn", "huynq");
            client.Send(mess);
        }
    }
}
