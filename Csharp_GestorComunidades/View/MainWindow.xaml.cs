using Csharp_GestorComunidades.ModelView;
using Csharp_GestorComunidades.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Csharp_GestorComunidades
{
   
    public partial class MainWindow : Window
    {
        PropietarioModelView modelPropietario = new PropietarioModelView();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = modelPropietario;
            modelPropietario.LoadPropietarios();
        }
        private void OpenNewComunity(object sender, RoutedEventArgs e)
        {
            if(modelPropietario.ListPropietario.Count == 0)
            {
                MessageBox.Show("Actualmente no existe ningún propietario registrado en el sistema. Necesitas tener al " +
                    "menos un propietario registrado para crear la comunidad y asignarle mínimo un piso a ese propietario");
            }
            else
            {
                NewNBH1 otherWindow = new NewNBH1();
                otherWindow.Show();
            }
           
        }

        private void openNewPropietario(object sender, RoutedEventArgs e)
        {
            NewPropietario propWindow = new NewPropietario();
            propWindow.Show();
        }

    }
}
