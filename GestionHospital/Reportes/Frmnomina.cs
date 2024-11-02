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
    public partial class Frmnomina : Form
    {

        private long _idNomina;

        public Frmnomina(long idNomina)
        {
            InitializeComponent();
            _idNomina = idNomina;
        }

        private void Frmnomina_Load(object sender, EventArgs e)
        {
            CargarReporte(_idNomina);

            //this.reportViewer1.RefreshReport();
        }

        public void MostrarReporte(long idNomina)
        {
            CargarReporte(idNomina);
            this.Show();
        }

        private void CargarReporte(long idNomina)
        {
            try
            {
                using (var dbContext = new prueba8Context())
                {
                    // Recuperar los datos del empleado para la nómina especificada
                    var empleados = dbContext.Nominaxempleado
                        .Where(ne => ne.IdNomina == idNomina)
                        .Select(ne => new
                        {
                            ne.IdEmpleado,
                            Nombre = ne.IdEmpleadoNavigation.EmpNombres,
                            Apellidos = ne.IdEmpleadoNavigation.EmpApellidos,
                            Dui = ne.IdEmpleadoNavigation.EmpDui,
                            Bonificaciones = ne.NomBonificaciones,
                            Deducciones = ne.NomDeducciones,
                            SalarioNeto = ne.IdEmpleadoNavigation.EmpSalarioBruto - ne.NomDeduccionSalarial
                        })
                        .ToList();

                    // Crear un DataSet y DataTable para el ReportViewer
                    var ds = new DataSet();
                    var dtEmpleados = ds.Tables.Add("Empleado");
                    dtEmpleados.Columns.Add("IdEmpleado", typeof(long)); // Cambiado a long
                    dtEmpleados.Columns.Add("Nombre", typeof(string));
                    dtEmpleados.Columns.Add("Apellidos", typeof(string));
                    dtEmpleados.Columns.Add("Dui", typeof(string));
                    dtEmpleados.Columns.Add("Bonificaciones", typeof(decimal));
                    dtEmpleados.Columns.Add("Deducciones", typeof(decimal));
                    dtEmpleados.Columns.Add("SalarioNeto", typeof(decimal));

                    // Llenar el DataTable con los datos obtenidos
                    foreach (var empleado in empleados)
                    {
                        dtEmpleados.Rows.Add(empleado.IdEmpleado, empleado.Nombre, empleado.Apellidos, empleado.Dui, empleado.Bonificaciones, empleado.Deducciones, empleado.SalarioNeto);
                    }

                    // Configurar el ReportViewer
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables["Empleado"]));
                    reportViewer1.RefreshReport(); // Refresca el ReportViewer después de agregar los datos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}");
            }
        }
    }
}
