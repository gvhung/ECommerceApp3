

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ECommerceApp3.Models;
using ECommerceApp3.Services;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;

namespace ECommerceApp3.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Atributos

        private DataService dataService;

        private ApiService apiService;

        private NetService netService;

        private string filter;
        #endregion

        #region Propriedades
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        //Usando em telas como exemplo:     ItemsSource="{Binding Products}"
        public ObservableCollection<ProductItemViewModel> Products { get; set; }

        public LoginViewModel NewLogin { get; set; }

        public UserViewModel UserLoged { get; set; }

        public string Filter
        {
            set
            {
                if (filter != value)
                {
                    filter = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Filter"));
                    if (string.IsNullOrEmpty(filter))
                    {
                        LoadLocalProducts();
                    }
                }
            }
            get
            {
                return filter;

            }
        }


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
            netService = new NetService();

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

        #region Commands
        public ICommand SearchProductCommand { get { return new RelayCommand(SearchProduct); } }


        #endregion

        #region events
        public event PropertyChangedEventHandler PropertyChanged;

        private void SearchProduct()
        {
            var products = dataService.GetProducts(Filter);

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
                    Price = product.Price,
                    ProductId = product.ProductId,
                    Remarks = product.Remarks,
                    Stock = product.Stock,
                    Tax = product.Tax,
                    TaxId = product.TaxId,
                });
            }

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
            var products = new List<Product>();
            if (netService.IsConnected())
            {
                products = await apiService.GetProducts();
                dataService.SaveProducts(products);
            }
            else
            {
                products = dataService.Getproducts();
            }
            ReloadProducts(products);
        }

        private  void LoadLocalProducts()
        {
            var products = dataService.Getproducts();
            ReloadProducts(products);
        }


        private void ReloadProducts(List<Product> products)
        {
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
