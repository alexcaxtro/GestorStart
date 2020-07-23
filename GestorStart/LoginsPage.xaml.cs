using GestorStart.Services;
using GestorStart.ServicesHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestorStart 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginsPage : ContentPage
    {
       


        public LoginsPage()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(Email.Text, Password.Text);

            if (getLoginDetails)
            {
                                
                
                await DisplayAlert("Inicio de sesión exitoso", "Has iniciado sesión", "Ok", "Cancelar");

                var mp = new MainPage();
                Application.Current.MainPage = new NavigationPage(mp);
            }
            else
            {
                await DisplayAlert("Inicio de sesión fallido", "Usuario y/o Password son incorrectos o no existen", "Ok", "Cancelar");
            }



        }
    }
}