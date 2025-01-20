using GavilanesExamen3Final.Complementos;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GavilanesExamen3Final.Complementos
{
    public class ApiJG
    {
        private readonly HttpClient _httpClient;

        public ApiJG()
        {
            _httpClient = new HttpClient();
        }

        public async Task<PaisJG> ObtenerPaisPorNombreAsync(string nombreDelPais)
        {
            try
            {
               
                var url = $"https://restcountries.com/v3.1/name/{nombreDelPais}?fullText=true";
                var respuesta = await _httpClient.GetStringAsync(url);

               
                var paises = JsonConvert.DeserializeObject<List<dynamic>>(respuesta);

              
                if (paises != null && paises.Count > 0)
                {
                    var pais = paises[0]; 

                   
                    return new PaisJG
                    {
                        PaisNombre = pais.name.common, 
                        ZonaGeografica = pais.region ?? "No disponible", 
                        EnlaceMapa = $"https://www.google.com/maps/search/?q={pais.name.common}", 
                        UsuarioRegistro = "JG" 
                    };
                }

               
                return null;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al obtener el país: " + ex.Message);
                return null;
            }
        }

    }
}
