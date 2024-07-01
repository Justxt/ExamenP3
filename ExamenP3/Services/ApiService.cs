

//using ExamenP3.Models;
//using System.Text.Json;
//using System.Text.Json.Nodes;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//namespace ExamenP3.Services;
//{
//    public class ApiService : BaseService
//    {
//        private string url = "https://api.chucknorris.io/jokes/aKS0aJOZRBmHtOOk9Lqm8Q";
//        public async Task<List<Chiste>> GetChistes()
//        {
//            var client = new HttpClient();
//            var response = await client.GetAsync(url);
//            var responseBody = await response.Content.ReadAsStringAsync();
//            JsonNode nodos = JsonNode.Parse(responseBody);
//            JsonNode chisteJM = nodos["chiste"];


//            var chiste = JsonSerializer.Deserialize<List<Chiste>>(chisteJM.ToString());
//            return chiste;
//        }
//    }
//}
