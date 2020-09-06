using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace QuickTaskApp.Controller
{
    public class AndroidNavigationPageCS : Xamarin.Forms.NavigationPage
    {
        public AndroidNavigationPageCS()
        {
            On<Android>().SetBarHeight(150);
        }
    }
}
