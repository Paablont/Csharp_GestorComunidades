using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.ModelView;
using Csharp_GestorComunidades.View;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Csharp_GestorComunidades
{
    /*
         *******************************************************************
         *              FIRST WINDOW. CREATE NEW NEIGHBORHOOD
         *******************************************************************              
         */

    public partial class NewNBH1 : MetroWindow
    {
        private ComunidadModelView modelNBH = new ComunidadModelView();       
        private int numPortales, surface;
        public NewNBH1()
        {
            InitializeComponent();
            DataContext = modelNBH;
            modelNBH.LoadNBH();
        }

        #region FUNCTIONS
        private void addNeighborhood(object sender, RoutedEventArgs e)
        {
            numPortales = modelNBH.NumPortales;
            surface = modelNBH.Surface;
            if (modelNBH.ListNBH.Where(x => x.NameNeighborhood == modelNBH.NameNeighborhood).FirstOrDefault() == null)
            {
                if (modelNBH.NameNeighborhood.Equals("") || modelNBH.Address.Equals("") || modelNBH.Surface.Equals("") || modelNBH.NumPortales.Equals(""))
                {
                    MessageBox.Show("Error. Hay campos sin rellenar");
                }
                else if (surface <= 0)
                {
                    MessageBox.Show("La superficie de la comunidad no puede ser 0 o números negativos");
                }
                else if (numPortales <= 0)
                {
                    MessageBox.Show("El número de portales de la comunidad no puede ser 0 o números negativos");
                }
                else
                {
                    Comunidad newNBH = new Comunidad
                    {
                        NameNeighborhood = modelNBH.NameNeighborhood.ToUpper(),
                        NumPortales = modelNBH.NumPortales,
                        Address = modelNBH.Address.ToUpper(),
                        Date = modelNBH.Date,
                        Surface = modelNBH.Surface,
                        HasPool = modelNBH.HasPool,
                        HasPadel = modelNBH.HasPadel,
                        HasTenis = modelNBH.HasTenis,
                        HasGym = modelNBH.HasGym,
                        HasPlayground = modelNBH.HasPlayground,
                        HasGateKeeper = modelNBH.HasGateKeeper,
                        HasShower = modelNBH.HasShower,
                        ListaPortales = modelNBH.ListPortals
                    };

                    modelNBH.ListNBH.Add(newNBH);
                    modelNBH.newNeighborhood();

                    //Generate an object of the new Window (NewPortals.xaml) and show it
                    NewPortals windowPortal = new NewPortals(newNBH);
                    windowPortal.Show();

                    //Hide the actual window (NewNBH1.xaml)
                    this.Hide();

                }

            }
            else
            {
                MessageBox.Show("Ya existe una comunidad con ese nombre");
            }

        }
        #endregion




    }
}
