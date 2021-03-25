using AppPets.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPets
{
    public partial class App : Application
    {
        public static List<PetModel> Pets;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PetsListView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
