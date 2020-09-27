using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLifeSeguros.Negocio
{
    public class Tarificador
    {
        
        public double PrimaAnual = 0;
        public string poliza;
        public double PrimaMensual = 0;
        public void ValorPrimaPlanVida1(string valor_combo)
        {
            Plan objPlan = new Plan();
            Cliente cliente = new Cliente();
            objPlan.IdPlan = valor_combo;
            if (objPlan.Read())
            {
                poliza = objPlan.PolizaActual;
            }

            double valorUf = 26983.06;


            
            if (objPlan.Read())
            {
                poliza = objPlan.PolizaActual;
                PrimaAnual = Math.Round(objPlan.PrimaBase * valorUf);
                if (DateTime.Today.Year - cliente.FechaNacimiento.Year <= 25)
                {
                    PrimaAnual= (PrimaAnual) + (Math.Round(valorUf * 3.6));
                }
                else if (DateTime.Today.Year - cliente.FechaNacimiento.Year <= 45)
                {
                    PrimaAnual = PrimaAnual + (Math.Round(valorUf * 2.5));
                }
                else
                {
                    PrimaAnual = PrimaAnual + (Math.Round(valorUf * 6));
                }
                switch (cliente.IdSexo)
                {
                    case 1:
                        PrimaAnual = PrimaAnual + (Math.Round(valorUf * 2.4));
                        break;
                    case 2:
                        PrimaAnual = PrimaAnual + (Math.Round(valorUf * 1.2));
                        break;
                }
                switch (cliente.IdEstadoCivil)
                {
                    case 1:
                        PrimaAnual= PrimaAnual + (Math.Round(valorUf * 4.8));
                        break;
                    case 2:
                        PrimaAnual =PrimaAnual + (Math.Round(valorUf * 2.4));
                        break;
                    default:
                        PrimaAnual = PrimaAnual + (Math.Round(valorUf * 3.6));
                        break;
                }

                PrimaMensual = Math.Round(PrimaAnual / 12);
            }

            
        }
        public void ValorPrimaHogar(string valor_combo,int anio_vivienda,int idregion,int valor_casa, int valor_contenido)
        {
            Plan objPlan = new Plan();
            Cliente cliente = new Cliente();
            Vivienda vivienda = new Vivienda();
            objPlan.IdPlan = valor_combo;
            vivienda.Anho = anio_vivienda;
            vivienda.IdRegion = idregion;
            vivienda.ValorInmueble = valor_casa;
            vivienda.ValorContenido = valor_contenido;
            
            if (objPlan.Read())
            {
                poliza = objPlan.PolizaActual;
            }

            double valorUf = 26983.06;



            if (objPlan.Read())
            {
                poliza = objPlan.PolizaActual;
                PrimaAnual = Math.Round(objPlan.PrimaBase * valorUf);
                PrimaAnual = PrimaAnual + Math.Round(vivienda.ValorInmueble * 0.03);
                PrimaAnual = PrimaAnual + Math.Round(vivienda.ValorContenido * 0.07);
                if (vivienda.Anho - DateTime.Today.Year < 6)
                {
                    PrimaAnual = (PrimaAnual) + (Math.Round(valorUf * 1.0));
                }
                else if (vivienda.Anho - DateTime.Today.Year >5 || vivienda.Anho - DateTime.Today.Year < 11)
                {
                    PrimaAnual = PrimaAnual + (Math.Round(valorUf * 0.8));
                }
                else if(vivienda.Anho - DateTime.Today.Year > 10 || vivienda.Anho - DateTime.Today.Year < 31)
                {
                    PrimaAnual = PrimaAnual + (Math.Round(valorUf * 0.4));
                }
                else if (vivienda.Anho - DateTime.Today.Year > 30)
                {
                    PrimaAnual = PrimaAnual + (Math.Round(valorUf * 0.2));
                }
                switch (vivienda.IdRegion)
                {
                    case 13:
                        PrimaAnual = PrimaAnual + (Math.Round(valorUf * 3.2));
                        break;
                    default:
                        PrimaAnual = PrimaAnual + (Math.Round(valorUf * 2.8));
                        break;
                }
                         PrimaMensual = Math.Round(PrimaAnual / 12);
            }
                
        }

        public void PrimaVehiculo(string valor_combo, int Anho)
        {
            Plan objPlan = new Plan();
            Cliente cliente = new Cliente();
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Anho = Anho;
            objPlan.IdPlan = valor_combo;
            if (objPlan.Read())
            {
                poliza = objPlan.PolizaActual;
            }

            double valorUf = 26983.06;



            if (objPlan.Read())
            {
                poliza = objPlan.PolizaActual;
                PrimaAnual = Math.Round(objPlan.PrimaBase * valorUf);
                if (DateTime.Today.Year - cliente.FechaNacimiento.Year <= 25)
                {
                    PrimaAnual = (PrimaAnual) + (Math.Round(valorUf * 1.2));
                }
                else if (DateTime.Today.Year - cliente.FechaNacimiento.Year <= 45)
                {
                    PrimaAnual = PrimaAnual + (Math.Round(valorUf * 2.4));
                }
                else
                {
                    PrimaAnual = PrimaAnual + (Math.Round(valorUf * 2.2));
                }
                switch (cliente.IdSexo)
                {
                    case 1:
                        PrimaAnual = PrimaAnual + (Math.Round(valorUf * 0.8));
                        break;
                    case 2:
                        PrimaAnual = PrimaAnual + (Math.Round(valorUf * 0.4));
                        break;
                }
               if(DateTime.Today.Year - vehiculo.Anho == 0)
                {
                    PrimaAnual = (PrimaAnual) + (Math.Round(valorUf * 1.2));
                }
                else if (DateTime.Today.Year - vehiculo.Anho > 0 || DateTime.Today.Year - vehiculo.Anho < 6)
                {
                    PrimaAnual = (PrimaAnual) + (Math.Round(valorUf * 0.8));
                }
                else if (DateTime.Today.Year - vehiculo.Anho > 5)
                {
                    PrimaAnual = (PrimaAnual) + (Math.Round(valorUf * 0.4));
                }

                PrimaMensual = Math.Round(PrimaAnual / 12);
            }

        }

        public void PolizaActualizar(string valor_combo)
        {
            Plan plan = new Plan();
            string poliza;
            plan.IdPlan = valor_combo;
            if (plan.Read())
            {
                poliza = plan.PolizaActual;
            }

           /* if (valor_combo == "VID01" || valor_combo == "VID02" || valor_combo == "VID03")
            {
              

            }
            else if (valor_combo == "HOG01" || valor_combo == "HOG02" || valor_combo == "HOG03")
            {


            }else
            {

            }*/
        }
    }
}


       
    

