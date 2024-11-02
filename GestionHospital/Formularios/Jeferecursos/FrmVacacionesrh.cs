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
    public partial class FrmVacacionesrh : Form
    {
        public FrmVacacionesrh()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private long idVacacionSeleccionada;
        private prueba8Context db = new prueba8Context();
        private void CargarVacacionesPendientes()
        {
            try
            {
                // Obtener vacaciones pendientes
                var vacacionesPendientes = db.Vacacion
                    .Where(v => v.IdEstado == 2)
                    .Select(v => new
                    {
                        v.IdVacacion,
                        v.IdEstado,
                        v.IdEmpleado,
                        v.IdEmpleadoNavigation.EmpNombres,
                        Apellidos = v.IdEmpleadoNavigation.EmpApellidos,
                        Estado = v.IdEstadoNavigation.EstNombre,
                        v.VacFechasolicitud,
                        v.VacFechainicio,
                        v.VacFechafin,
                        v.VacFechaprobacion
                    })
                    .ToList();

                // Asignar la lista al DataGridView
                dataGridView1.DataSource = vacacionesPendientes;

               // dataGridView1.Columns["IdEstado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vacaciones pendientes: {ex.Message}");
            }
        }

        //Actualizar el esrado de la vacacion
        private void ActualizarEstadoVacacion(long idVacacion, int nuevoEstado)
        {
            try
            {

                var vacacion = db.Vacacion.FirstOrDefault(v => v.IdVacacion == idVacacion);
                if (vacacion != null)
                {
                    // Actualizar el estado
                    vacacion.IdEstado = nuevoEstado;
                    db.SaveChanges();
                    MessageBox.Show("Estado actualizado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el estado: {ex.Message}");
            }
        }

        //Cargar Estados para el cmb
        private void CargarEstadosComboBox()
        {
            try
            {
                using (var dbContext = new prueba8Context())  // Asegúrate de usar tu propio contexto
                {
                    // Obtener los estados de la base de datos
                    var estados = dbContext.Estado
                        .Select(e => new { e.IdEstado, e.EstNombre})
                        .ToList();

                    // Asignar los datos al ComboBox
                    comboEstado.DataSource = estados;
                    comboEstado.DisplayMember = "EstNombre";  // Lo que se muestra en el ComboBox
                    comboEstado.ValueMember = "IdEstado";  // El valor asociado (clave primaria)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los estados: {ex.Message}");
            }
        }
        private void FrmVacacionesrh_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
               (panel2.Width - label1.Width) / 2,
               (panel2.Height - label1.Height) / 2
           );

            CargarVacacionesPendientes();
            CargarEstadosComboBox();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

            if (panel1.Contains(dataGridView1))
            {

                int nuevaX = (int)((panel1.Width - dataGridView1.Width) / 2.5);
                int nuevaY = (int)((panel1.Height - dataGridView1.Height) / 1.3);

                dataGridView1.Location = new Point(nuevaX, nuevaY);


                int nueva1X = dataGridView1.Location.X;
                int nueva1Y = panelelementos.Location.Y;
                panelelementos.Location = new Point(nueva1X, nueva1Y);

            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(
          (panel2.Width - label1.Width) / 2,
          (panel2.Height - label1.Height) / 2
      );
        }

        private void BtnActualizar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;


            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            ruta.AddArc(0, 0, radioEsquinas, radioEsquinas, 180, 90);
            ruta.AddArc(BtnActualizar.Width - radioEsquinas, 0, radioEsquinas, radioEsquinas, 270, 90);
            ruta.AddArc(BtnActualizar.Width - radioEsquinas, BtnActualizar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 0, 90);
            ruta.AddArc(0, BtnActualizar.Height - radioEsquinas, radioEsquinas, radioEsquinas, 90, 90);
            ruta.CloseFigure();


            BtnActualizar.Region = new Region(ruta);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["IdVacacion"].Value != null)
            {
                // Obtener el ID de la vacación seleccionada
               idVacacionSeleccionada = (long)dataGridView1.Rows[e.RowIndex].Cells["IdVacacion"].Value;

                // Obtener el estado actual de la vacación seleccionada
                long estadoActual = (long)dataGridView1.Rows[e.RowIndex].Cells["IdEstado"].Value;

                // Mostrar la información de la vacación seleccionada en los controles
                Txtnombre.Text = dataGridView1.Rows[e.RowIndex].Cells["EmpNombres"].Value.ToString();
                TxtApellidos.Text = dataGridView1.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                fechaSolicitud.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["VacFechasolicitud"].Value;
                fechaInicio.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["VacFechainicio"].Value;
                fechaFin.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["VacFechafin"].Value;

                // Asignar el estado actual al ComboBox
                comboEstado.SelectedValue = estadoActual;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {

            if (idVacacionSeleccionada > 0)  // Asegúrate de que haya una vacación seleccionada
            {
                try
                {
                    using (var dbContext = new prueba8Context())  // Utiliza tu contexto de base de datos
                    {
                        // Obtener la vacación seleccionada de la base de datos
                        var vacacion = dbContext.Vacacion.FirstOrDefault(v => v.IdVacacion == idVacacionSeleccionada);

                        if (vacacion != null)
                        {

                            long nuevoEstado = (long)comboEstado.SelectedValue;


                            vacacion.IdEstado = nuevoEstado;


                            vacacion.VacFechaprobacion = DateTime.Now;

                            dbContext.SaveChanges();


                            MessageBox.Show("El estado de la vacación se ha actualizado correctamente.");


                            CargarVacacionesPendientes();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la vacación seleccionada.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la vacación: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una vacación.");
            }
        }



        //Filtro
        private void CargarVacacionesFiltradas(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var dbContext = new prueba8Context())  // Usa tu contexto
            {
                // Consulta para filtrar las vacaciones por estado pendiente y fecha de solicitud
                var vacacionesFiltradas = dbContext.Vacacion
                    .Where(v => v.IdEstado == 2 && v.VacFechasolicitud >= fechaInicio && v.VacFechasolicitud <= fechaFin)
                    .Select(v => new
                    {
                        v.IdVacacion,
                        v.IdEstado,
                        v.IdEmpleado,
                        v.IdEmpleadoNavigation.EmpNombres,
                        Apellidos = v.IdEmpleadoNavigation.EmpApellidos,
                        Estado = v.IdEstadoNavigation.EstNombre,
                        v.VacFechasolicitud,
                        v.VacFechainicio,
                        v.VacFechafin,
                        v.VacFechaprobacion
                    })
                    .ToList();

                // Asignar los datos filtrados al DataGridView
                dataGridView1.DataSource = vacacionesFiltradas;
            }
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

            // Llamar al método para cargar las vacaciones filtradas
            CargarVacacionesFiltradas(fechaInicio, fechaFin);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CargarVacacionesPendientes();
           
        }
    }
}
