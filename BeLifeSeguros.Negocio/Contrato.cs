using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
    public class Contrato
    {
        public string Numero { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaTermino { get; set; }
        public string RutCliente { get; set; }
        public string CodigoPlan { get; set; }

        public int IdTipoContrato { get; set; }
        public System.DateTime FechaInicioVigencia { get; set; }

        public System.DateTime FechaFinVigencia { get; set; }
        public bool Vigente { get; set; }
        public bool DeclaracionSalud { get; set; }
        public double PrimaAnual { get; set; }
        public double PrimaMensual { get; set; }
        public string Observaciones { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Plan Plan { get; set; }

        public virtual Vivienda Vivienda { get; set;}
        public virtual Vehiculo Vehiculo { get; set; }

        public virtual TipoContrato TipoContrato { get; set; }

        public Contrato()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaTermino = DateTime.Now;
            //F_TerminoContrato = DateTime.Now; <= donde se guarda
            RutCliente = string.Empty;
            CodigoPlan = string.Empty;
            IdTipoContrato = 0;
            FechaInicioVigencia = DateTime.Now;
            FechaFinVigencia = DateTime.Now;
            Vigente = false;
            DeclaracionSalud = false;
            PrimaAnual = 0;
            PrimaMensual = 0;
            Observaciones = string.Empty;
            Cliente = new Cliente();
            Plan = new Plan();
            Vivienda = new Vivienda();
            Vehiculo = new Vehiculo();
            TipoContrato = new TipoContrato();
      

        }

        public bool Create()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            DALC.Contrato contrato = new DALC.Contrato();
            try
            {
                CommonBC.Syncronize(this, contrato);
                bbdd.Contrato.Add(contrato);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bbdd.Contrato.Remove(contrato);
                return false;
            }
        }

            public bool Read()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Contrato contrato = bbdd.Contrato.First(r => r.Numero.Equals(Numero));
                CommonBC.Syncronize(contrato, this);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ReadByRut()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Contrato contrato = bbdd.Contrato.First(r => r.RutCliente.Equals(RutCliente));
                CommonBC.Syncronize(contrato, this);
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
                DALC.Contrato contrato = bbdd.Contrato.First(r => r.Numero.Equals(Numero));
                CommonBC.Syncronize(this, contrato);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public bool Delete()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Contrato contrato =
                       bbdd.Contrato.First(r => r.Numero.Equals(Numero));

                bbdd.Contrato.Remove(contrato);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Contrato> ReadAll()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Contrato> listaDALC = bbdd.Contrato.ToList();
                List<Contrato> listaNegocio = GenerarListado(listaDALC);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<Contrato> GenerarListado(List<DALC.Contrato> listaDALC)
        {
            List<Contrato> listaNegocio = new List<Contrato>();
            foreach (DALC.Contrato dato in listaDALC)
            {
                Contrato negocio = new Contrato();
                CommonBC.Syncronize(dato, negocio);
                //negocio.Sexo.Descripcion = dato.Sexo.Descripcion;
                //negocio.EstadoCivil.Descripcion = dato.EstadoCivil.Descripcion;
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
        public List<Contrato> ReadAllByContrato(string NumContrato)
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Contrato> contrato = bbdd.Contrato.Where(r => r.Numero.Equals(NumContrato)).ToList();
                List<Contrato> listaNegocio = GenerarListado(contrato);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Contrato> ReadAllByRutC(string id_Rut)
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Contrato> contratos = bbdd.Contrato.Where(r => r.RutCliente.Equals(id_Rut)).ToList();
                List<Contrato> listaNegocio = GenerarListado(contratos);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Contrato> ReadAllByPoliza(string id_plan)
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Contrato> listaDALC = bbdd.Contrato.Where(r => r.CodigoPlan.Equals(id_plan)).ToList();
                List<Contrato> listaNegocio = GenerarListado(listaDALC);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void setMemento(Memento memento)
        {
            this.Numero = memento.Numero;
            this.RutCliente = memento.RutCliente;
            this.FechaCreacion = memento.FechaCreacion;
            this.FechaTermino = memento.FechaTermino;
            this.FechaInicioVigencia = memento.FechaInicioVigencia;
            this.FechaFinVigencia = memento.FechaFinVigencia;
            this.IdTipoContrato = memento.IdTipoContrato;
            this.CodigoPlan = memento.CodigoPlan;
            this.PrimaAnual = memento.PrimaAnual;
            this.PrimaMensual = memento.PrimaMensual;
            this.Vigente = memento.Vigente;
            this.DeclaracionSalud = memento.DeclaracionDeSalud;
            this.Observaciones = memento.Observaciones;
        }

        public Memento CreateMemento()
        {
            return new Memento(Numero, FechaCreacion, FechaTermino, RutCliente, CodigoPlan, IdTipoContrato, FechaInicioVigencia, FechaFinVigencia
                                , Vigente, DeclaracionSalud, PrimaAnual, PrimaMensual, Observaciones);
        }

    }


}
