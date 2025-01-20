using GavilanesExamen3Final.ViewModelsJG;  
using Microsoft.Maui.Controls;

namespace GavilanesExamen3Final.ViewsJG
{
    public partial class BuscarPaisJG : ContentPage
    {
        public BuscarPaisJG()
        {
            InitializeComponent();
            BindingContext = new ViewModelJG(); 
        }
    }
}
