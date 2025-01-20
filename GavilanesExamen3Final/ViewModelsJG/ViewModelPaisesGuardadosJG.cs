using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GavilanesExamen3Final.Complementos;
using CommunityToolkit.Mvvm.Input;

namespace GavilanesExamen3Final.ViewModelsJG
{
    public class ViewModelPaisesGuardadosJG : ObservableObject
    {
        private readonly BaseDatosJG _dbService;

        public ObservableCollection<PaisJG> PaisesGuardados { get; set; }

        public ViewModelPaisesGuardadosJG()
        {
            _dbService = new BaseDatosJG();
            PaisesGuardados = new ObservableCollection<PaisJG>();
            _ = CargarPaisesGuardadosAsync();
        }

        private async Task CargarPaisesGuardadosAsync()
        {
            try
            {
                var listaPaises = await _dbService.ObtenerPaisesGuardadosAsync();
                PaisesGuardados.Clear();

                if (listaPaises != null && listaPaises.Count > 0)
                {
                    foreach (var pais in listaPaises)
                    {
                        PaisesGuardados.Add(pais);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los países: {ex.Message}");
            }
        }

        public ICommand RefrescarCommand => new AsyncRelayCommand(CargarPaisesGuardadosAsync);
    }
}
