
namespace QLNhaSach.Layout.KhachHang
{
    partial class FGioHang
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
            this.panelParent = new System.Windows.Forms.Panel();
            this.panelEmpty = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lbTongTienChu = new System.Windows.Forms.Label();
            this.btnMuaThem = new FontAwesome.Sharp.IconButton();
            this.btnDatHang = new FontAwesome.Sharp.IconButton();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTiepNhan = new FontAwesome.Sharp.IconButton();
            this.lbTrangThaiHD = new System.Windows.Forms.Label();
            this.panelParent.SuspendLayout();
            this.panelEmpty.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelParent
            // 
            this.panelParent.AutoScroll = true;
            this.panelParent.Controls.Add(this.panelEmpty);
            this.panelParent.Controls.Add(this.panel3);
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelParent.Location = new System.Drawing.Point(0, 0);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(658, 607);
            this.panelParent.TabIndex = 0;
            // 
            // panelEmpty
            // 
            this.panelEmpty.Controls.Add(this.label5);
            this.panelEmpty.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEmpty.Location = new System.Drawing.Point(0, 63);
            this.panelEmpty.Name = "panelEmpty";
            this.panelEmpty.Size = new System.Drawing.Size(658, 68);
            this.panelEmpty.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(424, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Giỏ hàng hiện chưa có sản phẩm nào.";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 63);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbTrangThaiHD);
            this.panel2.Controls.Add(this.btnTiepNhan);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Controls.Add(this.lbTongTienChu);
            this.panel2.Controls.Add(this.btnMuaThem);
            this.panel2.Controls.Add(this.btnDatHang);
            this.panel2.Controls.Add(this.lbTongTien);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.txtDiaChi);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(658, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 607);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnHuy.Location = new System.Drawing.Point(55, 440);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(174, 43);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Từ chối đơn hàng";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lbTongTienChu
            // 
            this.lbTongTienChu.AutoSize = true;
            this.lbTongTienChu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTienChu.Location = new System.Drawing.Point(51, 319);
            this.lbTongTienChu.Name = "lbTongTienChu";
            this.lbTongTienChu.Size = new System.Drawing.Size(61, 19);
            this.lbTongTienChu.TabIndex = 5;
            this.lbTongTienChu.Text = "Tiền chữ";
            this.lbTongTienChu.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnMuaThem
            // 
            this.btnMuaThem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnMuaThem.IconColor = System.Drawing.Color.Black;
            this.btnMuaThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMuaThem.Location = new System.Drawing.Point(231, 489);
            this.btnMuaThem.Name = "btnMuaThem";
            this.btnMuaThem.Size = new System.Drawing.Size(95, 47);
            this.btnMuaThem.TabIndex = 4;
            this.btnMuaThem.Text = "Mua thêm";
            this.btnMuaThem.UseVisualStyleBackColor = true;
            // 
            // btnDatHang
            // 
            this.btnDatHang.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDatHang.IconColor = System.Drawing.Color.Black;
            this.btnDatHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDatHang.Location = new System.Drawing.Point(54, 489);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(161, 47);
            this.btnDatHang.TabIndex = 3;
            this.btnDatHang.Text = "Đặt hàng";
            this.btnDatHang.UseVisualStyleBackColor = true;
            this.btnDatHang.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(144, 279);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(17, 19);
            this.lbTongTien.TabIndex = 2;
            this.lbTongTien.Text = "0";
            this.lbTongTien.Click += new System.EventHandler(this.lbTongTien_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thành tiền";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(54, 217);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(272, 26);
            this.txtSDT.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(54, 88);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(272, 81);
            this.txtDiaChi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thông tin chi tiết";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ giao hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số điện thoại";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnTiepNhan
            // 
            this.btnTiepNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTiepNhan.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTiepNhan.IconColor = System.Drawing.Color.Black;
            this.btnTiepNhan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTiepNhan.Location = new System.Drawing.Point(54, 391);
            this.btnTiepNhan.Name = "btnTiepNhan";
            this.btnTiepNhan.Size = new System.Drawing.Size(175, 41);
            this.btnTiepNhan.TabIndex = 7;
            this.btnTiepNhan.Text = "Tiếp nhận và giao hàng";
            this.btnTiepNhan.UseVisualStyleBackColor = false;
            this.btnTiepNhan.Click += new System.EventHandler(this.btnTiepNhan_Click);
            // 
            // lbTrangThaiHD
            // 
            this.lbTrangThaiHD.AutoSize = true;
            this.lbTrangThaiHD.Location = new System.Drawing.Point(51, 371);
            this.lbTrangThaiHD.Name = "lbTrangThaiHD";
            this.lbTrangThaiHD.Size = new System.Drawing.Size(60, 17);
            this.lbTrangThaiHD.TabIndex = 8;
            this.lbTrangThaiHD.Text = "Thao tác";
            // 
            // FGioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 607);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelParent);
            this.Name = "FGioHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FGioHang";
            this.Load += new System.EventHandler(this.FGioHang_Load);
            this.panelParent.ResumeLayout(false);
            this.panelEmpty.ResumeLayout(false);
            this.panelEmpty.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTongTienChu;
        private FontAwesome.Sharp.IconButton btnMuaThem;
        private FontAwesome.Sharp.IconButton btnDatHang;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel panelEmpty;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnTiepNhan;
        private System.Windows.Forms.Label lbTrangThaiHD;
    }
}