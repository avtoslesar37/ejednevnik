using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejednevnik
{
    public partial class Form1 : Form
    {
        private Form currentChildForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add a = new add();
            a.Show();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //listBox1.Items.Add(themes);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from theme", db.getConnection());

            //adapter.SelectCommand = command;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            List<Theme> themes = new List<Theme>();

            while (reader.Read())
            {
                Theme theme = new Theme();
                int id = (int)reader[0];
                String name = (string)reader[1];
                DateTime date = (DateTime)reader[2];
                String content = (string)reader[3];
                theme.Id = id;
                theme.Name = name;
                theme.Date = date;
                theme.Content = content;

                listBox1.Items.Add(theme);
                //themes.Add(theme);
            }
            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Theme theme = (Theme)listBox1.SelectedItem;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("delete from theme where `theme_id` = @id", db.getConnection());
            command.Parameters.Add("@id", (MySqlDbType)SqlDbType.Int).Value = theme.Id;
            //adapter.SelectCommand = command;

            db.openConnection();

            command.ExecuteNonQuery();

            db.closeConnection();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from theme", db.getConnection());

            //adapter.SelectCommand = command;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            List<Theme> themes = new List<Theme>();

            while (reader.Read())
            {
                Theme theme = new Theme();
                int id = (int)reader[0];
                String name = (string)reader[1];
                DateTime date = (DateTime)reader[2];
                String content = (string)reader[3];
                int priority = (int)reader[4];

                theme.Id = id;
                theme.Name = name;
                theme.Date = date;
                theme.Content = content;
                theme.Priority = priority;

                listBox1.Items.Add(theme);
                //themes.Add(theme);
            }
            db.closeConnection();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from theme", db.getConnection());

            //adapter.SelectCommand = command;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            List<Theme> themes = new List<Theme>();

            while (reader.Read())
            {
                Theme theme = new Theme();
                int id = (int)reader[0];
                String name = (string)reader[1];
                DateTime date = (DateTime)reader[2];
                String content = (string)reader[3];
                int priority = (int)reader[4];

                theme.Id = id;
                theme.Name = name;
                theme.Date = date;
                theme.Content = content;
                theme.Priority = priority;

                themes.Add(theme);
            }
            db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Theme theme = (Theme)listBox1.SelectedItem;
            Info info = new Info(theme.Name, theme.Content, theme.Date, theme.Priority);
            info.Show();
        }


        private int fl = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from theme", db.getConnection());

            //adapter.SelectCommand = command;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            List<Theme> themes = new List<Theme>();

            while (reader.Read())
            {
                Theme theme = new Theme();
                int id = (int)reader[0];
                String name = (string)reader[1];
                DateTime date = (DateTime)reader[2];
                String content = (string)reader[3];
                theme.Id = id;
                theme.Name = name;
                theme.Date = date;
                theme.Content = content;

                themes.Add(theme);
                //themes.Add(theme);
            }
            db.closeConnection();

            fl++;
            if(fl == 1)
            {
                button5.Text = "Приоритет";

                /*Theme temp;
                for (int i = 0; i < themes.Count - 1; i++)
                {
                    for (int j = i + 1; j < themes.Count; j++)
                    {
                        if (themes[i].Date > themes[j].Date)
                        {
                            temp = themes[i];
                            themes[i] = themes[j];
                            themes[j] = temp;
                        }
                    }
                }*/
                themes = themes.OrderBy(keySelector: x => x.Date).ToList();
            }
            else if (fl == 2)
            {

                button5.Text = "Алфавит";

                themes = themes.OrderBy(keySelector: x => x.Priority).ToList();
            }
            else
            {
                fl = 0;
                button5.Text = "Дата";
                themes = themes.OrderBy(keySelector: x => x.Name).ToList();
            }

            listBox1.Items.Clear();

            for(int i = 0; i < themes.Count; i++)
            {
                listBox1.Items.Add(themes[i]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from theme", db.getConnection());

            //adapter.SelectCommand = command;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            List<Theme> themes = new List<Theme>();

            while (reader.Read())
            {
                Theme theme = new Theme();
                int id = (int)reader[0];
                String name = (string)reader[1];
                DateTime date = (DateTime)reader[2];
                String content = (string)reader[3];
                int priority = (int)reader[4];

                theme.Id = id;
                theme.Name = name;
                theme.Date = date;
                theme.Content = content;
                theme.Priority = priority;

                themes.Add(theme);
                //themes.Add(theme);
            }
            db.closeConnection();

            String search = textBox1.Text;
            listBox1.Items.Clear();

            for (int i = 0; i < themes.Count; i++)
            {
                if (themes[i].Name.Contains(search))
                {
                    listBox1.Items.Add(themes[i]);
                }
            }

            textBox1.Text = "";
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
