using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GavilanesExamen3Final.Models;

namespace GavilanesExamen3Final.Complementos
{
    public class BaseDatosJG
    {
        private SQLiteAsyncConnection _conexion;

        public BaseDatosJG()
        {
            var rutaBaseDeDatos = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "paises.db");
            _conexion = new SQLiteAsyncConnection(rutaBaseDeDatos);
            _conexion.CreateTableAsync<PaisJG>().Wait();  
        }

        public Task<int> GuardarPaisAsync(PaisJG pais)
        {
            return _conexion.InsertAsync(pais);
        }

        public Task<List<PaisJG>> ObtenerPaisesAsync()
        {
            return _conexion.Table<PaisJG>().ToListAsync();
        }
    }
}
