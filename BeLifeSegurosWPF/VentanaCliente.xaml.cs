using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.Windows.Interop;
using MahApps.Metro;
using BeLifeSeguros.Negocio;

namespace BeLifeSegurosWPF
{
    /// <summary>
    /// Lógica de interacción para VentanaCliente.xaml
    /// </summary>
    public partial class VentanaCliente : MetroWindow
    {
        public VentanaCliente()
        {
            InitializeComponent();
            CargarComboEstadoCivil();
            CargarComboSexo();
            LimpiarControlesBusqueda();
        }
        public int CalcularEdad()
        {
            int anioActual = DateTime.Now.Year;
            DateTime nacimiento = dtpActualizarFechaNacimiento.SelectedDate.Value;
            int anioNacimiento = nacimiento.Year;
            int edad = anioActual - anioNacimiento;

            return edad;
        }

        public void CargarClienteActualizar()
        {
            try
            {
                txtActualizarRut.Text = ((Cliente)dtDatosCliente.SelectedItem).RutCliente;
                txtActualizarPrimerNombre.Text = ((Cliente)dtDatosCliente.SelectedItem).Nombres;
                txtActualizarPrimerApellido.Text = ((Cliente)dtDatosCliente.SelectedItem).Apellidos;
                dtpActualizarFechaNacimiento.SelectedDate = ((Cliente)dtDatosCliente.SelectedItem).FechaNacimiento;
                cboActualizarEstadoCivil.SelectedValue = ((Cliente)dtDatosCliente.SelectedItem).IdEstadoCivil;

                if (((Cliente)dtDatosCliente.SelectedItem).IdSexo == 1)
                {
                    optActualizarMasculino.IsChecked = true;
                }
                else
                {
                    optActualizarFemenino.IsChecked = true;
                }
                txtActualizarRut.IsEnabled = false;
            }
            catch {/*Ignoro*/}
        }
        public void PoblarClienteActualizar(ref Cliente cliente)
        {
            cliente.RutCliente = txtActualizarRut.Text;
            cliente.Nombres = txtActualizarPrimerNombre.Text;
            cliente.Apellidos = txtActualizarPrimerApellido.Text;
            cliente.FechaNacimiento = (DateTime)dtpActualizarFechaNacimiento.SelectedDate;
            if ((bool)optActualizarMasculino.IsChecked)
            {
                cliente.IdSexo = 1;
            }
            else
            {
                cliente.IdSexo = 2;
            }
            cliente.IdEstadoCivil = Convert.ToInt32(cboActualizarEstadoCivil.SelectedValue.ToString());

        }

        private void LimpiarControlesBusqueda()
        {
            txtBuscarRut.Text = String.Empty;
            cboBuscarPorEstadoCivil.SelectedValue = 0;
            cboBuscarPorSexo.SelectedValue = 0;
        }
        private void MostrarClientes()
        {
            
            Cliente cliente = new Cliente();
            dtDatosCliente.ItemsSource = cliente.ReadAll();
        }

        private void btnBuscarTodos_Click(object sender, RoutedEventArgs e)
        {
            MostrarClientes();   
        }

        private void CargarComboEstadoCivil()
        {
            EstadoCivil estCivil = new EstadoCivil();
            cboBuscarPorEstadoCivil.ItemsSource = estCivil.ReadAll();
            cboBuscarPorEstadoCivil.DisplayMemberPath = "Descripcion";
            cboBuscarPorEstadoCivil.SelectedValuePath = "IdEstadoCivil";

            EstadoCivil estaCivil = new EstadoCivil();
            cboActualizarEstadoCivil.ItemsSource = estaCivil.ReadAll();
            cboActualizarEstadoCivil.DisplayMemberPath = "Descripcion";
            cboActualizarEstadoCivil.SelectedValuePath = "IdEstadoCivil";
        }

        private void CargarComboSexo()
        {
            Sexo sexo = new Sexo();
            cboBuscarPorSexo.ItemsSource = sexo.ReadAll();
            cboBuscarPorSexo.DisplayMemberPath = "Descripcion";
            cboBuscarPorSexo.SelectedValuePath = "IdSexo";
        }
        private void buscarRut()
        {
            string rut = txtBuscarRut.Text;
            Cliente buscarcliente = new Cliente();
            dtDatosCliente.ItemsSource = buscarcliente.BuscarporRut(rut);
            
        }

        private void btnBuscarFiltro_Click(object sender, RoutedEventArgs e)
        {
            buscarRut();
            LimpiarControlesBusqueda();
        }

        private void cboBuscarPorSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtDatosCliente.ItemsSource = null;
            Cliente buscarclientesexo = new Cliente();
            int v_valorComboSexo = Convert.ToInt32(cboBuscarPorSexo.SelectedValue.ToString());
            dtDatosCliente.ItemsSource = buscarclientesexo.BuscarPorSexo(v_valorComboSexo);
            cboBuscarPorEstadoCivil.SelectedValue = 0;
        }

        private void cboBuscarPorEstadoCivil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtDatosCliente.ItemsSource = null;
            Cliente buscarestadocivil = new Cliente();
            int v_valorComboEstadoCivil = Convert.ToInt32(cboBuscarPorEstadoCivil.SelectedValue.ToString());
            dtDatosCliente.ItemsSource = buscarestadocivil.BuscarPorEstadoCivil(v_valorComboEstadoCivil);
            cboBuscarPorSexo.SelectedValue = 0;
        }

        private void btnIrActualizar_Click(object sender, RoutedEventArgs e)
        {
            flyActualizar.IsOpen = true;
            CargarClienteActualizar();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();

            try
            {
                if (dtDatosCliente.SelectedIndex != -1)
                {


                    PoblarClienteActualizar(ref cliente);
                    if (cliente.Update())
                    {
                        this.ShowMessageAsync("Cliente Actualizado", "Información");
                        MostrarClientes();
                        txtActualizarRut.IsEnabled = true;
                        flyActualizar.IsOpen = false;
                    }
                    else
                    {
                        this.ShowMessageAsync("Cliente no se pudo Actualizar", "Error");
                    }
                }
                else
                {
                    this.ShowMessageAsync("No ah Seleccionado Cliente", "Atencion");
                }

            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error", ex.Message);
            }
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            try
            {
                if (dtDatosCliente.SelectedIndex != -1)
                {

                    CargarClienteActualizar();
                    PoblarClienteActualizar(ref cliente);
                    if (cliente.Delete())
                    {
                        this.ShowMessageAsync("Cliente Eliminado", "Informacion");
                        MostrarClientes();
                        txtActualizarRut.IsEnabled = true;
                    }
                    else
                    {
                        this.ShowMessageAsync("El cliente no se pudo eliminar", "Error");
                        txtActualizarRut.IsEnabled = true;

                    }
                }
                else
                {
                    this.ShowMessageAsync("No ah seleccionado cliente", "Advertencia");
                    txtActualizarRut.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error al Eliminar", ex.Message);
            }
        }
    }
}
