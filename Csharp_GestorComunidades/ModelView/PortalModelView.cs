using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.ModelView
{
    class PortalModelView
    {
        #region ATRIBUTOS
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _numPortal=0,_idNBH=0,_numStairs=0;
        private List<Escalera> _listStairs;
        private ObservableCollection<Portal> _listP;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CONST
        public PortalModelView()
        {
            _listP = new ObservableCollection<Portal>();
        }
        #endregion

        #region GET,SET

        public int NumPortal
        {
            get { return _numPortal; }
            set
            {
                _numPortal = value;
                OnPropertyChange(nameof(NumPortal));
            }
        }

        public int IDNBH
        {
            get { return _idNBH; }
            set
            {
                _idNBH = value;
                OnPropertyChange(nameof(IDNBH));
            }
        }

        public int NumStairs
        {
            get { return _numStairs; }
            set
            {
                _numStairs = value;
                OnPropertyChange(nameof(NumStairs));
            }
        }

        public List<Escalera> ListStairs
        {
            get { return _listStairs; }
            set
            {
                _listStairs = value;
                OnPropertyChange(nameof(ListStairs));
            }
        }

        

        public ObservableCollection<Portal> ListPortals
        {
            get { return _listP; }
            set
            {
                _listP = value;
                OnPropertyChange("ListPortals");
            }
        }
        #endregion

        #region SQL

        public void newNeighborhood()
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO portal (numEscaleras, idComunidad)" +
             $" VALUES ('{NumStairs}', '{IDNBH}');";

            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        
        #endregion
    }
}
