using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
   public  class Memento
    {

        private string numero;
        private System.DateTime fechaCreacion;
        private System.DateTime fechaTermino;
        private string rutCliente;
        private string codigoPlan;

        private int idTipoContrato;
        private System.DateTime fechaInicioVigencia;

        private System.DateTime fechaFinVigencia;
        private bool vigente;
        private bool declaracionSalud;
        private double primaAnual;
        private double primaMensual;
        private string observaciones;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        public DateTime FechaTermino
        {
            get { return fechaTermino; }
            set {fechaTermino = value; }
        }
        public string RutCliente
        {
            get { return rutCliente; }
            set { rutCliente = value; }
        }
        public string CodigoPlan
        {
            get { return codigoPlan; }
            set { codigoPlan = value; }
        }
        public int IdTipoContrato
        {
            get { return idTipoContrato; }
            set { idTipoContrato = value; }
        }
        public DateTime FechaInicioVigencia
        {
            get { return fechaInicioVigencia; }
            set { fechaInicioVigencia = value; }
        }
        public DateTime FechaFinVigencia
        {
            get { return fechaFinVigencia; }
            set { fechaFinVigencia = value; }
        }
        public bool Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }
        public bool DeclaracionDeSalud
        {
            get { return declaracionSalud; }
            set {declaracionSalud = value; }
        }
        public double PrimaAnual
        {
            get { return primaAnual; }
            set { primaAnual = value; }
        }
        public double PrimaMensual
        {
            get { return primaMensual; }
            set { primaMensual = value; }
        }
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public Memento(string num,DateTime fechacrea,DateTime fechater,string rut,string codplan,int idtipcontrato,DateTime fechavig,
                        DateTime fechafinvig,bool vigent,bool declarasalud,double primanual,double primamensual,string observ)
        {
            this.Numero = num;
            this.FechaCreacion = fechacrea;
            this.FechaTermino = fechater;
            this.RutCliente = rut;
            this.CodigoPlan = codplan;
            this.IdTipoContrato = idtipcontrato;
            this.FechaInicioVigencia = fechavig;
            this.FechaFinVigencia = fechafinvig;
            this.Vigente = vigent;
            this.DeclaracionDeSalud = declarasalud;
            this.PrimaAnual = primanual;
            this.PrimaMensual = primamensual;
            this.Observaciones = observ;
        }
    }
}
