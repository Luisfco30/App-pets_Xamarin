using AppPets.Models;
using AppPets.Services;
using AppPets.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppPets.Viewmodels
{
    public class PetsViewModel : BaseViewModel
    {
        Command _NewCommand;
        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewAction));

        Command _SelectCommand;
        public Command SelectCommand => _SelectCommand ?? (_SelectCommand = new Command(SelectAction));

        List<PetModel> _PetsList;
        public List<PetModel> PetsList
        {
            get => _PetsList;
            set => SetProperty(ref _PetsList, value);
        }

        PetModel _PetSelected;
        public PetModel PetSelected
        {
            get => _PetSelected;
            set => SetProperty(ref _PetSelected, value);
        }

        public PetsViewModel()
        {
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

            PetsList = App.Pets;*/
            LoadPets();
        }

        private async void LoadPets()
        {
            ApiResponse response = await new ApiService().GetDataAsync<PetModel>("Pets");
            if (response == null || !response.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert("AppPets", $"Error al cargar los viajes{response.Message}", "Ok");
                return;
            }
            PetsList = (List <PetModel>) response.Result;
        }

        public void PetsRefresh()
        {
            PetsList = null;
            PetsList = App.Pets;
            LoadPets();
        }

        private void NewAction(object obj)
        {
            //await Application.Current.MainPage.DisplayAlert("AppPets", "Generando una nueva mascota...", "Ok");
            Application.Current.MainPage.Navigation.PushAsync(new PetsDetailView(this));
        }

        private void SelectAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new PetsDetailView(this, PetSelected));
        }
    }
}
