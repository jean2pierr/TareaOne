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
using Toolbar = Android.Widget.Toolbar;

namespace AppTickets
{
    [Activity(Label = "TiposTelas")]
    public class TiposTelas : Activity
    {
        Button btnMacarena;
        Button btnMarquesina;
        Button btnBurda;
        Button btnRayas;

        Toolbar menu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Tipos);
            menu = FindViewById<Toolbar>(Resource.Id.Menu);

            SetActionBar(menu);
            ActionBar.Title = "Este es otro Menu";



            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Tipos);
            btnMacarena = FindViewById<Button>(Resource.Id.btnMacarena);
            btnMarquesina = FindViewById<Button>(Resource.Id.btnMarquesina);
            btnBurda = FindViewById<Button>(Resource.Id.btnBurda);
            btnRayas = FindViewById<Button>(Resource.Id.btnRayas);

            btnMacarena.Click += BtnMacarena_Click;
            btnMarquesina.Click += BtnMarquesina_Click;
            btnBurda.Click += BtnBurda_Click;
            btnRayas.Click += BtnRayas_Click;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        private void BtnMacarena_Click(object sender, System.EventArgs e)
        {
            Intent Macarena = new Intent(this, typeof(Create_Pedido));
            StartActivity(Macarena);
        }

        private void BtnMarquesina_Click(object sender, System.EventArgs e)
        {
            Intent Marquesina = new Intent(this, typeof(Create_Pedido));
            StartActivity(Marquesina);
        }

        private void BtnBurda_Click(object sender, System.EventArgs e)
        {
            Intent Burda = new Intent(this, typeof(Create_Pedido));
            StartActivity(Burda);
        }

        private void BtnRayas_Click(object sender, System.EventArgs e)
        {
            Intent Rayas = new Intent(this, typeof(Create_Pedido));
            StartActivity(Rayas);
        }


    }
}
            
        
    
