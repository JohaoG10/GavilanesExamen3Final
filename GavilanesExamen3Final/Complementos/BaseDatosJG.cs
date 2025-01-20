using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GavilanesExamen3Final.Complementos
{
    public class BaseDatosJG
    {
        private readonly SQLiteAsyncConnection _database;

        public BaseDatosJG()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PaisesDBJG.db3");

            _database = new SQLiteAsyncConnection(dbPath,
                SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.Create |
                SQLiteOpenFlags.SharedCache);

            _database.CreateTableAsync<PaisJG>().Wait();
        }

        public Task<List<PaisJG>> ObtenerPaisesGuardadosAsync()
        {
            return _database.Table<PaisJG>().ToListAsync();
        }

        public Task<int> GuardarPaisAsync(PaisJG pais)
        {
            return _database.InsertAsync(pais);
        }
    }
}
