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
        PortalModelView modelPortal;

        List<string> numPlanta = new List<string>();
        List<string> numPortales = new List<string>();
        List<string> numStairs = new List<string>();

        public NewAppartment(PlantaModelView plantas, EscaleraModelView escaleras, PortalModelView portales)
        {
            InitializeComponent();
            modelPlanta = plantas;
            modelStair = escaleras;
            modelPortal = portales;
            DataContext = modelPlanta;

            // Inicializar num ComboBox portales
            for (int i = 0; i < modelPortal.ListPortals.Count; i++)
            {
                numPortales.Add($"Portal {(i + 1)}");
            }

            // Inicializar num ComboBox escaleras
            for (int i = 0; i < modelStair.ListStairs.Count; i++)
            {
                numStairs.Add($"Escalera {(i + 1)}");
            }

            // Inicializar num ComboBox plantas
            for (int i = 0; i < modelPlanta.ListPlanta.Count; i++)
            {
                numPlanta.Add($"Planta {(i + 1)}");
            }

            // Establecer numPortal en ComboBox
            cbbNumPortal.ItemsSource = numPortales;

            // Manejar evento de selección de cbbNumPortal
            cbbNumPortal.SelectionChanged += CbbNumPortal_SelectionChanged;
            // Manejar evento de selección de cbbNumEscaleras
            cbbNumEscaleras.SelectionChanged += CbbNumEscaleras_SelectionChanged;
        }

        private void CbbNumPortal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verificar si hay elementos seleccionados en cbbNumPortal
            if (cbbNumPortal.SelectedIndex >= 0 && cbbNumPortal.SelectedIndex < numPortales.Count)
            {
                // Actualizar la lista de escaleras según el portal seleccionado
                int selectedIndex = cbbNumPortal.SelectedIndex;

                // Verificar si el índice es válido para la lista de escaleras
                if (selectedIndex >= 0 && selectedIndex < modelPortal.ListPortals.Count)
                {
                    numStairs.Clear();
                    for (int i = 0; i < modelPortal.ListPortals[selectedIndex].NumStairs; i++)
                    {
                        numStairs.Add($"Escalera {(i + 1)}");
                    }

                    // Actualizar el ComboBox de escaleras
                    cbbNumEscaleras.ItemsSource = null;
                    cbbNumEscaleras.ItemsSource = numStairs;

                    // También puedes actualizar el ComboBox de plantas aquí según la escalera seleccionada
                    // Por ejemplo, puedes llamar a CbbNumEscaleras_SelectionChanged para actualizar las plantas
                    CbbNumEscaleras_SelectionChanged(null, null);
                }
            }
        }

        private void CbbNumEscaleras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verificar si hay elementos seleccionados en cbbNumEscaleras
            if (cbbNumEscaleras.SelectedIndex >= 0 && cbbNumEscaleras.SelectedIndex < numStairs.Count)
            {
                // Actualizar la lista de plantas según la escalera seleccionada
                int selectedIndex = cbbNumEscaleras.SelectedIndex;

                // Verificar si el índice es válido para la lista de plantas
                if (selectedIndex >= 0 && selectedIndex < modelStair.ListStairs.Count)
                {
                    numPlanta.Clear();
                    for (int i = 0; i < modelStair.ListStairs[selectedIndex].ListaPlantas.Count; i++)
                    {
                        numPlanta.Add($"Planta {(i + 1)}");
                    }

                    // Actualizar el ComboBox de plantas
                    cbbNumPlantas.ItemsSource = null;
                    cbbNumPlantas.ItemsSource = numPlanta;
                }
            }
        }

    }

}
