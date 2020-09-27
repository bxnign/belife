using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
   public class MarcaVehiculo
    {
        private int _IdMarca { get; set; }
        private string _Descripcion { get; set; }

        public int IdMarca
        {
            get
            {
                return _IdMarca;
            }

            set
            {
                _IdMarca = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public List<MarcaVehiculo> ReadAll()
        {
            BeLifeSeguros.DALC.BeLifeEntities bbdd = new BeLifeSeguros.DALC.BeLifeEntities();

            try
            {
                //se obtienen registros de la tabla
                List<BeLifeSeguros.DALC.MarcaVehiculo> listadoDatos = bbdd.MarcaVehiculo.ToList<BeLifeSeguros.DALC.MarcaVehiculo>();
                //se convierte el listado de datos en un listado de negocio
                List<MarcaVehiculo> listadoNegocio = GenerarListado(listadoDatos);
                //se retorna la lista
                return listadoNegocio;
            }
            catch (Exception)
            {
                return new List<MarcaVehiculo>();
            }
        }

        //
        private List<MarcaVehiculo> GenerarListado(List<BeLifeSeguros.DALC.MarcaVehiculo> listadoDatos)
        {
            List<MarcaVehiculo> listamarca = new List<MarcaVehiculo>();

            foreach (BeLifeSeguros.DALC.MarcaVehiculo dato in listadoDatos)
            {
                MarcaVehiculo rg = new MarcaVehiculo();
                CommonBC.Syncronize(dato, rg);
                listamarca.Add(rg);
            }

            return listamarca;
        }
    }
}
