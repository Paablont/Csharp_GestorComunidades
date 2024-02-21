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
    public class PortalModelView
    {
        #region ATRIBUTOS
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        public event PropertyChangedEventHandler PropertyChanged;
        private int _numPortal=0,_idNBH=0,_numStairs=0;
        private List<Escalera> _listStairs;
        private ObservableCollection<Portal> _listP;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region CONST
        public PortalModelView()
        {
            _listP = new ObservableCollection<Portal>();
        }
        #endregion

        #region GET,SET

        public int NumPortal
        {
            get { return _numPortal; }
            set
            {
                _numPortal = value;
                OnPropertyChange(nameof(NumPortal));
            }
        }

        public int IDNBH
        {
            get { return _idNBH; }
            set
            {
                _idNBH = value;
                OnPropertyChange(nameof(IDNBH));
            }
        }

        public int NumStairs
        {
            get { return _numStairs; }
            set
            {
                _numStairs = value;
                OnPropertyChange(nameof(NumStairs));
            }
        }

        public List<Escalera> ListStairs
        {
            get { return _listStairs; }
            set
            {
                _listStairs = value;
                OnPropertyChange(nameof(ListStairs));
            }
        }

        

        public ObservableCollection<Portal> ListPortals
        {
            get { return _listP; }
            set
            {
                _listP = value;
                OnPropertyChange("ListPortals");
            }
        }
        #endregion

       

        #region SQL

        public void newPortal()
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO portal (numPortal,numEscaleras, idComunidad)" +
                         $" VALUES ('{NumPortal}','{NumStairs}', '{IDNBH}');";

            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        public void updatePortalStairs(int numPortal, int newNumStairs, int IDnb)
        {
            // Sentencia SQL para actualizar el número de escaleras en un portal específico
            // Se actualizará tanto por el número de portal como por el idComunidad
            String SQL = $"UPDATE portal SET numEscaleras = '{newNumStairs}' WHERE numPortal = '{numPortal}' AND idComunidad = '{IDnb}';";

            // Usamos las clases de la librería de MySQL para ejecutar la consulta
            // Asegúrate de manejar excepciones y errores en entornos de producción
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        public int getNumStairs(int numPortal,int IDnb)
        {
            int numStairs = 0;

            try
            {
                String SQL = $"SELECT numEscaleras FROM portal WHERE numPortal = '{numPortal}' AND idComunidad = '{IDnb}';";

                // Ejecuta la consulta y obtén el resultado
                object result = MySQLDataComponent.ExecuteScalar(SQL, cnstr);

                // Verifica si se obtuvo un resultado no nulo
                if (result != null)
                {
                    // Convierte el resultado a un tipo de datos adecuado (por ejemplo, int)
                    numStairs = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones, por ejemplo, muestra un mensaje o registra el error
                MessageBox.Show($"Error al obtener el ID de la comunidad: {ex.Message}");
            }

            return numStairs;
        }

        public int getIDPortal(int idNBH, int numPortal)
        {

            int idPortal = 0;
            try
            {
                String SQL = $"SELECT idportal FROM portal WHERE idComunidad = '{idNBH}' AND numPortal = '{numPortal}'";

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




        #endregion
    }
}
