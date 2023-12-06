using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

namespace Кинотеатр
{
    public partial class Post : Form
    {
        public string nazv, time, num_zal;
        public int form;
        public List<string> places = new List<string>();
        public string text, date;
        public bool admin;
        public int post;
        public string status;

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["kinoteatr"].ConnectionString);

        public Post()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите свою почту!");
            }
            else
            {
                sqlConnection.Open();

                foreach (string bilet in places)
                {
                    string[] place = bilet.Split();
                    SqlCommand tickets = new SqlCommand("INSERT INTO Билеты VALUES ((SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' and Зал = " + num_zal + " and Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "')), (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + "))", sqlConnection);
                    tickets.ExecuteNonQuery();                                                                                                                                                                                                                                                                                                                                                                  
                    SqlCommand book_m = new SqlCommand("INSERT INTO [Бронь билетов] VALUES ((SELECT [Код билета] FROM Билеты WHERE Сеанс = (SELECT [Код сеанса] FROM Сеансы WHERE Время = '" + time + "' and Зал = " + num_zal + " and Фильм = (SELECT [Код фильма] FROM Фильмы WHERE [Название фильма] = N'" + nazv + "') and Место = (SELECT [Код места] FROM Места WHERE [Номер зала] = " + num_zal + " AND Ряд = " + place[1] + " AND Место = " + place[3] + "))), '" + date + "', (SELECT [Код пользователя] FROM Пользователи WHERE [Почта пользователя] = N'" + textBox1.Text + "'))", sqlConnection);
                    book_m.ExecuteNonQuery();                    
                }
                MessageBox.Show("Места успешно забронированы.");

                sqlConnection.Close();

                if (form == 2)
                {
                    Form2 f = new Form2();
                    f.Text = text;
                    f.admin = admin;
                    f.post = post;
                    f.status = status;
                    f.Show();
                    Close();
                }
                else
                {
                    Form3 f = new Form3();
                    f.Text = text;
                    f.admin = admin;
                    f.post = post;
                    f.status = status;
                    f.Show();
                    Close();
                }
            }
        }
    }
}
