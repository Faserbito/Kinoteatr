using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Кинотеатр
{
    public partial class Form1 : Form
    {
        public bool admin; //кнопка для админа (добавление сеансов)
        public int post = 0;
        public string status;

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["kinoteatr"].ConnectionString);
        List<GroupBox> gb = new List<GroupBox>();
        List<LinkLabel> ll = new List<LinkLabel>();
        List<Label> l = new List<Label>();
        List<Button> days = new List<Button>();
        public Form1()
        {
            InitializeComponent();

            Day1.Text = "Сегодня" + "\n" + DateTime.Today.ToString();
            Day2.Text = "Завтра" + "\n" + DateTime.Today.AddDays(1).ToString();
            Day3.Text = DateTime.Today.AddDays(2).ToString("dddd").Substring(0, 1).ToUpper() + DateTime.Today.AddDays(2).ToString("dddd").Substring(1) + "\n" + DateTime.Today.AddDays(2).ToString();
            Day4.Text = DateTime.Today.AddDays(3).ToString("dddd").Substring(0, 1).ToUpper() + DateTime.Today.AddDays(3).ToString("dddd").Substring(1) + "\n" + DateTime.Today.AddDays(3).ToString();
            Day5.Text = DateTime.Today.AddDays(4).ToString("dddd").Substring(0, 1).ToUpper() + DateTime.Today.AddDays(4).ToString("dddd").Substring(1) + "\n" + DateTime.Today.AddDays(4).ToString();
            Day6.Text = DateTime.Today.AddDays(5).ToString("dddd").Substring(0, 1).ToUpper() + DateTime.Today.AddDays(5).ToString("dddd").Substring(1) + "\n" + DateTime.Today.AddDays(5).ToString();
            Day7.Text = DateTime.Today.AddDays(6).ToString("dddd").Substring(0, 1).ToUpper() + DateTime.Today.AddDays(6).ToString("dddd").Substring(1) + "\n" + DateTime.Today.AddDays(6).ToString();

            sqlConnection.Open();
            sqlConnection.Close();

            if (gb.Count() == 0)
            {
                gb.AddRange(new GroupBox[] { gb1, gb2, gb3, gb4, gb5, gb6 });
            } 
            
            if (ll.Count() == 0)
            {
                ll.AddRange(new LinkLabel[] { time1, time2, time3, time4, time5, time6, time7, time8, time9, time10, time11, time12, time13, time14, time15, time16, time17, time18, time19, time20, time21, time22, time23, time24, time25, time26, time27, time28, time29, time30, time31, time32, time33, time34, time35, time36, time37, time38, time39, time40, time41, time42 });
            }

            if (l.Count() == 0)
            {
                l.AddRange(new Label[] { format1, format2, format3, format4, format5, format6, format7, format8, format9, format10, format11, format12, format13, format14, format15, format16, format17, format18, format19, format20, format21, format22, format23, format24, format25, format26, format27, format28, format29, format30, format31, format32, format33, format34, format35, format36, format37, format38, format39, format40, format41, format42 });
            }

            if (days.Count() == 0)
            {
                days.AddRange(new Button[] { Day1, Day2, Day3, Day4, Day5, Day6, Day7 });
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (admin)
            {
                for_admin.Visible = true;
            }            
        }

        private void Day1_Click(object sender, EventArgs e)
        {
            Day1.BackColor = Color.DodgerBlue;
            Day2.BackColor = SystemColors.ControlLight;
            Day3.BackColor = SystemColors.ControlLight;
            Day4.BackColor = SystemColors.ControlLight;
            Day5.BackColor = SystemColors.ControlLight;
            Day6.BackColor = SystemColors.ControlLight;
            Day7.BackColor = SystemColors.ControlLight;

            cb_film.Items.Clear();
            cb_film.Text = "Выберите фильм";
            cb_film.Visible = true;
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand thisCommand = sqlConnection.CreateCommand();
            string date = DateTime.Today.Year.ToString() + "-" + DateTime.Today.ToString("MM") + "-" + DateTime.Today.ToString("dd");
            thisCommand.CommandText = "SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_film.Items.Add(thisReader["Название фильма"]);
            }
            thisReader.Close();
            sqlConnection.Close();
        }

        private void Day2_Click(object sender, EventArgs e)
        {
            Day1.BackColor = SystemColors.ControlLight;
            Day2.BackColor = Color.DodgerBlue;
            Day3.BackColor = SystemColors.ControlLight;
            Day4.BackColor = SystemColors.ControlLight;
            Day5.BackColor = SystemColors.ControlLight;
            Day6.BackColor = SystemColors.ControlLight;
            Day7.BackColor = SystemColors.ControlLight;

            cb_film.Items.Clear();
            cb_film.Text = "Выберите фильм";
            cb_film.Visible = true;
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand thisCommand = sqlConnection.CreateCommand();
            string date = DateTime.Today.AddDays(2).Year.ToString() + "-" + DateTime.Today.AddDays(2).ToString("MM") + "-" + DateTime.Today.AddDays(2).ToString("dd");
            thisCommand.CommandText = "SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_film.Items.Add(thisReader["Название фильма"]);
            }
            thisReader.Close();
            sqlConnection.Close();
        }

        private void Day3_Click(object sender, EventArgs e)
        {
            Day1.BackColor = SystemColors.ControlLight;
            Day2.BackColor = SystemColors.ControlLight;
            Day3.BackColor = Color.DodgerBlue;
            Day4.BackColor = SystemColors.ControlLight;
            Day5.BackColor = SystemColors.ControlLight;
            Day6.BackColor = SystemColors.ControlLight;
            Day7.BackColor = SystemColors.ControlLight;

            cb_film.Items.Clear();
            cb_film.Text = "Выберите фильм";
            cb_film.Visible = true;
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand thisCommand = sqlConnection.CreateCommand();
            string date = DateTime.Today.AddDays(3).Year.ToString() + "-" + DateTime.Today.AddDays(3).ToString("MM") + "-" + DateTime.Today.AddDays(3).ToString("dd");
            thisCommand.CommandText = "SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_film.Items.Add(thisReader["Название фильма"]);
            }
            thisReader.Close();
            sqlConnection.Close();
        }

        private void Day4_Click(object sender, EventArgs e)
        {
            Day1.BackColor = SystemColors.ControlLight;
            Day2.BackColor = SystemColors.ControlLight;
            Day3.BackColor = SystemColors.ControlLight;
            Day4.BackColor = Color.DodgerBlue;
            Day5.BackColor = SystemColors.ControlLight;
            Day6.BackColor = SystemColors.ControlLight;
            Day7.BackColor = SystemColors.ControlLight;

            cb_film.Items.Clear();
            cb_film.Text = "Выберите фильм";
            cb_film.Visible = true;
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand thisCommand = sqlConnection.CreateCommand();
            string date = DateTime.Today.AddDays(4).Year.ToString() + "-" + DateTime.Today.AddDays(4).ToString("MM") + "-" + DateTime.Today.AddDays(4).ToString("dd");
            thisCommand.CommandText = "SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_film.Items.Add(thisReader["Название фильма"]);
            }
            thisReader.Close();
            sqlConnection.Close();
        }

        private void Day5_Click(object sender, EventArgs e)
        {
            Day1.BackColor = SystemColors.ControlLight;
            Day2.BackColor = SystemColors.ControlLight;
            Day3.BackColor = SystemColors.ControlLight;
            Day4.BackColor = SystemColors.ControlLight;
            Day5.BackColor = Color.DodgerBlue;
            Day6.BackColor = SystemColors.ControlLight;
            Day7.BackColor = SystemColors.ControlLight;

            cb_film.Items.Clear();
            cb_film.Text = "Выберите фильм";
            cb_film.Visible = true;
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand thisCommand = sqlConnection.CreateCommand();
            string date = DateTime.Today.AddDays(5).Year.ToString() + "-" + DateTime.Today.AddDays(5).ToString("MM") + "-" + DateTime.Today.AddDays(5).ToString("dd");
            thisCommand.CommandText = "SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_film.Items.Add(thisReader["Название фильма"]);
            }
            thisReader.Close();
            sqlConnection.Close();
        }

        private void Day6_Click(object sender, EventArgs e)
        {
            Day1.BackColor = SystemColors.ControlLight;
            Day2.BackColor = SystemColors.ControlLight;
            Day3.BackColor = SystemColors.ControlLight;
            Day4.BackColor = SystemColors.ControlLight;
            Day5.BackColor = SystemColors.ControlLight;
            Day6.BackColor = Color.DodgerBlue;
            Day7.BackColor = SystemColors.ControlLight;

            cb_film.Items.Clear();
            cb_film.Text = "Выберите фильм";
            cb_film.Visible = true;
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand thisCommand = sqlConnection.CreateCommand();
            string date = DateTime.Today.AddDays(6).Year.ToString() + "-" + DateTime.Today.AddDays(6).ToString("MM") + "-" + DateTime.Today.AddDays(6).ToString("dd");
            thisCommand.CommandText = "SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_film.Items.Add(thisReader["Название фильма"]);
            }
            thisReader.Close();
            sqlConnection.Close();
        }

        private void Day7_Click(object sender, EventArgs e)
        {
            Day1.BackColor = SystemColors.ControlLight;
            Day2.BackColor = SystemColors.ControlLight;
            Day3.BackColor = SystemColors.ControlLight;
            Day4.BackColor = SystemColors.ControlLight;
            Day5.BackColor = SystemColors.ControlLight;
            Day6.BackColor = SystemColors.ControlLight;
            Day7.BackColor = Color.DodgerBlue;

            cb_film.Items.Clear();
            cb_film.Text = "Выберите фильм";
            cb_film.Visible = true;
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand thisCommand = sqlConnection.CreateCommand();
            string date = DateTime.Today.AddDays(7).Year.ToString() + "-" + DateTime.Today.AddDays(7).ToString("MM") + "-" + DateTime.Today.AddDays(7).ToString("dd");
            thisCommand.CommandText = "SELECT [Название фильма] from [Фильмы] where '" + date + "' BETWEEN [Начало проката] AND [Конец проката]";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                cb_film.Items.Add(thisReader["Название фильма"]);
            }
            thisReader.Close();
            sqlConnection.Close();
        }

        private void cb_film_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GroupBox g in gb)
            {
                g.Visible = false;
            }

            foreach (LinkLabel lil in ll)
            {
                lil.Visible = false;
            }

            foreach (Label label in l)
            {
                label.Visible = false;
            }

            sqlConnection.Open();

            //кол-во залов и названия GroupBox'ов
            SqlCommand kolvo_z = new SqlCommand("SELECT Count(Distinct(s.Зал)) FROM Сеансы s INNER JOIN Фильмы f ON s.Фильм = f.[Код фильма] WHERE f.[Название фильма] = N'" + cb_film.Text + "'", sqlConnection);
            int kol_z = Convert.ToInt32(kolvo_z.ExecuteScalar());
            List<int> zals = new List<int>();
            SqlCommand zal = new SqlCommand("SELECT Distinct(s.Зал) as Залы FROM Сеансы s INNER JOIN Фильмы f ON s.Фильм = f.[Код фильма] WHERE f.[Название фильма] = N'" + cb_film.Text + "'", sqlConnection);
            SqlDataReader reader = zal.ExecuteReader();
            while (reader.Read())
            {
                zals.Add(Convert.ToInt32(reader["Залы"]));
            }
            reader.Close();
            zals.Sort();
            bool vip = false;
            for (int i = 0; i < kol_z; i++)
            {
                SqlCommand vip_zal = new SqlCommand("SELECT VIP FROM Залы WHERE [Код зала] = " + zals[i], sqlConnection);
                SqlDataReader r = vip_zal.ExecuteReader();
                while (r.Read())
                {
                    if (Convert.ToInt32(r["VIP"]) == 1)
                    {
                        vip = true;
                    }
                    else
                    {
                        vip = false;
                    }
                }
                r.Close();

                if (vip == true)
                {
                    gb[i].Text = zals[i].ToString() + " Зал (VIP)";
                    gb[i].Visible = true;
                }
                else
                {
                    gb[i].Text = zals[i].ToString() + " Зал";
                    gb[i].Visible = true;
                }                               
            }

            List<string> time = new List<string>();
            List<string> format = new List<string>();
            int c = 0;
            for (int i = 0; i < zals.Count; i++)
            {
                SqlCommand kolvo_vremya = new SqlCommand("SELECT Count(s.Время) FROM Сеансы s INNER JOIN Фильмы f ON s.Фильм = f.[Код фильма] WHERE f.[Название фильма] = N'" + cb_film.Text + "' and s.Зал = " + zals[i], sqlConnection);
                int kol_t = Convert.ToInt32(kolvo_vremya.ExecuteScalar());
                SqlCommand vr = new SqlCommand("SELECT s.Время AS Время, form.[Формат фильма] AS Формат FROM Сеансы s INNER JOIN Фильмы f on s.Фильм = f.[Код фильма] INNER JOIN [Формат фильма] form on s.[Формат фильма] = form.[Код формата фильма] WHERE f.[Название фильма] = N'" + cb_film.Text + "' AND s.Зал = " + zals[i], sqlConnection);
                SqlDataReader reader_vr = vr.ExecuteReader();
                while (reader_vr.Read())
                {
                    DateTime vremya = DateTime.Parse(reader_vr["Время"].ToString());
                    time.Add(vremya.ToShortTimeString());
                    format.Add(reader_vr["Формат"].ToString());                    
                }
                reader_vr.Close();
                
                for (int j = i*7 + 1; j <= i*7 + kol_t; j++)
                {
                    ll[j - 1].Visible = true;
                    ll[j - 1].Text = time[c];                    
                    l[j - 1].Visible = true;
                    l[j - 1].Text = format[c];
                    if (days[0].BackColor == Color.DodgerBlue)
                    {
                        if (TimeSpan.Parse(time[c]) < TimeSpan.Parse(DateTime.Now.ToShortTimeString()))
                        {
                            ll[j - 1].Enabled = false;
                            l[j - 1].Enabled = false;
                        }
                    }
                    else
                    {
                        ll[j - 1].Enabled = true;
                        l[j - 1].Enabled = true;
                    }
                    c++;
                }
            }
            
            sqlConnection.Close();
        }

        private void cb_film_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 0) e.Handled = true;
        }

        private void time1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb1.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format1.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time1.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {                
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format1.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time1.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }           
        }

        private void time2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb1.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format2.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time2.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format2.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time2.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb1.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format3.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time3.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format3.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time3.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb1.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format4.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time4.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format4.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time4.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb1.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format5.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time5.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format5.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time5.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb1.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format6.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time6.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format6.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time6.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb1.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format7.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time7.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format7.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time7.Text + " " + gb1.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb2.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format8.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time8.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format8.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time8.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb2.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format9.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time9.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format9.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time9.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb2.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format10.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time10.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format10.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time10.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb2.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format11.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time11.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format11.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time11.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb2.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format12.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time12.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format12.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time12.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb2.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format13.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time13.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format13.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time13.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb2.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format14.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time14.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format14.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time14.Text + " " + gb2.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb3.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format15.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time15.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format15.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time15.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb3.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format16.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time16.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format16.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time16.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb3.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format17.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time17.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format17.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time17.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb3.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format18.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time18.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format18.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time18.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb3.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format19.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time19.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format19.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time19.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb3.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format20.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time20.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format20.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time20.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb3.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format21.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time21.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format21.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time21.Text + " " + gb3.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb4.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format22.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time22.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format22.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time22.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb4.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format23.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time23.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format23.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time23.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb4.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format24.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time24.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format24.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time24.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time25_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb4.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format25.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time25.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format25.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time25.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb4.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format26.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time26.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format26.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time26.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb4.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format27.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time27.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format27.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time27.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time28_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb4.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format28.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time28.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format28.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time28.Text + " " + gb4.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb5.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format29.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time29.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format29.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time29.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb5.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format30.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time30.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format30.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time30.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time31_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb5.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format31.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time31.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format31.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time31.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time32_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb5.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format32.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time32.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format32.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time32.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time33_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb5.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format33.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time33.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format33.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time33.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time34_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb5.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format34.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time34.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format34.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time34.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time35_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb5.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format35.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time35.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format35.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time35.Text + " " + gb5.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time36_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb6.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format36.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time36.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format36.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time36.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time37_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb6.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format37.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time37.Text + " " + gb6.Text;
                zal.post = post;
                zal.status = status;
                zal.admin = admin;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format37.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time37.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time38_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb6.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format38.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time38.Text + " " + gb6.Text;
                zal.post = post;
                zal.status = status;
                zal.admin = admin;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format38.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time38.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time39_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb6.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format39.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time39.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format39.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time39.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time40_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb6.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format40.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time40.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format40.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time40.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time41_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb6.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format41.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time41.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format41.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time41.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void time42_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i = 0;
            while (days[i].BackColor != Color.DodgerBlue)
            {
                i++;
            }

            if (gb6.Text.Contains("VIP"))
            {
                Form3 zal = new Form3();
                zal.Text = cb_film.Text + " " + format42.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time42.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
            else
            {
                Form2 zal = new Form2();
                zal.Text = cb_film.Text + " " + format42.Text + " ┃ " + DateTime.Today.AddDays(i).ToShortDateString() + " ┃ " + time42.Text + " " + gb6.Text;
                zal.post = post;
                zal.admin = admin;
                zal.status = status;
                zal.Show();
                Hide();
            }
        }

        private void for_admin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.post = post;
            admin.status = status;
            admin.Show();            
            Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }       
    }
}
