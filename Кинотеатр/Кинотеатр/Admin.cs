using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Кинотеатр
{
    public partial class Admin : Form
    {
        public int post;
        public string status = "";

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["kinoteatr"].ConnectionString);
        public Admin()
        {
            InitializeComponent();            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            cb_table.Items.Clear();
            cb_film.Items.Clear();
            cb_zal.Items.Clear();
            cb_format.Items.Clear();

            if (status != "admin")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
            }

            sqlConnection.Open(); 
            
            SqlCommand thisCommand = new SqlCommand("SELECT Name FROM dbo.sysobjects WHERE (xtype = 'U')", sqlConnection);
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_table.Items.Add(thisReader["Name"]);
            }
            thisReader.Close();

            string date = DateTime.Today.Year.ToString() + "-" + DateTime.Today.ToString("MM") + "-" + DateTime.Today.ToString("dd");
            SqlCommand film = new SqlCommand("SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]", sqlConnection);
            SqlDataReader reader = film.ExecuteReader();
            while (reader.Read())
            {
                cb_film.Items.Add(reader["Название фильма"]);
            }
            reader.Close();

            SqlCommand zal = new SqlCommand("SELECT [Код зала] FROM Залы", sqlConnection);
            SqlDataReader reader1 = zal.ExecuteReader();
            while (reader1.Read())
            {
                cb_zal.Items.Add(reader1["Код зала"]);
            }
            reader1.Close();

            SqlCommand format = new SqlCommand("SELECT [Формат фильма] FROM [Формат фильма]", sqlConnection);
            SqlDataReader reader2 = format.ExecuteReader();
            while (reader2.Read())
            {
                cb_format.Items.Add(reader2["Формат фильма"]);
            }
            reader2.Close();

            sqlConnection.Close();
        }

        private void cb_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [{cb_table.Text}]", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            sqlConnection.Close();
        }

        private void add_film_Click(object sender, EventArgs e)
        {          
            sqlConnection.Open();

            if (string.IsNullOrEmpty(nazv.Text) || string.IsNullOrEmpty(janr.Text) || string.IsNullOrEmpty(rej.Text) || string.IsNullOrEmpty(god.Text) || string.IsNullOrEmpty(dlit.Text) || string.IsNullOrEmpty(voz_ogr.Text) || string.IsNullOrEmpty(nach_p.Text) || string.IsNullOrEmpty(kon_p.Text))
            {
                MessageBox.Show("Заполните все пустые поля!", "Ошибка");
            }
            else
            {
                string[] nachalo = nach_p.Text.Split(Convert.ToChar("."));
                string[] konec = kon_p.Text.Split(Convert.ToChar("."));

                if ((Convert.ToInt32(nachalo[1]) > 0) && (Convert.ToInt32(nachalo[1]) <= 12) && (Convert.ToInt32(konec[1]) > 0) && (Convert.ToInt32(konec[1]) <= 12))
                {
                    if (Convert.ToInt32(nachalo[1]) == 1 || Convert.ToInt32(nachalo[1]) == 3 || Convert.ToInt32(nachalo[1]) == 5 || Convert.ToInt32(nachalo[1]) == 7 || Convert.ToInt32(nachalo[1]) == 8 || Convert.ToInt32(nachalo[1]) == 10 || Convert.ToInt32(nachalo[1]) == 12)
                    {
                        if (Convert.ToInt32(nachalo[0]) > 0 && Convert.ToInt32(nachalo[0]) < 32)
                        {
                            if (Convert.ToInt32(konec[1]) == 1 || Convert.ToInt32(konec[1]) == 3 || Convert.ToInt32(konec[1]) == 5 || Convert.ToInt32(konec[1]) == 7 || Convert.ToInt32(konec[1]) == 8 || Convert.ToInt32(konec[1]) == 10 || Convert.ToInt32(konec[1]) == 12)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 32)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }
                            }

                            if (Convert.ToInt32(konec[1]) == 4 || Convert.ToInt32(konec[1]) == 6 || Convert.ToInt32(konec[1]) == 9 || Convert.ToInt32(konec[1]) == 11)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 31)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }

                            }

                            if (Convert.ToInt32(konec[1]) == 2)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 29)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введена неверная дата в поле \"Начало проката\".");
                        }
                    }

                    if (Convert.ToInt32(nachalo[1]) == 4 || Convert.ToInt32(nachalo[1]) == 6 || Convert.ToInt32(nachalo[1]) == 9 || Convert.ToInt32(nachalo[1]) == 11)
                    {
                        if (Convert.ToInt32(nachalo[0]) > 0 && Convert.ToInt32(nachalo[0]) < 31)
                        {
                            if (Convert.ToInt32(konec[1]) == 1 || Convert.ToInt32(konec[1]) == 3 || Convert.ToInt32(konec[1]) == 5 || Convert.ToInt32(konec[1]) == 7 || Convert.ToInt32(konec[1]) == 8 || Convert.ToInt32(konec[1]) == 10 || Convert.ToInt32(konec[1]) == 12)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 32)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }
                            }

                            if (Convert.ToInt32(konec[1]) == 4 || Convert.ToInt32(konec[1]) == 6 || Convert.ToInt32(konec[1]) == 9 || Convert.ToInt32(konec[1]) == 11)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 31)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }

                            }

                            if (Convert.ToInt32(konec[1]) == 2)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 29)
                                {
                                    if (Convert.ToInt32(konec[1]) == 1 || Convert.ToInt32(konec[1]) == 3 || Convert.ToInt32(konec[1]) == 5 || Convert.ToInt32(konec[1]) == 7 || Convert.ToInt32(konec[1]) == 8 || Convert.ToInt32(konec[1]) == 10 || Convert.ToInt32(konec[1]) == 12)
                                    {
                                        if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 32)
                                        {
                                            string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                            string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                            SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                            add.ExecuteNonQuery();
                                            MessageBox.Show("Фильм успешно добавлен");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                        }
                                    }

                                    if (Convert.ToInt32(konec[1]) == 4 || Convert.ToInt32(konec[1]) == 6 || Convert.ToInt32(konec[1]) == 9 || Convert.ToInt32(konec[1]) == 11)
                                    {
                                        if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 31)
                                        {
                                            string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                            string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                            SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                            add.ExecuteNonQuery();
                                            MessageBox.Show("Фильм успешно добавлен");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                        }

                                    }

                                    if (Convert.ToInt32(konec[1]) == 2)
                                    {
                                        if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 29)
                                        {
                                            string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                            string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                            SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                            add.ExecuteNonQuery();
                                            MessageBox.Show("Фильм успешно добавлен");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введена неверная дата в поле \"Начало проката\".");
                        }
                    }

                    if (Convert.ToInt32(nachalo[1]) == 2)
                    {
                        if (Convert.ToInt32(nachalo[0]) > 0 && Convert.ToInt32(nachalo[0]) < 29)
                        {
                            if (Convert.ToInt32(konec[1]) == 1 || Convert.ToInt32(konec[1]) == 3 || Convert.ToInt32(konec[1]) == 5 || Convert.ToInt32(konec[1]) == 7 || Convert.ToInt32(konec[1]) == 8 || Convert.ToInt32(konec[1]) == 10 || Convert.ToInt32(konec[1]) == 12)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 32)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }
                            }

                            if (Convert.ToInt32(konec[1]) == 4 || Convert.ToInt32(konec[1]) == 6 || Convert.ToInt32(konec[1]) == 9 || Convert.ToInt32(konec[1]) == 11)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 31)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }

                            }

                            if (Convert.ToInt32(konec[1]) == 2)
                            {
                                if (Convert.ToInt32(konec[0]) > 0 && Convert.ToInt32(konec[0]) < 29)
                                {
                                    string date_n = nachalo[2] + "-" + nachalo[1] + "-" + nachalo[0];
                                    string date_k = konec[2] + "-" + konec[1] + "-" + konec[0];
                                    SqlCommand add = new SqlCommand("INSERT INTO Фильмы VALUES (N'" + nazv.Text + "', N'" + janr.Text + "', N'" + rej.Text + "', " + god.Text + ", " + dlit.Text + ", " + voz_ogr.Text + ", '" + date_n + "', '" + date_k + "')", sqlConnection);
                                    add.ExecuteNonQuery();
                                    MessageBox.Show("Фильм успешно добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Введена неверная дата в поле \"Конец проката\".");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введена неверная дата в поле \"Начало проката\".");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введен неверный месяц.");
                }                              
            }

            sqlConnection.Close();

            nazv.Text = "";
            janr.Text = "";
            rej.Text = "";
            god.Text = "";
            dlit.Text = "";
            voz_ogr.Text = "";
            nach_p.Text = "";
            kon_p.Text = "";
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            string date = DateTime.Today.Year.ToString() + "-" + DateTime.Today.ToString("MM") + "-" + DateTime.Today.ToString("dd");
            SqlCommand film = new SqlCommand("SELECT [Название фильма] FROM [Фильмы] WHERE '" + date + "' BETWEEN [Начало проката] AND [Конец проката]", sqlConnection);
            SqlDataReader reader = film.ExecuteReader();
            while (reader.Read())
            {
                cb_film.Items.Add(reader["Название фильма"]);
            }
            reader.Close();

            List<TimeSpan> time = new List<TimeSpan>();
            List<string> nazvanie = new List<string>();

            SqlCommand vremya = new SqlCommand($"SELECT s.Время AS Время, f.[Название фильма] as [Название фильма] FROM Сеансы s INNER JOIN [Фильмы] f ON s.Фильм = f.[Код фильма] WHERE '{date}' BETWEEN f.[Начало проката] AND f.[Конец проката] AND s.Зал = {cb_zal.Text}", sqlConnection);
            SqlDataReader reader1 = vremya.ExecuteReader();
            while (reader1.Read())
            {               
                time.Add(TimeSpan.Parse(reader1["Время"].ToString()));
                nazvanie.Add(reader1["Название фильма"].ToString());
            }
            reader1.Close();

            TimeSpan VremiaNachala;
            TimeSpan VremiaKontsa;
            TimeSpan VremiaKonDob = TimeSpan.Parse("00:00:00");
            TimeSpan VvedenoeVremia = TimeSpan.Parse(tb_time.Text);
            
            SqlCommand comandaA = new SqlCommand($"SELECT [Длительность (мин.)] FROM Фильмы WHERE [Название фильма] = N'{cb_film.Text}'", sqlConnection);
                        
            SqlDataReader chitala = comandaA.ExecuteReader();
            int count = 0;
            int dlit = 0;
            TimeSpan PobochnoeVremia = TimeSpan.Parse("00:00:00");
            while (chitala.Read())
            {
                dlit = Convert.ToInt32(chitala["Длительность (мин.)"]) + 15;
                PobochnoeVremia = TimeSpan.Parse((dlit / 60).ToString()  + ":" + (dlit - (dlit / 60) * 60).ToString() + ":00");
                VremiaKonDob = PobochnoeVremia + VvedenoeVremia;
            }
            chitala.Close();

            for (int i = 0; i < time.Count; i++)
            {
                SqlCommand comanda = new SqlCommand($"SELECT [Длительность (мин.)] FROM Фильмы WHERE [Название фильма] = N'{nazvanie[i]}'", sqlConnection);
                SqlDataReader reader2 = comanda.ExecuteReader();
                while (reader2.Read())
                {
                    dlit = Convert.ToInt32(reader2["Длительность (мин.)"]) + 15;
                }
                reader2.Close();

                PobochnoeVremia = TimeSpan.Parse((dlit / 60).ToString() + ":" + (dlit - (dlit / 60) * 60).ToString() + ":00");

                VremiaNachala = time[i];

                VremiaKontsa = PobochnoeVremia + VremiaNachala;

                if (VvedenoeVremia > VremiaNachala && VvedenoeVremia < VremiaKontsa || VremiaKonDob > VremiaNachala && VremiaKonDob < VremiaKontsa)
                {
                    count += 1;
                }
            }
                        
            if (count == 0)
            {
                SqlCommand thisCommand2 = new SqlCommand($"INSERT INTO Сеансы VALUES ((SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'{cb_film.Text}'), {cb_zal.Text}, '{VvedenoeVremia}', (SELECT [Код формата фильма] FROM [Формат фильма] WHERE [Формат фильма] = N'{cb_format.Text}'))", sqlConnection);
                thisCommand2.ExecuteNonQuery();
                MessageBox.Show("Сеанс успешно добавлен");
            }
            else
            {
                MessageBox.Show("Нельзя выбрать данное время");
            }

            sqlConnection.Close();

            cb_film.SelectedIndex = -1;
            cb_zal.SelectedIndex = -1;
            cb_format.SelectedIndex = -1;
            tb_time.Text = "";
        }

        private void god_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) e.Handled = true;
        }

        private void dlit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) e.Handled = true;
        }

        private void voz_ogr_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) e.Handled = true;
        }

        private void nach_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8 && num != 46) e.Handled = true;
        }

        private void kon_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8 && num != 46) e.Handled = true;
        }

        private void tb_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8 && num != 58) e.Handled = true;
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f = new Form1();
            f.admin = true;
            f.post = post;
            f.status = status;
            f.Show();
        }        
    }
}
