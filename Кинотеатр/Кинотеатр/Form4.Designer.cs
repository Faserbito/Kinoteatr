
namespace Кинотеатр
{
    partial class Form4
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
            this.places = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.kol_det = new System.Windows.Forms.TextBox();
            this.kol_stud = new System.Windows.Forms.TextBox();
            this.kol_vz = new System.Windows.Forms.TextBox();
            this.kol_l = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buy = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.l_bil = new System.Windows.Forms.Label();
            this.itogo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // places
            // 
            this.places.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.places.FormattingEnabled = true;
            this.places.ItemHeight = 23;
            this.places.Location = new System.Drawing.Point(12, 45);
            this.places.Name = "places";
            this.places.Size = new System.Drawing.Size(177, 188);
            this.places.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбранные места";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(191, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Студенческий билет";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(249, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Детский билет";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(235, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Взрослый билет";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(235, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Льготный билет";
            // 
            // kol_det
            // 
            this.kol_det.Location = new System.Drawing.Point(422, 61);
            this.kol_det.MaxLength = 1;
            this.kol_det.Name = "kol_det";
            this.kol_det.Size = new System.Drawing.Size(45, 22);
            this.kol_det.TabIndex = 6;
            this.kol_det.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kol_det.TextChanged += new System.EventHandler(this.kol_det_TextChanged);
            this.kol_det.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // kol_stud
            // 
            this.kol_stud.Location = new System.Drawing.Point(422, 111);
            this.kol_stud.MaxLength = 1;
            this.kol_stud.Name = "kol_stud";
            this.kol_stud.Size = new System.Drawing.Size(45, 22);
            this.kol_stud.TabIndex = 7;
            this.kol_stud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kol_stud.TextChanged += new System.EventHandler(this.kol_stud_TextChanged);
            this.kol_stud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // kol_vz
            // 
            this.kol_vz.Location = new System.Drawing.Point(422, 161);
            this.kol_vz.MaxLength = 1;
            this.kol_vz.Name = "kol_vz";
            this.kol_vz.Size = new System.Drawing.Size(45, 22);
            this.kol_vz.TabIndex = 8;
            this.kol_vz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kol_vz.TextChanged += new System.EventHandler(this.kol_vz_TextChanged);
            this.kol_vz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // kol_l
            // 
            this.kol_l.Location = new System.Drawing.Point(422, 211);
            this.kol_l.MaxLength = 1;
            this.kol_l.Name = "kol_l";
            this.kol_l.Size = new System.Drawing.Size(45, 22);
            this.kol_l.TabIndex = 9;
            this.kol_l.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kol_l.TextChanged += new System.EventHandler(this.kol_l_TextChanged);
            this.kol_l.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(473, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "шт.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(473, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "шт.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(473, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "шт.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(473, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "шт.";
            // 
            // buy
            // 
            this.buy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buy.Location = new System.Drawing.Point(110, 338);
            this.buy.Name = "buy";
            this.buy.Size = new System.Drawing.Size(326, 38);
            this.buy.TabIndex = 14;
            this.buy.Text = "Оплатить";
            this.buy.UseVisualStyleBackColor = true;
            this.buy.Click += new System.EventHandler(this.buy_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(235, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "Итого:";
            // 
            // l_bil
            // 
            this.l_bil.AutoSize = true;
            this.l_bil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_bil.Location = new System.Drawing.Point(145, 264);
            this.l_bil.Name = "l_bil";
            this.l_bil.Size = new System.Drawing.Size(153, 25);
            this.l_bil.TabIndex = 16;
            this.l_bil.Text = "Всего билетов:";
            // 
            // itogo
            // 
            this.itogo.AutoSize = true;
            this.itogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itogo.Location = new System.Drawing.Point(315, 298);
            this.itogo.Name = "itogo";
            this.itogo.Size = new System.Drawing.Size(0, 25);
            this.itogo.TabIndex = 17;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 386);
            this.Controls.Add(this.itogo);
            this.Controls.Add(this.l_bil);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buy);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kol_l);
            this.Controls.Add(this.kol_vz);
            this.Controls.Add(this.kol_stud);
            this.Controls.Add(this.kol_det);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.places);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form4";
            this.Text = "Покупка билетов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox places;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox kol_det;
        private System.Windows.Forms.TextBox kol_stud;
        private System.Windows.Forms.TextBox kol_vz;
        private System.Windows.Forms.TextBox kol_l;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label l_bil;
        private System.Windows.Forms.Label itogo;
    }
}