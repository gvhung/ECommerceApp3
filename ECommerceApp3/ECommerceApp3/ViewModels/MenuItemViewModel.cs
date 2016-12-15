using System.Windows.Input;
using ECommerceApp3.Services;
using GalaSoft.MvvmLight.Command;

namespace ECommerceApp3.ViewModels
{
    public class MenuItemViewModel
    {
        #region  Atributos
        private NavigationService navigationService;
        #endregion

        #region Propriedades
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        #endregion

        #region Construtores
        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }
        #endregion

        #region Comandos
        public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }
               
        private async void Navigate()
        {
          await  navigationService.Navigate(PageName);
        }
        #endregion

    }
}
