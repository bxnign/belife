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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // para realizar el memento
        Contrato contrato = new Contrato();
        Caretaker caretaker = new Caretaker();
        public String valorcbo;
        public MainWindow()
        {
            InitializeComponent();
            CargarComboAgregarCliente();
            MenuInvicible();
            CargarComboContrato();

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
            lblIngresePatente.Opacity =100;
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

        private void LimpiarAgregarCliente()
        {
            txtRut.Text = string.Empty;
            txtPrimerNombre.Text = string.Empty;
            txtPrimerApellido.Text = string.Empty;
            dtpFechaNacimiento.Text = string.Empty;
            optFemenino.IsChecked = false;
            optMasculino.IsChecked = false;
            cboEstadoCivil.SelectedValue = 0;
            
        }

        private void CargarComboAgregarCliente()
        {
            EstadoCivil estcivil = new EstadoCivil();
            cboEstadoCivil.ItemsSource = estcivil.ReadAll();
            cboEstadoCivil.DisplayMemberPath = "Descripcion";
            cboEstadoCivil.SelectedValuePath = "IdEstadoCivil";
        }

        private void CargarComboContrato()
        {
            //se carga el combo marca auto
            MarcaVehiculo marcavehiculo = new MarcaVehiculo();
            cboMarca.ItemsSource = marcavehiculo.ReadAll();
            cboMarca.DisplayMemberPath = "Descripcion";
            cboMarca.SelectedValuePath = "IdMarca";

            // se carga el combo de modelos
            ModeloVehiculo mod = new ModeloVehiculo();
            cboModelo.ItemsSource = mod.ReadAll();
            cboModelo.DisplayMemberPath = "Descripcion";
            cboModelo.SelectedValuePath = "IdModelo";

            //se carga el combo de las regiones
            Region region = new Region();
            cboRegion.ItemsSource = region.ReadAll();
            cboRegion.DisplayMemberPath = "NombreRegion";
            cboRegion.SelectedValuePath = "IdRegion";

            //Se carga el combo de las comunas
            Comuna comuna = new Comuna();

            cboComuna.ItemsSource = comuna.ReadAll();
            cboComuna.DisplayMemberPath = "NombreComuna";
            cboComuna.SelectedValuePath = "IdComuna";

            


            //se carga el combo de tipos de contrato
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

        public int CalcularEdad()
        {
            int anioActual = DateTime.Now.Year;
            DateTime nacimiento = dtpFechaNacimiento.SelectedDate.Value;
            int anioNacimiento = nacimiento.Year;
            int edad = anioActual - anioNacimiento;

            return edad;
        }


        public void PoblarCliente(ref Cliente cliente)
        {
            if (txtPrimerNombre.Text == string.Empty || txtPrimerApellido.Text == string.Empty || dtpFechaNacimiento.SelectedDate == DateTime.Today)
            {
                this.ShowMessageAsync("Atención", "Todos los campos son obligatorios");
            }
            else
            {
                if (CalcularEdad() < 18)
                {
                    this.ShowMessageAsync("El Cliente debe Ser Mayor de Edad", "Atencíón");
                }
                else
                {
                    cliente.RutCliente = txtRut.Text;
                    cliente.Nombres = txtPrimerNombre.Text;
                    cliente.Apellidos = txtPrimerApellido.Text;
                    cliente.FechaNacimiento = (DateTime)dtpFechaNacimiento.SelectedDate;
                    if (optMasculino.IsChecked == true)
                    {
                        cliente.IdSexo = 1;
                    }
                    else
                    {
                        cliente.IdSexo = 2;
                    }
                    cliente.IdEstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue.ToString());
                }
            }
        }
        private void btnLuna_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(App.Current,
            ThemeManager.GetAccent("Violet"),
            ThemeManager.GetAppTheme("BaseDark"));
        }

        private void btnSol_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(App.Current,
              ThemeManager.GetAccent("Violet"),
              ThemeManager.GetAppTheme("BaseLight"));
        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            FlyoutAgregarCliente.IsOpen = true;
        }

        private void btnAgregarAlCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            try
            {
                PoblarCliente(ref cliente);
                if (!cliente.Read())
                {
                    if (cliente.Create())
                    {
                        this.ShowMessageAsync("Cliente Agregado", "Informacion");
                        LimpiarAgregarCliente();
                    }
                    else
                    {
                        this.ShowMessageAsync("No se pudo Agregar Cliente", "Error");
                    }
                }
                else
                {
                    this.ShowMessageAsync("Cliente ya existe", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Error");
            }
        }

        private void btnLimpiarAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            LimpiarAgregarCliente();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            VentanaCliente vercliente = new VentanaCliente();
            vercliente.Owner = this;
            vercliente.ShowDialog();
        }

        private void btnAgregarContrato_Click(object sender, RoutedEventArgs e)
        {
            flyAgregarContrato.IsOpen = true;
            LimpiarControlesContrato();
            
        }

        private void cboTipoContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipoContrato tipo = new TipoContrato();
            int v_valorcombo = Convert.ToInt32(cboTipoContrato.SelectedValue.ToString());
            if(v_valorcombo == 10)
            {
                MenuVida();
                MenuViviendaNotvisible();
                MenuVehiculoNotVisible();
                chkDeclaracionSalud.IsChecked = true;
                chkDeclaracionSalud.IsEnabled = false;
              


            }
            else if(v_valorcombo == 20)
            {
                MenuVehiculoVisible();
                MenuVidaNotVisible();
                MenuViviendaNotvisible();
               
                // if para que el programa no se caiga
            }
            else if(v_valorcombo == 30)
            {
                MenuViviendaVisible();
                MenuVidaNotVisible();
                MenuVehiculoNotVisible();
                

            }
         
        }

        //regla de negocio
     
                 
            
        

        private void btnCrearContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato();
            Vehiculo vehiculo = new Vehiculo();
            Vivienda vivienda = new Vivienda();
            int valor_combo = Convert.ToInt32(cboTipoContrato.SelectedValue.ToString());
            try
            {
                if (valor_combo == 10)
                { 

                if (!contrato.Read())
                {
                    PoblarControlesContratoVida(ref contrato);
                    if (contrato.Create())
                    {
                            
                            this.ShowMessageAsync("Contrato agregado", "Información");
                            LimpiarControlesContrato();
                            flyAgregarContrato.IsOpen = false;
                        }   
                    else
                    {
                        this.ShowMessageAsync("Contrato No se agrego", "Información");
                    }
                }
                else
                {
                    this.ShowMessageAsync("El Contrato ya Existe", " Advertencia");
                }
                }
                else if (valor_combo == 20)
                {
                    if (!contrato.Read() && !vehiculo.Read())
                    {
                        PoblarControlesContratoVida(ref contrato);
                        PoblarControlesVehiculo(ref vehiculo);
                        if (contrato.Create() && vehiculo.Create())
                        {
                            
                            this.ShowMessageAsync("Contrato agregado", "Información");
                            LimpiarControlesContrato();
                            flyAgregarContrato.IsOpen = false;
                        }   
                        else

                        {
                            this.ShowMessageAsync("Contrato No se agrego", "Información");
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync("El Contrato ya Existe", " Advertencia");
                    }
                }
                else if (valor_combo == 30)
                {
                    if (!contrato.Read() && !vivienda.Read())
                    {
                        PoblarControlesContratoVida(ref contrato);
                        PoblarControlesVivienda(ref vivienda);
                        if (contrato.Create() && vivienda.Create())
                        {
                            this.ShowMessageAsync("Contrato agregado", "Información");
                            LimpiarControlesContrato();
                            flyAgregarContrato.IsOpen = false;
                            
                        }
                        else
                        {
                            this.ShowMessageAsync("Contrato No se agrego", "Información");
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync("El Contrato ya Existe", " Advertencia");
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error en base de datos", ex.Message);
            }
   }

        private void cboPlanAsociado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            // se declaran las variables y se inicia el valor del combo  
            string valor_combo = cboPlanAsociado.SelectedValue.ToString();
            int valor_casa;
            int valor_contenido;
            int anio_vivienda; 
            int idregion;
            int annio;
                

            // se diferencia de id y se llama al tipo de metodo que corresponde
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


        private void PoblarControlesContratoVida( ref Contrato contrato)
        {

            contrato.Numero = txtNumero.Text;
            contrato.FechaCreacion = (DateTime)dtInicioContrato.SelectedDate;
            contrato.FechaTermino = (DateTime)dtFinContrato.SelectedDate;
            contrato.RutCliente = txtBuscRutCliente.Text;
            contrato.FechaInicioVigencia = (DateTime)dtInicioVigencia.SelectedDate;
            contrato.FechaFinVigencia = (DateTime)dtFinVigencia.SelectedDate;
            contrato.DeclaracionSalud = (bool)chkDeclaracionSalud.IsChecked;
            contrato.Vigente = (bool)chkVigente.IsChecked;
            contrato.PrimaAnual = Convert.ToDouble(txtPrimaAnual.Text);
            contrato.PrimaMensual = Convert.ToDouble(txtPrimaMensual.Text);
            contrato.Observaciones = txtObservaciones.Text;
            contrato.CodigoPlan = cboPlanAsociado.SelectedValue.ToString(); 
            contrato.IdTipoContrato = Convert.ToInt32(cboTipoContrato.SelectedValue.ToString());
            

        }

      

        private void PoblarControlesVehiculo(ref Vehiculo vehiculo)
        {
            vehiculo.Patente = txtIngresePatente.Text;
            vehiculo.IdMarca = Convert.ToInt32(cboMarca.SelectedValue.ToString());
            vehiculo.IdModelo = Convert.ToInt32(cboModelo.SelectedValue.ToString());
            vehiculo.Anho = Convert.ToInt32(txtAnioAuto.Text);
        }

        private void PoblarControlesVivienda(ref Vivienda vivienda)
        {
            vivienda.CodigoPostal = Convert.ToInt32(txtCodigoPostal.Text);
            vivienda.Anho = Convert.ToInt32(txtCodigoPostal.Text);
            vivienda.Direccion = txtDireccion.Text;
            vivienda.ValorInmueble = Convert.ToInt32(txtValorVivienda.Text);
            vivienda.ValorContenido = Convert.ToInt32(txtValorContenido.Text);
            vivienda.IdRegion = Convert.ToInt32(cboRegion.SelectedValue.ToString());
            vivienda.IdComuna = Convert.ToInt32(cboComuna.SelectedValue.ToString());
        }

        public Cliente datosCliente = new Cliente();
        private void btnConBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            
            try
            {
                cliente.RutCliente = txtBuscRutCliente.Text;
                if (cliente.Read())
                {
                    datosCliente = cliente;
                    txtConNombreCliente.Text = cliente.Nombres + " " + cliente.Apellidos;
                    
                    dtInicioContrato.SelectedDate = (DateTime.Now);
                    dtInicioVigencia.SelectedDate = (DateTime.Now);
                    DateTime codigo = (DateTime.Now);
                    DateTime fecha = (DateTime.Today);
                    fecha = fecha.AddYears(1);
                    dtFinContrato.SelectedDate = fecha;
                    dtFinVigencia.SelectedDate = fecha;
                    string formato = "yyyyMMddHHmmss";
                    txtNumero.Text = codigo.ToString(formato);
                    dtInicioContrato.IsEnabled = false;
                    dtInicioVigencia.IsEnabled = false;
                    txtBuscRutCliente.IsEnabled = false;
                    txtConNombreCliente.IsEnabled = false;
                    chkVigente.IsChecked = true;
                    chkVigente.IsEnabled = false;
                    txtNumero.IsEnabled = false;
                }
                else
                {
                    this.ShowMessageAsync("Cliente no encontrado","Advertencia");
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync("Error", ex.Message);
            }
        }

        private void LimpiarControlesContrato()
        {
            dtInicioContrato.Text = string.Empty;
            dtFinContrato.Text = string.Empty;
            dtInicioVigencia.Text = string.Empty;
            dtFinVigencia.Text = string.Empty;
            txtBuscRutCliente.Text = string.Empty;
            txtConNombreCliente.Text = string.Empty;
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
            txtBuscRutCliente.IsEnabled = true;
            txtConNombreCliente.IsEnabled = true;
            chkVigente.IsChecked = false;
            chkVigente.IsEnabled = true;
            txtNumero.IsEnabled = true; 

        }

        private void txtNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
          

            }

        private void btnContrato_Click(object sender, RoutedEventArgs e)
        {
            VentanaContrato ventana = new VentanaContrato();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void btnRespaldar_Click(object sender, RoutedEventArgs e)
        {
            
            PoblarControlesContratoVida(ref contrato);
            caretaker.Memento = contrato.CreateMemento();
            
            this.ShowMessageAsync("Informacion Respaldada", "Información");

        }

        private void btnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            contrato.setMemento(caretaker.Memento);

            txtBuscRutCliente.Text = contrato.RutCliente;
            txtNumero.Text = contrato.Numero;
            dtInicioContrato.SelectedDate = contrato.FechaCreacion;
            dtFinContrato.SelectedDate = contrato.FechaTermino;
            dtInicioVigencia.SelectedDate = contrato.FechaInicioVigencia;
            dtFinVigencia.SelectedDate = contrato.FechaFinVigencia;
            chkDeclaracionSalud.IsChecked = contrato.DeclaracionSalud;
            chkVigente.IsChecked = contrato.Vigente;
            txtPrimaAnual.Text = Convert.ToString(contrato.PrimaAnual);
            txtPrimaMensual.Text = Convert.ToString(contrato.PrimaMensual);
           // cboPlanAsociado.SelectedValue = contrato.CodigoPlan;
           // cboTipoContrato.SelectedValue = contrato.IdTipoContrato;
            txtObservaciones.Text = contrato.Observaciones;
           
            
            

        }

        private void btnLimpiarContrato_Click(object sender, RoutedEventArgs e)
        {
            LimpiarControlesContrato();
            
        }

 
        }
    }
    

