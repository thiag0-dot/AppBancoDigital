using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;


namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        public static async Task<bool> Cadastrar(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/save");  

            return true;
        }

        public static async Task<bool> Entrar(Correntista q)
        {
            var json_a_enviar = JsonConvert.SerializeObject(q);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/entrar");
            return true;
        }
    }
}
