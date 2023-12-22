namespace DoAn01_BuiQuyHung
{
    partial class BaoCaoHangBanChay
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNam = new System.Windows.Forms.RadioButton();
            this.rbThang = new System.Windows.Forms.RadioButton();
            this.rbNgay = new System.Windows.Forms.RadioButton();
            this.btnTaoBaoCao = new System.Windows.Forms.Button();
            this.dtpDoanhThu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.rbNam);
            this.groupBox1.Controls.Add(this.rbThang);
            this.groupBox1.Controls.Add(this.rbNgay);
            this.groupBox1.Controls.Add(this.btnTaoBaoCao);
            this.groupBox1.Controls.Add(this.dtpDoanhThu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(242, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1124, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý hàng bán chạy";
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNam.Location = new System.Drawing.Point(674, 66);
            this.rbNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new System.Drawing.Size(205, 29);
            this.rbNam.TabIndex = 11;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Bán chạy theo năm";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // rbThang
            // 
            this.rbThang.AutoSize = true;
            this.rbThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThang.Location = new System.Drawing.Point(424, 66);
            this.rbThang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbThang.Name = "rbThang";
            this.rbThang.Size = new System.Drawing.Size(216, 29);
            this.rbThang.TabIndex = 10;
            this.rbThang.TabStop = true;
            this.rbThang.Text = "Bán chạy theo tháng";
            this.rbThang.UseVisualStyleBackColor = true;
            // 
            // rbNgay
            // 
            this.rbNgay.AutoSize = true;
            this.rbNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNgay.Location = new System.Drawing.Point(172, 66);
            this.rbNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbNgay.Name = "rbNgay";
            this.rbNgay.Size = new System.Drawing.Size(210, 29);
            this.rbNgay.TabIndex = 9;
            this.rbNgay.TabStop = true;
            this.rbNgay.Text = "Bán chạy theo ngày";
            this.rbNgay.UseVisualStyleBackColor = true;
            // 
            // btnTaoBaoCao
            // 
            this.btnTaoBaoCao.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(670, 13);
            this.btnTaoBaoCao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(164, 40);
            this.btnTaoBaoCao.TabIndex = 8;
            this.btnTaoBaoCao.Text = "In báo cáo";
            this.btnTaoBaoCao.UseVisualStyleBackColor = false;
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // dtpDoanhThu
            // 
            this.dtpDoanhThu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDoanhThu.Location = new System.Drawing.Point(463, 16);
            this.dtpDoanhThu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDoanhThu.Name = "dtpDoanhThu";
            this.dtpDoanhThu.Size = new System.Drawing.Size(151, 30);
            this.dtpDoanhThu.TabIndex = 7;
            this.dtpDoanhThu.Value = new System.DateTime(2023, 5, 18, 21, 1, 1, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chọn thời gian";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(29, 143);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1492, 804);
            this.crystalReportViewer1.TabIndex = 2;
            // 
            // BaoCaoHangBanChay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 959);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "BaoCaoHangBanChay";
            this.Text = "Báo Cáo Hàng Bán Chạy";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNam;
        private System.Windows.Forms.RadioButton rbThang;
        private System.Windows.Forms.RadioButton rbNgay;
        private System.Windows.Forms.Button btnTaoBaoCao;
        private System.Windows.Forms.DateTimePicker dtpDoanhThu;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}