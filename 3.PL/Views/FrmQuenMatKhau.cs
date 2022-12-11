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
        private string haha = "Gửi mail Từ Phần Mềm quản lý cửa hàng bán sách mã xác nhận của bạn là:  ";
        private string hihi;
        private string a;
        private string tk;
        string code;
        public FrmQuenMatKhau()
        {
            InitializeComponent();
            _iql = new QLNhanVienServices();
            email = tk;
            _lst = new List<NhanVien>();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (tbt_mxn.Text == code)
            {
                if (tbt_mk.Text == tbt_nhaplaimk.Text)
                {
                    NhanVien nhanVien = _iql.GetListNV().Where(c => c.Email == tbt_email.Text).FirstOrDefault();
                    nhanVien.Password = tbt_mk.Text;
                    MessageBox.Show(_iql.Update(nhanVien));
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string from, pass, to;
                from = "dungnvph22426@fpt.edu.vn";
                pass = "duymanh123";
                to = tbt_email.Text;
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                code = ramdomMK();
                message.Body = haha + code;
                message.Subject = "Reset";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Đợi", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string ramdomMK()
        {
            Random r = new Random();
            var x = r.Next(0, 1000000);
            string s = x.ToString("000000");
            return s;
        }
        
    }
}
