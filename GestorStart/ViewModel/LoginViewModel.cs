using GestorStart.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestorStart.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(Login);
        }
        public async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Email",
                    "Aceptar");

                return;

            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Password",
                    "Aceptar");

                return;

            }

            if (!this.Email.Equals("leica") || !this.Password.Equals("leica"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario y/o Contraseñas son incorrectas.",
                    "Aceptar");

                return;

            }

            

            var mp = new MainPage();
            Application.Current.MainPage = new NavigationPage(mp);


        }
    }
}


