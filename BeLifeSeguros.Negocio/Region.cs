using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
    public class Region
    {
        private int _IdRegion { get; set; }
        private string _NombreRegion { get; set; }

        public int IdRegion
        {
            get
            {
                return _IdRegion;
            }

            set
            {
                _IdRegion = value;
            }
        }

        public string NombreRegion
        {
            get
            {
                return _NombreRegion;
            }

            set
            {
                _NombreRegion = value;
            }
        }

        public List<Region> ReadAll()
        {
            BeLifeSeguros.DALC.BeLifeEntities bbdd = new BeLifeSeguros.DALC.BeLifeEntities();

            try
            {
                //se obtienen registros de la tabla
                List<BeLifeSeguros.DALC.Region> listadoDatos = bbdd.Region.ToList<BeLifeSeguros.DALC.Region>();
                //se convierte el listado de datos en un listado de negocio
                List<Region> listadoNegocio = GenerarListado(listadoDatos);
                //se retorna la lista
                return listadoNegocio;
            }
            catch (Exception)
            {
                return new List<Region>();
            }
        }

        //
        private List<Region> GenerarListado(List<BeLifeSeguros.DALC.Region> listadoDatos)
        {
            List<Region> listadoRegion = new List<Region>();

            foreach (BeLifeSeguros.DALC.Region dato in listadoDatos)
            {
                Region rg = new Region();
                CommonBC.Syncronize(dato, rg);
                listadoRegion.Add(rg);
            }

            return listadoRegion;
        }
    }
}

