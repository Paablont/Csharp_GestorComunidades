using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Csharp_GestorComunidades.View
{
    /// <summary>
    /// Lógica de interacción para NewPortals.xaml
    /// </summary>
    public partial class NewPortals : Window
    {
        private ComunidadModelView modelNBH = new ComunidadModelView();
        private PortalModelView modelPortal = new PortalModelView();
        string nbhName = "";
        int IDNBH;
        public NewPortals(string nameNBH)
        {
            InitializeComponent();
            DataContext = modelNBH;
            modelNBH.LoadNBH();
            nbhName = nameNBH;
            txtNBHName.Content = nbhName;
            IDNBH = modelNBH.getIDNBH(nbhName);
            //MessageBox.Show($"El id de la comunidad {nbhName} es {IDNBH}");
        }

        private void addPortals(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
