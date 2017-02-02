using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerceApp3.Models;
using ECommerceApp3.Services;
using GalaSoft.MvvmLight.Command;

namespace ECommerceApp3.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Attibutes
        private NavigationService navigationService;
        private DialogService dialogService;
        private ApiService apiService;
        private bool isRunning;
        private DataService dataService;
        private NetService netService;

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Contructors
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            apiService = new ApiService();
            dataService = new DataService();
            netService = new NetService();
            IsRemembered = true;
        }
        #endregion

        #region Properties
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }

        public bool IsRunning
        {
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;

                    //if (PropertyChanged != null)
                    //{
                    //    PropertyChanged(this, new PropertyChangedEventArgs("IsRunning"));
                    //}
                    //Mesma Coisa cógido acima
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
                }
            }
            get
            {
                return isRunning;
            }
        }
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
            IsRunning = true;
            var response = new Response();
            if (netService.IsConnected())
            {
                response = await apiService.Login(User, Password);
            }
            else
            {
                response = dataService.Login(User, Password);
            }

            IsRunning = false;

            if (!response.IsSucess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;

            }

            //Banco de Dados
            var user = (User)response.Result;
            user.IsRemembered = IsRemembered;
            user.Password = Password;
            dataService.InsertUser(user);

            navigationService.SetMainPage(user);
        }
        #endregion
    }
}
