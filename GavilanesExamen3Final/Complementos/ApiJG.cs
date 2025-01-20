using GavilanesExamen3Final.Models;
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
                var url = $"https://restcountries.com/v3.1/name/{nombreDelPais}?fields=name,region,flags,latlng,translations";
                var respuesta = await _httpClient.GetStringAsync(url);
                var paises = JsonConvert.DeserializeObject<List<PaisJG>>(respuesta);

                if (paises != null && paises.Count > 0)
                {
                    var pais = paises[0];
                    return new PaisJG
                    {
                        PaisNombre = pais.PaisNombre,
                        ZonaGeografica = pais.ZonaGeografica,
                        EnlaceMapa = $"https://www.google.com/maps/search/?q={pais.PaisNombre}",
                        UsuarioRegistro = "JG"
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
