using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Кинотеатр
{
    public partial class First : Form
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["kinoteatr"].ConnectionString);
        public First()
        {
            InitializeComponent();
            sqlConnection.Open();
            sqlConnection.Close();
        }

        private void b_enter_Click(object sender, EventArgs e)
        {
            b_enter.Visible = false;
            b_anon.Visible = false;
            back.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            b_vhod.Visible = true;
        }

        private void b_anon_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.admin = false;
            f.Show();
            Hide();
        }

        private void back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            b_enter.Visible = true;
            b_anon.Visible = true;
            back.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            b_vhod.Visible = false;
        }

        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            if (chb.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void b_vhod_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(login.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Заполните поля \"Логин\" и \"Пароль\"");
            }
            else
            {
                bool admin = false;
                string post = "";
                string status = "not admin";

                sqlConnection.Open();
                SqlCommand access = new SqlCommand("SELECT Логин, Пароль, Почта FROM Сотрудники ", sqlConnection);
                SqlDataReader reader = access.ExecuteReader();
                while (reader.Read())
                {
                    if (login.Text == reader["Логин"].ToString() && password.Text == reader["Пароль"].ToString())
                    {
                        admin = true;
                        post = reader["Почта"].ToString();
                        break;
                    }
                }                
                reader.Close();                               
                
                if (admin)
                {
                    bool flag = false;
                    Form1 f = new Form1();
                    f.admin = true;

                    SqlCommand stat = new SqlCommand($"SELECT Должность FROM Сотрудники WHERE Логин = N'{login.Text}'", sqlConnection);
                    SqlDataReader thisreader = stat.ExecuteReader();
                    while (thisreader.Read())
                    {
                        if (thisreader["Должность"].ToString() == "Администратор")
                        {
                            status = "admin";
                        }
                    }
                    thisreader.Close();

                    f.status = status;

                    SqlCommand pochta = new SqlCommand("SELECT [Код пользователя], [Почта пользователя] FROM Пользователи", sqlConnection);
                    SqlDataReader r = pochta.ExecuteReader();
                    while (r.Read())
                    {
                        if (r["Почта пользователя"].ToString() == post)
                        {
                            flag = true;
                            f.post = Convert.ToInt32(r["Код пользователя"]);
                            break;
                        }
                    }
                    r.Close();

                    if (flag == false)
                    {
                        SqlCommand new_post = new SqlCommand($"INSERT INTO Пользователи VALUES (N'{post}')", sqlConnection);
                        new_post.ExecuteNonQuery();
                        SqlDataReader read = pochta.ExecuteReader();
                        while (read.Read())
                        {
                            if (read["Почта пользователя"].ToString() == post)
                            {
                                f.post = Convert.ToInt32(read["Код пользователя"]);
                                break;
                            }
                        }
                        read.Close();
                    }                    
                    
                    f.Show();
                    Hide();
                    
                    sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль! Попробуйте еще раз.");
                    login.Text = "";
                    password.Text = "";
                }
            }            
        }
    }
}
