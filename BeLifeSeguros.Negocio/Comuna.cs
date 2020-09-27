using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
   public  class Comuna
    {
        private int _IdComuna { get; set; }
        private string _NombreComuna { get; set; }

      

      


        public int IdComuna
        {
            get
            {
                return _IdComuna;
            }

            set
            {
                _IdComuna = value;
            }
        }

        public string NombreComuna
        {
            get
            {
                return _NombreComuna;
            }

            set
            {
                _NombreComuna = value;
            }
        }

        public List<Comuna> ReadAll()
        {
            BeLifeSeguros.DALC.BeLifeEntities bbdd = new BeLifeSeguros.DALC.BeLifeEntities();

            try
            {
                //se obtienen registros de la tabla
                List<BeLifeSeguros.DALC.Comuna> listadoDatos = bbdd.Comuna.ToList<BeLifeSeguros.DALC.Comuna>();
                //se convierte el listado de datos en un listado de negocio
                List<Comuna> listadoNegocio = GenerarListado(listadoDatos);
                //se retorna la lista
                return listadoNegocio;
            }
            catch (Exception)
            {
                return new List<Comuna>();
            }
        }

        //
        private List<Comuna> GenerarListado(List<BeLifeSeguros.DALC.Comuna> listadoDatos)
        {
            List<Comuna> listadoComuna = new List<Comuna>();

            foreach (BeLifeSeguros.DALC.Comuna dato in listadoDatos)
            {
                Comuna rg = new Comuna();
                CommonBC.Syncronize(dato, rg);
                listadoComuna.Add(rg);
            }

            return listadoComuna;
        }


        public List<Comuna> BuscarPorRegion(Region IdRegion)
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Comuna> listaDatos = bbdd.Comuna.Where(r => r.IdComuna.Equals(IdRegion)).ToList();
                List<Comuna> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

