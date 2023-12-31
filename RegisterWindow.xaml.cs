﻿using GreenThumb;
using System;
using System.Windows;

namespace greenthumb
{
    public partial class RegisterWindow : Window
    {
        private User greenThumbManager;

        public RegisterWindow(User manager)
        {
            InitializeComponent();
            greenThumbManager = manager;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Kontrollera om användarnamnet redan är upptaget
            if (greenThumbManager.IsUsernameTaken(username))
            {
                MessageBox.Show("Användarnamnet är redan upptaget. Vänligen välj ett annat användarnamn.", "Varning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                User newUser = new User { Username = username, PasswordHash = password };
                greenThumbManager.AddUser(newUser);

                // Visa meddelande och stäng fönstret
                MessageBox.Show("Användaren har skapats framgångsrikt.", "Bekräftelse", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
    }
}
