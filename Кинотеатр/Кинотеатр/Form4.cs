using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Кинотеатр
{
    public partial class Form4 : Form
    {
        public List<string> bilet = new List<string>();
        public int num_form;
        public string text, nazv, time, type, num_zal, date;
        public bool admin;
        public int post;
        public string status;

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["kinoteatr"].ConnectionString);

        public Form4()
        {
            InitializeComponent();            
        }

        private void Form4_Load(object sender, EventArgs e)
        {            
            foreach (string i in bilet)
            {
                places.Items.Add(i);
            }
            l_bil.Text = "Всего билетов: " + bilet.Count();

            if (num_form == 3)
            {
                kol_det.Enabled = false;
                kol_stud.Enabled = false;
                kol_vz.Enabled = false;
                kol_l.Enabled = false;
                itogo.Text = (600 * bilet.Count()).ToString() + " руб.";
            }

            string v_ogr = "";
            sqlConnection.Open();
            SqlCommand ogranich = new SqlCommand("SELECT [Возрастные ограничения] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "'", sqlConnection);
            SqlDataReader reader = ogranich.ExecuteReader();
            while (reader.Read())
            {
                v_ogr = reader["Возрастные ограничения"].ToString();
            }
            reader.Close();
            sqlConnection.Close();

            if (v_ogr == "18")
            {
                kol_det.Enabled = false;
            }
        }

        private void buy_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            //проверка на кол-во билетов в текстбоксах и всего
            if (string.IsNullOrEmpty(kol_det.Text) && string.IsNullOrEmpty(kol_stud.Text) && string.IsNullOrEmpty(kol_vz.Text) && string.IsNullOrEmpty(kol_l.Text))
            {
                MessageBox.Show("Выберите количество билетов нужного вида!", "Ошибка");
            }
            else
            {
                int sum = 0;
                if (kol_det.Text != "")
                {
                    sum += Convert.ToInt32(kol_det.Text);
                }
                if (kol_stud.Text != "")
                {
                    sum += Convert.ToInt32(kol_stud.Text);
                }
                if (kol_vz.Text != "")
                {
                    sum += Convert.ToInt32(kol_vz.Text);
                }
                if (kol_l.Text != "")
                {
                    sum += Convert.ToInt32(kol_l.Text);
                }

                if (sum == bilet.Count())
                {
                    int k_det = 0;
                    int k_stud = 0;
                    int k_vz = 0;
                    int k_l = 0;
                    int k_b = 0;

                    foreach (string b in bilet)
                    {                        
                        string[] place = b.Split();

                        int kod_seansa = 0;
                        int kod_mesta = 0;
                        bool add = true;

                        SqlCommand kod_s = new SqlCommand("SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' AND Зал = " + num_zal + " AND Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')", sqlConnection);
                        SqlDataReader reader1 = kod_s.ExecuteReader();
                        while (reader1.Read())
                        {
                            kod_seansa = Convert.ToInt32(reader1["Код сеанса"]);
                        }
                        reader1.Close();

                        SqlCommand kod_m = new SqlCommand("SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3], sqlConnection);
                        SqlDataReader reader2 = kod_m.ExecuteReader();
                        while (reader2.Read())
                        {
                            kod_mesta = Convert.ToInt32(reader2["Код места"]);
                        }
                        reader2.Close();

                        SqlCommand bil = new SqlCommand("SELECT Сеанс, Место FROM Билеты", sqlConnection);
                        SqlDataReader reader3 = bil.ExecuteReader();
                        while (reader3.Read())
                        {
                            if (Convert.ToInt32(reader3["Сеанс"]) == kod_seansa && Convert.ToInt32(reader3["Место"]) == kod_mesta)
                            {
                                add = false;
                            }
                        }
                        reader3.Close();

                        if (add)
                        {
                            SqlCommand tickets = new SqlCommand("INSERT INTO Билеты VALUES ((SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' AND Зал = " + num_zal + " AND Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')), (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + "))", sqlConnection);
                            tickets.ExecuteNonQuery();
                        }

                        if (num_form == 3)
                        {
                            if (k_b < bilet.Count)
                            {
                                SqlCommand sale = new SqlCommand($"INSERT INTO [Продажа билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '{time}' AND Зал = {num_zal} AND Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'{nazv}')) and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = {num_zal} AND Ряд = {place[1]} AND Место = {place[3]})), '{date}', 3)", sqlConnection);
                                sale.ExecuteNonQuery();
                                k_b++;
                            }                                                          
                        }
                        else
                        {
                            if (kol_det.Text != "")
                            {
                                if (k_det < Convert.ToInt32(kol_det.Text))
                                {
                                    SqlCommand sale = new SqlCommand($"INSERT INTO [Продажа билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '{time}' AND Зал = {num_zal} AND Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'{nazv}')) and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = {num_zal} AND Ряд = {place[1]} AND Место = {place[3]})), '{date}', (SELECT [Код типа билета] FROM [Тип билета] WHERE [Тип билета] = N'Детский'))", sqlConnection);
                                    sale.ExecuteNonQuery();
                                    k_det++;
                                }
                                else
                                {
                                    if (kol_stud.Text != "")
                                    {
                                        if (k_stud < Convert.ToInt32(kol_stud.Text))
                                        {
                                            SqlCommand sale = new SqlCommand("INSERT INTO [Продажа билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' AND Зал = " + num_zal + " AND Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')) and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + ")), '" + date + "', (SELECT [Код типа билета] FROM [Тип билета] WHERE [Тип билета] = N'Студенческий'))", sqlConnection);
                                            sale.ExecuteNonQuery();
                                            k_stud++;
                                        }
                                    }
                                    else
                                    {
                                        if (kol_vz.Text != "")
                                        {
                                            if (k_vz < Convert.ToInt32(kol_vz.Text))
                                            {
                                                SqlCommand sale = new SqlCommand("INSERT INTO [Продажа билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' AND Зал = " + num_zal + " AND Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')) and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + ")), '" + date + "', (SELECT [Код типа билета] FROM [Тип билета] WHERE [Тип билета] = N'Взрослый'))", sqlConnection);
                                                sale.ExecuteNonQuery();
                                                k_vz++;
                                            }
                                        }
                                        else
                                        {
                                            if (kol_l.Text != "")
                                            {
                                                if (k_l < Convert.ToInt32(kol_l.Text))
                                                {
                                                    SqlCommand sale = new SqlCommand("INSERT INTO [Продажа билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' AND Зал = " + num_zal + " AND Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')) and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + ")), '" + date + "', (SELECT [Код типа билета] FROM [Тип билета] WHERE [Тип билета] = N'Льготный'))", sqlConnection);
                                                    sale.ExecuteNonQuery();
                                                    k_l++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }                       
                           
                        }                        
                    }

                    MessageBox.Show("Оплата прошла успешно.");
                    Close();
                }
                else
                {
                    if (sum < bilet.Count())
                    {
                        MessageBox.Show("Общее количество билетов меньше, чем количество выбранных мест. Не хватает " + (bilet.Count() - sum).ToString() + " шт.", "Ошибка");
                    }
                    else
                    {
                        MessageBox.Show("Общее количество билетов превышает количество выбранных мест. Количество избыточных билетов: " + (sum - bilet.Count()).ToString() + " шт.", "Ошибка");
                    }                        
                }
            }
            sqlConnection.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) e.Handled = true;
        }

        private void kol_det_TextChanged(object sender, EventArgs e)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(kol_det.Text) && string.IsNullOrEmpty(kol_stud.Text) && string.IsNullOrEmpty(kol_vz.Text) && string.IsNullOrEmpty(kol_l.Text))
            {
                itogo.Text = "0 руб.";
            }
            else
            {
                int percent = 0;

                if (Convert.ToDateTime(time) >= Convert.ToDateTime("6:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("11:59"))
                {
                    percent = 0;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("12:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("17:59"))
                {
                    percent = 5;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("18:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("23:59"))
                {
                    percent = 10;
                }
                else
                {
                    percent = 7;
                }

                if (kol_det.Text != "")
                {
                    //с 00:00 до 5:59 - наценка 7%, с 06:00 до 11:59 - наценка 0%, с 12:00 до 17:59 - наценка 5%, с 18:00 до 23:59 - наценка 10% 
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Детский'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type +"'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();                  
                        
                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_det.Text);
                }

                if (kol_stud.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Студенческий'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_stud.Text);
                }

                if (kol_vz.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Взрослый'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_vz.Text);
                }

                if (kol_l.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Льготный'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_l.Text);
                }

                itogo.Text = sum + " руб.";
            }
        }

        private void kol_stud_TextChanged(object sender, EventArgs e)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(kol_det.Text) && string.IsNullOrEmpty(kol_stud.Text) && string.IsNullOrEmpty(kol_vz.Text) && string.IsNullOrEmpty(kol_l.Text))
            {
                itogo.Text = "0 руб.";
            }
            else
            {
                int percent = 0;

                if (Convert.ToDateTime(time) >= Convert.ToDateTime("6:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("11:59"))
                {
                    percent = 0;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("12:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("17:59"))
                {
                    percent = 5;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("18:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("23:59"))
                {
                    percent = 10;
                }
                else
                {
                    percent = 7;
                }

                if (kol_det.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;

                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Детский'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_det.Text);
                }

                if (kol_stud.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Студенческий'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_stud.Text);
                }

                if (kol_vz.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Взрослый'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_vz.Text);
                }

                if (kol_l.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Льготный'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_l.Text);
                }

                itogo.Text = sum + " руб.";
            }
        }

        private void kol_vz_TextChanged(object sender, EventArgs e)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(kol_det.Text) && string.IsNullOrEmpty(kol_stud.Text) && string.IsNullOrEmpty(kol_vz.Text) && string.IsNullOrEmpty(kol_l.Text))
            {
                itogo.Text = "0 руб.";
            }
            else
            {
                int percent = 0;

                if (Convert.ToDateTime(time) >= Convert.ToDateTime("6:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("11:59"))
                {
                    percent = 0;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("12:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("17:59"))
                {
                    percent = 5;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("18:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("23:59"))
                {
                    percent = 10;
                }
                else
                {
                    percent = 7;
                }

                if (kol_det.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;

                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Детский'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_det.Text);
                }

                if (kol_stud.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Студенческий'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_stud.Text);
                }

                if (kol_vz.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Взрослый'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_vz.Text);
                }

                if (kol_l.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Льготный'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_l.Text);
                }

                itogo.Text = sum + " руб.";
            }
        }

        private void kol_l_TextChanged(object sender, EventArgs e)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(kol_det.Text) && string.IsNullOrEmpty(kol_stud.Text) && string.IsNullOrEmpty(kol_vz.Text) && string.IsNullOrEmpty(kol_l.Text))
            {
                itogo.Text = "0 руб.";
            }
            else
            {
                int percent = 0;

                if (Convert.ToDateTime(time) >= Convert.ToDateTime("6:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("11:59"))
                {
                    percent = 0;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("12:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("17:59"))
                {
                    percent = 5;
                }
                else if (Convert.ToDateTime(time) >= Convert.ToDateTime("18:00") && Convert.ToDateTime(time) <= Convert.ToDateTime("23:59"))
                {
                    percent = 10;
                }
                else
                {
                    percent = 7;
                }

                if (kol_det.Text != "")
                { 
                    int cena_mesta = 1;
                    int cena_formata = 0;

                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Детский'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_det.Text);
                }

                if (kol_stud.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Студенческий'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_stud.Text);
                }

                if (kol_vz.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Взрослый'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_vz.Text);
                }

                if (kol_l.Text != "")
                {
                    int cena_mesta = 1;
                    int cena_formata = 0;
                    sqlConnection.Open();
                    SqlCommand det_mesta = new SqlCommand("SELECT Цена FROM [Тип билета] WHERE [Тип билета] = N'Льготный'", sqlConnection);
                    SqlDataReader reader = det_mesta.ExecuteReader();
                    while (reader.Read())
                    {
                        cena_mesta = Convert.ToInt32(reader["Цена"]);
                    }
                    reader.Close();

                    SqlCommand st_type = new SqlCommand("SELECT Цена FROM [Формат фильма] WHERE [Формат фильма] = N'" + type + "'", sqlConnection);
                    SqlDataReader r = st_type.ExecuteReader();
                    while (r.Read())
                    {
                        cena_formata = Convert.ToInt32(r["Цена"]);
                    }
                    r.Close();
                    sqlConnection.Close();

                    sum += (((1 + percent / 100) * cena_mesta) + cena_formata) * Convert.ToInt32(kol_l.Text);
                }

                itogo.Text = sum + " руб.";
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) e.Handled = true;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (num_form == 2)
            {
                Form2 f = new Form2();
                f.Text = text;
                f.admin = admin;
                f.post = post;
                f.status = status;
                f.Show();
            }
            else
            {
                Form3 f = new Form3();
                f.Text = text;
                f.admin = admin;
                f.post = post;
                f.status = status;
                f.Show();
            }
        }
    }
}
