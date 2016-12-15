using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerceApp3.Services;
using GalaSoft.MvvmLight.Command;

namespace ECommerceApp3.ViewModels
{
    public class LoginViewModel
    {
        #region Attibutes
        private NavigationService navigationService;
        private DialogService dialogService;
        #endregion

        #region Contrutores
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            IsRemembered = true;
        }
        #endregion
        #region propriedades
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand { get { return new RelayCommand(Login); } }

        private async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await dialogService.ShowMessage("Erro", "Deve informar um usuário");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage("Erro", "Deve informar uma Senha");
                return;
            }
            navigationService.SetMainPage();
        }
        #endregion
    }
}
