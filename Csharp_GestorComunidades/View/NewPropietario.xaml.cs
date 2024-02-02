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

        //Method to prove DNI is valid (8 digits, 1 char)
        private bool IsValidDNI(string dni)
        {
            
            if (dni.Length != 9)
            {
                return false;
            }
            string numericPart = dni.Substring(0, 8);

            if (!int.TryParse(numericPart, out _))
            {
                return false;
            }

            
            char letter = dni[8];

            
            if (letter < 'A' || letter > 'Z')
            {
                return false;
            }

           
            return true;
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
                    
                    if (IsValidDNI(modelPropietario.DNI))
                    {
                        Propietario newPropietario = new Propietario
                        {
                            Name = modelPropietario.Name.ToUpper(),
                            Surname = modelPropietario.Surname.ToUpper(),
                            DNI = modelPropietario.DNI.ToUpper(),
                            Address = modelPropietario.Address.ToUpper(),
                            City = modelPropietario.City.ToUpper(),
                            Provincia = modelPropietario.Provincia.ToUpper(),
                            CP = modelPropietario.CP
                        };

                        modelPropietario.ListPropietario.Add(newPropietario);
                        modelPropietario.newPropietario();
                        MessageBox.Show($"Propietario {newPropietario.Name} añadido correctamente");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error. DNI INVALIDO. Recuerda que debe tener 8 numeros y 1 letra");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ya existe un propietario con ese nombre");
            }
        }

    }
}
