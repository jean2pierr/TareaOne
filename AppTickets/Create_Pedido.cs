using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Org.Apache.Http.Client.Params;

namespace AppTickets
{
    [Activity(Label = "Create_Pedido")]

    public class Create_Pedido : Activity
    {
        EditText txtId;
        TextView lblId;
        EditText txtReferencia;
        EditText txtColor;
        EditText txtDespacho;
        EditText txtKilos;
        Button btnPedido;
        Button btnConsultar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Pedido);
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtReferencia = FindViewById<EditText>(Resource.Id.txtReferencia);
            txtColor = FindViewById<EditText>(Resource.Id.txtColor);
            txtDespacho = FindViewById<EditText>(Resource.Id.txtDespacho);
            txtKilos = FindViewById<EditText>(Resource.Id.txtKilos);
            btnPedido = FindViewById<Button>(Resource.Id.btnPedido);
            btnConsultar = FindViewById<Button>(Resource.Id.btnConsultar);

            btnPedido.Click += BtnPedido_Click;
            //btnConsultar.Click += BtnConsultar_Click;

        }
        //Boton Pedido
        private void BtnPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtReferencia.Text.Trim()))
                {
                    new Auxiliar().GuardarTicket(new NewPedido()
                    {
                        Id = 0,
                        Referencia = txtReferencia.Text.Trim(),
                        Color = txtColor.Text.Trim(),
                        Despacho = txtDespacho.Text.Trim(),
                        Kilos = double.Parse(txtKilos.Text.Trim())
                    });
                    Toast.MakeText(this, "¡Registro Guardado!", ToastLength.Long).Show();
                    txtReferencia.Text = "";
                    txtColor.Text = "";
                    txtDespacho.Text = "";
                    txtKilos.Text = "";
                }
                else
                {
                    Toast.MakeText(this, "** Ingresar los datos requeridos **", ToastLength.Long).Show();
                }

            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        }
        
        //Boton consultar y WebService

        /*
        string uriServicio = "https://jsonplaceholder.typicode,com/post";
        private async void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    int t = 0;
                    if (int.TryParse(txtId.Text.Trim(), out t))
                    {
                        var resultado = await cliente.Get<Entrada>(uriServicio + "/" + txtId.Text);
                        if (cliente.codigoHTTP == 200)
                        {
                            txtReferencia.Text = resultado.title;
                            txtColor.Text = resultado.body;
                            Toast.MakeText(this, "Consulta realizada con éxito", ToastLength.Long).Show();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Error: " + ex.Message, ToastLength.Long).Show();
            }
        }*/
    }
    /*
        public class Entrada
        {
            //iniciar valores
            public Entrada()
            {
                userId = 1;
                id = 0;
                title = "";
                body = "";
            }
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }
        public class Cliente
        {
            public Cliente()
            {
                //200 = respuesta positiva
                //400 = respuesta negativa cliente
                //500 = respuesta negativa del servidor
                codigoHTTP = 200;
            }
            public int codigoHTTP { get; set; }

            //Get
            public async Task<T> Get<T>(string url)
            {
                HttpClient cliente = new HttpClient();
                var response = await cliente.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                codigoHTTP = (int)response.StatusCode;
                return JsonConvert.DeserializeObject<T>(json);
            }

            //Post
            public async Task<T> Post<T>(Entrada item, string url)
            {
                HttpClient cliente = new HttpClient();
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await cliente.PostAsync(url, content);
                json = await response.Content.ReadAsStringAsync();
                codigoHTTP = (int)response.StatusCode;
                return JsonConvert.DeserializeObject<T>(json);
            }
        }*/
    
}
