using AppPets.iOS.Render;
using AppPets.Renders;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]

namespace AppPets.iOS.Render
{
    public class MyEntryRenderer :EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BackgroundColor=UIColor.Blue;
                Control.BorderStyle = UITextBorderStyle.Line;

            }
        }
    }
    
}