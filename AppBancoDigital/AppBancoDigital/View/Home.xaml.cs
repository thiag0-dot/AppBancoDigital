﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        bool hideCorrente = false;
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            hideCorrente = !hideCorrente;
            ((Button)sender).Text = (hideCorrente) ? "\uE8f4" : "\uE8f5";
            Value.Text = (hideCorrente) ? " *****" : Value.Text = "0,00";
        }
    }
}