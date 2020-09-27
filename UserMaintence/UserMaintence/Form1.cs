using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintence.Entities;

namespace UserMaintence
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName; 
            lblFirstName.Text = Resource1.FirstName; 
            btnAdd.Text = Resource1.Add;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

            var u = new User()
            {
                LastName = txtFullName.Text,
                FirstName = txtFirstName.Text
            };
            users.Add(u);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
