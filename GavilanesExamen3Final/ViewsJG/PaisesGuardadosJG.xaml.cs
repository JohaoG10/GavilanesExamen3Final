using GavilanesExamen3Final.ViewModelsJG;

namespace GavilanesExamen3Final.ViewsJG
{
    public partial class PaisesGuardadosJG : ContentPage
    {
        public PaisesGuardadosJG()
        {
            InitializeComponent();  
            BindingContext = new ViewModelJG();
        }
    }
}
