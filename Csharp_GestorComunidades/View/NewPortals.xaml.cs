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
    
   
    public partial class NewPortals : Window
    {
        private ComunidadModelView modelNBH = new ComunidadModelView();
        private PortalModelView modelPortal = new PortalModelView();
        private EscaleraModelView modelStair = new EscaleraModelView();
        int numPortals;
        Comunidad neighb;
        public NewPortals(Comunidad nbh)
        {
            InitializeComponent();
            DataContext = modelPortal;
            modelNBH.LoadNBH();
            neighb = nbh;

            //Generate tabItems  = numPortals created in 1st window
            generateTabItems(nbh);

            //Obtain ID from actual neighborhood
            modelPortal.IDNBH = modelNBH.getIDNBH(nbh.NameNeighborhood);

            ////TEST: Para comprobar que el id de la comunidad lo coge bien
            //MessageBox.Show($"El id de la comunidad {nbhName} es {IDNBH}");

            //Add portals to nbh listPortales
            neighb.ListaPortales = new List<Portal>();
            for (int i = 0; i < nbh.NumPortales; i++)
            {
                modelPortal.NumPortal = (i + 1);
                Portal p = new Portal
                {
                    NumPortal = modelPortal.NumPortal,
                    NumStairs = 0,
                    IDNBH = modelPortal.IDNBH,
                    ListaEscaleras = modelPortal.ListStairs
                };
                modelPortal.ListPortals.Add(p);
                modelPortal.newPortal();
                neighb.ListaPortales.Add(p);
            }

            ////TEST: Para comprobar cuantos portales se crean
            //for(int i=0;i < modelPortal.ListPortals.Count; i++)
            //{
            //    MessageBox.Show(modelPortal.ListPortals[i].ToString());
            //}

            //TEST: Para comprobar que la lista tiene los portales segun el numero 
            //int port = 0;
            //for (int i = 0; i < nbh.ListaPortales.Count; i++)
            //{
            //    MessageBox.Show($"Portal num {(i + 1)} : IDNBH -> {nbh.ListaPortales[i].IDNBH} , ");
            //}

        }

        #region FUNCTIONS
        
        /*
        *******************************************************************
        *              SECOND WINDOW. ADD PORTALS TO THE NEIGHBORHOOD
        *******************************************************************              
        */

        private void addPortals(object sender, RoutedEventArgs e)
        {
            bool emptyStairs = false;
           
            for(int i= 0;i< modelPortal.ListPortals.Count;i++)
            {
                if (modelPortal.ListPortals[i].NumStairs == 0)
                {
                    emptyStairs = true;
                }
            }
            if(emptyStairs)
            {
                MessageBox.Show("Error al añadir portales a la comunidad. Todos los portales deben tener como mínimo una escalera");
            }
            else
            {
                MessageBox.Show("Portales añadidos");
                
                this.Hide();
            }
        }

        //Method to add stairs to each portal
        private void addStairs(object sender, RoutedEventArgs e)
        {
            
            TabItem activeTab = tbControlPortals.SelectedItem as TabItem;
            DataGrid newDataGrid = activeTab?.Content as DataGrid;

            //To make sure in which portal are we add stairs

            int actualNumStairs;
            if (activeTab != null)
            {
                //Get the index+1 of the actual tabItem( Portal 1 index 0+1, portal 2 index 1+1...)
                int numPortalINDEX = tbControlPortals.Items.IndexOf(activeTab) + 1;

                //Get the actual numStairs the Portal has
                actualNumStairs = modelPortal.getNumStairs(numPortalINDEX, modelPortal.IDNBH);
                actualNumStairs++;
                modelPortal.NumStairs = actualNumStairs;
                //Add numStairs to the DDBB
                modelPortal.updatePortalStairs(numPortalINDEX, modelPortal.NumStairs, modelPortal.IDNBH);
                //Add numStairs to the listPortals
                modelPortal.ListPortals[numPortalINDEX - 1].NumStairs = modelPortal.NumStairs; 
                MessageBox.Show($"Se ha añadido una nueva escalera al portal {numPortalINDEX}. Escaleras actuales: {modelPortal.NumStairs}");

                modelStair.NumPortal = modelPortal.getIDPortal(modelPortal.IDNBH,numPortalINDEX);
                modelStair.NumEscalera = modelPortal.NumStairs;
                //Add stairs to the DDBB and listOfStairs
                Escalera newStair = new Escalera
                {
                    NumEscalera = modelStair.NumEscalera,
                    NumPortal = modelStair.NumPortal,
                    ListaPlantas = modelStair.ListaPlantas
                    
                };

                modelStair.ListStairs.Add(newStair);
                modelStair.newStair();
                //modelPortal.ListStairs.Add(newStair);
            }


        }


        //Method to generate tabItems for the number of portals (each portal can have differente stairs)
        private void generateTabItems(Comunidad nbh)
        {
            for (int i = 1; i <= nbh.NumPortales; i++)
            {
                TabItem newTabItem = new TabItem();
                newTabItem.Header = $"Portal nº {i}";

                // Crear un nuevo DataGrid
                DataGrid newDataGrid = new DataGrid();
                // Configurar el DataGrid según tus necesidades
                // Por ejemplo, puedes asignar la ItemsSource, definir columnas, etc.

                // Agregar el DataGrid al contenido del TabItem
                newTabItem.Content = newDataGrid;

                // Agregar el nuevo TabItem al TabControl
                tbControlPortals.Items.Add(newTabItem);
            }
        }

        #endregion

    }
}
