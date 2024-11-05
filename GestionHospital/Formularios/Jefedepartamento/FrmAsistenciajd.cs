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

namespace GestionHospital.Formularios.Jefedepartamento
{
    public partial class FrmAsistenciajd : Form
    {
        private long idDepartamento;
        public FrmAsistenciajd(long idDepartamento)
        {
            InitializeComponent();
            this.idDepartamento = idDepartamento;
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

        private void Btncargarfechas_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btncargarfechas, radioEsquinas);
        }

        private void Btnbuscar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnbuscar, radioEsquinas);
        }

        private void FrmAsistenciajd_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
               (panel2.Width - label1.Width) / 2,
               (panel2.Height - label1.Height) / 2
           );
            CargarAsistenciaDepartamento(idDepartamento);
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
        private void CargarAsistenciaDepartamento(long idDepartamento)
        {
            using (var dbContext = new prueba8Context())  // Usa tu contexto
            {
                var asistencias = dbContext.Asistencia
                    .Where(a => a.IdEmpleadoNavigation.IdDepartamento == idDepartamento)
                    .Select(a => new
                    {
                        a.IdAsistencia,
                        a.IdEmpleado,
                        Nombres = a.IdEmpleadoNavigation.EmpNombres,
                        Apellidos = a.IdEmpleadoNavigation.EmpApellidos,
                        Dui = a.IdEmpleadoNavigation.EmpDui,
                        Turno = a.IdTurnoNavigation.IdTipoturnoNavigation.TipNombre,
                        FechaDeEntrada = a.AsiEntrada,
                        FechaDeSalida = a.AsiSalida,
                        FechaDeAprobacion = a.AsiFechaprobacion
                    })
                    .ToList();

                dataGridView1.DataSource = asistencias;
            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(
            (panel2.Width - label1.Width) / 2,
            (panel2.Height - label1.Height) / 2
        );
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

            CargarAsistenciaDepartamentoConFiltro(fechaInicio, fechaFin);
        }


        private void CargarAsistenciaDepartamentoConFiltro(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var dbContext = new prueba8Context())
            {
                var asistencias = dbContext.Asistencia
                    .Where(a => a.IdEmpleadoNavigation.IdDepartamento == idDepartamento &&
                                a.AsiFechaprobacion >= fechaInicio.Date &&
                                a.AsiFechaprobacion <= fechaFin.Date)
                    .Select(a => new
                    {
                        a.IdAsistencia,
                        a.IdEmpleado,
                        Nombres = a.IdEmpleadoNavigation.EmpNombres,
                        Apellidos = a.IdEmpleadoNavigation.EmpApellidos,
                        Dui = a.IdEmpleadoNavigation.EmpDui,
                        Turno = a.IdTurnoNavigation.IdTipoturnoNavigation.TipNombre,
                        FechaDeEntrada = a.AsiEntrada,
                        FechaDeSalida = a.AsiSalida,
                        FechaDeAprobacion = a.AsiFechaprobacion
                    })
                    .ToList();

                dataGridView1.DataSource = asistencias;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CargarAsistenciaDepartamento(idDepartamento);
        }
        private void FiltrarAsistencia(string filtro)
        {
            using (var dbContext = new prueba8Context())  // Usa tu contexto
            {
                var asistencias = dbContext.Asistencia
                    .Where(a => a.IdEmpleadoNavigation.IdDepartamento == idDepartamento &&
                                (a.IdEmpleado.ToString().Contains(filtro) ||
                                 a.IdEmpleadoNavigation.EmpNombres.Contains(filtro) ||
                                 a.IdEmpleadoNavigation.EmpApellidos.Contains(filtro) ||
                                 a.IdEmpleadoNavigation.EmpDui.Contains(filtro)))
                    .Select(a => new
                    {
                        a.IdAsistencia,
                        a.IdEmpleado,
                        Nombres = a.IdEmpleadoNavigation.EmpNombres,
                        Apellidos = a.IdEmpleadoNavigation.EmpApellidos,
                        Dui = a.IdEmpleadoNavigation.EmpDui,
                        Turno = a.IdTurnoNavigation.IdTipoturnoNavigation.TipNombre,
                        FechaDeEntrada = a.AsiEntrada,
                        FechaDeSalida = a.AsiSalida,
                        FechaDeAprobacion = a.AsiFechaprobacion
                    })
                    .ToList();

                dataGridView1.DataSource = asistencias;
            }
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            string filtro = Txtempleado.Text.Trim();  // Obtén el texto del TextBox
            FiltrarAsistencia(filtro);  // Llama al método de filtrado con el texto de búsqueda
        }

        private void iconButton1_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(iconButton1, radioEsquinas);
        }
    }
}
