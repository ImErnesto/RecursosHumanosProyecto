using GestionHospital.BD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionHospital.Formularios.Empleados
{
    public partial class FrmNomina : Form
    {
        private long idEmpleado;
        public FrmNomina(long idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
        }



        private void FrmNomina_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
             (panel2.Width - label1.Width) / 2,
             (panel2.Height - label1.Height) / 2
         );
            CargarNominaEmpleado(idEmpleado);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (panel1.Contains(dataGridView1))
            {

                int nuevaX = (int)((panel1.Width - dataGridView1.Width) / 2.5);
                int nuevaY = (int)((panel1.Height - dataGridView1.Height) / 1.6);

                dataGridView1.Location = new Point(nuevaX, nuevaY);

            }
        }

        private void CargarNominaEmpleado(long idEmpleado)
        {
            try
            {
                using (var dbContext = new prueba8Context())
                {
                    // Recuperar las nóminas del empleado según su ID
                    var nominaEmpleado = dbContext.Nominaxempleado
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

                    // Asignar los resultados al DataGridView
                    dataGridView1.DataSource = nominaEmpleado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la nómina: {ex.Message}");
            }
        }


        private void Btncargarfechas_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btncargarfechas, radioEsquinas);
        }

        private void Btnreporte_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnboleta, radioEsquinas);
        }

        private void redondearEsquinas(Button boton, int radioEsquinas)
        {
            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            ruta.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
            ruta.AddArc(boton.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
            ruta.AddArc(boton.Width - radioEsquinas, boton.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
            ruta.AddArc(0, boton.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
            ruta.CloseFigure();

            boton.Region = new Region(ruta);
        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Resize(object sender, EventArgs e)
        {

            label1.Location = new Point(
          (panel2.Width - label1.Width) / 2,
          (panel2.Height - label1.Height) / 2
      );
        }

        private void Btncargarfechas_Click(object sender, EventArgs e)
        {
            DateTime fechaInicioSeleccionada = dateTimePicker1.Value.Date;
            DateTime fechaFinSeleccionada = dateTimePicker2.Value.Date;

            if (fechaInicioSeleccionada > fechaFinSeleccionada)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.");
                return;
            }

            try
            {
                using (var dbContext = new prueba8Context())
                {
                    var nominaFiltrada = dbContext.Nominaxempleado
                        .Where(ne =>
                            ne.IdEmpleado == idEmpleado &&
                            ne.IdNominaNavigation.IdPeriodopagoNavigation.PerInicio >= fechaInicioSeleccionada &&
                            ne.IdNominaNavigation.IdPeriodopagoNavigation.PerFin <= fechaFinSeleccionada)
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

                    dataGridView1.DataSource = nominaFiltrada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar las nóminas: {ex.Message}");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CargarNominaEmpleado(idEmpleado);
        }
    }
}
