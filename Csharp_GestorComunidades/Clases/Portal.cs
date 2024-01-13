using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    class Portal
    {
        #region ATRIBUTOS
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _numPortal;
        private List<Escalera> _listaEscalera;
        private Comunidad _numComunidad;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CONSTRUCT,GET,SET
        public Portal(int numPortal, List<Escalera> listaEscalera, Comunidad numComunidad)
        {
            _numPortal = numPortal;
            _listaEscalera = listaEscalera;
            this._numComunidad = numComunidad;
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

        public List<Escalera> ListaEscaleras
        {
            get { return _listaEscalera; }
            set
            {
                _listaEscalera = value;
                OnPropertyChange(nameof(ListaEscaleras));
            }
        }

        public Comunidad NumComunidad
        {
            get { return _numComunidad; }
            set
            {
                _numComunidad = value;
                OnPropertyChange(nameof(NumComunidad));
            }
        }
        #endregion


    }
}
