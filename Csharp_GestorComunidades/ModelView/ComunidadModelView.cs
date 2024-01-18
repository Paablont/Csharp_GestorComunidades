using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
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

        private string _nameNeigh, _address, _date;

        private int _metrosCuadrados;
        private bool _hasPool, _hasPadel, _hasTenis, _hasMeetings, _hasGym, _hasPlayground, _hasGatekeeper, _hasShower;

        private List<Portal> _listaPortales;
        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONST
        public ComunidadModelView(string nameNeighb, string address, string date, int metrosCuadrados, bool hasPool, bool hasPadel, bool hasTenis, bool hasMeetings, bool hasGym, bool hasPlayground, bool hasGatekeeper, bool hasShower, List<Portal> listaPortales)
        {
            _nameNeigh = nameNeighb;
            _address = address;
            _date = date;
            _metrosCuadrados = metrosCuadrados;
            _hasPool = hasPool;
            _hasPadel = hasPadel;
            _hasTenis = hasTenis;
            _hasMeetings = hasMeetings;
            _hasGym = hasGym;
            _hasPlayground = hasPlayground;
            _hasGatekeeper = hasGatekeeper;
            _hasShower = hasShower;
            _listaPortales = listaPortales;
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

        public string Date
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



        #endregion

        #region SQL
        public void newNeighborhood()
        {
            String SQL = $"INSERT INTO partido (nombre,direccion,fecha,metroscuadrados,piscina,tienePortero,tieneZonaDuchas,tieneZonaInfantil,tieneZonaDeporte,tieneZonaReuniones,tieneTenis,tienePadel)" +
                $" VALUES ('{NameNeighborhood}','{Address}', '{Date}', '{MetrosCuadrados}', '{HasPool}', '{HasGateKeeper}, '{HasShower}', '{HasPlayground}', '{HasGym}', '{HasMeetings}', '{HasTenis}', '{HasPadel}'');";
            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }
        #endregion



    }
}
