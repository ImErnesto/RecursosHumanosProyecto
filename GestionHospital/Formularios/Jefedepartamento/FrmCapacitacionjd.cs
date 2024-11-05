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
    public partial class FrmCapacitacionjd : Form
    {
        private long idEmpleado;
        private long idDepartamento;
        public FrmCapacitacionjd(long idEmpleado, long idDepartamento)
        {
            InitializeComponent();
          
            this.idEmpleado = idEmpleado;
            this.idDepartamento = idDepartamento;
            cargarCombo();
        }

        private void CargarEmpleadosXCapacitacion(long? idCapacitacion = null, string filtroBusqueda = null)
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

                    
                    var empleadosCapacitacionQuery = dbContext.Empleadoxcapacitacion
                        .Join(dbContext.Capacitacion,
                            ec => ec.IdCapacitacion,
                            c => c.IdCapacitacion,
                            (ec, c) => new { ec, c })
                        .Join(dbContext.Empleado,
                            ecC => ecC.ec.IdEmpleado,
                            e => e.IdEmpleado,
                            (ecC, e) => new
                            {
                                ecC.ec.IdCapacitacion,
                                NombreCapacitacion = ecC.c.CapNombre,
                                ecC.ec.IdEmpleado,
                                NombreEmpleado = e.EmpNombres,
                                ApellidoEmpleado = e.EmpApellidos,
                                DUIEmpleado = e.EmpDui,
                                e.IdDepartamento
                            })
                        .Where(emp => emp.IdDepartamento == departamentoJefe);

                  
                    if (idCapacitacion.HasValue)
                    {
                        empleadosCapacitacionQuery = empleadosCapacitacionQuery
                            .Where(emp => emp.IdCapacitacion == idCapacitacion.Value);
                    }

                    
                    if (!string.IsNullOrWhiteSpace(filtroBusqueda))
                    {
                        empleadosCapacitacionQuery = empleadosCapacitacionQuery
                            .Where(emp => emp.IdEmpleado.ToString().Contains(filtroBusqueda) || 
                                          emp.NombreEmpleado.Contains(filtroBusqueda) || 
                                          emp.ApellidoEmpleado.Contains(filtroBusqueda) || 
                                          (emp.NombreEmpleado + " " + emp.ApellidoEmpleado).Contains(filtroBusqueda)); 
                    }

          
                    var empleadosCapacitacion = empleadosCapacitacionQuery
                        .OrderBy(emp => emp.IdEmpleado)
                        .ToList();

                 
                    dataGridView1.DataSource = empleadosCapacitacion;

           
                    dataGridView1.Columns["IdCapacitacion"].HeaderText = "ID Capacitación";
                    dataGridView1.Columns["NombreCapacitacion"].HeaderText = "Nombre Capacitación";
                    dataGridView1.Columns["IdEmpleado"].HeaderText = "ID Empleado";
                    dataGridView1.Columns["NombreEmpleado"].HeaderText = "Nombres";
                    dataGridView1.Columns["ApellidoEmpleado"].HeaderText = "Apellidos";
                    dataGridView1.Columns["DUIEmpleado"].HeaderText = "DUI";
                    dataGridView1.Columns["IdDepartamento"].HeaderText = "ID Departamento";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar empleados por capacitación: {ex.Message}");
                }
            }
        }



        private void cargarCombo()
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

                   
                    var capacitaciones = dbContext.Empleadoxcapacitacion
                        .Where(ec => ec.IdEmpleadoNavigation.IdDepartamento == departamentoJefe)
                        .Select(ec => new
                        {
                            CapacitacionId = ec.IdCapacitacion,
                            CapacitacionNombre = ec.IdCapacitacionNavigation.CapNombre
                        })
                        .Distinct() 
                        .ToList();

                    if (capacitaciones.Count == 0)
                    {
                        MessageBox.Show("No hay capacitaciones disponibles para este departamento.");
                        return;
                    }

            
                    comboCapacitacion.DataSource = capacitaciones;
                    comboCapacitacion.DisplayMember = "CapacitacionNombre";
                    comboCapacitacion.ValueMember = "CapacitacionId";

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el ComboBox: {ex.Message}");
                }
            }
        }






        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnbuscar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;


            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            ruta.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
            ruta.AddArc(Btnbuscar.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
            ruta.AddArc(Btnbuscar.Width - radioEsquinas, Btnbuscar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
            ruta.AddArc(0, Btnbuscar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
            ruta.CloseFigure();


            Btnbuscar.Region = new Region(ruta);
        }

        private void FrmCapacitacionjd_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
              (panel2.Width - label1.Width) / 2,
              (panel2.Height - label1.Height) / 2
          );
            CargarEmpleadosXCapacitacion();
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

     
      

        private void comboCapacitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCapacitacion.SelectedValue != null)
            {
                string nombreCapacitacion = comboCapacitacion.Text;

                using (var dbContext = new prueba8Context())
                {
                    var idCapacitacion = dbContext.Capacitacion
                        .Where(c => c.CapNombre == nombreCapacitacion)
                        .Select(c => c.IdCapacitacion)
                        .FirstOrDefault();

                    CargarEmpleadosXCapacitacion(idCapacitacion);
                }
            }
          
        }

        private void Btnrecargar_Click(object sender, EventArgs e)
        {
            CargarEmpleadosXCapacitacion();
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            string filtro = Txtempleado.Text.Trim();

            
            CargarEmpleadosXCapacitacion(null, filtro);
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
