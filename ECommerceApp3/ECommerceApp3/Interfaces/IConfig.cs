using SQLite.Net.Interop;

namespace ECommerceApp3.Interfaces
{
    public interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }
    }

}
