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
    public partial class FrmTurnos : Form
    {
        private long idEmpleado;
        public FrmTurnos(long idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTurnos_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
              (panel2.Width - label1.Width) / 2,
              (panel2.Height - label1.Height) / 2
          );
            CargarTurnosEmpleado(idEmpleado);
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

        private void CargarTurnosFiltrados(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var dbContext = new prueba8Context())  // Usa tu contexto
            {
                var turnos = dbContext.Asistencia
                    .Where(a => a.IdEmpleado == idEmpleado && a.IdTurnoNavigation.TurFecha >= fechaInicio && a.IdTurnoNavigation.TurFecha <= fechaFin)
                    .Select(a => new
                    {
                        IdTurno = a.IdTurnoNavigation.IdTurno,
                        TipoTurno = a.IdTurnoNavigation.IdTipoturnoNavigation.TipNombre,
                        FechaTurno = a.IdTurnoNavigation.TurFecha,
                        HoraDeInicio = a.IdTurnoNavigation.TurInicio,
                        HoraDeFin = a.IdTurnoNavigation.TurFin
                    })
                    .ToList();

                // Asignar los turnos filtrados al DataGridView
                dataGridView1.DataSource = turnos;
            }
        }
        private void panel2_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(
             (panel2.Width - label1.Width) / 2,
             (panel2.Height - label1.Height) / 2
         );
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarTurnosEmpleado(long idEmpleado)
        {
            using (var dbContext = new prueba8Context())  // Usa tu contexto
            {
                var turnos = dbContext.Asistencia
                    .Where(a => a.IdEmpleado == idEmpleado)
                    .Select(a => new
                    {
                        IdTurno = a.IdTurnoNavigation.IdTurno,
                        TipoTurno = a.IdTurnoNavigation.IdTipoturnoNavigation.TipNombre,
                        FechaTurno=a.IdTurnoNavigation.TurFecha,
                        HoraDeInicio=a.IdTurnoNavigation.TurInicio,
                        HoraDeFin=a.IdTurnoNavigation.TurFin
                    })
                    .ToList();

                // Asignar los turnos al DataGridView
                dataGridView1.DataSource = turnos;
            }
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

            // Llamar al método para cargar los turnos filtrados
            CargarTurnosFiltrados(fechaInicio, fechaFin);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CargarTurnosEmpleado(idEmpleado);
        }

        private void iconButton1_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;


            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            ruta.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
            ruta.AddArc(iconButton1.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
            ruta.AddArc(iconButton1.Width - radioEsquinas, iconButton1.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
            ruta.AddArc(0, iconButton1.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
            ruta.CloseFigure();


            iconButton1.Region = new Region(ruta);
        }
    }
}
