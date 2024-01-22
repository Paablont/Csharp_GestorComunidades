﻿using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.ModelView;
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

    public partial class NewNBH1 : Window
    {
        private ComunidadModelView modelNBH = new ComunidadModelView();

        private bool alreadyExist = false;

        public NewNBH1()
        {
            InitializeComponent();
            DataContext = modelNBH;
            modelNBH.LoadNBH();
        }

        private void addNeighborhood(object sender, RoutedEventArgs e)
        {

            if (modelNBH.ListNBH.Where(x => x.NameNeighborhood == modelNBH.NameNeighborhood).FirstOrDefault() == null)
            {
                Comunidad newNBH = new Comunidad
                {
                    NameNeighborhood = modelNBH.NameNeighborhood,
                    NumPortales = modelNBH.NumPortales,
                    Address = modelNBH.Address,
                    Date = modelNBH.Date,
                    MetrosCuadrados = modelNBH.MetrosCuadrados,
                    HasPool = modelNBH.HasPool,
                    HasPadel = modelNBH.HasPadel,
                    HasTenis = modelNBH.HasTenis,
                    HasGym = modelNBH.HasGym,
                    HasPlayground = modelNBH.HasPlayground,
                    HasGateKeeper = modelNBH.HasGateKeeper,
                    HasShower = modelNBH.HasShower,
                    ListaPortales = modelNBH.ListaPortales
                };
                
                modelNBH.ListNBH.Add(newNBH);
                modelNBH.newNeighborhood();
                //Abrir nueva ventana

            }
            else
            {
                MessageBox.Show("Ya existe una Comunidad con ese nombre");
            }





        }
    }
}