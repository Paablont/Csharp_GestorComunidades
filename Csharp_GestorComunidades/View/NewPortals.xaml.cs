using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.ModelView;
using MahApps.Metro.Controls;
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
    /*
        *******************************************************************
        *              SECOND WINDOW. ADD PORTALS,STAIRS AND PLANTAS TO THE NEIGHBORHOOD
        *******************************************************************              
    */

    public partial class NewPortals : MetroWindow
    {
        private ComunidadModelView modelNBH = new ComunidadModelView();
        private PortalModelView modelPortal = new PortalModelView();
        private EscaleraModelView modelStair = new EscaleraModelView();
        private PlantaModelView modelPlanta = new PlantaModelView();
        
        Comunidad neighb;

        #region CT
        public NewPortals(Comunidad nbh)
        {
            InitializeComponent();
            DataContext = modelPortal;
            modelNBH.LoadNBH();
            neighb = nbh;
            txtNBHName.Content = neighb.NameNeighborhood;

            //Generate tabItems  = numPortals created in 1st window
            generateTabItems(nbh);

            //Obtain ID from actual neighborhood
            modelPortal.IDNBH = modelNBH.getIDNBH(nbh.NameNeighborhood);

            

            //Initialice list of Plantas in Stairs
            modelStair.ListaPlantas = new List<Planta>();
            //Initialice list of Stairs in Portal
            modelPortal.ListStairs = new List<Escalera>();
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

        }
        #endregion

        #region FUNCTIONS


        //Method to add portals
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
            //Check if there's one portal without stairs
            if (emptyStairs)
            {
                MessageBox.Show("Error al añadir portales a la comunidad. Todos los portales deben tener como mínimo una escalera");
            }
            else
            {
                MessageBox.Show("Portales añadidos");
                NewAppartment windowAppart = new NewAppartment(modelPlanta, modelStair,modelPortal);
                windowAppart.Show();
                this.Hide();
            }
        }

        //Method to add stairs to each portal
        private void addStairs(object sender, RoutedEventArgs e)
        {
            String numPlantas;            
            numPlantas = tboxNumPlantas.Text.ToString();

            

            //Check if tboxNumPlantas is empty or less than 1 or not numberINT
            if ((!int.TryParse(numPlantas, out int numPlantasINT) || (string.IsNullOrEmpty(numPlantas) || numPlantasINT < 1)))
            {
                MessageBox.Show("Por favor, introduce un número válido de plantas.");
                return;
            }
            else
            {
                numPlantasINT = int.Parse(numPlantas);

                TabItem activeTab = tbControlPortals.SelectedItem as TabItem;
                

                
                //To make sure in which portal are we add stairs
                int actualNumStairs;
                if (activeTab != null)
                {
                    //Get the index+1 of the actual tabItem( Portal 1 index 0+1, portal 2 index 1+1...)
                    int numPortalINDEX = tbControlPortals.Items.IndexOf(activeTab) + 1;

                    //Get the actual numStairsString the Portal has
                    actualNumStairs = modelPortal.getNumStairs(numPortalINDEX, modelPortal.IDNBH);
                    actualNumStairs++;
                    modelPortal.NumStairs = actualNumStairs;
                    //Add numStairsString to the DDBB
                    modelPortal.updatePortalStairs(numPortalINDEX, modelPortal.NumStairs, modelPortal.IDNBH);
                    //Add numStairsString to the listPortals
                    modelPortal.ListPortals[numPortalINDEX - 1].NumStairs = modelPortal.NumStairs;
                    
                    modelStair.NumPortal = modelPortal.getIDPortal(modelPortal.IDNBH, numPortalINDEX);
                    modelStair.NumEscalera = modelPortal.NumStairs;

                    try
                    {
                        //Add stairs to the DDBB and listOfStairs
                        Escalera newStair = new Escalera
                        {
                            NumEscalera = modelStair.NumEscalera,
                            NumPortal = modelStair.NumPortal,
                            ListaPlantas = modelStair.ListaPlantas

                        };

                        modelStair.ListStairs.Add(newStair);
                        modelStair.newStair();
                        modelPortal.ListStairs.Add(newStair);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se han podido añadir escaleras a la BBDD");
                    }                  

                    try
                    {
                        // Add plantas to the DDBB and ListOfPlantas
                        for (int i = 0; i < numPlantasINT; i++)
                        {
                            Planta p = new Planta
                            {
                                NumPlanta = (i+1),
                                NumEscalera = modelStair.getIDStair(modelStair.NumPortal, modelStair.NumEscalera),
                                ListaPisos = modelPlanta.ListaPisos
                            };
                            modelPlanta.ListPlanta.Add(p);
                            modelStair.ListaPlantas.Add(p);
                            modelPlanta.newPlanta(p.NumPlanta,p.NumEscalera);
                            //modelPlanta.newPlanta();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se han podido añadir plantas a la BBDD");
                    }
                    MessageBox.Show($"Se ha añadido una nueva escalera al portal {numPortalINDEX}. " +
                        $"\nEscaleras totales del portal {numPortalINDEX}: {modelPortal.NumStairs}." +
                        $"\nLa escalera se ha añadido con {numPlantasINT} plantas");


                }

            }
        }


        //Method to generate tabItems for the number of portals (each portal can have differente stairs)
        private void generateTabItems(Comunidad nbh)
        {
            for (int i = 1; i <= nbh.NumPortales; i++)
            {
                TabItem newTabItem = new TabItem();
                newTabItem.Header = $"Portal nº {i}";

                
                DataGrid newDataGrid = new DataGrid();
               

               
                newTabItem.Content = newDataGrid;

                
                tbControlPortals.Items.Add(newTabItem);
            }
        }

        #endregion

    }
}
