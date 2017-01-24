using System;
using System.Threading.Tasks;
using ECommerceApp3.Models;
using ECommerceApp3.Pages;
using ECommerceApp3.ViewModels;

namespace ECommerceApp3.Services
{
    public class NavigationService
    {
        #region Atributos
        private DataService dataService;
        #endregion

        #region Construtores
        public NavigationService()
        {
            dataService = new DataService();
        }
        #endregion

        public async Task Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "CustomersPage":
                    await App.Navigator.PushAsync(new CustomersPage());
                    break;
                case "DeliveriesPage":
                    await App.Navigator.PushAsync(new DeliveriesPage());
                    break;
                case "OrdersPage":
                    await App.Navigator.PushAsync(new OrdersPage());
                    break;
                case "ProductsPage":
                    await App.Navigator.PushAsync(new ProductsPage());
                    break;
                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                case "SyncPage":
                    await App.Navigator.PushAsync(new SyncPage());
                    break;
                case "UserPage":
                    await App.Navigator.PushAsync(new UserPage());
                    break;
                case "LogoutPage":
                    Logout();
                    break;

                default:
                    break;
            }

        }

        internal User GetCurrentUser()
        {
            return App.CurrentUser;
        }

        private void Logout()
        {
            App.CurrentUser.IsRemembered = false;
            dataService.UpdateUser(App.CurrentUser);
            App.Current.MainPage = new LoginPage();

        }

        internal void SetMainPage(User user)
        {
            //Carregando usuario Atual, e não mais o user antigo.
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.LoadUser(user);

            App.CurrentUser = user;
            App.Current.MainPage = new MasterPage();
        }
    }
}
