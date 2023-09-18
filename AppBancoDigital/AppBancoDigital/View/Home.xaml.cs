using AppBancoDigital.Model;
using AppBancoDigital.Service;
using System;
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
            Value.Text = (hideCorrente) ? " *****" : Value.Text = "1000,00";
            Value2.Text = (hideCorrente) ? " *****" : Value2.Text = "1000,00";
        }

        protected override async void OnAppearing()
        {
            Correntista c = BindingContext as Correntista;

            List<Conta> contas = await DataServiceConta.GetContasByIDCorrentista(c);

            foreach (Conta conta in contas)
            {
                await DisplayAlert(conta.Id.ToString(), conta.Saldo.ToString("C"), "OK");
            }

        }
    }
}