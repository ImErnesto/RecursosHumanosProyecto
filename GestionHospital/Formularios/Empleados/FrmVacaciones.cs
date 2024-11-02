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
    public partial class FrmVacaciones : Form
    {
        private long idEmpleado;
        public FrmVacaciones(long idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            CargarVacaciones();
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void CargarVacaciones()
        {
            using (var dbContext = new prueba8Context())
            {
              var vacaciones = dbContext.Vacacion
             .Where(a => a.IdEmpleado == idEmpleado) 
             .Select(a => new
             {
                 a.IdVacacion, 
                 Estado = a.IdEstadoNavigation.EstNombre,
                 a.IdEmpleado,
                 a.VacFechasolicitud,
                 a.VacFechainicio,
                 a.VacFechafin,
                 a.VacFechaprobacion
                


             }).OrderBy(a => a.IdVacacion)
             .ToList();

             dataGridView1.DataSource = vacaciones;
                    dataGridView1.Columns["IdVacacion"].HeaderText = "ID Vacación";
                    dataGridView1.Columns["Estado"].HeaderText = "Estado";
                    dataGridView1.Columns["IdEmpleado"].HeaderText = "ID Empleado";
                    dataGridView1.Columns["VacFechasolicitud"].HeaderText = "Fecha solicitud";
                    dataGridView1.Columns["VacFechainicio"].HeaderText = "Fecha inicio";
                    dataGridView1.Columns["VacFechafin"].HeaderText = "Fecha fin";
                    dataGridView1.Columns["VacFechaprobacion"].HeaderText = "Fecha aprobación";
                    
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

        private void Btnsolicitar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnsolicitar, radioEsquinas);
        }

        private void FrmVacaciones_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
              (panel2.Width - label1.Width) / 2,
              (panel2.Height - label1.Height) / 2
          );
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

        private void Btnsolicitar_Click(object sender, EventArgs e)
        {
         
            DateTime fechaInicio = this.dateTimePicker1.Value;
            DateTime fechaFin = this.dateTimePicker2.Value;

            if (fechaInicio >= fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dbContext = new prueba8Context())
            {
                try
                {
               
                    var estadoPendiente = dbContext.Estado
                        .FirstOrDefault(es => es.EstNombre == "Pendiente");

                    if (estadoPendiente == null)
                    {
                        MessageBox.Show("No se encontró el estado 'Pendiente'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

         
                    var nuevaVacacion = new Vacacion
                    {
                        IdEmpleado = idEmpleado,
                        VacFechasolicitud = DateTime.Now,  
                        VacFechainicio = fechaInicio,
                        VacFechafin = fechaFin,
                        IdEstado = estadoPendiente.IdEstado,  
                        VacFechaprobacion = null  
                    };

                    
                    dbContext.Vacacion.Add(nuevaVacacion);
                    dbContext.SaveChanges();

                    MessageBox.Show("Solicitud de vacaciones realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarVacaciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
