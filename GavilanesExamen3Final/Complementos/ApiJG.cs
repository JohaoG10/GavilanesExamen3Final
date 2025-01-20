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
                // Realizamos la llamada a la API
                var url = $"https://restcountries.com/v3.1/name/{nombreDelPais}?fullText=true";
                var respuesta = await _httpClient.GetStringAsync(url);

                // Deserializamos la respuesta
                var paises = JsonConvert.DeserializeObject<List<dynamic>>(respuesta);

                // Verificamos si la respuesta contiene países
                if (paises != null && paises.Count > 0)
                {
                    var pais = paises[0]; // Tomamos el primer país (en caso de que haya varios)

                    // Devolvemos un objeto PaisJG con la información relevante
                    return new PaisJG
                    {
                        PaisNombre = pais.name.common, // Obtener el nombre común del país
                        ZonaGeografica = pais.region ?? "No disponible", // Asignar la región
                        EnlaceMapa = $"https://www.google.com/maps/search/?q={pais.name.common}", // Enlace de mapa
                        UsuarioRegistro = "JG" // Usuario de registro (puedes ajustarlo a tu preferencia)
                    };
                }

                // Si no se encontró el país, devolvemos null
                return null;
            }
            catch (Exception ex)
            {
                // En caso de error, podemos mostrar el error de la excepción para depuración
                Console.WriteLine("Error al obtener el país: " + ex.Message);
                return null;
            }
        }

    }
}
