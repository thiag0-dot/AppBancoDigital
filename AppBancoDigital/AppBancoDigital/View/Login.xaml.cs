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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent(); 

            NavigationPage.SetHasNavigationBar(this,false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await DataServiceCorrentista.Entrar(new Correntista
                {
                    Senha = txt_senha.Text,
                    Cpf = Convert.ToInt64(txt_cpf.Text)
                });

                

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}