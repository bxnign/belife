using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeLifeSeguros.DALC;

namespace BeLifeSeguros.Negocio
{
    public class Cliente
    {
        private string _rutCliente;
        //public string RutCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdSexo { get; set; }
        public int IdEstadoCivil { get; set; }
        public string RutCliente
        {
            get => _rutCliente;
            set
            {
                if (value.Length != 0)
                {
                    _rutCliente = value;
                }
                else
                {
                    throw new Exception("No debe ir vacio");
                }
            }
        }
        //Propiedades virtuales para acceder a 
        //la descripcion en tablas relacionadas
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual Sexo Sexo { get; set; }
        public Cliente()
        {
            this.Init();
        }

        private void Init()
        {
            RutCliente = "000";
            Nombres = string.Empty;
            Apellidos = string.Empty;
            FechaNacimiento = DateTime.Now;
            IdSexo = 0;
            IdEstadoCivil = 0;
            EstadoCivil = new EstadoCivil();
            Sexo = new Sexo();
        }
        //Operaciones de Mantención : CRUD
        public bool Create()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            DALC.Cliente cliente = new DALC.Cliente();
            try
            {
                CommonBC.Syncronize(this, cliente);
                bbdd.Cliente.Add(cliente);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bbdd.Cliente.Remove(cliente);
                return false;
            }
        }
        public bool Read()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                DALC.Cliente cliente =
                    bbdd.Cliente.First(r => r.RutCliente.Equals(RutCliente));
                CommonBC.Syncronize(cliente, this);
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
                DALC.Cliente cliente =
                    bbdd.Cliente.First(r => r.RutCliente.Equals(RutCliente));
                CommonBC.Syncronize(this, cliente);
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
                DALC.Cliente cliente =
                    bbdd.Cliente.First(r => r.RutCliente.Equals(RutCliente));

                bbdd.Cliente.Remove(cliente);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Cliente> ReadAll()
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Cliente> listaDALC = bbdd.Cliente.ToList();
                List<Cliente> listaNegocio = GenerarListado(listaDALC);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<Cliente> GenerarListado(List<DALC.Cliente> listaDALC)
        {
            List<Cliente> listaNegocio = new List<Cliente>();
            foreach (DALC.Cliente dato in listaDALC)
            {
                Cliente negocio = new Cliente();
                CommonBC.Syncronize(dato, negocio);
                negocio.Sexo.Descripcion = dato.Sexo.Descripcion;
                negocio.EstadoCivil.Descripcion = dato.EstadoCivil.Descripcion;
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }

        public List<Cliente> BuscarporRut(string rut)
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            var resultado =
                bbdd.Cliente.Where(r => r.RutCliente == rut);
            try
            {
                List<DALC.Sexo> listaDALC = bbdd.Sexo.ToList();
                List<Cliente> listaNegocio = GenerarListado(resultado.ToList());
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> BuscarPorSexo(int idSexo)
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Cliente> listaDatos = bbdd.Cliente.Where(r => r.IdSexo.Equals(idSexo)).ToList();
                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Cliente> BuscarPorEstadoCivil(int idestadocivil)
        {
            DALC.BeLifeEntities bbdd = new DALC.BeLifeEntities();
            try
            {
                //Creo una lista de tipo DALC
                List<DALC.Cliente> listaDatos = bbdd.Cliente.Where(r => r.IdEstadoCivil.Equals(idestadocivil)).ToList();
                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
}
