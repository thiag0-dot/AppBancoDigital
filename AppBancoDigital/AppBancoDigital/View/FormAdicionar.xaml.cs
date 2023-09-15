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
    public partial class FormAdicionar : ContentPage
    {
        public FormAdicionar()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            dtpck_data_nasc.MaximumDate= DateTime.Now.AddDays(-(365*18));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible= true;
            
            
            try
            {
                await DataServiceCorrentista.Cadastrar(new Correntista
                {
                    Nome = txt_nome.Text,
                    Data_Nasc = dtpck_data_nasc.Date,
                    Senha = txt_senha.Text,
                    Cpf = txt_cpf.Text
                });

                await DisplayAlert("Sucesso!", "Sua Conta foi criada!", "OK");
                await Navigation.PushAsync(new View.MainPage()) ;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                act_carregando.IsRunning = false;
                act_carregando.IsVisible = false;
            }
        }


            
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            
            TelaDeNome.IsVisible = false;
            TelaDeData.IsVisible = true;
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            TelaDeData.IsVisible = false;
            TelaDeCpf.IsVisible = true;
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            TelaDeCpf.IsVisible = false;
            TelaDaSenha.IsVisible = true;
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            TelaDeNome.IsVisible = true;
            TelaDeData.IsVisible = false;
        }

        private void Button_Clicked_6(object sender, EventArgs e)
        {
            TelaDeData.IsVisible = true;
            TelaDeCpf.IsVisible = false;
        }

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            TelaDaSenha.IsVisible = false;
            TelaDeCpf.IsVisible=true;
        }
        private void txt_nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            NomeParaData.BackgroundColor = (txt_nome.Text != null) ? Color.FromHex("#4c0677") : Color.FromHex("#f0f1f5");
        }
    }
}