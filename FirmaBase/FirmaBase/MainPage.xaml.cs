using FirmaBase.Models;
using System;
using System.IO;
using Xamarin.Forms;

namespace FirmaBase
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            Stream image = await Padview.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            BinaryReader br = new BinaryReader(image);

            
            Byte[] bytes = br.ReadBytes((Int32)image.Length);
            String bs64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            lbl.Text = bs64;

            if (ValidarDatos())
            {
                Persona person = new Persona
                {


                    nombre = txtnomb.Text,
                    descripcion = txtdescripcion.Text,
                    imagen = this.lbl.Text,

                };
                await App.SQLiteDB.SavePersona(person);

                Console.WriteLine(image);
                Console.WriteLine(bs64);
                Console.WriteLine(person.imagen);
                await DisplayAlert("Registro", "Datos agregados de manera correcta", "ok");
                
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "ok");
            }

        }

        public bool ValidarDatos()
        {
            bool respuesta;

            if (String.IsNullOrEmpty(txtnomb.Text))
            {
                respuesta = false;
            }

            else if (String.IsNullOrEmpty(txtdescripcion.Text))
            {
                respuesta = false;
            }

            else if (String.IsNullOrEmpty(lbl.Text))
            {
                respuesta = false;
            }

            else
            {
                respuesta = true;
            }
            return respuesta;

        }

        private async void BtnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listas.ListPage());
        }
    }
}
