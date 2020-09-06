using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QuickTaskApp.Controller;
using QuickTaskApp.Droid.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PlaceholderEditor), typeof(PlaceholderEditorRenderer))]
namespace QuickTaskApp.Droid.Resources
{
    public class PlaceholderEditorRenderer : EditorRenderer
    {
        [Obsolete]
        public PlaceholderEditorRenderer() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var element = e.NewElement as PlaceholderEditor;

                //this.Control.Background = Resources.GetDrawable(Resource.Drawable.borderEditText);
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

                this.Control.Hint = element.Placeholder;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == PlaceholderEditor.PlaceholderProperty.PropertyName)
            {
                var element = this.Element as PlaceholderEditor;
                this.Control.Hint = element.Placeholder;
            }
        }
    }
}