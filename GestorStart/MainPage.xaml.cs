using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GestorStart.Models;

namespace GestorStart
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void btn1_click(object sender,EventArgs e)
        {
            try
            {
                UserManager manager = new UserManager();
                var res = await manager.getPacientes();

                if (res != null)
                {
                    lstPaciente.ItemsSource = res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void btn1_salir(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Salir", "¿Esta seguro que quiere cerrar sesión? ", "Si", "No");
            if (answer.Equals("Si"))
            {
                //Settings.FirstName = string.Empty;
                //Settings.LastName = string.Empty;
                //Settings.Email = string.Empty;
                App.Current.Quit();
                new NavigationPage(new LoginsPage());

            }
            else
            {

                await Navigation.PushAsync(new MainPage());

            }
        }
       

    }
}
