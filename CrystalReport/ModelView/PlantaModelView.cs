using Csharp_GestorComunidades.Clases;
using Csharp_GestorComunidades.DDBB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Csharp_GestorComunidades.ModelView
{
    public class PlantaModelView
    {
        #region ATRIBUTOS
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        private int _numPlanta=0;
        private int _numEscalera=0;
        private List<Piso> _listaPiso;
        private ObservableCollection<Planta> _listP;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #region CONST
        public PlantaModelView()
        {
            _listP = new ObservableCollection<Planta>();
           


        }
        #endregion
        #region GET,SET

        public int NumPlanta
        {
            get { return _numPlanta; }
            set
            {
                _numPlanta = value;
                OnPropertyChange(nameof(NumPlanta));
            }
        }

        public List<Piso> ListaPisos
        {
            get { return _listaPiso; }
            set
            {
                _listaPiso = value;
                OnPropertyChange(nameof(ListaPisos));
            }
        }

        public int NumEscalera
        {
            get { return _numEscalera; }
            set
            {
                _numEscalera = value;
                OnPropertyChange(nameof(NumEscalera));
            }
        }

        public ObservableCollection<Planta> ListPlanta
        {
            get { return _listP; }
            set
            {
                _listP = value;
                OnPropertyChange("ListPlanta");
            }
        }

        #endregion


        #region SQL

        public void newPlanta(int numP,int numE)
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO planta (numPlanta,idEscalera)" +
                         $" VALUES ('{numP}', '{numE}');";

            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        public int getIDPlanta(int numPlanta, int idEscalera)
        {

            int idPlanta = 0;
            try
            {
                String SQL = $"SELECT idplanta FROM planta WHERE numPlanta = '{numPlanta}' AND idEscalera = '{idEscalera}'";

                // Ejecuta la consulta y obtén el resultado
                object result = MySQLDataComponent.ExecuteScalar(SQL, cnstr);

                // Verifica si se obtuvo un resultado no nulo
                if (result != null)
                {
                    // Convierte el resultado a un tipo de datos adecuado (por ejemplo, int)
                    idPlanta = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones, por ejemplo, muestra un mensaje o registra el error
                MessageBox.Show($"Error al obtener el ID del portal: {ex.Message}");
            }

            return idPlanta;
        }

        public int getNumPlantas(int idEscalera)
        {
            int numPlantas = 0;

            try
            {
                String SQL = $"SELECT COUNT(*) FROM planta WHERE idEscalera = {idEscalera};";

                // Ejecuta la consulta y obtén el resultado
                object result = MySQLDataComponent.ExecuteScalar(SQL, cnstr);

                // Verifica si se obtuvo un resultado no nulo
                if (result != null)
                {
                    // Convierte el resultado a un tipo de datos adecuado (por ejemplo, int)
                    numPlantas = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones, por ejemplo, muestra un mensaje o registra el error
                MessageBox.Show($"Error al obtener el num plantas: {ex.Message}");
            }

            return numPlantas;
        }
        #endregion
    }
}
