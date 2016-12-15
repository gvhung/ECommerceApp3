
using Xamarin.Forms;

namespace ECommerceApp3.Pages
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Master = this;
            App.Navigator = Navigator;

            
        }

    }
}
