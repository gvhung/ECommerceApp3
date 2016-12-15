﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        #endregion

        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        #region Contrutores
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            apiService = new ApiService();
            IsRemembered = true;
        }
        #endregion

        #region propriedades
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

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsRunning"));
                    }
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
            var response = await apiService.Login(User, Password);
            IsRunning = false;
            if (!response.IsSucess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;

            }
            navigationService.SetMainPage();
        }
        #endregion
    }
}