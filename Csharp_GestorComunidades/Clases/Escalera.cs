using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    class Escalera
    {
        #region ATRIBUTOS
        private int _numEscalera;
        private List<Planta> _listaPlantas;
        private Portal _numPortal;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONSTRUCT,GET,SET
        public Escalera(int numEscalera, List<Planta> listaPlantas, Portal numPortal)
        {
            _numEscalera = numEscalera;
            _listaPlantas = listaPlantas;
            this._numPortal = numPortal;
        }

        public int NumEscalera
        {
            get { return _numEscalera;}
            set 
            { 
                _numEscalera = value;
                OnPropertyChange(nameof(NumEscalera));
            }
        }

        public List<Planta> ListaPlantas
        {
            get { return _listaPlantas;}
            set
            {
                _listaPlantas = value;
                OnPropertyChange(nameof(ListaPlantas));    
            }
        }

        public Portal NumPortal
        {
            get { return _numPortal; }
            set
            {
                _numPortal = value;
                OnPropertyChange(nameof(NumPortal));
            }
        }
        #endregion



    }
}
