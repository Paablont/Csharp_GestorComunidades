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
        private int _numPlanta;
        private int _numParking, _numTrastero,_numPropietario; //Estos campos se generan aleatoriamente
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
                $" VALUES ('{LetraPiso}','{NumParking}','{NumTrastero}','{NumPlanta}','{NumPropietario}');";
            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        public int getID(int numPlanta)
        {

            int idPortal = 0;
            try
            {
                String SQL = $"SELECT idplanta FROM planta WHERE numPlanta = '{numPlanta}' AND numPortal = '{numPortal}'";

                // Ejecuta la consulta y obtén el resultado
                object result = MySQLDataComponent.ExecuteScalar(SQL, cnstr);

                // Verifica si se obtuvo un resultado no nulo
                if (result != null)
                {
                    // Convierte el resultado a un tipo de datos adecuado (por ejemplo, int)
                    idPortal = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones, por ejemplo, muestra un mensaje o registra el error
                MessageBox.Show($"Error al obtener el ID del portal: {ex.Message}");
            }

            return idPortal;
        }

        public void LoadNBH()
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
                    NumPropietario = int.Parse(i[2].ToString()),
                    NumPlanta = int.Parse(i[3].ToString()),
                    NumParking = int.Parse(i[4].ToString()),
                    NumTrastero = int.Parse(i[5].ToString())
                });

            }
            dt.Dispose();
        }
        #endregion
    }
}
