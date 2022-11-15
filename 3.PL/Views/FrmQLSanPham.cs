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
    public partial class FrmQLSanPham : Form
    {
        FrmMain frm;
        public FrmQLSanPham()
        {
            InitializeComponent();
            frm = new FrmMain();
        }
        Form activeForm;
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelhome.Controls.Add(childForm);
            this.panelhome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();



        }
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLNXB(), sender);
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLTheLoai(), sender);
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLSach(), sender);
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLTacGia(), sender);
        }
    }
}
