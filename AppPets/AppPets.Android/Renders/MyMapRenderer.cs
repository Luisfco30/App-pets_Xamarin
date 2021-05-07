using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppPets.Droid.Renders;
using AppPets.Models;
using AppPets.Renders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyMap), typeof(MyMapRenderer))]

namespace AppPets.Droid.Renders
{
    public class MyMapRenderer :MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        PetModel Pet;
        public MyMapRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                this.Pet = (e.NewElement as MyMap).Pet;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            //return base.CreateMarker(pin);
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(Pet.Latitude, Pet.Longitude));
            marker.SetTitle(Pet.Name);
            marker.SetSnippet($"{Pet.Breed} - {Pet.Age} años");
            return marker;
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;
                view = inflater.Inflate(Resource.Layout.MapWindow, null);
                var infoImage = view.FindViewById<ImageView>(Resource.Id.MapWindowImage);
                var infoName = view.FindViewById<TextView>(Resource.Id.MapWindowName);
                var infoBreedAge = view.FindViewById<TextView>(Resource.Id.MapWindowBreedAge);

                if (infoImage != null) infoImage.SetImageBitmap(BitmapFactory.DecodeFile(Pet.ImageBase64));
                if (infoName != null) infoName.Text = Pet.Name;
                if (infoBreedAge != null) infoBreedAge.Text = $"{Pet.Breed} - {Pet.Age} años";

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;  
        }
    }
}