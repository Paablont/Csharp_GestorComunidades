using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    class Planta
    {
        #region ATRIBUTOS
        private int _numPlanta;
        private Escalera _numEscalera;
        private List<Piso> _listaPiso;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #region CONSTRUCT,GET,SET
        public Planta(int numPlanta, Escalera numEscalera, List<Piso> listaPiso)
        {
            _numPlanta = numPlanta;
            _numEscalera = numEscalera;
            _listaPiso = listaPiso;
        }

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

        public Escalera NumEscalera
        {
            get { return _numEscalera;}
            set
            {
                _numEscalera = value;
                OnPropertyChange(nameof(NumEscalera));
            }
        }

        #endregion

    }
}
