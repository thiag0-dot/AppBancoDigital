using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Service
{
    public class DataServiceConta : DataService
    {
        public static async Task<List<Conta>> GetContasByIDCorrentista(Correntista c) {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.GetDataFromService("/conta/by-correntista?id_correntista=" + c.Id.ToString());

            return JsonConvert.DeserializeObject<List<Conta>>(json);
        }
    }
}
