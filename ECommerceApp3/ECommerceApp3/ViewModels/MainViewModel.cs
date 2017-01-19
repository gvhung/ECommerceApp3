

using System;
using System.Collections.ObjectModel;
using ECommerceApp3.Services;

namespace ECommerceApp3.ViewModels
{
    public class MainViewModel
    {
        #region Atributos

        private DataService dataService;

        #endregion

        #region Propriedades
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public LoginViewModel NewLogin { get; set; }

        public UserViewModel UserLoged { get; set; }
        #endregion

        #region Construtores
        public MainViewModel()
        {
            //Singleton
            instance = this;

            //Create observable collection
            Menu = new ObservableCollection<MenuItemViewModel>();

            //Create views
            NewLogin = new LoginViewModel();
            UserLoged = new UserViewModel();

            //Instance services
            dataService = new DataService();

            //Load data
            LoadMenu();
            LoadUser();
        }



        #endregion

        #region Singleton

        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

        #endregion


        #region Metodos

        private void LoadUser()
        {
            var user = dataService.GetUser();
            if (user != null)
            {
                UserLoged.FullName = user.FullName;
                UserLoged.Photo = user.PhotoFullPath;                
            }
            else
            {
                UserLoged.FullName = "User NULO";
                UserLoged.Photo = "Sem Photo";

            }

        }



        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_product.png",
                PageName = "ProductsPage",
                Title = "Produtos"
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_customer.png",
                PageName = "CustomersPage",
                Title = "Clientes"
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_order.png",
                PageName = "OrdersPage",
                Title = "Pedidos"
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_delivery.png",
                PageName = "DeliveriesPage",
                Title = "Entregas"
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_sync.png",
                PageName = "SyncPage",
                Title = "Sincronizar"

            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_setup.png",
                PageName = "SetupPage",
                Title = "Configuracao"

            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_logout.png",
                PageName = "LogoutPage",
                Title = "Sair"

            });
        }

        #endregion

    }

}
