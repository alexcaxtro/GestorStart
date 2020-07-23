using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GestorStart;

namespace GestorStart
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            MainPage = new LoginsPage();

            NavigationPage navPage = new NavigationPage(new MainPage());
            MainPage = navPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
