using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionHospital.BD;
using GestionHospital.Formularios.Empleados;

namespace GestionHospital.Formularios.Empleados
{
    public partial class FrmAsistencia : Form
    {
        private long idEmpleado;
        public FrmAsistencia(long idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
        }

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
               (panel2.Width - label1.Width) / 2,
               (panel2.Height - label1.Height) / 2
           );
            CargarAsistencia();
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

        private void CargarAsistencia()
        {
            using (var dbContext = new prueba8Context())
            {
                var asistencias = dbContext.Asistencia
             .Where(a => a.IdEmpleado == idEmpleado) // Filtrar por el ID del empleado
             .Select(a => new
             {
                 a.IdAsistencia, // ID de la asistencia
                 FechaDeAprobacion = a.AsiFechaprobacion, // Fecha de la asistencia
                 FechaDeEntrada = a.AsiEntrada, // Hora de entrada
                 FechaDeSalida = a.AsiSalida,  // Hora de salida

                 Turno = a.IdTurnoNavigation.IdTipoturnoNavigation.TipNombre,
                 NombreEmpleado = a.IdEmpleadoNavigation.EmpNombres, // Nombre del empleado
                 ApellidosEmpleado = a.IdEmpleadoNavigation.EmpApellidos // Apellidos del empleado
             })
             .ToList();

                dataGridView1.DataSource = asistencias;
            }
        }


        //Para filtrar por fechas
        private void CargarAsistenciasConFiltro(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var dbContext = new prueba8Context()) // Usa tu contexto
            {
                var asistenciasFiltradas = dbContext.Asistencia
                    .Where(a => a.IdEmpleado == idEmpleado && a.AsiFechaprobacion >= fechaInicio && a.AsiFechaprobacion <= fechaFin)
                    .Select(a => new
                    {
                        a.IdAsistencia, // ID de la asistencia
                        FechaDeAprobacion = a.AsiFechaprobacion, // Fecha de la asistencia
                        FechaDeEntrada = a.AsiEntrada, // Hora de entrada
                        FechaDeSalida = a.AsiSalida,  // Hora de salida

                        Turno = a.IdTurnoNavigation.IdTipoturnoNavigation.TipNombre,
                        NombreEmpleado = a.IdEmpleadoNavigation.EmpNombres, // Nombre del empleado
                        ApellidosEmpleado = a.IdEmpleadoNavigation.EmpApellidos // Apellidos del empleado
                    })
                    .ToList();

                // Asignar los datos filtrados al DataGridView
                dataGridView1.DataSource = asistenciasFiltradas;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Resize_1(object sender, EventArgs e)
        {
            label1.Location = new Point(
             (panel2.Width - label1.Width) / 2,
             (panel2.Height - label1.Height) / 2
         );
        }

        private void Btncargarfechas_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;


            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            ruta.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
            ruta.AddArc(Btncargarfechas.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
            ruta.AddArc(Btncargarfechas.Width - radioEsquinas, Btncargarfechas.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
            ruta.AddArc(0, Btncargarfechas.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
            ruta.CloseFigure();


            Btncargarfechas.Region = new Region(ruta);
        }

        private void Btncargarfechas_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;

            // Asegurarse de que la fecha de fin no sea menor que la fecha de inicio
            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.");
                return;
            }

            // Llamar al método para cargar las asistencias con filtro
            CargarAsistenciasConFiltro(fechaInicio, fechaFin);
            
        }
    }
}
