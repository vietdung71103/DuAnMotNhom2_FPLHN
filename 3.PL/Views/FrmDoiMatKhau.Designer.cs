namespace _3.PL.Views
{
    partial class FrmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoiMatKhau));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbt_mkmoi = new System.Windows.Forms.TextBox();
            this.tbt_mkcu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbt_nhaplaimkmoi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(58, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(55, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mật khẩu cũ:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(234, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 60);
            this.button1.TabIndex = 13;
            this.button1.Text = "Đổi mật khẩu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbt_mkmoi
            // 
            this.tbt_mkmoi.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbt_mkmoi.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbt_mkmoi.Location = new System.Drawing.Point(213, 110);
            this.tbt_mkmoi.Name = "tbt_mkmoi";
            this.tbt_mkmoi.PasswordChar = '*';
            this.tbt_mkmoi.Size = new System.Drawing.Size(290, 36);
            this.tbt_mkmoi.TabIndex = 10;
            this.tbt_mkmoi.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tbt_mkcu
            // 
            this.tbt_mkcu.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbt_mkcu.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbt_mkcu.Location = new System.Drawing.Point(213, 36);
            this.tbt_mkcu.Name = "tbt_mkcu";
            this.tbt_mkcu.Size = new System.Drawing.Size(290, 36);
            this.tbt_mkcu.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(58, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nhập lại mật khẩu mới:";
            // 
            // tbt_nhaplaimkmoi
            // 
            this.tbt_nhaplaimkmoi.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbt_nhaplaimkmoi.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbt_nhaplaimkmoi.Location = new System.Drawing.Point(213, 175);
            this.tbt_nhaplaimkmoi.Name = "tbt_nhaplaimkmoi";
            this.tbt_nhaplaimkmoi.PasswordChar = '*';
            this.tbt_nhaplaimkmoi.Size = new System.Drawing.Size(290, 36);
            this.tbt_nhaplaimkmoi.TabIndex = 16;
            // 
            // FrmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbt_nhaplaimkmoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbt_mkmoi);
            this.Controls.Add(this.tbt_mkcu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDoiMatKhau";
            this.Text = "FrmDoiMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbt_mkmoi;
        private System.Windows.Forms.TextBox tbt_mkcu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbt_nhaplaimkmoi;
    }
}