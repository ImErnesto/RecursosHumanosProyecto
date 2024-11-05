using FontAwesome.Sharp;
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
    public partial class FrmCapacitaciones : Form
    {
        private long idEmpleado;
        public FrmCapacitaciones(long idEmpleado)
        {
            InitializeComponent();
           
            this.idEmpleado = idEmpleado;
        }

        private prueba8Context db = new prueba8Context();

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCapacitaciones_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
               (panel2.Width - label1.Width) / 2,
               (panel2.Height - label1.Height) / 2
           );

            CargarCapacitaciones();
            cargarCombo();
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

        private void CargarCapacitaciones()
        {
            using (var dbContext = new prueba8Context())
            {
              var capacitaciones = dbContext.Empleadoxcapacitacion
             .Where(a => a.IdEmpleado == idEmpleado) 
             .Select(a => new
             {
                 a.IdCapacitacion,
                 CapacitacionNombre = a.IdCapacitacionNavigation.CapNombre,
                 CapacitacionFecha = a.IdCapacitacionNavigation.CapFecha,
                 a.IdEmpleado,
                 NombreEmpleado = a.IdEmpleadoNavigation.EmpNombres,
                 ApellidosEmpleado = a.IdEmpleadoNavigation.EmpApellidos,
                 DUIEmpleado = a.IdEmpleadoNavigation.EmpDui
             }).OrderBy(a => a.IdCapacitacion)
             .ToList();

                dataGridView1.DataSource = capacitaciones;
                dataGridView1.Columns["IdCapacitacion"].HeaderText = "ID Capacitación";
                dataGridView1.Columns["CapacitacionNombre"].HeaderText = "Capacitación";
                dataGridView1.Columns["CapacitacionFecha"].HeaderText = "Fecha";
                dataGridView1.Columns["IdEmpleado"].HeaderText = "ID Empleado";
                dataGridView1.Columns["NombreEmpleado"].HeaderText = "Nombres";
                dataGridView1.Columns["ApellidosEmpleado"].HeaderText = "Apellidos";
                dataGridView1.Columns["DUIEmpleado"].HeaderText = "DUI";
               
            }
        }


        private bool comboCargado = false;


        private void cargarCombo()
        {
            using (var dbContext = new prueba8Context())
            {
                var capacitaciones = dbContext.Empleadoxcapacitacion
                    .Where(a => a.IdEmpleado == idEmpleado)
                    .Select(a => new
                    {
                        CapacitacionId = a.IdCapacitacion,
                        CapacitacionNombre = a.IdCapacitacionNavigation.CapNombre
                    })
                    .ToList();

                comboCapacitacion.DataSource = capacitaciones;
                comboCapacitacion.DisplayMember = "CapacitacionNombre";
                comboCapacitacion.ValueMember = "CapacitacionId";

                comboCargado = true;  
            }
        }


        private void comboCapacitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboCargado) return; 

            if (comboCapacitacion.SelectedValue != null &&
                int.TryParse(comboCapacitacion.SelectedValue.ToString(), out int idCapacitacion))
            {
                filtrarporCapacitacion(idCapacitacion);
            }
            else
            {
                MessageBox.Show("No se pudo obtener el ID de la capacitación.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void filtrarporCapacitacion(int idCapacitacion)
        {
            using (var dbContext = new prueba8Context())
            {
                var capacitacionesFiltradas = dbContext.Empleadoxcapacitacion
                    .Where(a => a.IdEmpleado == idEmpleado && a.IdCapacitacion == idCapacitacion)
                    .Select(a => new
                    {
                        a.IdCapacitacion,
                        CapacitacionNombre = a.IdCapacitacionNavigation.CapNombre,
                        CapacitacionFecha = a.IdCapacitacionNavigation.CapFecha,
                        a.IdEmpleado,
                        NombreEmpleado = a.IdEmpleadoNavigation.EmpNombres,
                        ApellidosEmpleado = a.IdEmpleadoNavigation.EmpApellidos,
                        DUIEmpleado = a.IdEmpleadoNavigation.EmpDui
                    })
                    .ToList();

                dataGridView1.DataSource = capacitacionesFiltradas;
            }
        }

        private void Btnrecargar_Click(object sender, EventArgs e)
        {
            CargarCapacitaciones();
        }

        private void Btnrecargar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;


            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            ruta.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
            ruta.AddArc(Btnrecargar.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
            ruta.AddArc(Btnrecargar.Width - radioEsquinas, Btnrecargar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
            ruta.AddArc(0, Btnrecargar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
            ruta.CloseFigure();


            Btnrecargar.Region = new Region(ruta);
        }
    }
}
