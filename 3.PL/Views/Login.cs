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
using System.Net.Mail; // this namespace is required to send emails with SMTP
using System.Net;
namespace _3.PL.Views
{
    public partial class Login : Form
    {
        IQLNhanVienServices _iql;
        public Login()
        {
            InitializeComponent();
            _iql = new QLNhanVienServices();
            tbt_email.Text = Properties.Settings1.Default.user;
            tbt_password.Text = Properties.Settings1.Default.pass;
            cb_forget.Checked = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSignUp frm = new FrmSignUp();
            frm.ShowDialog();
        }
        void SaveInfor()
        {
            //if(cb_forget.Checked == false)
            //{
            //    Properties.Setting
            //}
            if (cb_forget.Checked == true)
            {
                Properties.Settings1.Default.user = tbt_email.Text;
                Properties.Settings1.Default.pass = tbt_password.Text;
                Properties.Settings1.Default.userlogined = tbt_email.Text;
                Properties.Settings1.Default.passlogined = tbt_password.Text;
                Properties.Settings1.Default.Save();

            }
            else
            {
                //Properties.Settings.Default.tk = "";
                //Properties.Settings.Default.mk = "";
                //Properties.Settings.Default.TKdaLogin = tbt_tk.Text;
                //Properties.Settings.Default.MKdaLogin = tbt_mk.Text;
                //Properties.Settings.Default.Save();
                Properties.Settings1.Default.user = "";
                Properties.Settings1.Default.pass = "";
                Properties.Settings1.Default.userlogined = tbt_email.Text;
                Properties.Settings1.Default.passlogined = tbt_password.Text;
                Properties.Settings1.Default.Save();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            var login = _iql.GetListNV().Where(c => c.Email == tbt_email.Text && c.Password == tbt_password.Text).FirstOrDefault();
            if(tbt_email.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                return;
            }
            if (tbt_password.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                return;
            }
            if (login != null)
            {
                SaveInfor();
                this.Hide();
                FrmMain frm = new FrmMain();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }

            
        }


        private void tbt_password_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbt_password.Text = "";
        }

        private void tbt_email_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbt_email.Text = "";
        }

        private void cb_forget_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmQuenMatKhau frm = new FrmQuenMatKhau();
            frm.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
