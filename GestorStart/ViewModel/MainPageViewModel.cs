using GestorStart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestorStart.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public Paciente Data
        {
            get => data; set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private const string infoPacUrl = "https://www.doctoralanza.cl/info_pac.php/";
        private Paciente data;

        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
        }

        public MainPageViewModel()
        {
            SearchCommand = new Command(async () =>
            {
                await GetData();
            });
        }

        private async Task GetData()
        {
            if (Application.Current.Properties.ContainsKey("id"))
            {
                var id = Application.Current.Properties["id"] as string;
                int UsuarioId = Convert.ToInt32(id);
                HttpClient client = new HttpClient();

                var res = await client.GetAsync(infoPacUrl + "?" + "UsuarioId=" + UsuarioId);

                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    var px = JsonConvert.DeserializeObject<Paciente>(content);
                    Data = px;
                }
            }
        }
    }
}