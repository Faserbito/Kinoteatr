
namespace Кинотеатр
{
    partial class First
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
            this.login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.chb = new System.Windows.Forms.CheckBox();
            this.b_enter = new System.Windows.Forms.Button();
            this.b_anon = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.LinkLabel();
            this.b_vhod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.Location = new System.Drawing.Point(136, 38);
            this.login.MaxLength = 25;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(163, 26);
            this.login.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(57, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(45, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            this.label2.Visible = false;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.Location = new System.Drawing.Point(136, 110);
            this.password.MaxLength = 10;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(163, 26);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // chb
            // 
            this.chb.AutoSize = true;
            this.chb.Location = new System.Drawing.Point(312, 113);
            this.chb.Name = "chb";
            this.chb.Size = new System.Drawing.Size(18, 17);
            this.chb.TabIndex = 4;
            this.chb.UseVisualStyleBackColor = true;
            this.chb.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // b_enter
            // 
            this.b_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_enter.Location = new System.Drawing.Point(62, 36);
            this.b_enter.Name = "b_enter";
            this.b_enter.Size = new System.Drawing.Size(268, 39);
            this.b_enter.TabIndex = 5;
            this.b_enter.Text = "Войти в учетную запись";
            this.b_enter.UseVisualStyleBackColor = true;
            this.b_enter.Click += new System.EventHandler(this.b_enter_Click);
            // 
            // b_anon
            // 
            this.b_anon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_anon.Location = new System.Drawing.Point(62, 104);
            this.b_anon.Name = "b_anon";
            this.b_anon.Size = new System.Drawing.Size(268, 39);
            this.b_anon.TabIndex = 6;
            this.b_anon.Text = "Анонимный вход";
            this.b_anon.UseVisualStyleBackColor = true;
            this.b_anon.Click += new System.EventHandler(this.b_anon_Click);
            // 
            // back
            // 
            this.back.AutoSize = true;
            this.back.LinkColor = System.Drawing.Color.DimGray;
            this.back.Location = new System.Drawing.Point(12, 184);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(47, 19);
            this.back.TabIndex = 7;
            this.back.TabStop = true;
            this.back.Text = "Назад";
            this.back.Visible = false;
            this.back.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.back_LinkClicked);
            // 
            // b_vhod
            // 
            this.b_vhod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_vhod.Location = new System.Drawing.Point(117, 168);
            this.b_vhod.Name = "b_vhod";
            this.b_vhod.Size = new System.Drawing.Size(152, 39);
            this.b_vhod.TabIndex = 8;
            this.b_vhod.Text = "Войти";
            this.b_vhod.UseVisualStyleBackColor = true;
            this.b_vhod.Visible = false;
            this.b_vhod.Click += new System.EventHandler(this.b_vhod_Click);
            // 
            // First
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 220);
            this.Controls.Add(this.b_vhod);
            this.Controls.Add(this.back);
            this.Controls.Add(this.b_anon);
            this.Controls.Add(this.b_enter);
            this.Controls.Add(this.chb);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "First";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.CheckBox chb;
        private System.Windows.Forms.Button b_enter;
        private System.Windows.Forms.Button b_anon;
        private System.Windows.Forms.LinkLabel back;
        private System.Windows.Forms.Button b_vhod;
    }
}