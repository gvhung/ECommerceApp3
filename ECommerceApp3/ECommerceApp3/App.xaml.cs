using ECommerceApp3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ECommerceApp3.Services;
using ECommerceApp3.Models;

namespace ECommerceApp3
{
    public partial class App : Application
    {
        #region Atributes

        private DataService dataService;
        #endregion

        #region Propriedades
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        public static User CurrentUser { get; internal set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();
            dataService = new DataService();
            var user = dataService.GetUser();
            if (user != null && user.IsRemembered)
            {
                App.CurrentUser = user;
                MainPage = new MasterPage();
            }
            else
            {
                MainPage = new LoginPage();
            }

        }
        #endregion

        #region Metodos

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
    }
}
