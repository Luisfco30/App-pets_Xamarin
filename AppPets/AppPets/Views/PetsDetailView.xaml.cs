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
    public partial class PetsDetailView : ContentPage
    {
        /*PetsListView _PetsListView;
        PetModel PetSelected;*/

        public PetsDetailView(PetsViewModel petsViewModel)
        {
            InitializeComponent();

            BindingContext = new PetsDetailViewModel(petsViewModel);

            //_PetsListView = petsListView;
        }

        public PetsDetailView(PetsViewModel petsViewModel, PetModel pet)
        {
            InitializeComponent();

            BindingContext = new PetsDetailViewModel(petsViewModel, pet);

            /*_PetsListView = petsListView;

            PetSelected = pet;
            FillPet(pet);*/
        }

        /*private void ToolbarSave_Clicked(object sender, EventArgs e)
        {
            if (PetSelected != null && PetSelected.ID > 0)
            {
                // Actualizar
                foreach(PetModel pet in App.Pets)
                {
                    if (pet.ID == PetSelected.ID)
                    {
                        pet.Name = EntryName.Text;
                        pet.Breed = EntryBreed.Text;
                        pet.Age = int.Parse(EntryAge.Text);
                        pet.Picture = EntryPicture.Text;
                        break;
                    }
                }
            }
            else
            {
                // Agregar
                App.Pets.Add(new Models.PetModel
                {
                    Name = EntryName.Text,
                    Breed = EntryBreed.Text,
                    Age = int.Parse(EntryAge.Text),
                    Picture = EntryPicture.Text
                });
            }

            _PetsListView.RefreshPets();

            Navigation.PopAsync();
        }

        private void ToolbarDelete_Clicked(object sender, EventArgs e)
        {
            /*if (PetSelected.ID > 0)
            {
                // Eliminar

                // Opción 1
                /*List<PetModel> petsNew = new List<PetModel>();
                foreach (PetModel pet in App.Pets)
                {
                    if (pet.ID != PetID)
                    {
                        petsNew.Add(pet);
                    }
                }
                App.Pets = petsNew;*/

                // Opción 2
                /*App.Pets.Remove(PetSelected);

                _PetsListView.RefreshPets();
                Navigation.PopAsync();
            }
        }

        private void FillPet(PetModel pet)
        {
            EntryName.Text = pet.Name;
            EntryBreed.Text = pet.Breed;
            EntryAge.Text = pet.Age.ToString();
            EntryPicture.Text = pet.Picture;
            ImagePicture.ImageSource = pet.Picture;
        }*/
    }
}