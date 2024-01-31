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
  
    public partial class NewPropietario : Window
    {
        private PropietarioModelView modelPropietario = new PropietarioModelView();

        private bool alreadyExist = false;
        
        public NewPropietario()
        {
            InitializeComponent();
            DataContext = modelPropietario;
            modelPropietario.LoadPropietarios();
        }

        private void newPropietario(object sender, RoutedEventArgs e)
        {
            if (modelPropietario.ListPropietario.Where(x => x.Name == modelPropietario.Name).FirstOrDefault() == null)
            {
                if (modelPropietario.Name.Equals("") || modelPropietario.Surname.Equals("") || modelPropietario.Address.Equals("") || modelPropietario.DNI.Equals("") || modelPropietario.City.Equals("") || modelPropietario.Provincia.Equals("") || modelPropietario.CP.Equals(""))
                {
                    MessageBox.Show("Error. Hay campos sin rellenar");

                }
                else
                {
                    Propietario newPropietario = new Propietario
                    {
                        Name = modelPropietario.Name,
                        Surname = modelPropietario.Surname,
                        DNI = modelPropietario.DNI,
                        Address = modelPropietario.Address,
                        City = modelPropietario.City,
                        Provincia = modelPropietario.Provincia,
                        CP = modelPropietario.CP
                    };

                    modelPropietario.ListPropietario.Add(newPropietario);
                    modelPropietario.newPropietario();
                }
            }
            else
            {
                MessageBox.Show("Ya existe un propietario con ese nombre");
            }
        }
    }
}
