using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoAspNetMvc
{
    public static class AutenticacaoUsuarios

    {
        private static string _URL = "https://wsibid.portaldecompras.co/";
        public class UserApi
        {
            public string Usuario { get; set; } = "Teste";
            public string Senha { get; set; } = "senhaProcessoSeletivo@ibid";
        }
        public class TokenApi
        {
            public string Token { get; set; }
            public DateTime Expirationexpiration { get; set; }
        }

        public static async Task<TokenApi> ObterToken()
        {

            var user = new UserApi();
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            client.BaseAddress = new Uri(_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.PostAsync("API/v1/Token", content);

            return JsonConvert.DeserializeObject<TokenApi>(response.Content.ReadAsStringAsync().Result);

        }
    }
}