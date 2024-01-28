using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    public class Portal
    {
        #region ATRIBUTOS
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _numPortal,_IDNBH,_numStairs;
        private List<Escalera> _listaEscalera;
        private Comunidad _numComunidad;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CONSTRUCT
        public Portal()
        {
            
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

        public List<Escalera> ListaEscaleras
        {
            get { return _listaEscalera; }
            set
            {
                _listaEscalera = value;
                OnPropertyChange(nameof(ListaEscaleras));
            }
        }

        public int IDNBH
        {
            get { return _IDNBH; }
            set
            {
                _IDNBH = value;
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
        #endregion

        

    }


}
