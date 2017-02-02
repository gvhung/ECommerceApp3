using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp3.Interfaces;
using Xamarin.Forms;

namespace ECommerceApp3.Services
{
    public class NetService
    {
        public bool IsConnected()
        {
            try
            {
                var networkConnection = DependencyService.Get<INetworkConnection>();
                networkConnection.CheckNetworkConnection();
                return networkConnection.IsConnected;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
