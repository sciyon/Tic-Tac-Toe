using System.ComponentModel;
using TicTacToe.ViewModels;
using Xamarin.Forms;

namespace TicTacToe.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}