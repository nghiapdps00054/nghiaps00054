namespace BanHangLapTop
{
    partial class frmChinh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChinh));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.grbQuanLy = new System.Windows.Forms.GroupBox();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.lblDMK = new System.Windows.Forms.Label();
            this.lblLaptop = new System.Windows.Forms.Label();
            this.lblLoaiLaptop = new System.Windows.Forms.Label();
            this.lblQLKH = new System.Windows.Forms.Label();
            this.lblQLNV = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGioiThieu = new DevComponents.DotNetBar.ButtonX();
            this.btnHuongDan = new DevComponents.DotNetBar.ButtonX();
            this.btnBanHang = new DevComponents.DotNetBar.ButtonX();
            this.btnNhapHang = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnDangXuat = new DevComponents.DotNetBar.ButtonX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.grbQuanLy.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(652, 25);
            this.toolStripStatusLabel1.Text = "FPT-PolyTechnic Hồ Chí Minh --- nghiapdps00054 --- Assignment Inf205";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(211, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "PHẦN MỀM QUẢN LÝ BÁN HÀNG";
            // 
            // grbQuanLy
            // 
            this.grbQuanLy.BackColor = System.Drawing.Color.Transparent;
            this.grbQuanLy.Controls.Add(this.buttonX8);
            this.grbQuanLy.Controls.Add(this.lblDMK);
            this.grbQuanLy.Controls.Add(this.lblLaptop);
            this.grbQuanLy.Controls.Add(this.lblLoaiLaptop);
            this.grbQuanLy.Controls.Add(this.lblQLKH);
            this.grbQuanLy.Controls.Add(this.lblQLNV);
            this.grbQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbQuanLy.ForeColor = System.Drawing.Color.White;
            this.grbQuanLy.Location = new System.Drawing.Point(39, 79);
            this.grbQuanLy.Name = "grbQuanLy";
            this.grbQuanLy.Size = new System.Drawing.Size(333, 200);
            this.grbQuanLy.TabIndex = 7;
            this.grbQuanLy.TabStop = false;
            this.grbQuanLy.Text = "Quản Lý";
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX8.Image = ((System.Drawing.Image)(resources.GetObject("buttonX8.Image")));
            this.buttonX8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX8.Location = new System.Drawing.Point(25, 47);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.buttonX8.Size = new System.Drawing.Size(113, 112);
            this.buttonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX8.TabIndex = 11;
            // 
            // lblDMK
            // 
            this.lblDMK.AutoSize = true;
            this.lblDMK.Location = new System.Drawing.Point(169, 140);
            this.lblDMK.Name = "lblDMK";
            this.lblDMK.Size = new System.Drawing.Size(85, 16);
            this.lblDMK.TabIndex = 9;
            this.lblDMK.Text = "Đổi mật khẩu\r\n";
            this.toolTip1.SetToolTip(this.lblDMK, "Quản lý hóa đơn");
            this.lblDMK.Click += new System.EventHandler(this.lblDMK_Click);
            // 
            // lblLaptop
            // 
            this.lblLaptop.AutoSize = true;
            this.lblLaptop.Location = new System.Drawing.Point(169, 116);
            this.lblLaptop.Name = "lblLaptop";
            this.lblLaptop.Size = new System.Drawing.Size(94, 16);
            this.lblLaptop.TabIndex = 10;
            this.lblLaptop.Text = "Quản lý laptop";
            this.toolTip1.SetToolTip(this.lblLaptop, "Quản lý laptop");
            this.lblLaptop.Click += new System.EventHandler(this.lblLaptop_Click);
            // 
            // lblLoaiLaptop
            // 
            this.lblLoaiLaptop.AutoSize = true;
            this.lblLoaiLaptop.Location = new System.Drawing.Point(169, 92);
            this.lblLoaiLaptop.Name = "lblLoaiLaptop";
            this.lblLoaiLaptop.Size = new System.Drawing.Size(119, 16);
            this.lblLoaiLaptop.TabIndex = 8;
            this.lblLoaiLaptop.Text = "Quản lý loại laptop";
            this.toolTip1.SetToolTip(this.lblLoaiLaptop, "Quản lý loại laptop");
            this.lblLoaiLaptop.Click += new System.EventHandler(this.lblLoaiLaptop_Click);
            // 
            // lblQLKH
            // 
            this.lblQLKH.AutoSize = true;
            this.lblQLKH.Location = new System.Drawing.Point(169, 68);
            this.lblQLKH.Name = "lblQLKH";
            this.lblQLKH.Size = new System.Drawing.Size(125, 16);
            this.lblQLKH.TabIndex = 6;
            this.lblQLKH.Text = "Quản lý khách hàng";
            this.toolTip1.SetToolTip(this.lblQLKH, "Quản lý khách hàng");
            this.lblQLKH.Click += new System.EventHandler(this.lblQLKH_Click);
            // 
            // lblQLNV
            // 
            this.lblQLNV.AutoSize = true;
            this.lblQLNV.Location = new System.Drawing.Point(169, 46);
            this.lblQLNV.Name = "lblQLNV";
            this.lblQLNV.Size = new System.Drawing.Size(113, 16);
            this.lblQLNV.TabIndex = 7;
            this.lblQLNV.Text = "Quản lý nhân viên";
            this.toolTip1.SetToolTip(this.lblQLNV, "Quản lý nhân viên");
            this.lblQLNV.Click += new System.EventHandler(this.lblQLNV_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnGioiThieu);
            this.groupBox2.Controls.Add(this.btnHuongDan);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(39, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 148);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin";
            // 
            // btnGioiThieu
            // 
            this.btnGioiThieu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGioiThieu.BackColor = System.Drawing.Color.Transparent;
            this.btnGioiThieu.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnGioiThieu.Image = ((System.Drawing.Image)(resources.GetObject("btnGioiThieu.Image")));
            this.btnGioiThieu.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGioiThieu.Location = new System.Drawing.Point(191, 29);
            this.btnGioiThieu.Name = "btnGioiThieu";
            this.btnGioiThieu.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnGioiThieu.Size = new System.Drawing.Size(103, 99);
            this.btnGioiThieu.TabIndex = 11;
            this.btnGioiThieu.Text = "Giới thiệu";
            this.btnGioiThieu.Tooltip = "Giới Thiệu";
            // 
            // btnHuongDan
            // 
            this.btnHuongDan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuongDan.BackColor = System.Drawing.Color.Transparent;
            this.btnHuongDan.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnHuongDan.Image = ((System.Drawing.Image)(resources.GetObject("btnHuongDan.Image")));
            this.btnHuongDan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHuongDan.Location = new System.Drawing.Point(35, 29);
            this.btnHuongDan.Name = "btnHuongDan";
            this.btnHuongDan.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnHuongDan.Size = new System.Drawing.Size(103, 99);
            this.btnHuongDan.TabIndex = 11;
            this.btnHuongDan.Text = "Hướng dẫn";
            this.btnHuongDan.Tooltip = "Hướng Dẫn";
            // 
            // btnBanHang
            // 
            this.btnBanHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBanHang.BackColor = System.Drawing.Color.Transparent;
            this.btnBanHang.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnBanHang.Image = ((System.Drawing.Image)(resources.GetObject("btnBanHang.Image")));
            this.btnBanHang.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBanHang.Location = new System.Drawing.Point(473, 83);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnBanHang.Size = new System.Drawing.Size(175, 166);
            this.btnBanHang.TabIndex = 11;
            this.btnBanHang.Text = "Bán hàng";
            this.btnBanHang.Tooltip = "Bán Hàng";
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNhapHang.BackColor = System.Drawing.Color.Transparent;
            this.btnNhapHang.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnNhapHang.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapHang.Image")));
            this.btnNhapHang.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNhapHang.Location = new System.Drawing.Point(473, 295);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnNhapHang.Size = new System.Drawing.Size(175, 166);
            this.btnNhapHang.TabIndex = 11;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.Tooltip = "Nhập Hàng";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnThoat.Location = new System.Drawing.Point(723, 440);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnThoat.Size = new System.Drawing.Size(41, 43);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Tooltip = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDangXuat.BackColor = System.Drawing.Color.Transparent;
            this.btnDangXuat.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.Image")));
            this.btnDangXuat.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDangXuat.Location = new System.Drawing.Point(674, 440);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnDangXuat.Size = new System.Drawing.Size(41, 43);
            this.btnDangXuat.TabIndex = 12;
            this.btnDangXuat.Tooltip = "Đăng Xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(766, 516);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.btnBanHang);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbQuanLy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý bán hàng Laptop";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grbQuanLy.ResumeLayout(false);
            this.grbQuanLy.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbQuanLy;
        private DevComponents.DotNetBar.ButtonX buttonX8;
        private System.Windows.Forms.Label lblDMK;
        private System.Windows.Forms.Label lblLaptop;
        private System.Windows.Forms.Label lblLoaiLaptop;
        private System.Windows.Forms.Label lblQLKH;
        private System.Windows.Forms.Label lblQLNV;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ButtonX btnGioiThieu;
        private DevComponents.DotNetBar.ButtonX btnHuongDan;
        private DevComponents.DotNetBar.ButtonX btnBanHang;
        private DevComponents.DotNetBar.ButtonX btnNhapHang;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnDangXuat;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}