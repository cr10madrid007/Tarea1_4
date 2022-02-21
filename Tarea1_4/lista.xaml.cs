using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1_4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lista : ContentPage
    {
        public lista()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaEmpleados.ItemsSource = await App.BaseDatos.listaempleados();
        }



        private async void ListaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {


           

                Models.constructor item = (Models.constructor)e.Item;
                var newpage = new vista();
                newpage.BindingContext = item;
                await Navigation.PushAsync(newpage);
            




        }
    }
}