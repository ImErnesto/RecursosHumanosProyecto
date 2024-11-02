using GestionHospital.BD;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionHospital.Reportes
{
    public partial class FormPersonal : Form
    {
        public FormPersonal(long idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
        }

        private long idEmpleado;
        private void FormPersonal_Load(object sender, EventArgs e)
        {

            CargarReporte();
            //this.reportViewer1.RefreshReport();
        }

        public void MostrarReporte()
        {
            CargarReporte();
            this.Show();
        }

        private void CargarReporte()
        {
            try
            {
                using (var dbContext = new prueba8Context())
                {
                    // Filtrar las nóminas que coinciden con el idEmpleado
                    var empleado = dbContext.Empleado
                        .FirstOrDefault(e => e.IdEmpleado == idEmpleado); // Asegúrate de que tienes la entidad correcta

                    if (empleado == null)
                    {
                        MessageBox.Show("Empleado no encontrado.");
                        return;
                    }

                    string nombreEmpleado = empleado.EmpNombres; // Cambia esto por el nombre de tu propiedad
                    string apellidoEmpleado = empleado.EmpApellidos; // Cambia esto por el nombre de tu propiedad

                    // Filtrar las nóminas
                    var nominaDetalles = dbContext.Nominaxempleado
                        .Where(ne => ne.IdEmpleado == idEmpleado)
                        .Select(ne => new
                        {
                            ne.IdNomina,
                            PeriodoNombre = ne.IdNominaNavigation.IdPeriodopagoNavigation.PerNombre,
                            PeriodoInicio = ne.IdNominaNavigation.IdPeriodopagoNavigation.PerInicio,
                            PeriodoFin = ne.IdNominaNavigation.IdPeriodopagoNavigation.PerFin,
                            Bonificaciones = ne.NomBonificaciones,
                            Deducciones = ne.NomDeducciones,
                            DeduccionSalarial = ne.NomDeduccionSalarial,
                            SalarioNeto = Convert.ToDecimal(ne.IdEmpleadoNavigation.EmpSalarioBruto - (ne.NomBonificaciones + ne.NomDeducciones + ne.NomDeduccionSalarial))
                        })
                        .ToList();

                    var ds = new DataSet();
                    var dtNomina = ds.Tables.Add("Nomina");
                    dtNomina.Columns.Add("IdNomina", typeof(long));
                    dtNomina.Columns.Add("PeriodoNombre", typeof(string));
                    dtNomina.Columns.Add("PeriodoInicio", typeof(DateTime));
                    dtNomina.Columns.Add("PeriodoFin", typeof(DateTime));
                    dtNomina.Columns.Add("Bonificaciones", typeof(decimal));
                    dtNomina.Columns.Add("Deducciones", typeof(decimal));
                    dtNomina.Columns.Add("DeduccionSalarial", typeof(decimal));
                    dtNomina.Columns.Add("SalarioNeto", typeof(decimal));

                    foreach (var nomina in nominaDetalles)
                    {
                        dtNomina.Rows.Add(nomina.IdNomina, nomina.PeriodoNombre, nomina.PeriodoInicio, nomina.PeriodoFin, nomina.Bonificaciones, nomina.Deducciones, nomina.DeduccionSalarial, nomina.SalarioNeto);
                    }

                    // Limpia las fuentes de datos del ReportViewer
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ds.Tables["Nomina"]));

                    // Agregar los parámetros al reporte
                    ReportParameter[] parameters = new ReportParameter[3];
                    parameters[0] = new ReportParameter("IdEmpleado", idEmpleado.ToString());
                    parameters[1] = new ReportParameter("NombreEmpleado", nombreEmpleado);
                    parameters[2] = new ReportParameter("ApellidoEmpleado", apellidoEmpleado);

                    reportViewer1.LocalReport.SetParameters(parameters);

                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}");
            }
        }

    }
}
