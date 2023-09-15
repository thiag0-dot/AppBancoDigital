using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        public static async Task<Correntista> Cadastrar(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/save");  

            return JsonConvert.DeserializeObject<Correntista>(json);
        }

        public static async Task<Correntista> GetCorrentistaByCpfAndSenha(Correntista model)
        {
            var json_a_enviar = JsonConvert.SerializeObject(model);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/entrar");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }
    }
}
