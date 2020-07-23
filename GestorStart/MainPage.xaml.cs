﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GestorStart.Models;
using GestorStart.Services;
using GestorStart.RestApiClient;

namespace GestorStart
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ApiServices apiServices;
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
                string Nombre = "";
                string Rut = "";
                string Sexo = "";
                int PacienteId = 0;
                if (res != null)
                {
                    foreach (var item in res)
                    {
                        Nombre = item.Nombres;
                        Rut = item.Rut;
                        Sexo = item.Sexo;
                        PacienteId = item.PacienteId;
                    }

                    this.BindingContext = Nombre;
                    this.BindingContext = Rut;
                    this.BindingContext = Sexo;
                    this.BindingContext = PacienteId;


                    lstPaciente.ItemsSource = res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btn2_click(object sender, EventArgs e)
        {
            try
            {
                RestClient<Paciente> infoPac = new RestClient<Paciente>();
                var res = await infoPac.getPaciente();

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
        private async void btn3_click(object sender, EventArgs e)
        {
            try
            {
                RestClient<Calendario> infoCal = new RestClient<Calendario>();
                var res = await infoCal.getCitas();

                if (res != null)
                {
                   
                    lstCalendario.ItemsSource = res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btn4_click(object sender, EventArgs e)
        {
            //https://wa.link/pzj230
        }


        public async void btn1_salir(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Salir", "¿Esta seguro que quiere cerrar sesión? ", "Si", "No");
            if (answer.Equals("Si"))
            {
                //Settings.FirstName = string.Empty;
                //Settings.LastName = string.Empty;
                //Settings.Email = string.Empty;
                await Navigation.PopToRootAsync();

            }
            else
            {

                await Navigation.PushAsync(new MainPage());

            }
        }
       
        public async void obtenerInfoPac()
        {
            var response = await this.apiServices.GetListAsync<Paciente>("https://www.doctoralanza.cl/info_pac.php/2");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }

            var myInfo = (Paciente)response.Result;
            

        }

    }
}
