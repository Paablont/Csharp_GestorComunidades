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
using System.Windows;
using System.Xml.Linq;

namespace Csharp_GestorComunidades.ModelView
{
    class ComunidadModelView
    {
        #region ATRIBUTES
        private const String cnstr = "server=localhost;uid=pablo;pwd=pablo;database=comunidad";
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<Comunidad> _listNBH;
        private string _nameNeigh = "", _address= "";
        private DateTime _date;

        private int _surface=0,_numPortales=0;
        private bool _hasPool=false, _hasPadel = false, _hasTenis = false, _hasMeetings = false, _hasGym, _hasPlayground = false, _hasGatekeeper = false, _hasShower = false;

        private List<Portal> _listPortals;
        // Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region CONST
        public ComunidadModelView()
        {
            _listNBH = new ObservableCollection<Comunidad>();
        }
        #endregion

        #region GET,SET

        public string NameNeighborhood
        {
            get { return _nameNeigh; }
            set
            {
                _nameNeigh = value;
                OnPropertyChange(nameof(NameNeighborhood));
            }
        }
        public int NumPortales
        {
            get { return _numPortales; }
            set
            {
                _numPortales = value;
                OnPropertyChange(nameof(NumPortales));
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChange(nameof(Date));
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

        public int Surface
        {
            get { return _surface; }
            set
            {
                _surface = value;
                OnPropertyChange(nameof(Surface));
            }
        }

        public bool HasPool
        {
            get { return _hasPool; }
            set
            {
                _hasPool = value;
                OnPropertyChange(nameof(HasPool));
            }
        }

        public bool HasPadel
        {
            get { return _hasPadel; }
            set
            {
                _hasPadel = value;
                OnPropertyChange(nameof(HasPadel));
            }
        }

        public bool HasTenis
        {
            get { return _hasTenis; }
            set
            {
                _hasTenis = value;
                OnPropertyChange(nameof(HasTenis));
            }
        }
        public bool HasMeetings
        {
            get { return _hasMeetings; }
            set
            {
                _hasMeetings = value;
                OnPropertyChange(nameof(HasMeetings));
            }
        }
        public bool HasPlayground
        {
            get { return _hasPlayground; }
            set
            {
                _hasPlayground = value;
                OnPropertyChange(nameof(HasPlayground));
            }
        }

        public bool HasGym
        {
            get { return _hasGym; }
            set
            {
                _hasGym = value;
                OnPropertyChange(nameof(HasGym));
            }
        }

        public bool HasGateKeeper
        {
            get { return _hasGatekeeper; }
            set
            {
                _hasGatekeeper = value;
                OnPropertyChange(nameof(HasGateKeeper));
            }
        }

        public bool HasShower
        {
            get { return _hasShower; }
            set
            {
                _hasShower = value;
                OnPropertyChange(nameof(HasShower));
            }
        }

        public List<Portal> ListPortals
        {
            get { return _listPortals; }
            set
            {
                _listPortals = value;
                OnPropertyChange(nameof(ListPortals));
            }
        }

        public ObservableCollection<Comunidad> ListNBH
        {
            get { return _listNBH; }
            set
            {
                _listNBH = value;
                OnPropertyChange("ListNBH");
            }
        }


        #endregion

        #region SQL
        public void newNeighborhood()
        {
            //Para meter booleanos en MySQL: (nombreVariable? 0 : 1)
            String SQL = $"INSERT INTO comunidad (nombre,direccion,fecha,numPortales,metroscuadrados,piscina,tienePortero,tieneZonaDuchas,tieneZonaInfantil,tieneZonaDeporte,tieneZonaReuniones,tieneTenis,tienePadel)" +
                $" VALUES ('{NameNeighborhood}','{Address}', '{Date.ToString("yyyy-MM-dd")}', '{NumPortales}', '{Surface}', '{(HasPool? 1 : 0)}', '{(HasGateKeeper ? 1 : 0)}', '{(HasShower ? 1 : 0)}', '{(HasPlayground ? 1 : 0)}', '{(HasGym ? 1 : 0)}', '{(HasMeetings ? 1 : 0)}', '{(HasTenis ? 1 : 0)}', '{(HasPadel ? 1 : 0)}');";
            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paquete MySQL.Data
            MySQLDataComponent.ExecuteNonQuery(SQL, cnstr);
        }

        
        public int getIDNBH(String nameNBH)
        {
            int idNBH = 0;

            try
            {
                String SQL = $"SELECT idcomunidad FROM comunidad.comunidad WHERE nombre = '{nameNBH}'";

                // Ejecuta la consulta y obtén el resultado
                object result = MySQLDataComponent.ExecuteScalar(SQL, cnstr);

                // Verifica si se obtuvo un resultado no nulo
                if (result != null)
                {
                    // Convierte el resultado a un tipo de datos adecuado (por ejemplo, int)
                    idNBH = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones, por ejemplo, muestra un mensaje o registra el error
                MessageBox.Show($"Error al obtener el ID de la comunidad: {ex.Message}");
            }

            return idNBH;
        }


        public void LoadNBH()
        {
            String SQL = $"SELECT * FROM comunidad.comunidad;";
            DataTable dt = MySQLDataComponent.LoadData(SQL, cnstr);

            // Limpia la colección actual
            ListNBH.Clear();

            foreach (DataRow i in dt.Rows)
            {
                ListNBH.Add(new Comunidad
                {
                    NameNeighborhood = i[1].ToString(),
                    Address = i[2].ToString(),
                    Date = DateTime.Parse(i[3].ToString()),
                    NumPortales = int.Parse(i[4].ToString()),
                    Surface = int.Parse(i[5].ToString()),
                    HasPool = bool.TryParse(i[6].ToString(), out bool hasPool) ? hasPool : false,
                    HasGateKeeper = bool.TryParse(i[7].ToString(), out bool hasGateKeeper) ? hasGateKeeper : false,
                    HasShower = bool.TryParse(i[8].ToString(), out bool hasShower) ? hasShower : false,
                    HasPlayground = bool.TryParse(i[9].ToString(), out bool hasPlayground) ? hasPlayground : false,
                    HasGym = bool.TryParse(i[10].ToString(), out bool hasGym) ? hasGym : false,
                    HasMeetings = bool.TryParse(i[11].ToString(), out bool hasMeetings) ? hasMeetings : false,
                    HasTenis = bool.TryParse(i[12].ToString(), out bool hasTenis) ? hasTenis : false,
                    HasPadel = bool.TryParse(i[13].ToString(), out bool hasPadel) ? hasPadel : false,
                });
            }


            dt.Dispose();
        }
        #endregion



    }
}
