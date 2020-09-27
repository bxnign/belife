using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeLifeSeguros.DALC;

namespace BeLifeSeguros.Negocio
{
    public class EstadoCivil
    {
        private int _idEstadoCivil;
        private string _descripcion;

        public int IdEstadoCivil
        {
            get
            {
                return _idEstadoCivil;
            }

            set
            {
                _idEstadoCivil = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        //retorna la lista de estados civiles
        public List<EstadoCivil> ReadAll()
        {
            BeLifeSeguros.DALC.BeLifeEntities bbdd = new  BeLifeSeguros.DALC.BeLifeEntities();

            try
            {
                //se obtienen registros de la tabla
                List<BeLifeSeguros.DALC.EstadoCivil> listadoDatos = bbdd.EstadoCivil.ToList<BeLifeSeguros.DALC.EstadoCivil>();
                //se convierte el listado de datos en un listado de negocio
                List<EstadoCivil> listadoNegocio = GenerarListado(listadoDatos);
                //se retorna la lista
                return listadoNegocio;
            }
            catch (Exception)
            {
                return new List<EstadoCivil>();
            }
        }

        //
        private List<EstadoCivil> GenerarListado(List<BeLifeSeguros.DALC.EstadoCivil> listadoDatos)
        {
            List<EstadoCivil> listadoEstadoCivil = new List<EstadoCivil>();

            foreach (BeLifeSeguros.DALC.EstadoCivil dato in listadoDatos)
            {
                EstadoCivil ec = new EstadoCivil();
                CommonBC.Syncronize(dato, ec);
                listadoEstadoCivil.Add(ec);
            }

            return listadoEstadoCivil;
        }
    }
}
