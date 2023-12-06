using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Кинотеатр
{
    public partial class Form2 : Form
    {
        public bool admin;
        public int post;
        public string status;

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["kinoteatr"].ConnectionString);
        List<Button> places = new List<Button>();
        List<string> bilet = new List<string>();
        string nazv = "";        
        string time, num_zal, type, date;
        
        public Form2()
        {
            InitializeComponent();

            if (places.Count() == 0)
            {
                places.AddRange(new Button[] { b11, b12, b13, b14, b15, b16, b17, b18, b19, b110, b21, b22, b23, b24, b25, b26, b27, b28, b29, b210, b31, b32, b33, b34, b35, b36, b37, b38, b41, b42, b43, b44, b45, b46, b47, b48, b51, b52, b53, b54, b55, b56, b57, b58, b61, b62, b63, b64, b65, b66, b67, b68, b71, b72, b73, b74, b75, b76, b77, b78, b81, b82, b83, b84, b85, b86, b87, b88, b89, b810, b811, b812 });
            }
            // выбирает - Green, занято (покупка) - Red, забронировано - DarkOrange, обратно - 40; 50; 67
        }

        private void Form2_Load(object sender, EventArgs e)
        {          
            string[] s = Text.Split(Convert.ToChar("┃"));
            
            string[] sl = s[0].Split();

            nazv = "";

            if (sl[sl.Length - 3] == "IMAX")
            {
                for (int i = 0; i < sl.Length - 3; i++)
                {
                    if (i == sl.Length - 4)
                    {
                        nazv += sl[i];
                    }
                    else
                    {
                        nazv += sl[i] + " ";
                    }
                }
                type = sl[sl.Length - 3] + " " + sl[sl.Length - 2];
            }
            else
            {
                for (int i = 0; i < sl.Length - 2; i++)
                {
                    if (i == sl.Length - 3)
                    {
                        nazv += sl[i];
                    }
                    else
                    {
                        nazv += sl[i] + " ";
                    }
                }
                type = sl[sl.Length - 2];
            }

            sl = s[2].Split();

            time = sl[1];
            num_zal = sl[2];

            
            sqlConnection.Open();
            date = s[1].Split(Convert.ToChar("."))[2] + "-" + s[1].Split(Convert.ToChar("."))[1] + "-" + s[1].Split(Convert.ToChar("."))[0];

            SqlCommand book_mesta = new SqlCommand($"SELECT m.Ряд, m.Место FROM Места m JOIN Билеты b ON m.[Код места] = b.Место JOIN Сеансы s ON s.[Код сеанса] = b.Сеанс JOIN [Бронь билетов] br ON br.Билет = b.[Код билета] JOIN Фильмы f ON s.Фильм = f.[Код фильма] WHERE br.[Дата брони] = '{date}' AND f.[Название фильма] = N'{nazv}' AND s.Время = '{time}' AND s.Зал = {num_zal}", sqlConnection);
            SqlDataReader reader = book_mesta.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < places.Count; i++)
                {
                    if (places[i].Name.Substring(1) == reader["Ряд"].ToString() + reader["Место"].ToString())
                    {
                        if (admin)
                        {
                            places[i].BackColor = Color.DarkOrange;
                        }
                        else
                        {
                            places[i].BackColor = Color.Red;
                        }                            
                    }
                }
            }
            reader.Close();
                
            SqlCommand buy_mesta = new SqlCommand($"SELECT m.Ряд, m.Место FROM Места m JOIN Билеты b ON m.[Код места] = b.Место JOIN Сеансы s ON s.[Код сеанса] = b.Сеанс JOIN [Продажа билетов] pr ON pr.Билет = b.[Код билета] JOIN Фильмы f ON s.Фильм = f.[Код фильма] WHERE pr.Дата = '{date}' AND f.[Название фильма] = N'{nazv}' AND s.Время = '{time}' AND s.Зал = {num_zal}", sqlConnection);
            SqlDataReader reader1 = buy_mesta.ExecuteReader();
            while (reader1.Read())
            {
                for (int i = 0; i < places.Count; i++)
                {
                    if (places[i].Name.Substring(1) == reader1["Ряд"].ToString() + reader1["Место"].ToString())
                    {
                        places[i].BackColor = Color.Red;
                    }
                }
            }
            reader1.Close();
            sqlConnection.Close();            
        }

        private void book_Click(object sender, EventArgs e)
        {
            foreach (Button place in places)
            {
                if (place.BackColor == Color.Green)
                {                    
                    bilet.Add("Ряд " + place.Name.Substring(1, 1) + " Место " + place.Name.Substring(2));                    
                    place.BackColor = Color.DarkOrange;
                }
            }
            if (bilet.Count() == 0)
            {
                MessageBox.Show("Вы не выбрали место!", "Ошибка");
            }
            else
            {
                if (post == 0)
                {
                    Post f = new Post();
                    f.time = time;
                    f.num_zal = num_zal;
                    f.nazv = nazv;
                    f.form = 2;
                    f.places = bilet;
                    f.text = Text;
                    f.admin = admin;
                    f.post = post;
                    f.date = date;
                    f.status = status;
                    Hide();
                    f.Show();
                }
                else
                {
                    foreach (string b in bilet)
                    {
                        string[] place = b.Split();
                        SqlCommand tickets = new SqlCommand("INSERT INTO Билеты VALUES ((SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' and Зал = " + num_zal + " and Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')), (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + "))", sqlConnection);
                        tickets.ExecuteNonQuery();                                                                                                                                                                                                                                                                                                                                                                  
                        SqlCommand book_m = new SqlCommand("INSERT INTO [Бронь билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' and Зал = " + num_zal + " and Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "') and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + "))), '" + date + "', N'" + post + "')", sqlConnection);
                        book_m.ExecuteNonQuery();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                    }
                    MessageBox.Show("Места успешно забронированы.");
                }
            }
        }

        private void buy_Click(object sender, EventArgs e)
        {
            foreach (Button place in places)
            {
                if (place.BackColor == Color.Green)
                {                    
                    bilet.Add("Ряд " + place.Name.Substring(1, 1) + " Место " + place.Name.Substring(2));                    
                    place.BackColor = Color.Red;
                }
            }
            if (bilet.Count() == 0)
            {
                MessageBox.Show("Вы не выбрали место!", "Ошибка");
            }
            else
            {
                Form4 f = new Form4();
                f.bilet = bilet;
                f.num_form = 2;
                f.text = Text;
                f.nazv = nazv;
                f.time = time;
                f.type = type;
                f.admin = admin;
                f.post = post;
                f.num_zal = num_zal;
                f.date = date;
                f.status = status;
                f.Show();
                Hide();
            }
        }

        private void b11_Click(object sender, EventArgs e)
        {
            if (b11.BackColor == Color.FromArgb(40, 50, 67))
            {
                b11.BackColor = Color.Green;
            }
            else if (b11.BackColor == Color.Green)
            {
                b11.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b11.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b11.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b12_Click(object sender, EventArgs e)
        {
            if (b12.BackColor == Color.FromArgb(40, 50, 67))
            {
                b12.BackColor = Color.Green;
            }
            else if (b12.BackColor == Color.Green)
            {
                b12.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b12.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b12.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b13_Click(object sender, EventArgs e)
        {
            if (b13.BackColor == Color.FromArgb(40, 50, 67))
            {
                b13.BackColor = Color.Green;
            }
            else if (b13.BackColor == Color.Green)
            {
                b13.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b13.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b13.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b14_Click(object sender, EventArgs e)
        {
            if (b14.BackColor == Color.FromArgb(40, 50, 67))
            {
                b14.BackColor = Color.Green;
            }
            else if (b14.BackColor == Color.Green)
            {
                b14.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b14.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b14.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b15_Click(object sender, EventArgs e)
        {
            if (b15.BackColor == Color.FromArgb(40, 50, 67))
            {
                b15.BackColor = Color.Green;
            }
            else if (b15.BackColor == Color.Green)
            {
                b15.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b15.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b15.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b16_Click(object sender, EventArgs e)
        {
            if (b16.BackColor == Color.FromArgb(40, 50, 67))
            {
                b16.BackColor = Color.Green;
            }
            else if (b16.BackColor == Color.Green)
            {
                b16.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b16.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b16.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b17_Click(object sender, EventArgs e)
        {
            if (b17.BackColor == Color.FromArgb(40, 50, 67))
            {
                b17.BackColor = Color.Green;
            }
            else if (b17.BackColor == Color.Green)
            {
                b17.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b17.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b17.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b18_Click(object sender, EventArgs e)
        {
            if (b18.BackColor == Color.FromArgb(40, 50, 67))
            {
                b18.BackColor = Color.Green;
            }
            else if (b18.BackColor == Color.Green)
            {
                b18.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b18.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b18.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b19_Click(object sender, EventArgs e)
        {
            if (b19.BackColor == Color.FromArgb(40, 50, 67))
            {
                b19.BackColor = Color.Green;
            }
            else if (b19.BackColor == Color.Green)
            {
                b19.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b19.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b19.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b110_Click(object sender, EventArgs e)
        {
            if (b110.BackColor == Color.FromArgb(40, 50, 67))
            {
                b110.BackColor = Color.Green;
            }
            else if (b110.BackColor == Color.Green)
            {
                b110.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b110.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b110.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b21_Click(object sender, EventArgs e)
        {
            if (b21.BackColor == Color.FromArgb(40, 50, 67))
            {
                b21.BackColor = Color.Green;
            }
            else if (b21.BackColor == Color.Green)
            {
                b21.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b21.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b21.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b22_Click(object sender, EventArgs e)
        {
            if (b22.BackColor == Color.FromArgb(40, 50, 67))
            {
                b22.BackColor = Color.Green;
            }
            else if (b22.BackColor == Color.Green)
            {
                b22.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b22.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b22.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b23_Click(object sender, EventArgs e)
        {
            if (b23.BackColor == Color.FromArgb(40, 50, 67))
            {
                b23.BackColor = Color.Green;
            }
            else if (b23.BackColor == Color.Green)
            {
                b23.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b23.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b23.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b24_Click(object sender, EventArgs e)
        {
            if (b24.BackColor == Color.FromArgb(40, 50, 67))
            {
                b24.BackColor = Color.Green;
            }
            else if (b24.BackColor == Color.Green)
            {
                b24.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b24.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b24.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b25_Click(object sender, EventArgs e)
        {
            if (b25.BackColor == Color.FromArgb(40, 50, 67))
            {
                b25.BackColor = Color.Green;
            }
            else if (b25.BackColor == Color.Green)
            {
                b25.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b25.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b25.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b26_Click(object sender, EventArgs e)
        {
            if (b26.BackColor == Color.FromArgb(40, 50, 67))
            {
                b26.BackColor = Color.Green;
            }
            else if (b26.BackColor == Color.Green)
            {
                b26.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b26.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b26.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b27_Click(object sender, EventArgs e)
        {
            if (b27.BackColor == Color.FromArgb(40, 50, 67))
            {
                b27.BackColor = Color.Green;
            }
            else if (b27.BackColor == Color.Green)
            {
                b27.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b27.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b27.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }           

        private void b28_Click(object sender, EventArgs e)
        {
            if (b28.BackColor == Color.FromArgb(40, 50, 67))
            {
                b28.BackColor = Color.Green;
            }
            else if (b28.BackColor == Color.Green)
            {
                b28.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b28.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b28.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b29_Click(object sender, EventArgs e)
        {
            if (b29.BackColor == Color.FromArgb(40, 50, 67))
            {
                b29.BackColor = Color.Green;
            }
            else if (b29.BackColor == Color.Green)
            {
                b29.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b29.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b29.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b210_Click(object sender, EventArgs e)
        {
            if (b210.BackColor == Color.FromArgb(40, 50, 67))
            {
                b210.BackColor = Color.Green;
            }
            else if (b210.BackColor == Color.Green)
            {
                b210.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b210.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b210.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b31_Click(object sender, EventArgs e)
        {
            if (b31.BackColor == Color.FromArgb(40, 50, 67))
            {
                b31.BackColor = Color.Green;
            }
            else if (b31.BackColor == Color.Green)
            {
                b31.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b31.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b31.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b32_Click(object sender, EventArgs e)
        {
            if (b32.BackColor == Color.FromArgb(40, 50, 67))
            {
                b32.BackColor = Color.Green;
            }
            else if (b32.BackColor == Color.Green)
            {
                b32.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b32.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b32.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b33_Click(object sender, EventArgs e)
        {
            if (b33.BackColor == Color.FromArgb(40, 50, 67))
            {
                b33.BackColor = Color.Green;
            }
            else if (b33.BackColor == Color.Green)
            {
                b33.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b33.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b33.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b34_Click(object sender, EventArgs e)
        {
            if (b34.BackColor == Color.FromArgb(40, 50, 67))
            {
                b34.BackColor = Color.Green;
            }
            else if (b34.BackColor == Color.Green)
            {
                b34.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b34.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b34.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b35_Click(object sender, EventArgs e)
        {
            if (b35.BackColor == Color.FromArgb(40, 50, 67))
            {
                b35.BackColor = Color.Green;
            }
            else if (b35.BackColor == Color.Green)
            {
                b35.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b35.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b35.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b36_Click(object sender, EventArgs e)
        {
            if (b36.BackColor == Color.FromArgb(40, 50, 67))
            {
                b36.BackColor = Color.Green;
            }
            else if (b36.BackColor == Color.Green)
            {
                b36.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b36.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b36.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b37_Click(object sender, EventArgs e)
        {
            if (b37.BackColor == Color.FromArgb(40, 50, 67))
            {
                b37.BackColor = Color.Green;
            }
            else if (b37.BackColor == Color.Green)
            {
                b37.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b37.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b37.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b38_Click(object sender, EventArgs e)
        {
            if (b38.BackColor == Color.FromArgb(40, 50, 67))
            {
                b38.BackColor = Color.Green;
            }
            else if (b38.BackColor == Color.Green)
            {
                b38.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b38.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b38.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b41_Click(object sender, EventArgs e)
        {
            if (b41.BackColor == Color.FromArgb(40, 50, 67))
            {
                b41.BackColor = Color.Green;
            }
            else if (b41.BackColor == Color.Green)
            {
                b41.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b41.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b41.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b42_Click(object sender, EventArgs e)
        {
            if (b42.BackColor == Color.FromArgb(40, 50, 67))
            {
                b42.BackColor = Color.Green;
            }
            else if (b42.BackColor == Color.Green)
            {
                b42.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b42.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b42.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b43_Click(object sender, EventArgs e)
        {
            if (b43.BackColor == Color.FromArgb(40, 50, 67))
            {
                b43.BackColor = Color.Green;
            }
            else if (b43.BackColor == Color.Green)
            {
                b43.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b43.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b43.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b44_Click(object sender, EventArgs e)
        {
            if (b44.BackColor == Color.FromArgb(40, 50, 67))
            {
                b44.BackColor = Color.Green;
            }
            else if (b44.BackColor == Color.Green)
            {
                b44.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b44.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b44.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b45_Click(object sender, EventArgs e)
        {
            if (b45.BackColor == Color.FromArgb(40, 50, 67))
            {
                b45.BackColor = Color.Green;
            }
            else if (b45.BackColor == Color.Green)
            {
                b45.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b45.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b45.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b46_Click(object sender, EventArgs e)
        {
            if (b46.BackColor == Color.FromArgb(40, 50, 67))
            {
                b46.BackColor = Color.Green;
            }
            else if (b46.BackColor == Color.Green)
            {
                b46.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b46.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b46.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b47_Click(object sender, EventArgs e)
        {
            if (b47.BackColor == Color.FromArgb(40, 50, 67))
            {
                b47.BackColor = Color.Green;
            }
            else if (b47.BackColor == Color.Green)
            {
                b47.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b47.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b47.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b48_Click(object sender, EventArgs e)
        {
            if (b48.BackColor == Color.FromArgb(40, 50, 67))
            {
                b48.BackColor = Color.Green;
            }
            else if (b48.BackColor == Color.Green)
            {
                b48.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b48.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b48.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b51_Click(object sender, EventArgs e)
        {
            if (b51.BackColor == Color.FromArgb(40, 50, 67))
            {
                b51.BackColor = Color.Green;
            }
            else if (b51.BackColor == Color.Green)
            {
                b51.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b51.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b51.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b52_Click(object sender, EventArgs e)
        {
            if (b52.BackColor == Color.FromArgb(40, 50, 67))
            {
                b52.BackColor = Color.Green;
            }
            else if (b52.BackColor == Color.Green)
            {
                b52.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b52.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b52.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b53_Click(object sender, EventArgs e)
        {
            if (b53.BackColor == Color.FromArgb(40, 50, 67))
            {
                b53.BackColor = Color.Green;
            }
            else if (b53.BackColor == Color.Green)
            {
                b53.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b53.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b53.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b54_Click(object sender, EventArgs e)
        {
            if (b54.BackColor == Color.FromArgb(40, 50, 67))
            {
                b54.BackColor = Color.Green;
            }
            else if (b54.BackColor == Color.Green)
            {
                b54.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b54.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b54.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b55_Click(object sender, EventArgs e)
        {
            if (b55.BackColor == Color.FromArgb(40, 50, 67))
            {
                b55.BackColor = Color.Green;
            }
            else if (b55.BackColor == Color.Green)
            {
                b55.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b55.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b55.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b56_Click(object sender, EventArgs e)
        {
            if (b56.BackColor == Color.FromArgb(40, 50, 67))
            {
                b56.BackColor = Color.Green;
            }
            else if (b56.BackColor == Color.Green)
            {
                b56.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b56.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b56.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b57_Click(object sender, EventArgs e)
        {
            if (b57.BackColor == Color.FromArgb(40, 50, 67))
            {
                b57.BackColor = Color.Green;
            }
            else if (b57.BackColor == Color.Green)
            {
                b57.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b57.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b57.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b58_Click(object sender, EventArgs e)
        {
            if (b58.BackColor == Color.FromArgb(40, 50, 67))
            {
                b58.BackColor = Color.Green;
            }
            else if (b58.BackColor == Color.Green)
            {
                b58.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b58.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b58.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b61_Click(object sender, EventArgs e)
        {
            if (b61.BackColor == Color.FromArgb(40, 50, 67))
            {
                b61.BackColor = Color.Green;
            }
            else if (b61.BackColor == Color.Green)
            {
                b61.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b61.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b61.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b62_Click(object sender, EventArgs e)
        {
            if (b62.BackColor == Color.FromArgb(40, 50, 67))
            {
                b62.BackColor = Color.Green;
            }
            else if (b62.BackColor == Color.Green)
            {
                b62.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b62.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b62.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b63_Click(object sender, EventArgs e)
        {
            if (b63.BackColor == Color.FromArgb(40, 50, 67))
            {
                b63.BackColor = Color.Green;
            }
            else if (b63.BackColor == Color.Green)
            {
                b63.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b63.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b63.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b64_Click(object sender, EventArgs e)
        {
            if (b64.BackColor == Color.FromArgb(40, 50, 67))
            {
                b64.BackColor = Color.Green;
            }
            else if (b64.BackColor == Color.Green)
            {
                b64.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b64.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b64.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b65_Click(object sender, EventArgs e)
        {
            if (b65.BackColor == Color.FromArgb(40, 50, 67))
            {
                b65.BackColor = Color.Green;
            }
            else if (b65.BackColor == Color.Green)
            {
                b65.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b65.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b65.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b66_Click(object sender, EventArgs e)
        {
            if (b66.BackColor == Color.FromArgb(40, 50, 67))
            {
                b66.BackColor = Color.Green;
            }
            else if (b66.BackColor == Color.Green)
            {
                b66.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b66.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b66.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b67_Click(object sender, EventArgs e)
        {
            if (b67.BackColor == Color.FromArgb(40, 50, 67))
            {
                b67.BackColor = Color.Green;
            }
            else if (b67.BackColor == Color.Green)
            {
                b67.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b67.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b67.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b68_Click(object sender, EventArgs e)
        {
            if (b68.BackColor == Color.FromArgb(40, 50, 67))
            {
                b68.BackColor = Color.Green;
            }
            else if (b68.BackColor == Color.Green)
            {
                b68.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b68.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b68.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b71_Click(object sender, EventArgs e)
        {
            if (b71.BackColor == Color.FromArgb(40, 50, 67))
            {
                b71.BackColor = Color.Green;
            }
            else if (b71.BackColor == Color.Green)
            {
                b71.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b71.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b71.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b72_Click(object sender, EventArgs e)
        {
            if (b72.BackColor == Color.FromArgb(40, 50, 67))
            {
                b72.BackColor = Color.Green;
            }
            else if (b72.BackColor == Color.Green)
            {
                b72.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b72.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b72.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b73_Click(object sender, EventArgs e)
        {
            if (b73.BackColor == Color.FromArgb(40, 50, 67))
            {
                b73.BackColor = Color.Green;
            }
            else if (b73.BackColor == Color.Green)
            {
                b73.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b73.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b73.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b74_Click(object sender, EventArgs e)
        {
            if (b74.BackColor == Color.FromArgb(40, 50, 67))
            {
                b74.BackColor = Color.Green;
            }
            else if (b74.BackColor == Color.Green)
            {
                b74.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b74.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b74.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b75_Click(object sender, EventArgs e)
        {
            if (b75.BackColor == Color.FromArgb(40, 50, 67))
            {
                b75.BackColor = Color.Green;
            }
            else if (b75.BackColor == Color.Green)
            {
                b75.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b75.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b75.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b76_Click(object sender, EventArgs e)
        {
            if (b76.BackColor == Color.FromArgb(40, 50, 67))
            {
                b76.BackColor = Color.Green;
            }
            else if (b76.BackColor == Color.Green)
            {
                b76.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b76.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b76.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b77_Click(object sender, EventArgs e)
        {
            if (b77.BackColor == Color.FromArgb(40, 50, 67))
            {
                b77.BackColor = Color.Green;
            }
            else if (b77.BackColor == Color.Green)
            {
                b77.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b77.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b77.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b78_Click(object sender, EventArgs e)
        {
            if (b78.BackColor == Color.FromArgb(40, 50, 67))
            {
                b78.BackColor = Color.Green;
            }
            else if (b78.BackColor == Color.Green)
            {
                b78.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b78.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b78.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b81_Click(object sender, EventArgs e)
        {
            if (b81.BackColor == Color.FromArgb(40, 50, 67))
            {
                b81.BackColor = Color.Green;
            }
            else if (b81.BackColor == Color.Green)
            {
                b81.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b81.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b81.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b82_Click(object sender, EventArgs e)
        {
            if (b82.BackColor == Color.FromArgb(40, 50, 67))
            {
                b82.BackColor = Color.Green;
            }
            else if (b82.BackColor == Color.Green)
            {
                b82.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b82.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b82.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b83_Click(object sender, EventArgs e)
        {
            if (b83.BackColor == Color.FromArgb(40, 50, 67))
            {
                b83.BackColor = Color.Green;
            }
            else if (b83.BackColor == Color.Green)
            {
                b83.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b83.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b83.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b84_Click(object sender, EventArgs e)
        {
            if (b84.BackColor == Color.FromArgb(40, 50, 67))
            {
                b84.BackColor = Color.Green;
            }
            else if (b84.BackColor == Color.Green)
            {
                b84.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b84.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b84.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b85_Click(object sender, EventArgs e)
        {
            if (b85.BackColor == Color.FromArgb(40, 50, 67))
            {
                b85.BackColor = Color.Green;
            }
            else if (b85.BackColor == Color.Green)
            {
                b85.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b85.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b85.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b86_Click(object sender, EventArgs e)
        {
            if (b86.BackColor == Color.FromArgb(40, 50, 67))
            {
                b86.BackColor = Color.Green;
            }
            else if (b86.BackColor == Color.Green)
            {
                b86.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b86.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b86.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b87_Click(object sender, EventArgs e)
        {
            if (b87.BackColor == Color.FromArgb(40, 50, 67))
            {
                b87.BackColor = Color.Green;
            }
            else if (b87.BackColor == Color.Green)
            {
                b87.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b87.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b87.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b88_Click(object sender, EventArgs e)
        {
            if (b88.BackColor == Color.FromArgb(40, 50, 67))
            {
                b88.BackColor = Color.Green;
            }
            else if (b88.BackColor == Color.Green)
            {
                b88.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b88.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b88.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b89_Click(object sender, EventArgs e)
        {
            if (b89.BackColor == Color.FromArgb(40, 50, 67))
            {
                b89.BackColor = Color.Green;
            }
            else if (b89.BackColor == Color.Green)
            {
                b89.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b89.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b89.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b810_Click(object sender, EventArgs e)
        {
            if (b810.BackColor == Color.FromArgb(40, 50, 67))
            {
                b810.BackColor = Color.Green;
            }
            else if (b810.BackColor == Color.Green)
            {
                b810.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b810.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b810.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b811_Click(object sender, EventArgs e)
        {
            if (b811.BackColor == Color.FromArgb(40, 50, 67))
            {
                b811.BackColor = Color.Green;
            }
            else if (b811.BackColor == Color.Green)
            {
                b811.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b811.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b811.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void b812_Click(object sender, EventArgs e)
        {
            if (b812.BackColor == Color.FromArgb(40, 50, 67))
            {
                b812.BackColor = Color.Green;
            }
            else if (b812.BackColor == Color.Green)
            {
                b812.BackColor = Color.FromArgb(40, 50, 67);
            }
            else if (b812.BackColor == Color.DarkOrange)
            {
                MessageBox.Show("Данное место забронировано");
            }
            else if (b812.BackColor == Color.Red)
            {
                MessageBox.Show("Данное место занято");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f = new Form1();
            f.admin = admin;
            f.post = post;
            f.status = status;
            f.Show();
        }
    }
}
