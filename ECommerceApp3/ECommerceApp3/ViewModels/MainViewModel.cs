using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp3.ViewModels
{
    public class MainViewModel
    {
        #region Propriedades
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        #endregion

        #region Construtores
        public MainViewModel()
        {
            LoadMenu();
        }

        #endregion

        #region Metodos
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
                Icon = "ic_action_snyc.png",
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
