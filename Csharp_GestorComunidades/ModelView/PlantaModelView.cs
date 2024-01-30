using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.ModelView
{
    public class PlantaModelView
    {
        #region ATRIBUTOS
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        private int _numPlanta;
        private int _numEscalera;
        private List<Piso> _listaPiso;
        private ObservableCollection<Planta> _listP;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #region CONST
        public PlantaModelView()
        {
            _listP = new ObservableCollection<Planta>();


        }
        #endregion
        #region GET,SET

        public int NumPlanta
        {
            get { return _numPlanta; }
            set
            {
                _numPlanta = value;
                OnPropertyChange(nameof(NumPlanta));
            }
        }

        public List<Piso> ListaPisos
        {
            get { return _listaPiso; }
            set
            {
                _listaPiso = value;
                OnPropertyChange(nameof(ListaPisos));
            }
        }

        public int NumEscalera
        {
            get { return _numEscalera; }
            set
            {
                _numEscalera = value;
                OnPropertyChange(nameof(NumEscalera));
            }
        }

        public ObservableCollection<Planta> ListPlanta
        {
            get { return _listP; }
            set
            {
                _listP = value;
                OnPropertyChange("ListPlanta");
            }
        }

        #endregion


        #region SQL

        public void newPlanta()
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO planta (numPlanta,idEscalera)" +
                         $" VALUES ('{NumPlanta}', '{NumEscalera}');";

            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }
        #endregion
    }
}
