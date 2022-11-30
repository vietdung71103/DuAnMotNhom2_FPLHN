namespace _3.PL.Views
{
    partial class FrmQLKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQLKhachHang));
            this.label9 = new System.Windows.Forms.Label();
            this.tbt_sdt = new System.Windows.Forms.TextBox();
            this.tbt_diachi = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbt_timkiem = new System.Windows.Forms.TextBox();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.cbb_gioitinh = new System.Windows.Forms.ComboBox();
            this.tbt_tenkh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtg_show = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbt_makh = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_loc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(419, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "Lọc:";
            // 
            // tbt_sdt
            // 
            this.tbt_sdt.Location = new System.Drawing.Point(178, 269);
            this.tbt_sdt.Name = "tbt_sdt";
            this.tbt_sdt.Size = new System.Drawing.Size(395, 30);
            this.tbt_sdt.TabIndex = 11;
            // 
            // tbt_diachi
            // 
            this.tbt_diachi.Location = new System.Drawing.Point(178, 212);
            this.tbt_diachi.Name = "tbt_diachi";
            this.tbt_diachi.Size = new System.Drawing.Size(395, 30);
            this.tbt_diachi.TabIndex = 10;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // tbt_timkiem
            // 
            this.tbt_timkiem.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbt_timkiem.Location = new System.Drawing.Point(56, 35);
            this.tbt_timkiem.Name = "tbt_timkiem";
            this.tbt_timkiem.Size = new System.Drawing.Size(302, 27);
            this.tbt_timkiem.TabIndex = 18;
            this.tbt_timkiem.TextChanged += new System.EventHandler(this.tbt_timkiem_TextChanged);
            // 
            // btn_sua
            // 
            this.btn_sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sua.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_sua.Image")));
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(886, 29);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(156, 36);
            this.btn_sua.TabIndex = 3;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xoa.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_xoa.Image")));
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(1059, 29);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(156, 36);
            this.btn_xoa.TabIndex = 2;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // cbb_gioitinh
            // 
            this.cbb_gioitinh.FormattingEnabled = true;
            this.cbb_gioitinh.Location = new System.Drawing.Point(178, 153);
            this.cbb_gioitinh.Name = "cbb_gioitinh";
            this.cbb_gioitinh.Size = new System.Drawing.Size(214, 31);
            this.cbb_gioitinh.TabIndex = 9;
            // 
            // tbt_tenkh
            // 
            this.tbt_tenkh.Location = new System.Drawing.Point(178, 101);
            this.tbt_tenkh.Name = "tbt_tenkh";
            this.tbt_tenkh.Size = new System.Drawing.Size(395, 30);
            this.tbt_tenkh.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Số điện thoại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tên khách hàng:";
            // 
            // dtg_show
            // 
            this.dtg_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_show.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtg_show.Location = new System.Drawing.Point(3, 71);
            this.dtg_show.Name = "dtg_show";
            this.dtg_show.RowTemplate.Height = 25;
            this.dtg_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_show.Size = new System.Drawing.Size(1218, 223);
            this.dtg_show.TabIndex = 0;
            this.dtg_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_show_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Giới tính:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã khách hàng;";
            // 
            // tbt_makh
            // 
            this.tbt_makh.Location = new System.Drawing.Point(178, 47);
            this.tbt_makh.Name = "tbt_makh";
            this.tbt_makh.Size = new System.Drawing.Size(310, 30);
            this.tbt_makh.TabIndex = 0;
            // 
            // btn_them
            // 
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_them.Image = ((System.Drawing.Image)(resources.GetObject("btn_them.Image")));
            this.btn_them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_them.Location = new System.Drawing.Point(711, 29);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(156, 36);
            this.btn_them.TabIndex = 1;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbb_loc);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.tbt_timkiem);
            this.groupBox2.Controls.Add(this.btn_sua);
            this.groupBox2.Controls.Add(this.btn_xoa);
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Controls.Add(this.dtg_show);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(0, 389);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1224, 297);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hiển thị";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_ngaysinh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbt_sdt);
            this.groupBox1.Controls.Add(this.tbt_diachi);
            this.groupBox1.Controls.Add(this.cbb_gioitinh);
            this.groupBox1.Controls.Add(this.tbt_tenkh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbt_makh);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1224, 385);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // dtp_ngaysinh
            // 
            this.dtp_ngaysinh.Location = new System.Drawing.Point(178, 322);
            this.dtp_ngaysinh.Name = "dtp_ngaysinh";
            this.dtp_ngaysinh.Size = new System.Drawing.Size(275, 30);
            this.dtp_ngaysinh.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ngày sinh:";
            // 
            // cbb_loc
            // 
            this.cbb_loc.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbb_loc.FormattingEnabled = true;
            this.cbb_loc.Location = new System.Drawing.Point(459, 35);
            this.cbb_loc.Name = "cbb_loc";
            this.cbb_loc.Size = new System.Drawing.Size(191, 27);
            this.cbb_loc.TabIndex = 20;
            // 
            // FrmQLKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 685);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmQLKhachHang";
            this.Text = "FrmQLKhachHang";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbt_sdt;
        private System.Windows.Forms.TextBox tbt_diachi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbt_timkiem;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.ComboBox cbb_gioitinh;
        private System.Windows.Forms.TextBox tbt_tenkh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtg_show;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbt_makh;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_ngaysinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_loc;
    }
}