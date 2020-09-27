using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
   public class Sexo
    {
        private int _idSexo;
        private string _descripcion;

        public int IdSexo
        {
            get
            {
                return _idSexo;
            }

            set
            {
                _idSexo = value;
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

        public List<Sexo> ReadAll()
        {
            BeLifeSeguros.DALC.BeLifeEntities bbdd = new BeLifeSeguros.DALC.BeLifeEntities();

            try
            {
                //se obtienen registros de la tabla
                List<BeLifeSeguros.DALC.Sexo> listadoDatos = bbdd.Sexo.ToList<BeLifeSeguros.DALC.Sexo>();
                //se convierte el listado de datos en un listado de negocio
                List<Sexo> listadoNegocio = GenerarListado(listadoDatos);
                //se retorna la lista
                return listadoNegocio;
            }
            catch (Exception)
            {
                return new List<Sexo>();
            }
        }

        //
        private List<Sexo> GenerarListado(List<BeLifeSeguros.DALC.Sexo> listadoDatos)
        {
            List<Sexo> listadoSexo = new List<Sexo>();

            foreach (BeLifeSeguros.DALC.Sexo dato in listadoDatos)
            {
                Sexo sx = new Sexo();
                CommonBC.Syncronize(dato, sx);
                listadoSexo.Add(sx);
            }

            return listadoSexo;
        }
    }
}
