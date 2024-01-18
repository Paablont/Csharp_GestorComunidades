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
       
        private string _nombreComunidad, _direccion, _fecha;
        //Como bool no existe en BBDD, piscina = 1 si tiene, piscina = 0 no tiene
        private int _metrosCuadrados, _piscina;

        private List<Portal> _listaPortales;
        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONSTRUCT
        public ComunidadModelView(string nombreComunidad, string direccion, string fecha, int metrosCuadrados, int piscina, List<Portal> listaPortales)
        {
            _nombreComunidad = nombreComunidad;
            _direccion = direccion;
            _fecha = fecha;
            _metrosCuadrados = metrosCuadrados;
            _piscina = piscina;
            _listaPortales = listaPortales;
        }

        #endregion

        #region GET,SET
        
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
