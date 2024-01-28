using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Csharp_GestorComunidades.ModelView
{
    internal class EscaleraModelView
    {
        #region ATRIBUTOS
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        private int _numEscalera;
        private List<Planta> _listaPlantas;
        private int _numPortal;
        private ObservableCollection<Escalera> _listS;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONST
        public EscaleraModelView()
        {
            _listS = new ObservableCollection<Escalera>();
        }
        #endregion

        #region GET,SET

        public int NumEscalera
        {
            get { return _numEscalera; }
            set
            {
                _numEscalera = value;
                OnPropertyChange(nameof(NumEscalera));
            }
        }

        public List<Planta> ListaPlantas
        {
            get { return _listaPlantas; }
            set
            {
                _listaPlantas = value;
                OnPropertyChange(nameof(ListaPlantas));
            }
        }

        public int NumPortal
        {
            get { return _numPortal; }
            set
            {
                _numPortal = value;
                OnPropertyChange(nameof(NumPortal));
            }
        }

        public ObservableCollection<Escalera> ListStairs
        {
            get { return _listS; }
            set
            {
                _listS = value;
                OnPropertyChange("ListStairs");
            }
        }
        #endregion



        #region SQL

        public void newStair()
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO escalera (numEscalera,idPortal)" +
                         $" VALUES ('{NumEscalera}', '{NumPortal}');";

            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }
        #endregion
    }
}
