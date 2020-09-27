using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public int Anho { get; set; }

        

        
        public virtual MarcaVehiculo MarcaVehiculo { get; set; }
        public virtual ModeloVehiculo ModeloVehiculo { get; set; }

        


        public Vehiculo()
        {
            this.Init();
        }

        private void Init()
        {
            Patente = string.Empty;
            IdMarca = 0;
            IdModelo = 0;
            Anho = 0;
            MarcaVehiculo = new MarcaVehiculo();
            ModeloVehiculo = new ModeloVehiculo();
           
        }

        public bool Create()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            DALC.Vehiculo vehiculo = new DALC.Vehiculo();
            try
            {
                CommonBC.Syncronize(this, vehiculo);
                bbdd.Vehiculo.Add(vehiculo);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bbdd.Vehiculo.Remove(vehiculo);
                return false;
            }
        }
        public bool Read()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Vehiculo vehiculo = bbdd.Vehiculo.First(r => r.Patente.Equals(Patente));
                CommonBC.Syncronize(vehiculo, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Vehiculo vehiculo = bbdd.Vehiculo.First(r => r.Patente.Equals(Patente));
                CommonBC.Syncronize(this, vehiculo);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                
                return false;
            }
        }

        public bool Delete()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Vehiculo vehiculo =
                    bbdd.Vehiculo.First(r => r.Patente.Equals(Patente));

                bbdd.Vehiculo.Remove(vehiculo);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Vehiculo> ReadAll()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Vehiculo> listaDALC = bbdd.Vehiculo.ToList();
                List<Vehiculo> listavehiculo = GenerarListado(listaDALC);
                return listavehiculo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Vehiculo> GenerarListado(List<DALC.Vehiculo> listaDALC)
        {
            List<Vehiculo> listaNegocio = new List<Vehiculo>();
            foreach (DALC.Vehiculo dato in listaDALC)
            {
                Vehiculo negocio = new Vehiculo();
                CommonBC.Syncronize(dato, negocio);
                //negocio.Sexo.Descripcion = dato.Sexo.Descripcion;
                //negocio.EstadoCivil.Descripcion = dato.EstadoCivil.Descripcion;
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }

}

