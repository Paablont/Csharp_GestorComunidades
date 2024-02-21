using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    public class Escalera
    {
        #region ATRIBUTOS
        private int _numEscalera;
        private List<Planta> _listaPlantas;
        private int _numPortal;
        private int _numPlantas;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONSTRUCT
        public Escalera()
        {
            
        }
        #endregion
        #region GET,SET

        public int NumEscalera
        {
            get { return _numEscalera;}
            set 
            { 
                _numEscalera = value;
                OnPropertyChange(nameof(NumEscalera));
            }
        }
        public int NumPlantas
        {
            get { return _numPlantas; }
            set
            {
                _numPlantas = value;
                OnPropertyChange(nameof(NumPlantas));
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

        public int NumPortal
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
