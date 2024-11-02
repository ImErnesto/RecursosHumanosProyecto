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
    public partial class FrmAusencia : Form
    {
        private long idEmpleado;
        public FrmAusencia(long idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            CargarAusencias();
            CargarTipo();
        }

        private prueba8Context db = new prueba8Context();
        private void CargarAusencias()
        {
            using (var dbContext = new prueba8Context())
            {
                var ausencias = dbContext.RegistroAusencia
               .Where(a => a.IdEmpleado == idEmpleado)
               .Select(a => new
               {
                   
               a.IdRegistroausencias,
               a.IdEmpleado,
               TipoAusencia = a.IdTipoausenciaNavigation.TipoNombre,
               Estado = a.IdEstadoNavigation.EstNombre,
               a.RegFechasolicitud,
               a.RegFechainicio,
               a.RegFechafin,
               a.RegJustificacion

               })
               .ToList();

                dataGridView1.DataSource = ausencias;
                dataGridView1.Columns["IdRegistroausencias"].HeaderText = "ID Ausencia";
                dataGridView1.Columns["IdEmpleado"].HeaderText = "ID Empleado";
                dataGridView1.Columns["TipoAusencia"].HeaderText = "Tipo";
                dataGridView1.Columns["Estado"].HeaderText = "Estado";
                dataGridView1.Columns["RegFechasolicitud"].HeaderText = "Fecha solicitud";
                dataGridView1.Columns["RegFechainicio"].HeaderText = "Fecha inicio";
                dataGridView1.Columns["RegFechafin"].HeaderText = "Fecha fin";
                dataGridView1.Columns["RegJustificacion"].HeaderText = "Justificación";
            }
        }



        private void CargarTipo()
        {
            using (var dbContext = new prueba8Context())
            {
                var tiposAusencia = dbContext.TipoAusencia.ToList();
                this.comboAusencia.DataSource = tiposAusencia;
                this.comboAusencia.DisplayMember = "TipoNombre";  
                this.comboAusencia.ValueMember = "IdTipoausencia";  
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnsolicitar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;


            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            ruta.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
            ruta.AddArc(Btnsolicitar.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
            ruta.AddArc(Btnsolicitar.Width - radioEsquinas, Btnsolicitar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
            ruta.AddArc(0, Btnsolicitar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
            ruta.CloseFigure();


            Btnsolicitar.Region = new Region(ruta);
        }

        private void FrmAusencia_Load(object sender, EventArgs e)
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
         
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;


            if (fechaInicio >= fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            string justificacion = this.Txtjustificacion.Text;

            if (string.IsNullOrWhiteSpace(justificacion))
            {
                MessageBox.Show("Debe ingresar una justificación.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var tipoAusenciaSeleccionado = comboAusencia.SelectedItem as TipoAusencia;
            if (tipoAusenciaSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de ausencia.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dbContext = new prueba8Context())
            {
                try
                {
                    // Buscar el estado 'Pendiente'
                    var estadoPendiente = dbContext.Estado
                        .FirstOrDefault(es => es.EstNombre == "Pendiente");

                    if (estadoPendiente == null)
                    {
                        MessageBox.Show("No se encontró el estado 'Pendiente'.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

               
                    var nuevoRegistro = new RegistroAusencia
                    {
                        IdEmpleado = idEmpleado,  
                        IdTipoausencia = tipoAusenciaSeleccionado.IdTipoausencia,
                        RegFechasolicitud = DateTime.Now,
                        RegFechainicio = fechaInicio,
                        RegFechafin = fechaFin,
                        RegJustificacion = justificacion,
                        IdEstado = estadoPendiente.IdEstado,  
                    };

          
                    dbContext.RegistroAusencia.Add(nuevoRegistro);
                    dbContext.SaveChanges();
                    CargarAusencias();
                    MessageBox.Show("Registro de ausencia realizado con éxito.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
