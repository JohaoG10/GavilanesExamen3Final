using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GavilanesExamen3Final.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using GavilanesExamen3Final.Complementos;

namespace GavilanesExamen3Final.ViewModelsJG
{
    public class ViewModelJG : ObservableObject
    {
        private readonly ApiJG _servicioApi;
        private readonly BaseDatosJG _servicioBaseDeDatos;

        public ViewModelJG()
        {
            _servicioApi = new ApiJG();
            _servicioBaseDeDatos = new BaseDatosJG();
            BuscarComando = new AsyncRelayCommand(BuscarPaisAsync);
            LimpiarComando = new RelayCommand(LimpiarCampos);
        }

        private string _paisNombre;
        public string PaisNombre
        {
            get => _paisNombre;
            set => SetProperty(ref _paisNombre, value);
        }

        private string _zonaGeografica;
        public string ZonaGeografica
        {
            get => _zonaGeografica;
            set => SetProperty(ref _zonaGeografica, value);
        }

        private string _enlaceMapa;
        public string EnlaceMapa
        {
            get => _enlaceMapa;
            set => SetProperty(ref _enlaceMapa, value);
        }

        private string _usuarioRegistro;
        public string UsuarioRegistro
        {
            get => _usuarioRegistro;
            set => SetProperty(ref _usuarioRegistro, value);
        }

        private string _mensajeError;
        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        private bool _isErrorVisible;
        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set => SetProperty(ref _isErrorVisible, value);
        }

        public ICommand BuscarComando { get; }
        public ICommand LimpiarComando { get; }

        private async Task BuscarPaisAsync()
        {
            if (string.IsNullOrEmpty(PaisNombre))
            {
                MensajeError = "Por favor ingresa un nombre de país.";
                IsErrorVisible = true;
                return;
            }

            var pais = await _servicioApi.ObtenerPaisPorNombreAsync(PaisNombre);
            if (pais != null)
            {
                var nuevoPais = new PaisJG
                {
                    PaisNombre = pais.PaisNombre,
                    ZonaGeografica = pais.ZonaGeografica,
                    EnlaceMapa = pais.EnlaceMapa,
                    UsuarioRegistro = "JGAVILANES"
                };

                await _servicioBaseDeDatos.GuardarPaisAsync(nuevoPais);

                PaisNombre = pais.PaisNombre;
                ZonaGeografica = pais.ZonaGeografica;
                EnlaceMapa = pais.EnlaceMapa;
                UsuarioRegistro = "JGAVILANES";
                MensajeError = string.Empty;
                IsErrorVisible = false;
            }
            else
            {
                MensajeError = "No se encontró el país.";
                IsErrorVisible = true;
            }
        }

        private void LimpiarCampos()
        {
            PaisNombre = string.Empty;
            ZonaGeografica = string.Empty;
            EnlaceMapa = string.Empty;
            UsuarioRegistro = string.Empty;
            MensajeError = string.Empty;
            IsErrorVisible = false;
        }
    }
}
