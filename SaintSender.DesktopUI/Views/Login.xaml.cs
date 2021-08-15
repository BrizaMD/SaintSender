﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            PasswordBox.SelectAll();
            PasswordBox.Focus();
            EmailBox.SelectAll();
            EmailBox.Focus();
            this.DialogResult = true;

        }

        public string Email 
        { 
            get { return EmailBox.Text; }
        }

    }
}