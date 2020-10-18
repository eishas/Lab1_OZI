﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI_lab1
{
    public partial class ChangePassword : Form
    {
        User user = new User();
        UserContext userContext = new UserContext();

        public ChangePassword(string name)
        {
            InitializeComponent();
            user.Name = name;
        }

        private bool IsPasswordPossible(string password)
        {
            if ((password.Any(c => char.IsLetter(c))) && (password.Any(c => char.IsNumber(c))))
                return true;
            else return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (oldPassword.Text == userContext.Users.Find(user.Name).Password.ToString())
            {
                if ((IsPasswordPossible(newPassword.Text) == false) && (userContext.Users.Find(user.Name).Restriction == true))
                    MessageBox.Show("Пароль має містити букви та цифри");
                else if (newPassword.Text == confirmPassword.Text)
                {
                    user.Password = newPassword.Text;
                    userContext.Users.Find(user.Name).Password = user.Password;
                    MessageBox.Show("Пароль успішно змінено");
                }
                else MessageBox.Show("Спробуйте ще раз");
            }
            else MessageBox.Show("Введіть вірний старий пароль");
            userContext.SaveChanges();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void oldPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
