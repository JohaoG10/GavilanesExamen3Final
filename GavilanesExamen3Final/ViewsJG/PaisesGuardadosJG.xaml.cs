using GavilanesExamen3Final.ViewModelsJG;
using Microsoft.Maui.Controls;

namespace GavilanesExamen3Final.ViewsJG
{
    public partial class PaisesGuardadosJG : ContentPage
    {
        public PaisesGuardadosJG()
        {
            InitializeComponent();
            BindingContext = new ViewModelPaisesGuardadosJG();
        }
    }
}
