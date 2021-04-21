using AppPets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppPets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetsMapsView : ContentPage
    {
        public PetsMapsView(PetModel petSelected)
        {
            InitializeComponent();

            MapPets.MoveToRegion(

                MapSpan.FromCenterAndRadius(
                    new Position(
                        petSelected.Latitude,
                        petSelected.Longitude
                        ),
                    Distance.FromMiles(.5)
                )
            );
            MapPets.Pins.Add(
                new Pin
                {
                    Type = PinType.Place,
                    Label = petSelected.Name,
                    Position = new Position(
                        petSelected.Latitude,
                        petSelected.Longitude
                    )
                }
            );

            PetName.Text = petSelected.Name;
            PetAge.Text = petSelected.Age.ToString();
            PetBreed.Text = petSelected.Breed;

        }
    }
}