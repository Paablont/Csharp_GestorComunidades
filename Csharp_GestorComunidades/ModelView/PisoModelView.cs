using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Csharp_GestorComunidades.ModelView
{
    public class PisoModelView
    {
        #region ATRIBUTOS
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        private char _letraPiso;
        private List<Propietario> _listaPropietarios;
        private int _idPlanta, _numPlanta,_numPortal,_numStair;

        private string _nomPropietario;
        private int _numParking, _numTrastero,_idPropietario; //Estos campos se generan aleatoriamente
        private ObservableCollection<Piso> _listPiso;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #region CONSTRUCT,GET,SET

        public PisoModelView()
        {
            _listPiso = new ObservableCollection<Piso>();
            
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
            get { return _idPropietario; }
            set
            {
                _idPropietario = value;
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

        public ObservableCollection<Piso> ListPiso
        {
            get { return _listPiso; }
            set
            {
                _listPiso = value;
                OnPropertyChange("ListPiso");
            }
        }
        #endregion

        #region SQL
        public void newPiso()
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO piso (letraPiso,idParking,idTrastero,idPlanta,idPropietario)" +
                $" VALUES ('{LetraPiso}','{NumParking}','{NumTrastero}','{idPlanta}','{idPropietario}');";
            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        public void LoadPiso()
        {
            String SQL = $"SELECT * FROM piso;";
            DataTable dt = MySQLDataComponent.LoadData(SQL, cnstr);

            // Limpia la colección actual
            ListPiso.Clear();

            foreach (DataRow i in dt.Rows)
            {
                ListPiso.Add(new Piso
                {
                    LetraPiso = Convert.ToChar(i[1].ToString()),
                    idPropietario = int.Parse(i[2].ToString()),
                    NumPlanta = int.Parse(i[3].ToString()),
                    NumParking = int.Parse(i[4].ToString()),
                    NumTrastero = int.Parse(i[5].ToString())
                });

            }
            dt.Dispose();
        }

        public string getNomPropietario(int idPropietario)
        {
            string nomPropietario = "";
            try
            {
                String SQL = $"SELECT nombre FROM propietario WHERE idpropietario = '{idPropietario}'";

                // Ejecuta la consulta y obtén el resultado
                object result = MySQLDataComponent.ExecuteScalar(SQL, cnstr);

                // Verifica si se obtuvo un resultado no nulo
                if (result != null)
                {
                    // Convierte el resultado a un tipo de datos adecuado (por ejemplo, int)
                    nomPropietario = result.ToString();
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones, por ejemplo, muestra un mensaje o registra el error
                MessageBox.Show($"Error al obtener el ID del portal: {ex.Message}");
            }

            return nomPropietario;
        }

        #endregion
    }
}
