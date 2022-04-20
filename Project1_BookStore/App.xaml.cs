using Project1_BookStore.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project1_BookStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string OnStart { get; set; } = AppConfig.GetValue("OnStart");
        public static string LastScreen { get; set; } = AppConfig.GetValue("LastScreen");
        protected override void OnStartup(StartupEventArgs e)
        {

            if (OnStart.Equals("0"))
            {
                this.StartupUri = new System.Uri(LastScreen, System.UriKind.Relative);
            }
            else
            {
                this.StartupUri = new System.Uri("GUI/loginwindow.xaml", System.UriKind.Relative);
            }
        }
    }
}
