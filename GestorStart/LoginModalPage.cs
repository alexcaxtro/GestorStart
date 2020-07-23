using GestorStart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestorStart
{
    public class LoginModalPage : CarouselPage
    {
        ContentPage login;

        public LoginModalPage(ILoginManager ilm)
        {
            //login = new LoginXamSharp(ilm);

            //this.Children.Add(login);
            //MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            //{
            //    this.SelectedItem = login;
            //});
        }
    }
}
