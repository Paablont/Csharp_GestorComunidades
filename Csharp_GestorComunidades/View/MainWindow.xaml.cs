﻿using Csharp_GestorComunidades.ModelView;
using Csharp_GestorComunidades.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Csharp_GestorComunidades
{
   
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void OpenNewComunity(object sender, RoutedEventArgs e)
        {
            
                NewNBH1 otherWindow = new NewNBH1();
                otherWindow.Show();
           
           
        }

        

    }
}
