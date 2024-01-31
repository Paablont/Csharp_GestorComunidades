using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.Clases
{
    public class Propietario
    {
        #region ATRIB
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _name, _surname, _address, _city, _provincia, _DNI;
        private int _CP; //Codiog postal

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CONST
        public Propietario() { }
        #endregion

        #region GET,SET
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChange(nameof(Name));
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChange(nameof(Surname));
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
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChange(nameof(City));
            }
        }
        public string Provincia
        {
            get { return _provincia; }
            set
            {
                _provincia = value;
                OnPropertyChange(nameof(Provincia));
            }
        }
        public string DNI
        {
            get { return _DNI; }
            set
            {
                _DNI = value;
                OnPropertyChange(nameof(DNI));
            }
        }
        public int CP
        {
            get { return _CP; }
            set
            {
                _CP = value;
                OnPropertyChange(nameof(CP));
            }
        }
        #endregion
    }
}
