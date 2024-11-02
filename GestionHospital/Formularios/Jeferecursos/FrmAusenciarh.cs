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
    public partial class FrmAusenciarh : Form
    {
        public FrmAusenciarh()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAusenciarh_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
              (panel2.Width - label1.Width) / 2,
              (panel2.Height - label1.Height) / 2
          );

            CargarAusencias();
            CargarEstadosComboBox();
        }
        private long idAusenciaSeleccionada;
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
        private void CargarAusencias()
        {
            try
            {
                using (var dbContext = new prueba8Context())  // Usa tu contexto
                {
                    var ausencias = dbContext.RegistroAusencia
                        .Select(a => new
                        {
                            a.IdRegistroausencias,
                            a.IdEstado,
                            NombreEmpleado = a.IdEmpleadoNavigation.EmpNombres,
                            ApellidosEmpleado= a.IdEmpleadoNavigation.EmpApellidos,
                            TipoAusencia = a.IdTipoausenciaNavigation.TipoNombre,
                            Estado = a.IdEstadoNavigation.EstNombre,
                            FechaDeSolicitud= a.RegFechasolicitud,
                            FechaDeInicio= a.RegFechainicio,
                            FechaDeFin = a.RegFechafin,
                            Justificacion= a.RegJustificacion
                        })
                        .ToList();

                    dataGridView1.DataSource = ausencias;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ausencias: {ex.Message}");
            }
        }

        //Cargar estados en el combobox
        private void CargarEstadosComboBox()
        {
            try
            {
                using (var dbContext = new prueba8Context())  
                {
                   
                    var estados = dbContext.Estado
                        .Select(e => new { e.IdEstado, e.EstNombre })
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
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["IdRegistroausencias"].Value != null)
            {
                // Obtener el ID de la ausencia seleccionada
                idAusenciaSeleccionada = (long)dataGridView1.Rows[e.RowIndex].Cells["IdRegistroAusencias"].Value;

                // Cargar la información de la ausencia seleccionada en los controles
                Txtnombre.Text = dataGridView1.Rows[e.RowIndex].Cells["NombreEmpleado"].Value.ToString();
                TxtApellidos.Text = dataGridView1.Rows[e.RowIndex].Cells["ApellidosEmpleado"].Value.ToString();
                fechaSolicitud.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["FechaDeSolicitud"].Value;
                fechaInicio.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["FechaDeInicio"].Value;

                var fechaa = dataGridView1.Rows[e.RowIndex].Cells["FechaDeFin"].Value;
                // Comprobar si reg_fechafin es null antes de asignarla
                if (fechaa != null && fechaa != DBNull.Value)
                {
                    fechaFin.Value = (DateTime)fechaa;
                    fechaFin.Format = DateTimePickerFormat.Short;
                }
                else
                {
                    // Si es null, asigna una fecha predeterminada o deshabilita el control
                    fechaFin.CustomFormat = " "; // Mostrar en blanco
                    fechaFin.Format = DateTimePickerFormat.Custom; // Cambiar el formato
                }

                Txtjustificacion.Text = dataGridView1.Rows[e.RowIndex].Cells["Justificacion"].Value.ToString();

                // Cargar el estado actual en el ComboBox
                long estadoActual = (long)dataGridView1.Rows[e.RowIndex].Cells["IdEstado"].Value;
                comboEstado.SelectedValue = estadoActual;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (idAusenciaSeleccionada > 0)
            {
                try
                {
                    using (var dbContext = new prueba8Context())
                    {
                        // Obtener la ausencia seleccionada desde la base de datos
                        var ausencia = dbContext.RegistroAusencia.FirstOrDefault(a => a.IdRegistroausencias == idAusenciaSeleccionada);
                        if (ausencia != null)
                        {
                            // Obtener el nuevo estado seleccionado en el ComboBox
                            long nuevoEstado = (long)comboEstado.SelectedValue;

                            // Actualizar el estado de la ausencia
                            ausencia.IdEstado = nuevoEstado;
                            // Verificar si hay una fecha seleccionada en dateTimePickerFin
                            if (fechaFin.Format == DateTimePickerFormat.Custom && fechaFin.CustomFormat == " ")
                            {
                                
                                ausencia.RegFechafin = null; // Guardar como null en la base de datos
                            }
                            else
                            {
                             
                                ausencia.RegFechafin = fechaFin.Value; // Guardar la fecha seleccionada
                            }
                            // Guardar los cambios en la base de datos
                            dbContext.SaveChanges();

                            MessageBox.Show("El estado de la ausencia se ha actualizado correctamente.");

                            // Recargar el DataGridView para reflejar los cambios
                            CargarAusencias();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la ausencia seleccionada.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la ausencia: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una ausencia.");
            }
        }

        private void fechaFin_ValueChanged(object sender, EventArgs e)
        {
            fechaFin.Format = DateTimePickerFormat.Short;
            fechaFin.CustomFormat = null;
        }


        private void CargarAusenciasFiltradas(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var dbContext = new prueba8Context())  // Usa tu contexto
            {
                // Consulta para filtrar las ausencias por estado y fecha de solicitud
                var ausenciasFiltradas = dbContext.RegistroAusencia
                    .Where(a => a.IdEstado == 1 && a.RegFechasolicitud >= fechaInicio && a.RegFechasolicitud <= fechaFin)
                    .Select(a => new
                    {
                        a.IdRegistroausencias,
                        a.IdEstado,
                        NombreEmpleado = a.IdEmpleadoNavigation.EmpNombres,
                        ApellidosEmpleado = a.IdEmpleadoNavigation.EmpApellidos,
                        TipoAusencia = a.IdTipoausenciaNavigation.TipoNombre,
                        Estado = a.IdEstadoNavigation.EstNombre,
                        FechaDeSolicitud = a.RegFechasolicitud,
                        FechaDeInicio = a.RegFechainicio,
                        FechaDeFin = a.RegFechafin,
                        Justificacion = a.RegJustificacion
                    })
                    .ToList();

                // Asignar los datos filtrados al DataGridView
                dataGridView1.DataSource = ausenciasFiltradas;
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

            // Llamar al método para cargar las ausencias filtradas
            CargarAusenciasFiltradas(fechaInicio, fechaFin);
        }
    }
}
