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
        //Amount of accounts variable
        public static int amountOfAccounts = 1;

        public register()
        {
            InitializeComponent();
        }

        private void RegisterAccount_Click(object sender, EventArgs e)
        {
            //Variables
            int userCounter = 0;
            bool validFile = false;

            //Save text in text input to list
            Form1.user.Add(UsernameText.Text);
            Form1.pass.Add(PasswordText.Text);

            //Check how many accounts there currently are
            while (!validFile)
            {
                if (!File.Exists(Form1.storeUserPath + "/" + amountOfAccounts + ".txt"))
                {
                    validFile = true;
                }
                
                else
                {
                    amountOfAccounts += 1;
                }
            }

            //Create new file
            TextWriter user = File.CreateText(Form1.storeUserPath + "/" + amountOfAccounts + ".txt");

            //Add username and password to file
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

            //Open login form
            var login = new Form1();
            login.Show();
            Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            //Open login form
            var login = new Form1();
            login.Show();
            Hide();
        }
    }
}
