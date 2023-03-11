using System;
using System.Collections.Generic;
using System.ComponentModel;
using TicTacToe.Models;
using TicTacToe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}