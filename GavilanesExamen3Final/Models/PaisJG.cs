using SQLite;

namespace AplicacionPais.Models
{
    public class PaisJG
    {
        [PrimaryKey, AutoIncrement]
        public int PaisId { get; set; }
        public string PaisNombre { get; set; }
        public string ZonaGeografica { get; set; }
        public string EnlaceMapa { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
