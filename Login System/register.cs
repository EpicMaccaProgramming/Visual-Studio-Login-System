using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Login_System
{
    public partial class register : Form
    {
        public static int amountOfAccounts = 1;

        public register()
        {
            InitializeComponent();
        }

        private void ollol_Click(object sender, EventArgs e)
        {
            int userCounter = 0;
            bool validFile = false;

            Form1.user.Add(UsernameText.Text);
            Form1.pass.Add(PasswordText.Text);

            while (!validFile)
            {
                if (!File.Exists("C:/UserInfo/" + amountOfAccounts + ".txt"))
                {
                    validFile = true;
                }
                
                else
                {
                    amountOfAccounts += 1;
                }
            }
            TextWriter user = File.CreateText("C:/UserInfo/" + amountOfAccounts + ".txt");


            foreach (string item in Form1.user)
            {
                user.Write(Form1.user[userCounter] + " ");
                user.Write(Form1.pass[userCounter] + " ");
                user.WriteLine("");
                userCounter += 1;
            }
            user.Close();
            Form1.user.Clear();
            Form1.pass.Clear();

            var login = new Form1();
            login.Show();
            Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            var login = new Form1();
            login.Show();
            Hide();
        }
    }
}
