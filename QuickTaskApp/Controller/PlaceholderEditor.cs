using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuickTaskApp.Controller
{
    public class PlaceholderEditor: Editor
    {
        public static new readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create("Placeholder", typeof(string), typeof(string), "");

        public PlaceholderEditor()
        {
        }

        public new string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }

            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }
    }
}
