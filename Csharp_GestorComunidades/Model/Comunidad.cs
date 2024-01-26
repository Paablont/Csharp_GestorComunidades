using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    class Comunidad : INotifyPropertyChanged
    {
        #region ATRIBUTES
        
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _nameNeigh, _address;
        private DateTime _date;

        private int _surface,_numPortales;
        private bool _hasPool, _hasPadel, _hasTenis, _hasMeetings, _hasGym, _hasPlayground, _hasGatekeeper, _hasShower;

        private List<Portal> _listaPortales;
        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONST
       
        public Comunidad()
        {

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

        public int Surface
        {
            get { return _surface; }
            set
            {
                _surface = value;
                OnPropertyChange(nameof(Surface));
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




    }
}
