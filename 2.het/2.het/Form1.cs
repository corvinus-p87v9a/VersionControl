﻿using _2.het.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            label1.Text = Resource1.LastName; // label1
            label2.Text = Resource1.FirstName; // label2
            button1.Text = Resource1.Add; // button1

            // listbox1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            var u = new user()
            {
                LastName = textBox1.Text,
                FirstName = textBox2.Text
            };
            users.Add(u);
        }
    }
}
