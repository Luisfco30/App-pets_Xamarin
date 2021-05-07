using AppPets.Models;
using AppPets.Renders;
using AppPets.UWP.Renders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MyMap), typeof(MyMapRenderer))]

namespace AppPets.UWP.Renders
{
    public class MyMapRenderer : MapRenderer
    {
        MapControl NativeMap;
        PetModel Pet;
        MapWindow PetWindow;
        bool IsPetWindowVisible;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.MapElementClick -= OnMapElementClick;
                NativeMap.Children.Clear();
                NativeMap = null;
                PetWindow = null;
            }

            if(e.NewElement != null)
            {
                this.Pet = (e.NewElement as MyMap).Pet;

                var formMap = (MyMap)e.NewElement;
                NativeMap = Control as MapControl;
                NativeMap.Children.Clear();
                NativeMap.MapElementClick += OnMapElementClick;

                var position = new BasicGeoposition
                {
                    Latitude = Pet.Latitude,
                    Longitude = Pet.Longitude
                };
                var point = new Geopoint(position);

                var mapicon = new MapIcon();
                mapicon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///pin.png"));
                mapicon.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
                mapicon.Location = point;
                mapicon.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);

                NativeMap.MapElements.Add(mapicon);
            }
        }

        private void OnMapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            var mapicon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;
            if (mapicon != null)
            {
                if (!IsPetWindowVisible)
                {
                    if (PetWindow == null)
                    {
                        PetWindow = new MapWindow(Pet);
                    }
                    var position = new BasicGeoposition
                    {
                        Latitude = Pet.Latitude,
                        Longitude = Pet.Longitude
                    };
                    var point = new Geopoint(position);

                    NativeMap.Children.Add(PetWindow);
                    MapControl.SetLocation(PetWindow, point);
                    MapControl.SetNormalizedAnchorPoint(PetWindow, new Windows.Foundation.Point(0.5, 1.0));

                    IsPetWindowVisible = true;
                }
                else
                {
                    NativeMap.Children.Remove(PetWindow);

                    IsPetWindowVisible = false;
                }
            }
        }
    }
}
