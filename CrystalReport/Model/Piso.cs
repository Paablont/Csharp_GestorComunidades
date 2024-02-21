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
        private int _idPlanta,_numPlanta, _numPortal, _numStair;
        private string _nomPropietario;
        private int _numParking, _numTrastero, _numPropietario; //Estos campos se generan aleatoriamente

        public event PropertyChangedEventHandler PropertyChanged;
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

        public string NombrePropietario
        {
            get { return _nomPropietario; }
            set
            {
                _nomPropietario = value;
                OnPropertyChange(nameof(NombrePropietario));
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

        public int idPropietario
        {
            get { return _numPropietario; }
            set
            {
                _numPropietario = value;
                OnPropertyChange(nameof(idPropietario));
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
        public int NumPortal
        {
            get { return _numPortal; }
            set
            {
                _numPortal = value;
                OnPropertyChange(nameof(NumPortal));
            }
        }
        public int NumStair
        {
            get { return _numStair; }
            set
            {
                _numStair = value;
                OnPropertyChange(nameof(NumStair));
            }
        }

        public int idPlanta
        {
            get { return _idPlanta; }
            set
            {
                _idPlanta = value;
                OnPropertyChange(nameof(idPlanta));
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
