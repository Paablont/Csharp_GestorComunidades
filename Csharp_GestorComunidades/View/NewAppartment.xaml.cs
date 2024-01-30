using Csharp_GestorComunidades.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    
    public partial class NewAppartment : Window
    {
        PlantaModelView modelPlanta;
        EscaleraModelView modelStair;
        //List for ComboBox 
        List<string> numPlanta = new List<string>();
            
        
        public NewAppartment(PlantaModelView plantas,EscaleraModelView escaleras)
        {
            
            InitializeComponent();
            modelPlanta = plantas;
            modelStair = escaleras;
            DataContext = modelPlanta;

            //Initialice num ComboBox plantas
            for (int i = 1; i <= modelPlanta.ListPlanta.Count; i++)
            {
                numPlanta.Add($"Escalera {modelStair.NumEscalera}, Planta {i}");
            }

            // Establecer la lista como origen de datos para el ComboBox
            cbbNumPlantas.ItemsSource = numPlanta;

        }
    }
}
