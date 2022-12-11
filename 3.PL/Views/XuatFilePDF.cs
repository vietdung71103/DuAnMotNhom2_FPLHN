using _2.BUS.IServices;
using _2.BUS.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.Views
{
    public partial class XuatFilePDF : Form
    {
        IQLSanPhamServices _iqlSP;

        public XuatFilePDF()
        {
            InitializeComponent();
            _iqlSP = new QLSanPhamServices();
            LoadData();
        }
    
            void LoadData()
            {
                dtg_show.ColumnCount = 12;
                dtg_show.Rows.Clear();
                int stt = 1;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "STT";
                dtg_show.Columns[2].Name = "Mã";
                dtg_show.Columns[3].Name = "Sách";
                dtg_show.Columns[4].Name = "Tác giả";
                dtg_show.Columns[5].Name = "Thể loại";
                dtg_show.Columns[6].Name = "Nhà xuất bản";
                //dtg_show.Columns[6].Name = "Ảnh";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Giá nhập";
                dtg_show.Columns[9].Name = "Giá bán";
                dtg_show.Columns[10].Name = "Số lượng tồn";
                dtg_show.Columns[11].Name = "Số trang";
                foreach (var x in _iqlSP.GetAll())
                {
                    dtg_show.Rows.Add(x.SachChiTiets.Id, stt++, x.SachChiTiets.Ma, x.Sachs.Ten, x.TacGias.Ten,
                        x.TheLoais.Ten, x.NXBs.Ten/*, x.Anhs.Ten*/, x.SachChiTiets.MoTa,
                        x.SachChiTiets.GiaNhap, x.SachChiTiets.GiaBan,
                        x.SachChiTiets.SoLuongTon, x.SachChiTiets.SoTrang);
                 }
            }
            void XuatDuLieu(DataGridView dtg,string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftb = new PdfPTable(dtg.Columns.Count);
            pdftb.DefaultCell.Padding = 3;
            pdftb.WidthPercentage = 100;
            pdftb.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftb.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            foreach (DataGridViewColumn column in dtg_show.Columns)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(column.HeaderText));
                pdftb.AddCell(pdfPCell);
            }
            foreach (DataGridViewRow row in dtg_show.Rows)
            {
                foreach (DataGridViewCell cells in row.Cells)
                {
                    pdftb.AddCell(new Phrase(Convert.ToString(cells.Value), text));
                }
            }
            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";
            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A1, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftb);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xuất ra file PDF không ?", "Thông báo", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    
                    XuatDuLieu(dtg_show, "FilePDF");
                    MessageBox.Show("Xuất file thành công", "Thông báo");
                }
                if(result == DialogResult.No)
                {
                    MessageBox.Show("Không xuất thì thôi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                throw;
            }
        }
    }
}
