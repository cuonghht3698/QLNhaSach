
namespace QLNhaSach.Layout.Authent
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.linkQuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.LinkTaoTaiKhoan = new System.Windows.Forms.LinkLabel();
            this.cbNhoMatKhau = new System.Windows.Forms.CheckBox();
            this.linkGoToLoginAdmin = new System.Windows.Forms.LinkLabel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbCheckNV = new System.Windows.Forms.Label();
            this.lbLoginFailed = new System.Windows.Forms.Label();
            this.btnDangNhap = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txtUser.Location = new System.Drawing.Point(149, 81);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(202, 25);
            this.txtUser.TabIndex = 1;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txtPassword.Location = new System.Drawing.Point(149, 125);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(202, 25);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            // 
            // linkQuenMatKhau
            // 
            this.linkQuenMatKhau.AutoSize = true;
            this.linkQuenMatKhau.Location = new System.Drawing.Point(153, 210);
            this.linkQuenMatKhau.Name = "linkQuenMatKhau";
            this.linkQuenMatKhau.Size = new System.Drawing.Size(80, 13);
            this.linkQuenMatKhau.TabIndex = 3;
            this.linkQuenMatKhau.TabStop = true;
            this.linkQuenMatKhau.Text = "Quên mật khẩu";
            this.linkQuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LinkTaoTaiKhoan
            // 
            this.LinkTaoTaiKhoan.AutoSize = true;
            this.LinkTaoTaiKhoan.Location = new System.Drawing.Point(258, 210);
            this.LinkTaoTaiKhoan.Name = "LinkTaoTaiKhoan";
            this.LinkTaoTaiKhoan.Size = new System.Drawing.Size(79, 13);
            this.LinkTaoTaiKhoan.TabIndex = 3;
            this.LinkTaoTaiKhoan.TabStop = true;
            this.LinkTaoTaiKhoan.Text = "Tạo tài khoản?";
            this.LinkTaoTaiKhoan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbNhoMatKhau
            // 
            this.cbNhoMatKhau.AutoSize = true;
            this.cbNhoMatKhau.Location = new System.Drawing.Point(149, 182);
            this.cbNhoMatKhau.Name = "cbNhoMatKhau";
            this.cbNhoMatKhau.Size = new System.Drawing.Size(93, 17);
            this.cbNhoMatKhau.TabIndex = 4;
            this.cbNhoMatKhau.Text = "Nhớ mật khẩu";
            this.cbNhoMatKhau.UseVisualStyleBackColor = true;
            // 
            // linkGoToLoginAdmin
            // 
            this.linkGoToLoginAdmin.AutoSize = true;
            this.linkGoToLoginAdmin.Location = new System.Drawing.Point(367, 293);
            this.linkGoToLoginAdmin.Name = "linkGoToLoginAdmin";
            this.linkGoToLoginAdmin.Size = new System.Drawing.Size(97, 13);
            this.linkGoToLoginAdmin.TabIndex = 5;
            this.linkGoToLoginAdmin.TabStop = true;
            this.linkGoToLoginAdmin.Text = "Đăng nhập admin?";
            this.linkGoToLoginAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGoToLoginAdmin_LinkClicked);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Italic);
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(109, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(333, 33);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "Tên phầm mềm quần què gì đó";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lbCheckNV
            // 
            this.lbCheckNV.AutoSize = true;
            this.lbCheckNV.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbCheckNV.ForeColor = System.Drawing.Color.Red;
            this.lbCheckNV.Location = new System.Drawing.Point(151, 210);
            this.lbCheckNV.Name = "lbCheckNV";
            this.lbCheckNV.Size = new System.Drawing.Size(0, 17);
            this.lbCheckNV.TabIndex = 8;
            // 
            // lbLoginFailed
            // 
            this.lbLoginFailed.AutoSize = true;
            this.lbLoginFailed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbLoginFailed.Location = new System.Drawing.Point(146, 154);
            this.lbLoginFailed.Name = "lbLoginFailed";
            this.lbLoginFailed.Size = new System.Drawing.Size(0, 13);
            this.lbLoginFailed.TabIndex = 101;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.IconChar = FontAwesome.Sharp.IconChar.Mendeley;
            this.btnDangNhap.IconColor = System.Drawing.Color.Maroon;
            this.btnDangNhap.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangNhap.Location = new System.Drawing.Point(156, 256);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(168, 50);
            this.btnDangNhap.TabIndex = 102;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(486, 328);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.lbLoginFailed);
            this.Controls.Add(this.lbCheckNV);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.linkGoToLoginAdmin);
            this.Controls.Add(this.cbNhoMatKhau);
            this.Controls.Add(this.LinkTaoTaiKhoan);
            this.Controls.Add(this.linkQuenMatKhau);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel linkQuenMatKhau;
        private System.Windows.Forms.LinkLabel LinkTaoTaiKhoan;
        private System.Windows.Forms.CheckBox cbNhoMatKhau;
        private System.Windows.Forms.LinkLabel linkGoToLoginAdmin;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCheckNV;
        private System.Windows.Forms.Label lbLoginFailed;
        private FontAwesome.Sharp.IconButton btnDangNhap;
    }
}