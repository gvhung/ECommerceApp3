using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp3.Interfaces
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }

        void CheckNetworkConnection();

    }
}
