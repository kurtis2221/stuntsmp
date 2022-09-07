namespace stuntsmp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_exe = new System.Windows.Forms.TextBox();
            this.tb_exe_par = new System.Windows.Forms.TextBox();
            this.tb_base = new System.Windows.Forms.TextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.bt_exe = new System.Windows.Forms.Button();
            this.bt_exe_par = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lb_sep = new System.Windows.Forms.Label();
            this.cb_version = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DOSBox path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stunts path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Base address";
            // 
            // tb_exe
            // 
            this.tb_exe.Location = new System.Drawing.Point(91, 62);
            this.tb_exe.Name = "tb_exe";
            this.tb_exe.Size = new System.Drawing.Size(342, 20);
            this.tb_exe.TabIndex = 2;
            // 
            // tb_exe_par
            // 
            this.tb_exe_par.Location = new System.Drawing.Point(91, 94);
            this.tb_exe_par.Name = "tb_exe_par";
            this.tb_exe_par.Size = new System.Drawing.Size(342, 20);
            this.tb_exe_par.TabIndex = 4;
            // 
            // tb_base
            // 
            this.tb_base.Location = new System.Drawing.Point(91, 127);
            this.tb_base.Name = "tb_base";
            this.tb_base.Size = new System.Drawing.Size(342, 20);
            this.tb_base.TabIndex = 6;
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(91, 6);
            this.tb_ip.MaxLength = 15;
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(181, 20);
            this.tb_ip.TabIndex = 0;
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(278, 6);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(184, 24);
            this.bt_connect.TabIndex = 1;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // bt_exe
            // 
            this.bt_exe.Location = new System.Drawing.Point(438, 62);
            this.bt_exe.Name = "bt_exe";
            this.bt_exe.Size = new System.Drawing.Size(24, 20);
            this.bt_exe.TabIndex = 3;
            this.bt_exe.Text = "...";
            this.bt_exe.UseVisualStyleBackColor = true;
            this.bt_exe.Click += new System.EventHandler(this.bt_exe_Click);
            // 
            // bt_exe_par
            // 
            this.bt_exe_par.Location = new System.Drawing.Point(439, 94);
            this.bt_exe_par.Name = "bt_exe_par";
            this.bt_exe_par.Size = new System.Drawing.Size(24, 20);
            this.bt_exe_par.TabIndex = 5;
            this.bt_exe_par.Text = "...";
            this.bt_exe_par.UseVisualStyleBackColor = true;
            this.bt_exe_par.Click += new System.EventHandler(this.bt_exe_par_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "EXE files|*.exe|BAT files|*.bat|All files|*.*";
            // 
            // lb_sep
            // 
            this.lb_sep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_sep.Location = new System.Drawing.Point(12, 45);
            this.lb_sep.Name = "lb_sep";
            this.lb_sep.Size = new System.Drawing.Size(450, 2);
            this.lb_sep.TabIndex = 4;
            // 
            // cb_version
            // 
            this.cb_version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_version.FormattingEnabled = true;
            this.cb_version.Items.AddRange(new object[] {
            "1.0",
            "1.0 Old Loader",
            "1.0 Loader",
            "1.1",
            "1.1 Loader"});
            this.cb_version.Location = new System.Drawing.Point(91, 160);
            this.cb_version.Name = "cb_version";
            this.cb_version.Size = new System.Drawing.Size(104, 21);
            this.cb_version.TabIndex = 7;
            this.cb_version.SelectedIndexChanged += new System.EventHandler(this.cb_version_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Version";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 191);
            this.Controls.Add(this.cb_version);
            this.Controls.Add(this.lb_sep);
            this.Controls.Add(this.bt_exe_par);
            this.Controls.Add(this.bt_exe);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.tb_base);
            this.Controls.Add(this.tb_exe_par);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.tb_exe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_exe;
        private System.Windows.Forms.TextBox tb_exe_par;
        private System.Windows.Forms.TextBox tb_base;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_exe;
        private System.Windows.Forms.Button bt_exe_par;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label lb_sep;
        private System.Windows.Forms.ComboBox cb_version;
        private System.Windows.Forms.Label label5;
    }
}