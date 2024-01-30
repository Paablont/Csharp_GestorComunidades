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

            //Initialize COMBOBOX portal
            for (int i = 0; i < modelPortal.ListPortals.Count; i++)
            {
                numPortales.Add($"Portal {(i + 1)}");
            }

            //Initialize COMBOBOX esclaera
            for (int i = 0; i < modelStair.ListStairs.Count; i++)
            {
                numStairs.Add($"Escalera {(i + 1)}");
            }

            //Initialize COMBOBOX planta
            for (int i = 0; i < modelPlanta.ListPlanta.Count; i++)
            {
                numPlanta.Add($"Planta {(i + 1)}");
            }

            //Set num portals in CCBOX portal
            cbbNumPortal.ItemsSource = numPortales;

            //Change amount of stairs from portal number
            cbbNumPortal.SelectionChanged += CbbNumPortal_SelectionChanged;
            //Change amount of plantas from stair number
            cbbNumEscaleras.SelectionChanged += CbbNumEscaleras_SelectionChanged;
        }

        private void CbbNumPortal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cbbNumPortal.SelectedIndex >= 0 && cbbNumPortal.SelectedIndex < numPortales.Count)
            {
                //Index of selected cbbox
                int selectedIndex = cbbNumPortal.SelectedIndex;

                
                if (selectedIndex >= 0 && selectedIndex < modelPortal.ListPortals.Count)
                {
                    numStairs.Clear();
                    for (int i = 0; i < modelPortal.ListPortals[selectedIndex].NumStairs; i++)
                    {
                        numStairs.Add($"Escalera {(i + 1)}");
                    }

                    //Update ccbox Stairs
                    cbbNumEscaleras.ItemsSource = null;
                    cbbNumEscaleras.ItemsSource = numStairs;

                    
                    CbbNumEscaleras_SelectionChanged(null, null);
                }
            }
        }

        private void CbbNumEscaleras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbNumEscaleras.SelectedIndex >= 0 && cbbNumEscaleras.SelectedIndex < numStairs.Count)
            {
                //Index of selected cbbox
                int selectedIndex = cbbNumEscaleras.SelectedIndex;

                if (selectedIndex >= 0 && selectedIndex < modelStair.ListStairs.Count)
                {
                    numPlanta.Clear();

                    //List of plantas associate with stairs index
                    var plantasAsociadas = modelStair.ListStairs[selectedIndex].ListaPlantas;

                    for (int i = 0; i < plantasAsociadas.Count; i++)
                    {
                        numPlanta.Add($"Planta {(i + 1)}");
                    }

                    //Update ccbox plantas
                    cbbNumPlantas.ItemsSource = null;
                    cbbNumPlantas.ItemsSource = numPlanta;

                    
                    cbbNumPlantas.SelectedIndex = 0;
                }
            }
        }



    }

}
