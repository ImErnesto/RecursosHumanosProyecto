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

namespace GestionHospital.Formularios.Jeferecursos
{
    public partial class FrmCapacitacionrh : Form
    {
       

        public FrmCapacitacionrh()
        {
            InitializeComponent();
         
  
        }

        private prueba8Context db = new prueba8Context();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCapacitacionrh_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
            (panel2.Width - label1.Width) / 2,
            (panel2.Height - label1.Height) / 2
        );
            CargarCapacitaciones();
            Cargarcombo();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (panel1.Contains(dataGridView1))
            {

                int nuevaX = (int)((panel1.Width - dataGridView1.Width) / 2.5);
                int nuevaY = (int)((panel1.Height - dataGridView1.Height) / 2.3);

                dataGridView1.Location = new Point(nuevaX, nuevaY);


                int nueva1X = dataGridView1.Location.X;
                int nueva1Y = panelelementos.Location.Y;
                panelelementos.Location = new Point(nueva1X, nueva1Y);

                int nueva2X = dataGridView1.Location.X;
                int nueva2Y = dataGridView2.Location.Y;
                int nueva3Y = label3.Location.Y;
                label3.Location = new Point(nueva2X, nueva3Y);
                dataGridView2.Location = new Point(nueva2X, nueva2Y);

            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(
       (panel2.Width - label1.Width) / 2,
       (int)((panel2.Height - label1.Height) / 2.3)
   );
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

        private void BtnNuevo_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(BtnNuevo, radioEsquinas);
        }

        private void BtnActualizar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(BtnActualizar, radioEsquinas);
        }

        private void Btnguardar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnguardar, radioEsquinas);
        }

        private void Btneliminar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btneliminar, radioEsquinas);
        }

        private void BtnAsignar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(BtnAsignar, radioEsquinas);
        }

        private void CargarCapacitaciones(int? idCapacitacion = null)
        {
            dataGridView1.SuspendLayout();

            try
            {

                var capacitacionesQuery = db.Capacitacion.AsQueryable();


                if (idCapacitacion.HasValue)
                {
                    capacitacionesQuery = capacitacionesQuery.Where(c => c.IdCapacitacion == idCapacitacion.Value);
                }


                var capacitaciones = capacitacionesQuery
                    .Select(c => new
                    {
                        c.IdCapacitacion,
                        c.CapNombre,
                        c.CapDescripcion,
                        c.CapFecha,
                        c.CapEstado

                    })
                    .OrderBy(c => c.IdCapacitacion)
                    .ToList();


                dataGridView1.DataSource = capacitaciones;

                dataGridView1.Columns["IdCapacitacion"].HeaderText = "ID";
                dataGridView1.Columns["CapNombre"].HeaderText = "Nombre";
                dataGridView1.Columns["CapDescripcion"].HeaderText = "Descripción";
                dataGridView1.Columns["CapFecha"].HeaderText = "Fecha";
                dataGridView1.Columns["CapEstado"].HeaderText = "Estado";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar capacitaciones: {ex.Message}");
            }
            finally
            {
                dataGridView1.ResumeLayout();
            }
        }

        private void CargarEmpleadosXCapacitacion(int? idCapacitacion = null)
        {
            dataGridView2.SuspendLayout();

            try
            {
                var empleadosCapacitacionQuery = db.Empleadoxcapacitacion.AsQueryable();

                if (idCapacitacion.HasValue)
                {
                    empleadosCapacitacionQuery = empleadosCapacitacionQuery.Where(ec => ec.IdCapacitacion == idCapacitacion.Value);
                }

                var empleadosCapacitacion = empleadosCapacitacionQuery
                    .Join(db.Capacitacion,
                        ec => ec.IdCapacitacion,
                        c => c.IdCapacitacion,
                        (ec, c) => new { ec, c })
                    .Join(db.Empleado,
                        ecC => ecC.ec.IdEmpleado,
                        e => e.IdEmpleado,
                        (ecC, e) => new
                        {
                            ecC.ec.IdCapacitacion,      // ID de la capacitación
                            NombreCapacitacion = ecC.c.CapNombre, // Nombre de la capacitación
                            ecC.ec.IdEmpleado,          // ID del empleado
                            NombreEmpleado = e.EmpNombres,  // Nombre del empleado
                            ApellidoEmpleado = e.EmpApellidos, // Apellido del empleado
                            DUIEmpleado = e.EmpDui       // DUI del empleado
                        })
                    .OrderBy(ec => ec.IdEmpleado)
                    .ToList();

                dataGridView2.DataSource = empleadosCapacitacion;

                // Establecer nombres de los encabezados correctamente
                dataGridView2.Columns["IdCapacitacion"].HeaderText = "ID Capacitación";
                dataGridView2.Columns["NombreCapacitacion"].HeaderText = "Nombre Capacitación"; // Cambiado a NombreCapacitacion
                dataGridView2.Columns["IdEmpleado"].HeaderText = "ID Empleado"; // Cambiado a IdEmpleado
                dataGridView2.Columns["NombreEmpleado"].HeaderText = "Nombres"; // Cambiado a NombreEmpleado
                dataGridView2.Columns["ApellidoEmpleado"].HeaderText = "Apellidos"; // Cambiado a ApellidoEmpleado
                dataGridView2.Columns["DUIEmpleado"].HeaderText = "DUI"; // Cambiado a DUIEmpleado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados por capacitación: {ex.Message}");
            }
            finally
            {
                dataGridView2.ResumeLayout();
            }
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    int capacitacionId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCapacitacion"].Value);



                    var capacitacion = db.Capacitacion.FirstOrDefault(c => c.IdCapacitacion == capacitacionId);
                    if (capacitacion == null)
                    {
                        MessageBox.Show("Capacitación no encontrada.");
                        return;
                    }



                    capacitacion.CapNombre = Txtnombre.Text;
                    capacitacion.CapDescripcion = Txtdescripcion.Text;
                    capacitacion.CapFecha = this.fechaCapacitacion.Value;
                    capacitacion.CapEstado = this.comboEstado.SelectedItem.ToString();


                    db.SaveChanges();
                    MessageBox.Show("Capacitación actualizada correctamente.");
                    CargarCapacitaciones();
                    Cargarcombo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar capacitación: {ex.Message}");
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Txtnombre.Text = string.Empty;
            Txtdescripcion.Text = string.Empty;

        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txtnombre.Text) || string.IsNullOrWhiteSpace(Txtdescripcion.Text))
                {
                    MessageBox.Show(
                        "Debe llenar tanto el nombre como la descripción de la capacitación.",
                        "Campos requeridos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var nuevaCapacitacion = new Capacitacion
                {
                    CapNombre = Txtnombre.Text,
                    CapDescripcion = Txtdescripcion.Text,
                    CapFecha = fechaCapacitacion.Value,
                    CapEstado = comboEstado.SelectedItem?.ToString() ?? "Pendiente"
                };

                db.Capacitacion.Add(nuevaCapacitacion);
                db.SaveChanges();

                CargarCapacitaciones();
                Cargarcombo();

                MessageBox.Show(
                    "Capacitación guardada exitosamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar capacitación: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int capacitacionId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCapacitacion"].Value);
                    var capacitacion = db.Capacitacion.FirstOrDefault(cap => cap.IdCapacitacion == capacitacionId);

                    if (capacitacion == null)
                    {
                        MessageBox.Show("Capacitación no encontrada.");
                        return;
                    }

                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas cambiar el estado de esta capacitación?",
                                                         "Confirmación de eliminación",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {

                        capacitacion.CapEstado = "Inactivo";
                        db.SaveChanges();

                        MessageBox.Show("Capacitación inactivada correctamente.");
                        CargarCapacitaciones();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inactivar capacitación: {ex.Message}");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MostrarEmpleado();
                e.SuppressKeyPress = true;
            }
            TxtNombres.Visible = true;
        }

        private void MostrarEmpleado()
        {
            this.TxtNombres.Visible = true;

            if (int.TryParse(TxtID.Text, out int idEmpleado))
            {
                string nombreCompleto = CargarEmpleados(idEmpleado);
                TxtNombres.Text = nombreCompleto ?? "Empleado no encontrado";
            }
            else
            {
                TxtNombres.Text = "Ingrese un ID válido";
            }
        }

        private string CargarEmpleados(int idEmpleado)
        {
            try
            {

                var empleado = db.Empleado
                    .Where(e => e.IdEmpleado == idEmpleado)
                    .Select(e => new
                    {
                        NombreCompleto = e.EmpNombres + " " + e.EmpApellidos
                    })
                    .FirstOrDefault();


                return empleado?.NombreCompleto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el empleado: {ex.Message}");
                return null;
            }
        }

        private void Cargarcombo()
        {
            // Cargar capacitaciones desde la base de datos
            var capacitaciones = db.Capacitacion.ToList();

            // Llenar el combo box con la lista de capacitaciones
            comboCapacitacion.DataSource = capacitaciones;
            comboCapacitacion.DisplayMember = "CapNombre"; // Campo para mostrar
            comboCapacitacion.ValueMember = "IdCapacitacion"; // Campo para usar como valor
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var row = dataGridView1.CurrentRow;
                    Txtnombre.Text = row.Cells["CapNombre"].Value.ToString();


                    Txtdescripcion.Text = row.Cells["CapDescripcion"].Value != null
                        ? row.Cells["CapDescripcion"].Value.ToString()
                        : string.Empty;

                    this.fechaCapacitacion.Value = (DateTime)row.Cells["CapFecha"].Value;
                    string Estado = row.Cells["CapEstado"].Value.ToString();
                    this.comboEstado.Text = Estado;

                    var row2 = dataGridView1.CurrentRow;
                    int idCapacitacion = Convert.ToInt32(row2.Cells["IdCapacitacion"].Value);
                    CargarEmpleadosXCapacitacion(idCapacitacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }


        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                long idEmpleado = long.Parse(TxtID.Text);

                bool empleadoExiste = db.Empleado.Any(em => em.IdEmpleado == idEmpleado);
                if (!empleadoExiste)
                {
                    MessageBox.Show("El empleado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var capacitacionSeleccionada = comboCapacitacion.SelectedItem as Capacitacion;
                if (capacitacionSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una capacitación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool asignacionExiste = db.Empleadoxcapacitacion.Any(ec =>
                    ec.IdEmpleado == idEmpleado && ec.IdCapacitacion == capacitacionSeleccionada.IdCapacitacion);

                if (asignacionExiste)
                {
                    MessageBox.Show("Este empleado ya está inscrito en esta capacitación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var nuevaAsignacion = new Empleadoxcapacitacion
                {
                    IdEmpleado = idEmpleado,
                    IdCapacitacion = capacitacionSeleccionada.IdCapacitacion
                };

                db.Entry(nuevaAsignacion).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                db.SaveChanges();

                MessageBox.Show("Empleado inscrito en la capacitación exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEmpleadosXCapacitacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar capacitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
