using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
  public  class ModeloVehiculo
    {
        private int _IdModelo { get; set; }
        private string _Descripcion { get; set; }

        public int IdModelo
        {
            get
            {
                return _IdModelo;
            }

            set
            {
                _IdModelo = value;
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

        public List<ModeloVehiculo> ReadAll()
        {
            BeLifeSeguros.DALC.BeLifeEntities bbdd = new BeLifeSeguros.DALC.BeLifeEntities();

            try
            {
                //se obtienen registros de la tabla
                List<BeLifeSeguros.DALC.ModeloVehiculo> listadoDatos = bbdd.ModeloVehiculo.ToList<BeLifeSeguros.DALC.ModeloVehiculo>();
                //se convierte el listado de datos en un listado de negocio
                List<ModeloVehiculo> listadoNegocio = GenerarListado(listadoDatos);
                //se retorna la lista
                return listadoNegocio;
            }
            catch (Exception)
            {
                return new List<ModeloVehiculo>();
            }
        }

        //
        private List<ModeloVehiculo> GenerarListado(List<BeLifeSeguros.DALC.ModeloVehiculo> listadoDatos)
        {
            List<ModeloVehiculo> listadomodelo = new List<ModeloVehiculo>();

            foreach (BeLifeSeguros.DALC.ModeloVehiculo dato in listadoDatos)
            {
                ModeloVehiculo rg = new ModeloVehiculo();
                CommonBC.Syncronize(dato, rg);
                listadomodelo.Add(rg);
            }

            return listadomodelo;
        }
    }
}

