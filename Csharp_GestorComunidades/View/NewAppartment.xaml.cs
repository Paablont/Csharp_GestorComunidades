using Csharp_GestorComunidades.Clases;
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
        PropietarioModelView modelPropietario = new PropietarioModelView();
        PisoModelView modelPiso = new PisoModelView();

        List<string> numPlantaString = new List<string>();
        List<string> numPortalesString = new List<string>();
        List<string> numStairsString = new List<string>();
        List<string> numPropietariosString = new List<string>();

        #region CONST
        public NewAppartment(PlantaModelView plantas, EscaleraModelView escaleras, PortalModelView portales)
        {
            InitializeComponent();
            modelPlanta = plantas;
            modelStair = escaleras;
            modelPortal = portales;
            DataContext = modelPlanta;
            modelPropietario.LoadPropietarios();
            modelPlanta.ListaPisos = new List<Piso>();

            //Initialize COMBOBOX portal
            for (int i = 0; i < modelPortal.ListPortals.Count; i++)
            {
                numPortalesString.Add($"Portal {(i + 1)}");
            }

            //Initialize COMBOBOX esclaera
            for (int i = 0; i < modelStair.ListStairs.Count; i++)
            {
                numStairsString.Add($"Escalera {(i + 1)}");
            }

            //Initialize COMBOBOX planta
            for (int i = 0; i < modelPlanta.ListPlanta.Count; i++)
            {
                numPlantaString.Add($"Planta {(i + 1)}");
            }

            //Initialize COMBOBOX propietarios (name, surname and DNI)
            for (int i = 0; i < modelPropietario.ListPropietario.Count; i++)
            {
                numPropietariosString.Add($"{modelPropietario.ListPropietario[i].Name}  {modelPropietario.ListPropietario[i].Surname},{modelPropietario.ListPropietario[i].DNI} ");
            }

            //Set num portals in CCBOX portal and num propietarios in CCBOX propietarios
            cbbNumPortal.ItemsSource = numPortalesString;
            cbbPropietarios.ItemsSource = numPropietariosString;

            //Change amount of stairs from portal number
            cbbNumPortal.SelectionChanged += CbbNumPortal_SelectionChanged;

            //Change amount of plantas from stair number
            cbbNumEscaleras.SelectionChanged += CbbNumEscaleras_SelectionChanged;
        }

        #endregion
        #region FUNCTIONS

        //Method to change the value of Stair CCBOX depends on the selected Portal
        private void CbbNumPortal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbbNumPortal.SelectedIndex >= 0 && cbbNumPortal.SelectedIndex < numPortalesString.Count)
            {
                //Index of selected cbbox
                int selectedIndex = cbbNumPortal.SelectedIndex;


                if (selectedIndex >= 0 && selectedIndex < modelPortal.ListPortals.Count)
                {
                    numStairsString.Clear();
                    for (int i = 0; i < modelPortal.ListPortals[selectedIndex].NumStairs; i++)
                    {
                        numStairsString.Add($"Escalera {(i + 1)}");
                    }

                    //Update ccbox Stairs
                    cbbNumEscaleras.ItemsSource = null;
                    cbbNumEscaleras.ItemsSource = numStairsString;


                    CbbNumEscaleras_SelectionChanged(null, null);
                }
            }
        }

        //Method to change the value of Planta CCBOX depends on the selected Stair
        private void CbbNumEscaleras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbNumEscaleras.SelectedIndex >= 0 && cbbNumEscaleras.SelectedIndex < numStairsString.Count)
            {
                // Obtener la escalera seleccionada
                int selectedIndex = cbbNumEscaleras.SelectedIndex;
                Escalera selectedStair = modelStair.ListStairs[selectedIndex];
                int idPortal = modelPortal.getIDPortal(modelPortal.IDNBH, (cbbNumPortal.SelectedIndex + 1));
                int idEscalera = modelStair.getIDStair(idPortal, (cbbNumEscaleras.SelectedIndex + 1));
                int numPlantas = modelPlanta.getNumPlantas(idEscalera);
                if (selectedStair != null)
                {
                    numPlantaString.Clear();

                    for (int i = 0; i < numPlantas; i++)
                    {
                        numPlantaString.Add($"Planta {(i + 1)}");
                    }

                    // Actualizar ComboBox de plantas
                    cbbNumPlantas.ItemsSource = null;
                    cbbNumPlantas.ItemsSource = numPlantaString;

                    // Seleccionar la primera planta por defecto
                    cbbNumPlantas.SelectedIndex = 0;
                }
            }
        }

        //Method to add new apartment(Piso)
        private void newAppartment(object sender, RoutedEventArgs e)
        {
            if (cbbPropietarios.SelectedIndex >= 0)
            {
                Random rnd = new Random();
                int idPortal = modelPortal.getIDPortal(modelPortal.IDNBH, (cbbNumPortal.SelectedIndex + 1));
                int idEscalera = modelStair.getIDStair(idPortal, (cbbNumEscaleras.SelectedIndex + 1));
                int idPropietario = modelPropietario.getIDPropietario((modelPropietario.ListPropietario[cbbPropietarios.SelectedIndex].DNI)); ;
                int idPlanta = modelPlanta.getIDPlanta((cbbNumPlantas.SelectedIndex + 1), idEscalera);
                // Obtener o inicializar la lista de letras asignadas para la planta actual
                List<char> letrasAsignadas = ObtenerOInicializarLetrasAsignadas(idPlanta);

                // Obtener la próxima letra disponible
                char nuevaLetra = ObtenerProximaLetraDisponible(letrasAsignadas);

                Piso newp = new Piso
                {
                    LetraPiso = nuevaLetra,
                    NumPropietario = idPropietario,
                    NumPlanta = modelPlanta.getIDPlanta((cbbNumPlantas.SelectedIndex + 1), idEscalera),
                    NumParking = rnd.Next(1, 11),
                    NumTrastero = rnd.Next(1, 11),
                    ListaPropietarios = modelPiso.ListaPropietarios

                };
                modelPlanta.ListaPisos.Add(newp);
                modelPiso.ListPiso.Add(newp);
                try
                {
                    modelPiso.newPiso(newp.LetraPiso, newp.NumParking, newp.NumTrastero, newp.NumPlanta, newp.NumPropietario);
                    //modelPiso.newPiso();
                    // Actualizar la lista de letras asignadas para la planta actual
                    letrasAsignadas.Add(newp.LetraPiso);

                    MessageBox.Show($"Piso {newp.LetraPiso} añadido a la planta con id {newp.NumPlanta} correctamente. El propietario tiene id: {newp.NumPropietario}");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir un piso");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona al menos un propietario. Si no sale ningun propietario en la lista, añada uno");
            }
        }

        private List<char> ObtenerOInicializarLetrasAsignadas(int idPlanta)
        {
            // Buscar la lista de letras asignadas para la planta actual
            var letrasAsignadas = modelPlanta.ListaPisos
                .Where(p => p.NumPlanta == idPlanta)
                .Select(p => p.LetraPiso)
                .ToList();

            // Si la lista no existe, inicializarla
            if (letrasAsignadas == null)
            {
                letrasAsignadas = new List<char>();
            }

            return letrasAsignadas;
        }

        private char ObtenerProximaLetraDisponible(List<char> letrasAsignadas)
        {
            // Obtener la próxima letra disponible que no ha sido asignada
            char nuevaLetra = 'A';

            while (letrasAsignadas.Contains(nuevaLetra))
            {
                nuevaLetra++;
            }

            return nuevaLetra;
        }

        //Update Combobox propietarios if you add new one
        public void UpdatePropietariosComboBox()
        {
            numPropietariosString.Clear();

            
            for (int i = 0; i < modelPropietario.ListPropietario.Count; i++)
            {
                numPropietariosString.Add($"{modelPropietario.ListPropietario[i].Name}  {modelPropietario.ListPropietario[i].Surname},{modelPropietario.ListPropietario[i].DNI} ");
            }

            
            cbbPropietarios.ItemsSource = null;
            cbbPropietarios.ItemsSource = numPropietariosString;
        }


        //Method to open NewPropietario (to create new one)
        private void openNewPropietario(object sender, RoutedEventArgs e)
        {
            NewPropietario propWindow = new NewPropietario();

            propWindow.ShowDialog();

            UpdatePropietariosComboBox();

        }
        #endregion
    }

}
