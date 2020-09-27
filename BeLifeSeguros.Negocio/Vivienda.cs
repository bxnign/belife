using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
   public  class Vivienda
    {

        public int CodigoPostal { get; set; }
        public int Anho { get; set; }
        public string Direccion { get; set; }
        public double ValorInmueble { get; set; }
        public double ValorContenido { get; set; }
        public int IdComuna { get; set; }
        public int IdRegion { get; set; }

      

        public virtual Comuna Comuna { get; set; }
        public virtual Region Region { get; set; }
       

        public Vivienda()
        {
            this.Init();
        }

        private void Init()
        {
            CodigoPostal = 0;
            Anho = 0;
            Direccion = string.Empty;
            ValorInmueble = 0;
            ValorContenido = 0;
            IdComuna = 0;
            IdRegion = 0;
            Comuna = new Comuna();
            Region = new Region();
            
            
        }


        public bool Create()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            DALC.Vivienda vivienda = new DALC.Vivienda();
            try
            {
                CommonBC.Syncronize(this, vivienda);
                bbdd.Vivienda.Add(vivienda);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bbdd.Vivienda.Remove(vivienda);
                return false;
            }
        }

        public bool Read()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Vivienda vivienda = bbdd.Vivienda.First(r => r.CodigoPostal.Equals(CodigoPostal));
                CommonBC.Syncronize(vivienda, this);
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
                DALC.Vivienda vivienda = bbdd.Vivienda.First(r => r.CodigoPostal.Equals(CodigoPostal));
                CommonBC.Syncronize(this, vivienda);
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
                DALC.Vivienda vivienda =
                    bbdd.Vivienda.First(r => r.CodigoPostal.Equals(CodigoPostal));

                bbdd.Vivienda.Remove(vivienda);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Vivienda> ReadAll()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Vivienda> listaDALC = bbdd.Vivienda.ToList();
                List<Vivienda> listaNegocio = GenerarListado(listaDALC);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private List<Vivienda> GenerarListado(List<DALC.Vivienda> listaDALC)
        {
            List<Vivienda> listavivienda = new List<Vivienda>();
            foreach (DALC.Vivienda dato in listaDALC)
            {
                Vivienda negocio = new Vivienda();
                CommonBC.Syncronize(dato, negocio);
                //negocio.Sexo.Descripcion = dato.Sexo.Descripcion;
                //negocio.EstadoCivil.Descripcion = dato.EstadoCivil.Descripcion;
                listavivienda.Add(negocio);
            }
            return listavivienda;
        }

       
    }
}
