﻿using AppBancoDigital.Model;
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
                    Senha= txt_senha.Text,
                    Cpf= Convert.ToInt64(txt_cpf.Text)
                });

                await DisplayAlert("Sucesso!", "Sua Conta foi criada!", "OK");

                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                act_carregando.IsRunning= false;
                act_carregando.IsVisible= false;
            }
        }
    }
}