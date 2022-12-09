namespace _3.PL.Views
{
    partial class NhapFileExcel
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
            this.dtg_show = new System.Windows.Forms.DataGridView();
            this.tbt_filename = new System.Windows.Forms.TextBox();
            this.btn_chonfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_imfe = new System.Windows.Forms.Button();
            this.btn_addtodb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_show
            // 
            this.dtg_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_show.Location = new System.Drawing.Point(0, 0);
            this.dtg_show.Name = "dtg_show";
            this.dtg_show.RowTemplate.Height = 25;
            this.dtg_show.Size = new System.Drawing.Size(1184, 539);
            this.dtg_show.TabIndex = 0;
            // 
            // tbt_filename
            // 
            this.tbt_filename.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbt_filename.Location = new System.Drawing.Point(114, 545);
            this.tbt_filename.Name = "tbt_filename";
            this.tbt_filename.Size = new System.Drawing.Size(871, 29);
            this.tbt_filename.TabIndex = 1;
            // 
            // btn_chonfile
            // 
            this.btn_chonfile.BackColor = System.Drawing.Color.White;
            this.btn_chonfile.Location = new System.Drawing.Point(991, 545);
            this.btn_chonfile.Name = "btn_chonfile";
            this.btn_chonfile.Size = new System.Drawing.Size(181, 29);
            this.btn_chonfile.TabIndex = 2;
            this.btn_chonfile.Text = "....";
            this.btn_chonfile.UseVisualStyleBackColor = false;
            this.btn_chonfile.Click += new System.EventHandler(this.btn_chonfile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 553);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên file:";
            // 
            // btn_imfe
            // 
            this.btn_imfe.BackColor = System.Drawing.Color.White;
            this.btn_imfe.Location = new System.Drawing.Point(991, 580);
            this.btn_imfe.Name = "btn_imfe";
            this.btn_imfe.Size = new System.Drawing.Size(181, 29);
            this.btn_imfe.TabIndex = 4;
            this.btn_imfe.Text = "Import file excel";
            this.btn_imfe.UseVisualStyleBackColor = false;
            this.btn_imfe.Click += new System.EventHandler(this.btn_imfe_Click);
            // 
            // btn_addtodb
            // 
            this.btn_addtodb.BackColor = System.Drawing.Color.White;
            this.btn_addtodb.Location = new System.Drawing.Point(991, 615);
            this.btn_addtodb.Name = "btn_addtodb";
            this.btn_addtodb.Size = new System.Drawing.Size(181, 29);
            this.btn_addtodb.TabIndex = 5;
            this.btn_addtodb.Text = "Add to database";
            this.btn_addtodb.UseVisualStyleBackColor = false;
            this.btn_addtodb.Click += new System.EventHandler(this.btn_addtodb_Click);
            // 
            // NhapFileExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btn_addtodb);
            this.Controls.Add(this.btn_imfe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_chonfile);
            this.Controls.Add(this.tbt_filename);
            this.Controls.Add(this.dtg_show);
            this.Name = "NhapFileExcel";
            this.Text = "NhapFileExcel";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_show;
        private System.Windows.Forms.TextBox tbt_filename;
        private System.Windows.Forms.Button btn_chonfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_imfe;
        private System.Windows.Forms.Button btn_addtodb;
    }
}