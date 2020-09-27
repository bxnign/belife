using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
    public class Plan
    {
        public string IdPlan { get; set; }

        public int IdTipoContrato { get; set; }
        public string Nombre { get; set; }
        public double PrimaBase { get; set; }
        public string PolizaActual { get; set; }

        


        public bool Read()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
               
            {
                
                DALC.Plan plan = bbdd.Plan.First(a => a.IdPlan == IdPlan);
                CommonBC.Syncronize(plan, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Plan> ReadAll()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Plan> listaDALC = bbdd.Plan.ToList();
                List<Plan> listaNegocio = GenerarListado(listaDALC);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<Plan> GenerarListado(List<DALC.Plan> listaDALC)
        {
            List<Plan> listaNegocio = new List<Plan>();
            foreach (DALC.Plan dato in listaDALC)
            {
                Plan negocio = new Plan();
                CommonBC.Syncronize(dato, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }

   
}
