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
    public partial class Info : Form
    {
        public Info(String name, String content, DateTime date, int priority)
        {
            
            InitializeComponent();
            List<String> priorities = new List<string> { "LOW", "MEDIUM", "HIGH" };
            textBox2.Text = content;
            label4.Text = name;
            monthCalendar1.SetDate(date);
            label5.Text = "Приоритет: " + priorities[priority];
        }

        private void Info_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
