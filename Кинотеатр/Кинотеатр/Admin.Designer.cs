
namespace Кинотеатр
{
    partial class Admin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_table = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.b_add = new System.Windows.Forms.Button();
            this.cb_format = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_zal = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_time = new System.Windows.Forms.TextBox();
            this.cb_film = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.add_film = new System.Windows.Forms.Button();
            this.kon_p = new System.Windows.Forms.TextBox();
            this.nach_p = new System.Windows.Forms.TextBox();
            this.voz_ogr = new System.Windows.Forms.TextBox();
            this.dlit = new System.Windows.Forms.TextBox();
            this.god = new System.Windows.Forms.TextBox();
            this.rej = new System.Windows.Forms.TextBox();
            this.janr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nazv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cb_table);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(932, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Просмотр данных";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Таблицы:";
            // 
            // cb_table
            // 
            this.cb_table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_table.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_table.FormattingEnabled = true;
            this.cb_table.Location = new System.Drawing.Point(114, 26);
            this.cb_table.Name = "cb_table";
            this.cb_table.Size = new System.Drawing.Size(281, 28);
            this.cb_table.TabIndex = 1;
            this.cb_table.SelectedIndexChanged += new System.EventHandler(this.cb_table_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(911, 438);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.b_add);
            this.tabPage2.Controls.Add(this.cb_format);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.cb_zal);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tb_time);
            this.tabPage2.Controls.Add(this.cb_film);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(932, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Добавление сеансов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // b_add
            // 
            this.b_add.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_add.Location = new System.Drawing.Point(41, 286);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(500, 66);
            this.b_add.TabIndex = 9;
            this.b_add.Text = "Добавить сеанс";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // cb_format
            // 
            this.cb_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_format.FormattingEnabled = true;
            this.cb_format.Location = new System.Drawing.Point(172, 186);
            this.cb_format.Name = "cb_format";
            this.cb_format.Size = new System.Drawing.Size(369, 24);
            this.cb_format.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(6, 185);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 23);
            this.label14.TabIndex = 7;
            this.label14.Text = "Формат фильма";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(40, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 23);
            this.label13.TabIndex = 6;
            this.label13.Text = "Время";
            // 
            // cb_zal
            // 
            this.cb_zal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_zal.FormattingEnabled = true;
            this.cb_zal.Location = new System.Drawing.Point(172, 77);
            this.cb_zal.Name = "cb_zal";
            this.cb_zal.Size = new System.Drawing.Size(369, 24);
            this.cb_zal.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(46, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 23);
            this.label12.TabIndex = 4;
            this.label12.Text = "Зал";
            // 
            // tb_time
            // 
            this.tb_time.Location = new System.Drawing.Point(172, 129);
            this.tb_time.MaxLength = 5;
            this.tb_time.Name = "tb_time";
            this.tb_time.Size = new System.Drawing.Size(369, 22);
            this.tb_time.TabIndex = 3;
            this.tb_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_time_KeyPress);
            // 
            // cb_film
            // 
            this.cb_film.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_film.FormattingEnabled = true;
            this.cb_film.Location = new System.Drawing.Point(172, 26);
            this.cb_film.Name = "cb_film";
            this.cb_film.Size = new System.Drawing.Size(369, 24);
            this.cb_film.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(36, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 23);
            this.label11.TabIndex = 1;
            this.label11.Text = "Фильм";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.add_film);
            this.tabPage3.Controls.Add(this.kon_p);
            this.tabPage3.Controls.Add(this.nach_p);
            this.tabPage3.Controls.Add(this.voz_ogr);
            this.tabPage3.Controls.Add(this.dlit);
            this.tabPage3.Controls.Add(this.god);
            this.tabPage3.Controls.Add(this.rej);
            this.tabPage3.Controls.Add(this.janr);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.nazv);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(932, 510);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Добавление фильмов";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // add_film
            // 
            this.add_film.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_film.Location = new System.Drawing.Point(649, 209);
            this.add_film.Name = "add_film";
            this.add_film.Size = new System.Drawing.Size(226, 71);
            this.add_film.TabIndex = 16;
            this.add_film.Text = "Добавить фильм";
            this.add_film.UseVisualStyleBackColor = true;
            this.add_film.Click += new System.EventHandler(this.add_film_Click);
            // 
            // kon_p
            // 
            this.kon_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kon_p.Location = new System.Drawing.Point(243, 437);
            this.kon_p.MaxLength = 10;
            this.kon_p.Name = "kon_p";
            this.kon_p.Size = new System.Drawing.Size(329, 26);
            this.kon_p.TabIndex = 15;
            this.kon_p.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kon_p_KeyPress);
            // 
            // nach_p
            // 
            this.nach_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nach_p.Location = new System.Drawing.Point(243, 377);
            this.nach_p.MaxLength = 10;
            this.nach_p.Name = "nach_p";
            this.nach_p.Size = new System.Drawing.Size(329, 26);
            this.nach_p.TabIndex = 14;
            this.nach_p.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nach_p_KeyPress);
            // 
            // voz_ogr
            // 
            this.voz_ogr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voz_ogr.Location = new System.Drawing.Point(243, 317);
            this.voz_ogr.MaxLength = 2;
            this.voz_ogr.Name = "voz_ogr";
            this.voz_ogr.Size = new System.Drawing.Size(329, 26);
            this.voz_ogr.TabIndex = 13;
            this.voz_ogr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.voz_ogr_KeyPress);
            // 
            // dlit
            // 
            this.dlit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dlit.Location = new System.Drawing.Point(243, 257);
            this.dlit.MaxLength = 3;
            this.dlit.Name = "dlit";
            this.dlit.Size = new System.Drawing.Size(329, 26);
            this.dlit.TabIndex = 12;
            this.dlit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dlit_KeyPress);
            // 
            // god
            // 
            this.god.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.god.Location = new System.Drawing.Point(243, 197);
            this.god.MaxLength = 4;
            this.god.Name = "god";
            this.god.Size = new System.Drawing.Size(329, 26);
            this.god.TabIndex = 11;
            this.god.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.god_KeyPress);
            // 
            // rej
            // 
            this.rej.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rej.Location = new System.Drawing.Point(243, 137);
            this.rej.Name = "rej";
            this.rej.Size = new System.Drawing.Size(329, 26);
            this.rej.TabIndex = 10;
            // 
            // janr
            // 
            this.janr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.janr.Location = new System.Drawing.Point(243, 77);
            this.janr.Name = "janr";
            this.janr.Size = new System.Drawing.Size(329, 26);
            this.janr.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(54, 440);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Конец проката";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(48, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Начало проката";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Возрастные ограничения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(27, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Длительность (мин.)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(59, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Год выпуска";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(70, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Режиссер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(85, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Жанр";
            // 
            // nazv
            // 
            this.nazv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nazv.Location = new System.Drawing.Point(243, 17);
            this.nazv.Name = "nazv";
            this.nazv.Size = new System.Drawing.Size(329, 26);
            this.nazv.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(26, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Название фильма";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 563);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_FormClosed);
            this.Load += new System.EventHandler(this.Admin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cb_table;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button add_film;
        private System.Windows.Forms.TextBox kon_p;
        private System.Windows.Forms.TextBox nach_p;
        private System.Windows.Forms.TextBox voz_ogr;
        private System.Windows.Forms.TextBox dlit;
        private System.Windows.Forms.TextBox god;
        private System.Windows.Forms.TextBox rej;
        private System.Windows.Forms.TextBox janr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nazv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_format;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_zal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_time;
        private System.Windows.Forms.ComboBox cb_film;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button b_add;
    }
}