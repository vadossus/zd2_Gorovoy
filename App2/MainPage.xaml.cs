using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnLoginClicked(object sender, EventArgs e)
        {
            if (LoginEntry.Text == "ects" && PasswordEntry.Text == "ects2024")
            {
                var tabbedPage = new TabbedPage1();
                tabbedPage.SetUserName(LoginEntry.Text);
                Application.Current.MainPage = new NavigationPage(tabbedPage);
            }
            else
            {
                DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            }
        }
    }
}
