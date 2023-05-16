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
            string cpf = txt_cpf.Text;
            string senha = txt_senha.Text;

            try
            {
                Correntista correntista = await DataServiceCorrentista.GetCorrentistaByCpfAndSenha(new Correntista
                {
                    Cpf = cpf,
                    Senha = senha
                });

                await Navigation.PushAsync(new View.FormEdit());

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