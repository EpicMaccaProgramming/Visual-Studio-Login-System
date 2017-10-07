using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Login_System
{
    public partial class Form1 : Form
    {
        //CHANGE THIS TO THE PATH WHERE THE USERNAMES/PASSWORDS WILL BE STORED
        public static string storeUserPath = "C:/UserInfo";

        //Variables
        public static List<string> user = new List<string>();
        public static List<string> pass = new List<string>();
        public static List<string> splitUserAndPass = new List<string>();
        public List<string> usernames = new List<string>();
        public List<string> passwords = new List<string>();

        string xuser;
        List<string> yuser = new List<string>();
        string xpass;
        List<string> ypass = new List<string>();

        bool validFile = false;
        int numberOfAccounts = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {

            //Check how many accounts there currently are
            while (!validFile)
            {
                if (!File.Exists(storeUserPath + "/" + numberOfAccounts + ".txt"))
                {
                    validFile = true;
                }

                else
                {
                    numberOfAccounts += 1;
                }
            }
            int passwordCounter = 0;
            bool checkedUserAndPass = false;

            //Read username/password files and info to lists
            for (int i = 1; i <= numberOfAccounts - 1; i++)
            {
                splitUserAndPass.Add(File.ReadAllText(storeUserPath + "/" + i + ".txt"));
            }

            for (int i = 0; i <= splitUserAndPass.Count - 1; i++)
            {
                xuser = splitUserAndPass[i];
                yuser.Insert(i, xuser.Split(' ')[0]);
            }

            for (int i1 = 0; i1 <= yuser.Count - 1; i1 ++)
            {
                usernames.Add(yuser[i1]);
            }

            for (int i = 0; i <= splitUserAndPass.Count - 1; i++)
            {
                xpass = splitUserAndPass[i];
                ypass.Insert(i, xpass.Split(' ')[1]);
            }

            for (int i1 = 0; i1 <= ypass.Count - 1; i1 ++)
            {
                passwords.Add(ypass[i1]);
            }

            //Check if username/password entered was correct
            for (int i = 0; i <= yuser.Count - 1; i++)
            {
                if (UsernameText.Text == usernames[i])
                {
                    if (PasswordText.Text == passwords[i])
                    {
                        MessageBox.Show("Login Successful!", "Login", MessageBoxButtons.OK);
                        var newForm = new Form2();
                        newForm.Show();
                        Hide();
                        checkedUserAndPass = true;
                        break;
                    }
                }
                passwordCounter += 1;
            }

            if (!checkedUserAndPass)
            {
                MessageBox.Show("Incorrect Username/Password", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Go to register
        private void Register_Click(object sender, EventArgs e)
        {
            var register = new register();
            register.Show();
            Hide();
        }
    }
}
