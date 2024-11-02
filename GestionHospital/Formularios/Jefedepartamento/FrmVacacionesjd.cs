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
    public partial class FrmVacacionesjd : Form
    {
        private long idEmpleado;
        private long idDepartamento;
        public FrmVacacionesjd(long idEmpleado, long idDepartamento)
        {
            InitializeComponent();
           
            this.idEmpleado = idEmpleado;
            this.idDepartamento = idDepartamento;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarVacacionesPorDepartamento(
     DateTime? fechaInicio = null,
     DateTime? fechaFin = null,
     string filtroBusqueda = null)
        {
            using (var dbContext = new prueba8Context())
            {
                try
                {
                    
                    var departamentoJefe = dbContext.Empleado
                        .Where(e => e.IdEmpleado == idEmpleado)
                        .Select(e => e.IdDepartamento)
                        .FirstOrDefault();

                    if (departamentoJefe == 0)
                    {
                        MessageBox.Show("No se encontró el departamento del jefe.");
                        return;
                    }

                    
                    var vacacionesQuery = dbContext.Vacacion
                        .Join(dbContext.Empleado,
                            v => v.IdEmpleado,
                            e => e.IdEmpleado,
                            (v, e) => new
                            {
                                v.IdVacacion,
                                Estado = v.IdEstadoNavigation.EstNombre,
                                v.IdEmpleado,
                                e.EmpNombres,
                                e.EmpApellidos,
                                e.EmpDui,
                                e.IdDepartamento,
                                v.VacFechasolicitud,
                                v.VacFechainicio,
                                v.VacFechafin,
                                v.VacFechaprobacion,
                               
                            })
                        .Where(v => v.IdDepartamento == departamentoJefe);

                
                    if (fechaInicio.HasValue && fechaFin.HasValue)
                    {
                        vacacionesQuery = vacacionesQuery
                            .Where(v => v.VacFechasolicitud >= fechaInicio.Value &&
                                        v.VacFechasolicitud <= fechaFin.Value);
                    }

               
                    if (!string.IsNullOrWhiteSpace(filtroBusqueda))
                    {
                        vacacionesQuery = vacacionesQuery
                            .Where(v =>
                                v.IdEmpleado.ToString().Contains(filtroBusqueda) ||
                                v.EmpNombres.Contains(filtroBusqueda) ||
                                v.EmpApellidos.Contains(filtroBusqueda) ||
                                (v.EmpNombres + " " + v.EmpApellidos).Contains(filtroBusqueda));
                    }

                    
                    var vacaciones = vacacionesQuery
                        .OrderBy(v => v.IdVacacion)
                        .ToList();

                
                    dataGridView1.DataSource = vacaciones;

             
                    dataGridView1.Columns["IdVacacion"].HeaderText = "ID Vacación";
                    dataGridView1.Columns["Estado"].HeaderText = "Estado";
                    dataGridView1.Columns["IdEmpleado"].HeaderText = "ID Empleado";
                    dataGridView1.Columns["EmpNombres"].HeaderText = "Nombres";
                    dataGridView1.Columns["EmpApellidos"].HeaderText = "Apellido";
                    dataGridView1.Columns["EmpDui"].HeaderText = "DUI";
                    dataGridView1.Columns["IdDepartamento"].HeaderText = "ID Departamento";
                    dataGridView1.Columns["VacFechasolicitud"].HeaderText = "Fecha Solicitud";
                    dataGridView1.Columns["VacFechainicio"].HeaderText = "Fecha Inicio";
                    dataGridView1.Columns["VacFechafin"].HeaderText = "Fecha Fin";
                    dataGridView1.Columns["VacFechaprobacion"].HeaderText = "Fecha Aprobación";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar vacaciones: {ex.Message}");
                }
            }
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

        private void FrmVacacionesjd_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
            (panel2.Width - label1.Width) / 2,
            (panel2.Height - label1.Height) / 2
        );
            CargarVacacionesPorDepartamento();
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

        private void Btncargarfechas_Click(object sender, EventArgs e)
        {
            DateTime? fechaInicio = this.dateTimePicker1.Value;
            DateTime? fechaFin = this.dateTimePicker2.Value;

       
            CargarVacacionesPorDepartamento(fechaInicio, fechaFin);
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {

            string filtroBusqueda = Txtempleado.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtroBusqueda))
            {
               
                CargarVacacionesPorDepartamento();
            }
            else
            {
               
                CargarVacacionesPorDepartamento(filtroBusqueda: filtroBusqueda);
            }

        }
    }
}
