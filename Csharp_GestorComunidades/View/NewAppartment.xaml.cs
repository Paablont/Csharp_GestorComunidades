using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.ModelView;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class NewAppartment : MetroWindow
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
                modelPiso.LetraPiso = nuevaLetra;
                modelPiso.idPropietario = idPropietario;
                modelPiso.idPlanta = modelPlanta.getIDPlanta((cbbNumPlantas.SelectedIndex + 1), idEscalera);
                modelPiso.NumParking = rnd.Next(1, 11);
                modelPiso.NumTrastero = rnd.Next(1, 11);
               
                Piso newp = new Piso
                {
                    LetraPiso = modelPiso.LetraPiso,
                    idPropietario = modelPiso.idPropietario,
                    idPlanta = modelPiso.idPlanta,
                    NumParking = modelPiso.NumParking,
                    NumTrastero = modelPiso.NumTrastero,
                    ListaPropietarios = modelPiso.ListaPropietarios,
                    NombrePropietario = modelPiso.getNomPropietario(idPropietario),
                    NumPlanta = cbbNumPlantas.SelectedIndex + 1,
                    

                };
                modelPlanta.ListaPisos.Add(newp);
                modelPiso.ListPiso.Add(newp);
                try
                {
                    modelPiso.newPiso();
                    // Actualizar la lista de letras asignadas para la planta actual
                    dvgPisos.ItemsSource = modelPiso.ListPiso;
                    
                    letrasAsignadas.Add(newp.LetraPiso);

                    MessageBox.Show($"Piso {newp.LetraPiso} añadido a la planta con id {newp.NumPlanta} correctamente. El propietario tiene id: {newp.idPropietario}");
                    
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


        //Method to create random propietario
        public void createNewPropietario(object sender, RoutedEventArgs e)
        {
            //Arrays to put the value random
            string[] nombres = { "Juan", "María", "Pedro", "Luisa", "Ana", "Carlos", "Elena", "José", "Laura", "David" };
            string[] apellidos = { "García", "Rodríguez", "Fernández", "López", "Martínez", "Sánchez", "Pérez", "González", "Romero", "Torres" };
            string[] DNIs = { "12345678A", "87654321B", "13579246C", "98765432D", "24681357E", "15926374F", "75395182G", "86420759H", "43857219J", "61724398K" };
            string[] direcciones = { "Calle Principal 123", "Avenida Central 456", "Callejón Secundario 789", "Paseo Grande 321", "Plaza Pequeña 654", "Travesía Estrecha 987", "Ronda Ancha 246", "Prolongación Larga 135", "Bulevar Céntrico 789", "Pasaje Angosto 642" };
            string[] ciudades = { "Madrid", "Barcelona", "Valencia", "Sevilla", "Bilbao", "Málaga", "Zaragoza", "Murcia", "Palma", "Las Palmas" };
            string[] provincias = { "Madrid", "Barcelona", "Valencia", "Sevilla", "Vizcaya", "Málaga", "Zaragoza", "Murcia", "Islas Baleares", "Las Palmas" };
            int[] codigosPostales = { 28001, 08001, 46001, 41001, 48001, 29001, 50001, 30001, 70001, 35001 };


            Random rnd = new Random();
            int nombreIndex = rnd.Next(nombres.Length);
            int apellidoIndex = rnd.Next(apellidos.Length);
            int dniIndex = rnd.Next(DNIs.Length);
            int direccionIndex = rnd.Next(direcciones.Length);
            int ciudadIndex = rnd.Next(ciudades.Length);
            int provinciaIndex = rnd.Next(provincias.Length);
            int cpIndex = rnd.Next(codigosPostales.Length);
            modelPropietario.Name = nombres[nombreIndex];
            modelPropietario.Surname = apellidos[apellidoIndex];
            modelPropietario.DNI = DNIs[dniIndex];
            modelPropietario.Address = direcciones[direccionIndex];
            modelPropietario.City = ciudades[ciudadIndex];
            modelPropietario.Provincia = provincias[provinciaIndex];
            modelPropietario.CP = codigosPostales[cpIndex];
            Propietario nuevoPropietario = new Propietario
            {
                Name = modelPropietario.Name,
                Surname = modelPropietario.Surname,
                DNI = modelPropietario.DNI,
                Address = modelPropietario.Address,
                City = modelPropietario.City,
                Provincia = modelPropietario.Provincia,
                CP = modelPropietario.CP
            };

            //Add propietary to DDBB and list
            modelPropietario.ListPropietario.Add(nuevoPropietario);
            modelPropietario.newPropietario();

            MessageBox.Show($"Se ha creado {nombres[nombreIndex]} {apellidos[apellidoIndex]} con DNI: {DNIs[dniIndex]}");
            UpdatePropietariosComboBox();
        }

        #endregion
    }

}
