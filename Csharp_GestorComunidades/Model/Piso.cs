using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    public class Piso
    {
        #region ATRIBUTOS
        private char _letraPiso;
        private List<Propietario> _listaPropietarios;
        private int _numPlanta;
        private int _numParking, _numTrastero, _numPropietario; //Estos campos se generan aleatoriamente

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #region CONSTRUCT,GET,SET

        public Piso()
        {
           
        }

        public Char LetraPiso
        {
            get { return _letraPiso; }
            set
            {
                _letraPiso = value;
                OnPropertyChange(nameof(LetraPiso));
            }
        }

        public List<Propietario> ListaPropietarios
        {
            get { return _listaPropietarios; }
            set
            {
                _listaPropietarios = value;
                OnPropertyChange(nameof(ListaPropietarios));
            }
        }

        public int NumPropietario
        {
            get { return _numPropietario; }
            set
            {
                _numPropietario = value;
                OnPropertyChange(nameof(NumPropietario));
            }
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

        public int NumParking
        {
            get { return _numParking; }
            set
            {
                _numParking = value;
                OnPropertyChange(nameof(NumParking));
            }
        }

        public int NumTrastero
        {
            get { return _numTrastero; }
            set
            {
                _numTrastero = value;
                OnPropertyChange(nameof(NumTrastero));
            }
        }
        #endregion
    }
}
