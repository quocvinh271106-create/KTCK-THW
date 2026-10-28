using Covid19.BLL;
using System;
using System.Windows.Forms;
using System.Linq;

namespace Covid19.GUI
{
    public partial class frmDiaPhuong : Form
    {
        private readonly TrangThaiBLL ttBLL = new TrangThaiBLL();
        private readonly DiaPhuongBLL bnBLL = new DiaPhuongBLL();

        public frmDiaPhuong()
        {
            InitializeComponent();
            this.Load += frmThongKe_Load;
        }

        private void frmThongKe_Load(object? sender, EventArgs e)
        {
            try
            {
                cboTinhTrang.DataSource = ttBLL.GetAll();
                cboTinhTrang.DisplayMember = "TenTT";
                cboTinhTrang.ValueMember = "MaTT";
                cboTinhTrang.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void cboTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTinhTrang.SelectedValue == null ||
                !int.TryParse(cboTinhTrang.SelectedValue.ToString(), out int maTT))
            {
                MessageBox.Show("Vui lòng chọn tình trạng!");
                return;
            }

            try
            {
                var danhSach = bnBLL.GetDanhSachHienThi()
                    .Where(x => x.MaTT == maTT)
                    .Select(x => new
                    {
                        MaDP = x.MaDP,
                        TenDP = x.TenDP,
                        SoCaNhiem = x.SoCaNhiemMoi
                    })
                    .ToList();

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Không có địa phương thuộc trạng thái đã chọn!");
                    return;
                }

                // Bước tiếp theo: đưa danhSach vào ReportViewer RDLC.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
    }
}