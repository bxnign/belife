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
using BeLifeSeguros.Negocio;

namespace BeLifeSegurosWPF
{
    /// <summary>
    /// Lógica de interacción para VentanaContrato.xaml
    /// </summary>
    public partial class VentanaContrato : MetroWindow
    {
        public VentanaContrato()
        {


            InitializeComponent();
            LlenarCombos();
            MenuInvicible();
            
            
        }

        private void MenuInvicible()
        {
            lblAnioAuto.Opacity = 0;
            txtAnioAuto.Opacity = 0;
            lblAnioCasa.Opacity = 0;
            txtAnioVivienda.Opacity = 0;
            lblCodigoPostal.Opacity = 0;
            txtCodigoPostal.Opacity = 0;
            lblcomuna.Opacity = 0;
            cboComuna.Opacity = 0;
            lblIngresePatente.Opacity = 0;
            txtIngresePatente.Opacity = 0;
            lblMarcaVehiculo.Opacity = 0;
            cboMarca.Opacity = 0;
            lblModeloVehiculo.Opacity = 0;
            cboModelo.Opacity = 0;
            lblRegion.Opacity = 0;
            cboRegion.Opacity = 0;
            lblvalorVivienda.Opacity = 0;
            txtValorVivienda.Opacity = 0;
            lblValorContenido.Opacity = 0;
            txtValorContenido.Opacity = 0;
            lblDireccion.Opacity = 0;
            txtDireccion.Opacity = 0;



        }

        public void MenuVehiculoVisible()
        {
            lblAnioAuto.Opacity = 100;
            txtAnioAuto.Opacity = 100;
            lblIngresePatente.Opacity = 100;
            txtIngresePatente.Opacity = 100;
            lblMarcaVehiculo.Opacity = 100;
            cboMarca.Opacity = 100;
            lblModeloVehiculo.Opacity = 100;
            cboModelo.Opacity = 100;
            lblPlanAsociado.Opacity = 100;
            cboPlanAsociado.Opacity = 100;


        }
        public void MenuVehiculoNotVisible()
        {
            lblAnioAuto.Opacity = 0;
            txtAnioAuto.Opacity = 0;
            lblIngresePatente.Opacity = 0;
            txtIngresePatente.Opacity = 0;
            lblMarcaVehiculo.Opacity = 0;
            cboMarca.Opacity = 0;
            lblModeloVehiculo.Opacity = 0;
            cboModelo.Opacity = 0;



        }

        public void MenuViviendaVisible()
        {
            lblAnioCasa.Opacity = 100;
            txtAnioVivienda.Opacity = 100;
            lblCodigoPostal.Opacity = 100;
            txtCodigoPostal.Opacity = 100;
            lblcomuna.Opacity = 100;
            cboComuna.Opacity = 100;
            lblPlanAsociado.Opacity = 100;
            cboPlanAsociado.Opacity = 100;
            lblRegion.Opacity = 100;
            cboRegion.Opacity = 100;
            lblvalorVivienda.Opacity = 100;
            txtValorVivienda.Opacity = 100;
            lblValorContenido.Opacity = 100;
            txtValorContenido.Opacity = 100;
            lblDireccion.Opacity = 100;
            txtDireccion.Opacity = 100;


        }
        public void MenuViviendaNotvisible()
        {
            lblAnioCasa.Opacity = 0;
            txtAnioVivienda.Opacity = 0;
            lblCodigoPostal.Opacity = 0;
            txtCodigoPostal.Opacity = 0;
            lblcomuna.Opacity = 0;
            cboComuna.Opacity = 0;
            lblRegion.Opacity = 0;
            cboRegion.Opacity = 0;
            lblvalorVivienda.Opacity = 0;
            txtValorVivienda.Opacity = 0;
            lblValorContenido.Opacity = 0;
            txtValorContenido.Opacity = 0;
            lblDireccion.Opacity = 0;
            txtDireccion.Opacity = 0;


        }

        public void MenuVida()
        {
            lblPlanAsociado.Opacity = 100;
            cboPlanAsociado.Opacity = 100;
            chkDeclaracionSalud.IsChecked = true;
            chkDeclaracionSalud.IsEnabled = true;
        }

        public void MenuVidaNotVisible()
        {

            chkDeclaracionSalud.IsChecked = false;
            chkDeclaracionSalud.IsEnabled = true;
        }
        public void PoblarContratos(ref Contrato obcontrato)
        {
            

            obcontrato.Numero = txtNumero.Text;
            obcontrato.FechaCreacion = (DateTime)dtInicioContrato.SelectedDate;
            obcontrato.FechaTermino = (DateTime)dtFinContrato.SelectedDate;
            obcontrato.RutCliente = txtRutCliente.Text;
            obcontrato.FechaInicioVigencia = (DateTime)dtInicioVigencia.SelectedDate;
            obcontrato.FechaFinVigencia = (DateTime)dtFinVigencia.SelectedDate;
            obcontrato.DeclaracionSalud = (bool)chkDeclaracionSalud.IsChecked;
            obcontrato.Vigente = (bool)chkVigente.IsChecked;
            obcontrato.PrimaAnual = Convert.ToDouble(txtPrimaAnual.Text);
            obcontrato.PrimaMensual = Convert.ToDouble(txtPrimaMensual.Text);
            obcontrato.Observaciones = txtObservaciones.Text;
            obcontrato.CodigoPlan = cboPlanAsociado.SelectedValue.ToString();
            obcontrato.IdTipoContrato = Convert.ToInt32(cboTipoContrato.SelectedValue.ToString());
        }
        // este metodo se hace para poder terminar la vigencia de contratos, ya que con el otro poblar me tira error
       
       

        public void CargarControles()
        {

            
            txtNumero.Text = ((Contrato)dgDatosContratos.SelectedItem).Numero;
            txtRutCliente.Text = ((Contrato)dgDatosContratos.SelectedItem).RutCliente;
            txtObservaciones.Text = ((Contrato)dgDatosContratos.SelectedItem).Observaciones;
            dtInicioContrato.SelectedDate = ((Contrato)dgDatosContratos.SelectedItem).FechaCreacion;
            dtFinContrato.SelectedDate = ((Contrato)dgDatosContratos.SelectedItem).FechaTermino;
            dtInicioVigencia.SelectedDate = ((Contrato)dgDatosContratos.SelectedItem).FechaInicioVigencia;
            dtFinVigencia.SelectedDate = ((Contrato)dgDatosContratos.SelectedItem).FechaFinVigencia;
            txtPrimaAnual.Text = ((Contrato)dgDatosContratos.SelectedItem).PrimaAnual.ToString();
            txtPrimaMensual.Text = ((Contrato)dgDatosContratos.SelectedItem).PrimaMensual.ToString();
            cboTipoContrato.SelectedValue = ((Contrato)dgDatosContratos.SelectedItem).IdTipoContrato;
            cboPlanAsociado.SelectedValue = ((Contrato)dgDatosContratos.SelectedItem).CodigoPlan;
            


            if (((Contrato)dgDatosContratos.SelectedItem).DeclaracionSalud == true)
            {
                chkDeclaracionSalud.IsChecked = true;
            }else
            {
                chkDeclaracionSalud.IsChecked = false;
            }
           if(((Contrato)dgDatosContratos.SelectedItem).Vigente == true)
            {
                chkVigente.IsChecked = true;
            }
            else
            {
                chkVigente.IsChecked = false;
            }
            txtNumero.IsEnabled = false;
            txtRutCliente.IsEnabled = false;
            dtInicioContrato.IsEnabled = false;
            dtInicioVigencia.IsEnabled = false;
            chkDeclaracionSalud.IsEnabled = false;
            chkVigente.IsEnabled = false;

        }

        public void LimpiarControles()
        {
            dtInicioContrato.Text = string.Empty;
            dtFinContrato.Text = string.Empty;
            dtInicioVigencia.Text = string.Empty;
            dtFinVigencia.Text = string.Empty;
            txtRutCliente.Text = string.Empty;
            
            txtNumero.Text = string.Empty;
            txtPoliza.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtPrimaAnual.Text = string.Empty;
            txtPrimaMensual.Text = string.Empty;
            txtCodigoPostal.Text = string.Empty;
            txtAnioVivienda.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtValorContenido.Text = string.Empty;
            txtValorVivienda.Text = string.Empty;
            txtAnioAuto.Text = string.Empty;
            txtIngresePatente.Text = string.Empty;
            chkDeclaracionSalud.IsChecked = false;
            chkVigente.IsChecked = false;
            cboComuna.SelectedValue = 0;
            cboRegion.SelectedValue = 0;
            cboMarca.SelectedValue = 0;
            cboModelo.SelectedValue = 0;
            cboTipoContrato.SelectedValue = 0;
            cboPlanAsociado.SelectedValue = 0;
            dtInicioContrato.IsEnabled = true;
            dtInicioVigencia.IsEnabled = true;
            txtRutCliente.IsEnabled = true;
            chkVigente.IsChecked = false;
            chkVigente.IsEnabled = true;
            txtNumero.IsEnabled = true;
        }


        private void LlenarCombos()
        {
            Contrato contrato = new Contrato();
            cboCodigoContrato.ItemsSource = contrato.ReadAll();
            cboCodigoContrato.DisplayMemberPath = "Numero";
            cboCodigoContrato.SelectedValuePath = "Numero";

            Plan poliza = new Plan();
            cboPolizas.ItemsSource = poliza.ReadAll();
            cboPolizas.DisplayMemberPath = "PolizaActual";
            cboPolizas.SelectedValuePath = "IdPlan";

            
            cboRut.ItemsSource = contrato.ReadAll();
            cboRut.DisplayMemberPath = "RutCliente";
            cboRut.SelectedValuePath = "RutCliente";

            TipoContrato tipocontrato = new TipoContrato();
            cboTipoContrato.ItemsSource = tipocontrato.ReadAll();
            cboTipoContrato.DisplayMemberPath = "Descripcion";
            cboTipoContrato.SelectedValuePath = "IdTipoContrato";



            // se carga combo plan
            Plan plan = new Plan();
            cboPlanAsociado.ItemsSource = plan.ReadAll();
            cboPlanAsociado.DisplayMemberPath = "Nombre";
            cboPlanAsociado.SelectedValuePath = "IdPlan";
        }

        private void btnActualizarContrato_Click(object sender, RoutedEventArgs e)
        {
            flyActualizarContrato.IsOpen = true;
            CargarControles();

        }

        private void btnFinVigencia_Click(object sender, RoutedEventArgs e)
        {

            Contrato obcontrato = new Contrato();
            try
            {
                
                dtFinContrato.SelectedDate = DateTime.Today;
                dtFinVigencia.SelectedDate = DateTime.Today;

                CargarControles();
                PoblarContratos(ref obcontrato);
                if (obcontrato.Delete())
                {
                    this.ShowMessageAsync("Contrato Terminado", "Información");
                    LimpiarControles();
                    Tarificador tar = new Tarificador();
            
            
                }
                else
                {
                    this.ShowMessageAsync("Contrato no se pudo Terminar", "Información");
                }

            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error", ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            Contrato obcontrato = new Contrato();
            try
            {
                PoblarContratos(ref obcontrato);
                if (obcontrato.Update())
                {
                    this.ShowMessageAsync("Contrato Actualizado", "Información");
                    LimpiarControles();
                    txtNumero.IsEnabled = true;
                    txtRutCliente.IsEnabled = true;
                    dtInicioContrato.IsEnabled = true;
                    dtInicioVigencia.IsEnabled = true;
                    chkDeclaracionSalud.IsEnabled = true;
                    chkVigente.IsEnabled = true;
                    flyActualizarContrato.IsOpen = false;

                }
                else
                {
                    this.ShowMessageAsync("Contrato no se pudo actualizar", "Error");
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error", ex.Message);
            }
        }

        private void btnBuscarTodos_Click(object sender, RoutedEventArgs e)
        {
            
            Contrato contrato = new Contrato();
            dgDatosContratos.ItemsSource = contrato.ReadAll(); 
            
        }

        private void cboTipoContrato_SelectValue(object sender, SelectionChangedEventArgs e)
        {

            
            int v_valorcombo = Convert.ToInt32(cboTipoContrato.SelectedValue);
            if (v_valorcombo == 10)
            {
                MenuVida();
                MenuViviendaNotvisible();
                MenuVehiculoNotVisible();
                chkDeclaracionSalud.IsChecked = true;
                chkDeclaracionSalud.IsEnabled = false;



            }
            else if (v_valorcombo == 20)
            {
                MenuVehiculoVisible();
                MenuVidaNotVisible();
                MenuViviendaNotvisible();

                // if para que el programa no se caiga
            }
            else if (v_valorcombo == 30)
            {
                MenuViviendaVisible();
                MenuVidaNotVisible();
                MenuVehiculoNotVisible();


            }

        }

        private void cboPlanAsociado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            // se declaran las variables y se inicia el valor del combo  
            string valor_combo = Convert.ToString(cboPlanAsociado.SelectedValue);
            int valor_casa;
            int valor_contenido;
            int anio_vivienda;
            int idregion;
            int annio;
            Tarificador tar = new Tarificador();
            Plan plan = new Plan();
            if (valor_combo == "VID01" || valor_combo == "VID02" || valor_combo == "VID03")
            {

                tar.ValorPrimaPlanVida1(valor_combo);
                txtPrimaAnual.Text = Convert.ToString(tar.PrimaAnual);
                txtPrimaMensual.Text = Convert.ToString(tar.PrimaMensual);
                txtPoliza.Text = tar.poliza;
            }
            else if (valor_combo == "HOG01" || valor_combo == "HOG02" || valor_combo == "HOG03")
            {

                // if para que el programa no se caiga
                Vivienda vivienda = new Vivienda();
                if (vivienda.Read())
                {

                }
                if (txtValorContenido.Text == string.Empty || txtValorVivienda.Text == string.Empty || txtAnioVivienda.Text == string.Empty)
                {
                    valor_casa = 0;
                    valor_contenido = 0;
                    idregion = 0;
                    anio_vivienda = 0;
                    tar.ValorPrimaHogar(valor_combo, anio_vivienda, idregion, valor_casa, valor_contenido);
                    txtPrimaAnual.Text = Convert.ToString(tar.PrimaAnual);
                    txtPrimaMensual.Text = Convert.ToString(tar.PrimaMensual);
                    txtPoliza.Text = tar.poliza;

                }
                else
                {
                    valor_casa = Convert.ToInt32(txtValorVivienda.Text);
                    valor_contenido = Convert.ToInt32(txtValorContenido.Text);
                    anio_vivienda = Convert.ToInt32(txtAnioVivienda.Text);
                    idregion = Convert.ToInt32(cboRegion.SelectedValue.ToString());
                    tar.ValorPrimaHogar(valor_combo, anio_vivienda, idregion, valor_casa, valor_contenido);
                    txtPrimaAnual.Text = Convert.ToString(tar.PrimaAnual);
                    txtPrimaMensual.Text = Convert.ToString(tar.PrimaMensual);
                    txtPoliza.Text = tar.poliza;
                }
            }
            else if (valor_combo == "VEH01" || valor_combo == "VEH02" || valor_combo == "VEH03")
            {

                if (txtAnioAuto.Text == string.Empty)
                {
                    annio = 0;
                    tar.PrimaVehiculo(valor_combo, annio);
                    txtPrimaAnual.Text = Convert.ToString(tar.PrimaAnual);
                    txtPrimaMensual.Text = Convert.ToString(tar.PrimaMensual);
                    txtPoliza.Text = tar.poliza;
                }
                else
                {
                    annio = Convert.ToInt32(txtAnioAuto.Text);
                    tar.PrimaVehiculo(valor_combo, annio);
                    txtPrimaAnual.Text = Convert.ToString(tar.PrimaAnual);
                    txtPrimaMensual.Text = Convert.ToString(tar.PrimaMensual);
                    txtPoliza.Text = tar.poliza;
                }
            }

        }

      

 
     
   

        private void btnCargarControles_Click(object sender, RoutedEventArgs e)
        {
            CargarControles();
        }

        private void cboCodigoContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgDatosContratos.ItemsSource = null;
            Contrato objContratoABuscar = new Contrato();
            string v_valorCombo = cboCodigoContrato.SelectedValue.ToString();
            dgDatosContratos.ItemsSource = objContratoABuscar.ReadAllByContrato(v_valorCombo);
            cboPolizas.SelectedValue = 0;
            cboRut.SelectedValue = 0;
        }

        private void cboPolizas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            dgDatosContratos.ItemsSource = null;
            Contrato objPolizaABuscar = new Contrato();
            string v_valorCombo = cboPolizas.SelectedValue.ToString();
            dgDatosContratos.ItemsSource = objPolizaABuscar.ReadAllByPoliza(v_valorCombo);
            cboCodigoContrato.SelectedValue = 0;
            cboRut.SelectedValue = 0;
        }

        private void cboRut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            dgDatosContratos.ItemsSource = null;
            Contrato objClientesABuscar = new Contrato();
            string v_valorCombo = cboRut.SelectedValue.ToString();
            dgDatosContratos.ItemsSource = objClientesABuscar.ReadAllByRutC(v_valorCombo);
            cboCodigoContrato.SelectedValue = 0;
            cboPolizas.SelectedValue = 0;
        }

        private void txtIngresePatente_DragEnter(object sender, DragEventArgs e)
        {
            if (txtIngresePatente.Text == "AAAA99, AAA999 o AA9999")
            {
                txtIngresePatente.Text = "";
                

                    }
        }

        private void txtIngresePatente_DragLeave(object sender, DragEventArgs e)
        {

            if (txtIngresePatente.Text == "")
            {
                txtIngresePatente.Text = "AAAA99, AAA999 o AA9999";


            }

        }
    }
    }

