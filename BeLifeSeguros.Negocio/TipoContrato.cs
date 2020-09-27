using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
    public class TipoContrato
    {
        private int _IdTipoContrato { get; set; }
        private string _Descripcion { get; set; }

        public int IdTipoContrato
        {
            get
            {
                return _IdTipoContrato;
            }

            set
            {
                _IdTipoContrato = value;
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

        public TipoContrato()
        {

        }

        public bool Read()
        {

            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.TipoContrato tipocontrato = bbdd.TipoContrato.First(r => r.IdTipoContrato.Equals(IdTipoContrato));
                CommonBC.Syncronize(tipocontrato, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<TipoContrato> ReadAll()
        {
            BeLifeSeguros.DALC.BeLifeEntities bbdd = new BeLifeSeguros.DALC.BeLifeEntities();

            try
            {
                //se obtienen registros de la tabla
                List<BeLifeSeguros.DALC.TipoContrato> listadoDatos = bbdd.TipoContrato.ToList<BeLifeSeguros.DALC.TipoContrato>();
                //se convierte el listado de datos en un listado de negocio
                List<TipoContrato> listadoNegocio = GenerarListado(listadoDatos);
                //se retorna la lista
                return listadoNegocio;
            }
            catch (Exception)
            {
                return new List<TipoContrato>();
            }
        }

        //
        private List<TipoContrato> GenerarListado(List<BeLifeSeguros.DALC.TipoContrato> listadoDatos)
        {
            List<TipoContrato> listadoTipoContrato = new List<TipoContrato>();

            foreach (BeLifeSeguros.DALC.TipoContrato dato in listadoDatos)
            {
                TipoContrato rg = new TipoContrato();
                CommonBC.Syncronize(dato, rg);
                listadoTipoContrato.Add(rg);
            }

            return listadoTipoContrato;
        }
    }
}
