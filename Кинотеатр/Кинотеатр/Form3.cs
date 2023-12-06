using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Кинотеатр
{
    public partial class Form3 : Form
    {
        public bool admin;
        public int post;
        public string status;

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["kinoteatr"].ConnectionString);
        List<Button> places = new List<Button>();
        List<string> bilet = new List<string>();
        string nazv = "";
        string time, num_zal, date;

        public Form3()
        {
            InitializeComponent();

            if (places.Count() == 0)
            {
                places.AddRange(new Button[] { b11, b12, b13, b14, b21, b22, b23, b24, b31, b32 });
            }
        }

        private void Form3_Load(object sender, EventArgs e)
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
            }

            sl = s[2].Split();

            time = sl[1];
            num_zal = sl[2];

            
            sqlConnection.Open();
            date = s[1].Split(Convert.ToChar("."))[2] + "-" + s[1].Split(Convert.ToChar("."))[1] + "-" + s[1].Split(Convert.ToChar("."))[0];

            SqlCommand book_mesta = new SqlCommand("SELECT Ряд, Место FROM Места WHERE [Код места] = (SELECT b.Место FROM Билеты b JOIN Сеансы s ON b.Сеанс = (SELECT s.[Код сеанса] WHERE s.Время = '" + time + "' AND s.Зал = " + num_zal + " AND s.Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')) WHERE b.[Код билета] = (SELECT Билет FROM [Бронь билетов]))", sqlConnection);
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

            SqlCommand buy_mesta = new SqlCommand("SELECT Ряд, Место FROM Места WHERE[Код места] = (SELECT b.Место FROM Билеты b JOIN Сеансы s ON b.Сеанс = (SELECT s.[Код сеанса] WHERE s.Время = '" + time + "' AND s.Зал = " + num_zal + " AND s.Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')) JOIN[Продажа билетов] pr ON b.[Код билета] = (SELECT pr.Билет WHERE Дата = '" + date + "'))", sqlConnection);
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
                    f.form = 3;
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
                        SqlCommand book_m = new SqlCommand("INSERT INTO [Бронь билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' and Зал = " + num_zal + " and Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "') and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + "))), " + DateTime.Today.ToShortDateString() + ", N'" + post + "')", sqlConnection);
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
                f.num_form = 3;
                f.text = Text;
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

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f = new Form1();
            f.admin = admin;
            f.post = post;
            f.status = status;
            f.Show();
        }
    }
}
