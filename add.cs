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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> priorities = new List<string> { "LOW", "MEDIUM", "HIGH" };
            String themeName = textBox1.Text;
            String content = textBox2.Text;
            DateTime date = monthCalendar1.SelectionRange.Start;
            int priority = priorities.IndexOf(comboBox1.SelectedItem.ToString());

            if (themeName.Length != 0 && content.Length != 0)
            {

                DB db = new DB();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("INSERT INTO `theme`(`name`, `content`, `date`, `priority`) VALUES(@name, @content, @date, @priority)", db.getConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = themeName;
                command.Parameters.Add("@content", MySqlDbType.VarChar).Value = content;
                command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
                command.Parameters.Add("@priority", MySqlDbType.Int32).Value = priority;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Добавлено!");
                }

                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Поля должны быть заполнены!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
