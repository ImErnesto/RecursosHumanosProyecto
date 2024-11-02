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
    public partial class FrmAusenciasjd : Form
    {

        private long idEmpleado;
        private long idDepartamento;
        public FrmAusenciasjd(long idEmpleado,long idDepartamento)
        {
            InitializeComponent();
            this.idDepartamento = idDepartamento;
            this.idEmpleado = idEmpleado;
        }

        private void CargarAusenciasPorDepartamento(
    DateTime? fechaInicio = null,
    DateTime? fechaFin = null,
    string filtroBusqueda = null)
        {
            using (var dbContext = new prueba8Context())
            {
                try
                {
                    // Obtener el departamento del jefe
                    var departamentoJefe = dbContext.Empleado
                        .Where(e => e.IdEmpleado == idEmpleado)
                        .Select(e => e.IdDepartamento)
                        .FirstOrDefault();

                    if (departamentoJefe == 0)
                    {
                        MessageBox.Show("No se encontró el departamento del jefe.");
                        return;
                    }

                    // Query para cargar ausencias del departamento correspondiente
                    var ausenciasQuery = dbContext.RegistroAusencia
                        .Join(dbContext.Empleado,
                            a => a.IdEmpleado,
                            e => e.IdEmpleado,
                            (a, e) => new
                            {
                                a.IdRegistroausencias,
                                Estado = a.IdEstadoNavigation.EstNombre,
                                idEmpleado = e.IdEmpleado,
                                NombreEmpleado = e.EmpNombres,
                                ApellidosEmpleado = e.EmpApellidos,
                                TipoAusencia = a.IdTipoausenciaNavigation.TipoNombre,
                                FechaDeSolicitud = a.RegFechasolicitud,
                                FechaDeInicio = a.RegFechainicio,
                                FechaDeFin = a.RegFechafin,
                                Justificacion = a.RegJustificacion,
                                e.IdDepartamento
                            })
                        .Where(a => a.IdDepartamento == departamentoJefe);

                    // Filtrar por fechas si se proporcionan
                    if (fechaInicio.HasValue && fechaFin.HasValue)
                    {
                        ausenciasQuery = ausenciasQuery
                            .Where(a => a.FechaDeSolicitud >= fechaInicio.Value &&
                                        a.FechaDeSolicitud <= fechaFin.Value);
                    }

                    // Filtrar por el término de búsqueda si se proporciona
                    if (!string.IsNullOrWhiteSpace(filtroBusqueda))
                    {
                        ausenciasQuery = ausenciasQuery
                            .Where(a =>
                               
                                a.NombreEmpleado.Contains(filtroBusqueda) ||
                                a.ApellidosEmpleado.Contains(filtroBusqueda) ||
                                (a.NombreEmpleado + " " + a.ApellidosEmpleado).Contains(filtroBusqueda));
                    }

                   
                    var ausencias = ausenciasQuery
                        .OrderBy(a => a.IdRegistroausencias)
                        .ToList();

                    dataGridView1.DataSource = ausencias;

                  
                    dataGridView1.Columns["IdRegistroausencias"].HeaderText = "ID Ausencia";
                    dataGridView1.Columns["Estado"].HeaderText = "Estado";
                    dataGridView1.Columns["idEmpleado"].HeaderText = "ID Empleado";
                    dataGridView1.Columns["NombreEmpleado"].HeaderText = "Nombres";
                    dataGridView1.Columns["ApellidosEmpleado"].HeaderText = "Apellidos";
                    dataGridView1.Columns["TipoAusencia"].HeaderText = "Tipo de Ausencia";
                    dataGridView1.Columns["FechaDeSolicitud"].HeaderText = "Fecha Solicitud";
                    dataGridView1.Columns["FechaDeInicio"].HeaderText = "Fecha Inicio";
                    dataGridView1.Columns["FechaDeFin"].HeaderText = "Fecha Fin";
                    dataGridView1.Columns["Justificacion"].HeaderText = "Justificación";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar ausencias: {ex.Message}");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAusenciasjd_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
             (panel2.Width - label1.Width) / 2,
             (panel2.Height - label1.Height) / 2
         );

            CargarAusenciasPorDepartamento();
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

        private void panel2_Resize(object sender, EventArgs e)
        {

            label1.Location = new Point(
             (panel2.Width - label1.Width) / 2,
             (panel2.Height - label1.Height) / 2
         );
        }

        private void Btnbuscar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnbuscar, radioEsquinas);
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


        private void Btncargarfechas_Click(object sender, EventArgs e)
        {
            DateTime? fechaInicio = this.dateTimePicker1.Value;
            DateTime? fechaFin = this.dateTimePicker2.Value;


            CargarAusenciasPorDepartamento(fechaInicio, fechaFin);
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            string filtroBusqueda = Txtempleado.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtroBusqueda))
            {

                CargarAusenciasPorDepartamento();
            }
            else
            {

                CargarAusenciasPorDepartamento(filtroBusqueda: filtroBusqueda);
            }
        }
    }
}
