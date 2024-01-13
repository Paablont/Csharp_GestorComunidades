using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    class Comunidad : INotifyPropertyChanged
    {
        #region ATRIBUTOS
        
        private string _nombreComunidad, _direccion, _fecha;
        //Como bool no existe en BBDD, piscina = 1 si tiene, piscina = 0 no tiene
        private int _numComunidad,_metrosCuadrados,_piscina;

        private List<Portal> _listaPortales;
        // Método que se encarga de actualizar las propiedades en cada cambio
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CONSTRUCT,GET,SET
        public Comunidad(int numComunidad,string nombreComunidad, string direccion, string fecha, int metrosCuadrados, int piscina,List<Portal> listaPortales)
        {
            _numComunidad = numComunidad;
            _nombreComunidad = nombreComunidad;
            _direccion = direccion;
            _fecha = fecha;
            _metrosCuadrados = metrosCuadrados;
            _piscina = piscina;
            _listaPortales = listaPortales;
        }
        public int NumComunidad
        {
            get { return _numComunidad; }
            set
            {
                _numComunidad = value;
                OnPropertyChange(nameof(NumComunidad));
            }
        }
        public string NombreComunidad
        {
            get { return _nombreComunidad; }
            set
            {
                _nombreComunidad = value;
                OnPropertyChange(nameof(NombreComunidad));
            }
        }

        public string Fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChange(nameof(Fecha));
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChange(nameof(Direccion));
            }
        }

        public int Piscina
        {
            get { return _piscina; }
            set
            {
                _piscina = value;
                OnPropertyChange(nameof(Piscina));
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
