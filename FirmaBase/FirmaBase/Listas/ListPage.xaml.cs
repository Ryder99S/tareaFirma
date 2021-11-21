using FirmaBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirmaBase.Listas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            LlenarDatos();
        }

        public async void LlenarDatos()
        {
            Persona item = new Persona();

            var lista = await App.SQLiteDB.GetPersonasAync();
            if (lista != null)
            {

                lstdatos.ItemsSource = lista;
                //Console.WriteLine(lista["idPersona"]);
                Console.WriteLine(lista);
            }
            else
            {
                await DisplayAlert("No", "No hay registros", "Okis");
            }
        }

        private void lstdatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Persona item = (Models.Persona)e.Item;
                
            Object objSitioGlobal = new
            {
                Idpersona = item.Idpersona,
                nombre = item.nombre,
                descripcion = item.descripcion,
                imagen = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(item.imagen)))
            };
            //Console.WriteLine(objSitioGlobal);
        }
    }
}