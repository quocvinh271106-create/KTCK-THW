namespace Covid19.GUI
{
    partial class frmDiaPhuong
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
            grpThongKe = new GroupBox();
            btnTimKiem = new Button();
            cboTinhTrang = new ComboBox();
            label1 = new Label();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            grpThongKe.SuspendLayout();
            SuspendLayout();
            // 
            // grpThongKe
            // 
            grpThongKe.Controls.Add(btnTimKiem);
            grpThongKe.Controls.Add(cboTinhTrang);
            grpThongKe.Controls.Add(label1);
            grpThongKe.Location = new Point(195, 12);
            grpThongKe.Name = "grpThongKe";
            grpThongKe.Size = new Size(401, 125);
            grpThongKe.TabIndex = 0;
            grpThongKe.TabStop = false;
            grpThongKe.Text = "Thống kê";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(149, 85);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.FormattingEnabled = true;
            cboTinhTrang.Location = new Point(147, 29);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(218, 28);
            cboTinhTrang.TabIndex = 1;
            cboTinhTrang.SelectedIndexChanged += cboTinhTrang_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 32);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Tình trạng";
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmDiaPhuong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpThongKe);
            Name = "frmDiaPhuong";
            Text = "frmThongKe";
            Load += frmThongKe_Load;
            grpThongKe.ResumeLayout(false);
            grpThongKe.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongKe;
        private Label label1;
        private Button btnTimKiem;
        private ComboBox cboTinhTrang;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}