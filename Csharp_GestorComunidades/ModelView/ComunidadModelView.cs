using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Csharp_GestorComunidades.ModelView
{
    class ComunidadModelView
    {
        #region ATRIBUTES
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<Comunidad> _listNBH;
        private string _nameNeigh = "", _address= "";
        private DateTime _date;

        private int _metrosCuadrados=0,_numPortales=0;
        private bool _hasPool=false, _hasPadel = false, _hasTenis = false, _hasMeetings = false, _hasGym, _hasPlayground = false, _hasGatekeeper = false, _hasShower = false;

        private List<Portal> _listaPortales;
        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONST
        public ComunidadModelView()
        {
            _listNBH = new ObservableCollection<Comunidad>();
        }
        #endregion

        #region GET,SET

        public string NameNeighborhood
        {
            get { return _nameNeigh; }
            set
            {
                _nameNeigh = value;
                OnPropertyChange(nameof(NameNeighborhood));
            }
        }
        public int NumPortales
        {
            get { return _numPortales; }
            set
            {
                _numPortales = value;
                OnPropertyChange(nameof(NumPortales));
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChange(nameof(Date));
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChange(nameof(Address));
            }
        }

        public int MetrosCuadrados
        {
            get { return _metrosCuadrados; }
            set
            {
                _metrosCuadrados = value;
                OnPropertyChange(nameof(MetrosCuadrados));
            }
        }

        public bool HasPool
        {
            get { return _hasPool; }
            set
            {
                _hasPool = value;
                OnPropertyChange(nameof(HasPool));
            }
        }

        public bool HasPadel
        {
            get { return _hasPadel; }
            set
            {
                _hasPadel = value;
                OnPropertyChange(nameof(HasPadel));
            }
        }

        public bool HasTenis
        {
            get { return _hasTenis; }
            set
            {
                _hasTenis = value;
                OnPropertyChange(nameof(HasTenis));
            }
        }
        public bool HasMeetings
        {
            get { return _hasMeetings; }
            set
            {
                _hasMeetings = value;
                OnPropertyChange(nameof(HasMeetings));
            }
        }
        public bool HasPlayground
        {
            get { return _hasPlayground; }
            set
            {
                _hasPlayground = value;
                OnPropertyChange(nameof(HasPlayground));
            }
        }

        public bool HasGym
        {
            get { return _hasGym; }
            set
            {
                _hasGym = value;
                OnPropertyChange(nameof(HasGym));
            }
        }

        public bool HasGateKeeper
        {
            get { return _hasGatekeeper; }
            set
            {
                _hasGatekeeper = value;
                OnPropertyChange(nameof(HasGateKeeper));
            }
        }

        public bool HasShower
        {
            get { return _hasShower; }
            set
            {
                _hasShower = value;
                OnPropertyChange(nameof(HasShower));
            }
        }

        public List<Portal> ListaPortales
        {
            get { return _listaPortales; }
            set
            {
                _listaPortales = value;
                OnPropertyChange(nameof(ListaPortales));
            }
        }

        public ObservableCollection<Comunidad> ListNBH
        {
            get { return _listNBH; }
            set
            {
                _listNBH = value;
                OnPropertyChange("ListNBH");
            }
        }


        #endregion

        #region SQL
        public void newNeighborhood()
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO comunidad (nombre,direccion,fecha,numPortales,metroscuadrados,piscina,tienePortero,tieneZonaDuchas,tieneZonaInfantil,tieneZonaDeporte,tieneZonaReuniones,tieneTenis,tienePadel)" +
                $" VALUES ('{NameNeighborhood}','{Address}', '{Date.ToString("yyyy-MM-dd")}', '{NumPortales}', '{MetrosCuadrados}', '{(HasPool? 1 : 0)}', '{(HasGateKeeper ? 1 : 0)}', '{(HasShower ? 1 : 0)}', '{(HasPlayground ? 1 : 0)}', '{(HasGym ? 1 : 0)}', '{(HasMeetings ? 1 : 0)}', '{(HasTenis ? 1 : 0)}', '{(HasPadel ? 1 : 0)}');";
            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }
        #endregion



    }
}
