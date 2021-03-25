using AppPets.Models;
using AppPets.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetsListView : ContentPage
    {
        public PetsListView()
        {
            InitializeComponent();

            BindingContext = new PetsViewModel();

            /*App.Pets = new List<PetModel>
            {
                new PetModel
                {
                    ID = 1,
                    Name = "Dante",
                    Age = 12,
                    Breed = "Labrador",
                    Picture = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.yOsv0W4wnDncLprPl2cRMgHaK6%26pid%3DApi&f=1"
                },
                new PetModel
                {
                    ID = 2,
                    Name = "Kitty",
                    Age = 10,
                    Breed = "Snauzer",
                    Picture = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.X85MEmp4hP4_tsy_BmTC_wHaJQ%26pid%3DApi&f=1"
                },
                new PetModel
                {
                    ID = 3,
                    Name = "Simba",
                    Age = 1,
                    Breed = "Pastor Belga",
                    Picture = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.FDJ7iq8UgNQzAv6n1ytb9wHaJ4%26pid%3DApi&f=1"
                }
            };

            PetsList.ItemsSource = App.Pets;*/
        }

        /*private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PetsDetailView());
        }

        private void PetsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PetModel pet = e.CurrentSelection.FirstOrDefault() as PetModel;

            if (pet != null)
            {
                Navigation.PushAsync(new PetsDetailView(pet));
            }
        }

        public void RefreshPets()
        {
            PetsList.ItemsSource = null;
            PetsList.ItemsSource = App.Pets;
        }*/
    }
}