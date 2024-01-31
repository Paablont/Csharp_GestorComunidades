using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GestorComunidades.ModelView
{
    public class PropietarioModelView
    {
        #region ATRIB
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _name, _surname, _address, _city, _provincia, _DNI;
        private int _CP; //Codiog postal
        private ObservableCollection<Propietario> _listProp;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CONST
        public PropietarioModelView()
        {
            _listProp = new ObservableCollection<Propietario>();
        }
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

        public ObservableCollection<Propietario> ListPropietario
        {
            get { return _listProp; }
            set
            {
                _listProp = value;
                OnPropertyChange("ListPropietario");
            }
        }
        #endregion

        #region SQL

        public void newPropietario()
        {

            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO propietario (DNI,nombre,apellidos,direccion,localidad,CP,provincia)" +
                         $" VALUES ('{DNI}', '{Name}', '{Surname}', '{Address}', '{City}', '{CP}', '{Provincia}');";

            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        public void LoadPropietarios()
        {
            String SQL = $"SELECT * FROM propietario;";
            DataTable dt = MySQLDataComponent.LoadData(SQL, cnstr);

            // Limpia la colección actual
            ListPropietario.Clear();

            foreach (DataRow i in dt.Rows)
            {
                ListPropietario.Add(new Propietario
                {
                    DNI = i[1].ToString(),
                    Name = i[2].ToString(),
                    Surname = i[3].ToString(),
                    Address = i[4].ToString(),
                    City = i[5].ToString(),
                    CP = int.Parse(i[6].ToString()),
                    Provincia = i[7].ToString(),
                });
            }


            dt.Dispose();
        }

        #endregion
    }
}
