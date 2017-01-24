

using System;
using System.Collections.ObjectModel;
using ECommerceApp3.Models;
using ECommerceApp3.Services;

namespace ECommerceApp3.ViewModels
{
    public class MainViewModel
    {
        #region Atributos

        private DataService dataService;

        private ApiService apiService;
        #endregion

        #region Propriedades
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        //Usando em telas como exemplo:     ItemsSource="{Binding Products}"
        public ObservableCollection<ProductItemViewModel> Products { get; set; }

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
            Products = new ObservableCollection<ProductItemViewModel>();

            //Create views
            NewLogin = new LoginViewModel();
            UserLoged = new UserViewModel();

            //Instance services
            dataService = new DataService();
            apiService = new ApiService();

            //Load data
            LoadMenu();
            // LoadUser();
            LoadProducts();
        }



        #endregion

        #region Singleton

        private static MainViewModel instance;

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

        public void LoadUser(User user)
        {
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

            //var user = dataService.GetUser();
            //if (user != null)
            //{
            //    UserLoged.FullName = user.FullName;
            //    UserLoged.Photo = user.PhotoFullPath;
            //}
            //else
            //{
            //    UserLoged.FullName = "User NULO";
            //    UserLoged.Photo = "Sem Photo";

            //}

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


        private async void LoadProducts()
        {
            var products = await apiService.GetProducts();

            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(new ProductItemViewModel
                {
                    BarCode = product.BarCode,
                    Category = product.Category,
                    CategoryId = product.CategoryId,
                    Company = product.Company,
                    CompanyId = product.CompanyId,
                    Description = product.Description,
                    Image = product.Image,
                    Inventories = product.Inventories,
                    OrderDetails = product.OrderDetails,
                    OrderDetailTmps = product.OrderDetailTmps,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    Remarks = product.Remarks,
                    Stock = product.Stock,
                    Tax = product.Tax,
                    TaxId = product.TaxId
                });

            }
        }
        #endregion

    }

}
