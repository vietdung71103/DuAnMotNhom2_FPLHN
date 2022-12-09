using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.Views
{
    public partial class NhapFileExcel : Form
    {
        IQLSanPhamServices _iqlSP;
        IQLNXBServices _iqlNXB;
        IQLTacGiaServices _iqlTG;
        IQLSachServices _iqlSach;
        IQLTheLoaiServices _iqlTL;
        SachChiTiet sp;
        TacGia tg;
        NXB nxb;
        TheLoai tl;
        Sach sach;
        private Guid Ids;
        private Guid IdSachs;
        private Guid IdTacGias;
        private Guid IdTheLoais;
        private Guid IdNXBs;
        private string Anhs ="";
        private string Mas = "";
        private string MoTas = "";
        private decimal GiaNhaps;
        private decimal GiaBans;
        private int SoLuongTons;
        private int SoTrangs;
        public NhapFileExcel()
        {
            InitializeComponent();
            _iqlTL = new QLTheLoaiServices();
            _iqlSach = new QLSachServices();
            _iqlSP = new QLSanPhamServices();
            _iqlNXB = new QLNXBServices();
            _iqlTL = new QLTheLoaiServices();
            tg = new TacGia();
            tl = new TheLoai();
            nxb = new NXB();
            sach = new Sach();
            sp = new SachChiTiet();
        }

        private void cbb_sheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_chonfile_Click(object sender, EventArgs e)
        {
            //using(OpenFileDialog opd = new OpenFileDialog() { Filter= "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            //{
            //    if(opd.ShowDialog() == DialogResult.OK)
            //    {
            //        tbt_filename.Text = opd.FileName;
            //        using(var stream = File.Open(opd.FileName,FileMode.Open,FileAccess.Read))
            //        {
            //            using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            //            {
            //                DataSet result = reader.AsDataSet(new ExcelReaderConfiguration() { 
            //                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration

            //                })
            //            }
            //        }
            //    }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.FileName = tbt_filename.Text;
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbt_filename.Text = openFileDialog.FileName;
            }
        }

        private void btn_imfe_Click(object sender, EventArgs e)
        {
            if(tbt_filename.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn file excel");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn import file excel không", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + tbt_filename.Text + "';Extended Properties=Excel 12.0 Xml;");
                conn.Open();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("Select * from[Sheet1$]", conn);
                DataSet theSD = new DataSet();
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (dt.Columns.Count != 12)
                {
                    MessageBox.Show("File bạn chọn sai định dạng nên không import được", "Thông Báo");
                    tbt_filename.Text = "";
                    return;
                }
                this.dtg_show.DataSource = dt.DefaultView;
                for (int i = 0; i < dtg_show.Rows.Count; i++)
                {
                    //dtg_show.Columns[0].Name = "ID";
                    //dtg_show.Columns[0].Visible = false;
                    //dtg_show.Columns[1].Name = "STT";
                    //dtg_show.Columns[2].Name = "Mã";
                    //dtg_show.Columns[3].Name = "Sách";
                    //dtg_show.Columns[4].Name = "Tác giả";
                    //dtg_show.Columns[5].Name = "Thể loại";
                    //dtg_show.Columns[6].Name = "Nhà xuất bản";
                    ////dtg_show.Columns[6].Name = "Ảnh";
                    //dtg_show.Columns[7].Name = "Mô tả";
                    //dtg_show.Columns[8].Name = "Giá nhập";
                    //dtg_show.Columns[9].Name = "Giá bán";
                    //dtg_show.Columns[10].Name = "Số lượng tồn";
                    //dtg_show.Columns[11].Name = "Số trang";
                  
                    try
                    {
                        //NXB
                        bool index = _iqlNXB.GetListNXB().Any(c => c.Id == Guid.Parse(Convert.ToString( dtg_show.Rows[i].Cells[6].Value)));
                        if (index == false)
                        {
                            nxb.Id = Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[6].Value));
                            _iqlNXB.Add(nxb);
                          
                        }
                        //TacGia
                        bool index1 = _iqlTG.GetListTacGia().Any(c => c.Id == Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[4].Value)));
                        if (index1 == false)
                        {
                            tg.Id = Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[4].Value));
                            _iqlTG.Add(tg);

                        }
                        //Sach
                        bool index2 = _iqlSach.GetListSach().Any(c => c.Id == Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[3].Value)));
                        if (index2 == false)
                        {
                            sach.Id = Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[3].Value));
                            _iqlSach.Add(sach);
                        }
                        //TheLoai
                        bool index3 = _iqlTL.GetListTheLoai().Any(c => c.Id == Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[5].Value)));
                        if (index3 == false)
                        {
                            tl.Id = Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[5].Value));
                            _iqlTL.Add(tl);
                        }


                    }
                    catch (Exception b)
                    {

                        MessageBox.Show(Convert.ToString(b.Message), "Thông Báo");
                        return;
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    MessageBox.Show("Import thành công");
                }
                return;
            }
            if(result == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {
                    MessageBox.Show("Import thất bại");
                }
                return;
            

        }


    }

        private void btn_addtodb_Click(object sender, EventArgs e)
        {
            if (tbt_filename.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn file excel");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn thêm các sản phẩm ở file excel vào database không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < dtg_show.Rows.Count; i++)
                {
        //             private Guid Id;
        //private Guid IdSach;
        //private Guid IdTacGia;
        //private Guid IdTheLoai;
        //private Guid IdNXB;
        //private string Anh = "";
        //private string Ma = "";
        //private string MoTa = "";
        //private decimal GiaNhap;
        //private decimal GiaBan;
        //private int SoLuongTon;
        //private int SoTrang;
                    try
                    {
                        Ids = Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[0].Value));
                        Mas = Convert.ToString(dtg_show.Rows[i].Cells[1].Value);
                        IdSachs = Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[2].Value));
                        IdTacGias= Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[3].Value));
                        IdTheLoais= Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[4].Value));
                        IdNXBs = Guid.Parse(Convert.ToString(dtg_show.Rows[i].Cells[5].Value));
                        Anhs= Convert.ToString(dtg_show.Rows[i].Cells[6].Value);
                        MoTas = Convert.ToString(dtg_show.Rows[i].Cells[7].Value);
                        GiaNhaps = Convert.ToDecimal(dtg_show.Rows[i].Cells[8].Value);
                        GiaBans = Convert.ToDecimal(dtg_show.Rows[i].Cells[9].Value);
                        SoLuongTons = Convert.ToInt32(dtg_show.Rows[i].Cells[10].Value);
                       SoTrangs = Convert.ToInt32(dtg_show.Rows[i].Cells[11].Value);
                        var sct = new SachChiTiet()
                        {
                            Id = Ids,
                            Ma = Mas,
                            IdSach = IdSachs,
                            IdNXB = IdNXBs,
                            IdTacGia = IdTacGias,
                            IdTheLoai = IdTheLoais,
                            Anh = Anhs,
                            MoTa = MoTas,
                            GiaNhap = GiaNhaps,
                            GiaBan = GiaBans,
                            SoLuongTon = SoLuongTons,
                            SoTrang = SoTrangs

                        };
                        _iqlSP.Add(sct);
                        }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Convert.ToString(ex.Message), "Thông Báo");
                        return;
                    }
                }
                MessageBox.Show("Import thành công");
                return;
     
            }
            if(result == DialogResult.No)
            {
                return;
            }
        }
    }
}
