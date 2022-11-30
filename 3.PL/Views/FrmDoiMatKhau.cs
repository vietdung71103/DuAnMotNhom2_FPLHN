using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.Views
{
    public partial class FrmDoiMatKhau : Form
    {
        IQLNhanVienServices _iql;
        public FrmDoiMatKhau()
        {
            InitializeComponent();
            _iql = new QLNhanVienServices();   
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void Reset()
        {
            tbt_mkcu.Text = "";
            tbt_mkmoi.Text = "";
            tbt_nhaplaimkmoi.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dmk = _iql.GetListNV().Where(c => c.Email == Properties.Settings1.Default.userlogined).FirstOrDefault();
           // var cc = _iql.GetListNV().Where(c => c.Email == Properties.Settings1.Default.userlogined);
            if(tbt_mkcu.Text == "")
            {
                MessageBox.Show("Mật khẩu cũ chưa được nhập");
                return;
            }
            if (tbt_mkcu.Text != dmk.Password)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác");
                return;
            }
            if(tbt_mkcu.Text == dmk.Password)
            {
                if(tbt_mkmoi.Text == "")
                {
                    MessageBox.Show("Mời nhập mật khẩu mới");
                    return;
                }
                if (tbt_nhaplaimkmoi.Text == "")
                {
                    MessageBox.Show("Mời nhập lại mật khẩu mới");
                    return;
                }
                if(tbt_mkmoi.Text != tbt_nhaplaimkmoi.Text)
                {
                    MessageBox.Show("Mật khẩu mới không trùng nhau");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có muốn đổi mật khẩu?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    foreach (NhanVien x in _iql.GetListNV().Where(c => c.Email == Properties.Settings1.Default.userlogined))
                    {
                        x.Password = tbt_mkmoi.Text;
                        _iql.Update(x);
                        MessageBox.Show("Đổi mật khẩu thành công");
                        
                    }
                    Reset();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
