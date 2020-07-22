using GestorStart.ServicesHandler;
using GestorStart.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GestorStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(Email.Text, Password.Text);

            if (getLoginDetails)
            {
                var mp = new MainPage();
                Application.Current.MainPage = new NavigationPage(mp);
                await DisplayAlert("Inicio de sesión exitoso", "Has Iniciado", "Ok", "Cancelar");
            }
            else
            {
                await DisplayAlert("Inicio de sesión fallido", "Usuario o Password son incorrectos o no existen", "Ok", "Cancelar");
            }
        }
    }
}