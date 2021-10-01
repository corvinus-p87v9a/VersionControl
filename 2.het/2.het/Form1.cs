using _2.het.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.het
{
    public partial class Form1 : Form
    {
        BindingList<user> users = new BindingList<user>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName; // label1
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.button2; // button2    


            // listbox1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            var u = new user()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                foreach (var u in users)
                {
                    sw.Write(u.ID);
                    sw.Write(";");
                    sw.Write(u.FullName);
                    sw.WriteLine();
                }
        }
    }
}
    