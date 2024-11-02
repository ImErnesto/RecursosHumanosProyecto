﻿using GestionHospital.BD;
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
    public partial class FrmNominarh : Form
    {
        public FrmNominarh()
        {
            InitializeComponent();
        }

        private prueba8Context db = new prueba8Context();
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmNominarh_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
            (panel2.Width - label1.Width) / 2,
            (panel2.Height - label1.Height) / 2
        );
            CargarNominas();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (panel1.Contains(dataGridView1))
            {

                int nuevaX = (int)((panel1.Width - dataGridView1.Width) / 2.5);
                int nuevaY = (int)((panel1.Height - dataGridView1.Height) / 2.4);

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
            (panel2.Height - label1.Height) / 2
            );
        }

        private void CargarNominas()
        {
            try
            {
                using (var dbContext = new prueba8Context())
                {
                    var nominas = dbContext.Nomina
                        .Select(n => new
                        {
                            IdNomina = n.IdNomina,
                            n.IdPeriodopago,
                            PeriodoNombre = n.IdPeriodopagoNavigation.PerNombre,
                            PeriodoInicio = n.IdPeriodopagoNavigation.PerInicio,
                            PeriodoFin = n.IdPeriodopagoNavigation.PerFin
                        })
                        .ToList();

                    dataGridView1.DataSource = nominas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar nóminas: {ex.Message}");
            }
        }

        private void CargarEmpleadosPorNomina(long idNomina)
        {
            try
            {
                using (var dbContext = new prueba8Context())
                {
                    var empleados = dbContext.Nominaxempleado
                        .Where(ne => ne.IdNomina == idNomina)
                        .Select(ne => new
                        {
                            ne.IdEmpleado,
                            Nombre = ne.IdEmpleadoNavigation.EmpNombres,
                            Apellidos = ne.IdEmpleadoNavigation.EmpApellidos,
                            Dui = ne.IdEmpleadoNavigation.EmpDui,
                            Bonificaciones = ne.NomBonificaciones,
                            Deducciones = ne.NomDeducciones,
                            SalarioNeto = ne.IdEmpleadoNavigation.EmpSalarioBruto - ne.NomDeduccionSalarial
                        })
                        .ToList();

                    dataGridView2.DataSource = empleados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}");
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

        private void BtnNuevo_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(BtnNuevo, radioEsquinas);
        }

        private void Btneliminar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btneliminar, radioEsquinas);
        }

        private void Btnbuscar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnbuscar, radioEsquinas);
        }

        private void Btnboleta_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnboleta, radioEsquinas);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar que el índice de la fila sea válido
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    // Verificar que la celda no sea nula
                    var cellValue = dataGridView1.Rows[e.RowIndex].Cells["IdNomina"].Value;

                    if (cellValue != null && cellValue != DBNull.Value)
                    {
                        long idNominaSeleccionada = Convert.ToInt64(cellValue);
                        CargarEmpleadosPorNomina(idNominaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un IdNomina válido en la fila seleccionada.");
                    }
                }
                else
                {
                    MessageBox.Show("Índice de fila fuera de rango.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar la nómina: {ex.Message}");
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new prueba8Context())
                {
                    // Crear un nuevo objeto de periodo de pago
                    var nuevoPeriodo = new PeriodoPago
                    {
                        PerNombre = Txtnombre.Text,
                        PerInicio = fechaInicio.Value.Date,  // Obtener solo la fecha
                        PerFin = periodoFin.Value.Date        // Obtener solo la fecha
                    };

                    // Agregar el periodo de pago al contexto y guardar cambios
                    dbContext.PeriodoPago.Add(nuevoPeriodo);
                    dbContext.SaveChanges();

                    MessageBox.Show("Periodo de pago creado exitosamente. La nómina se generará automáticamente.");

                    // Recargar la lista de periodos para reflejar los cambios
                    CargarNominas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el periodo de pago: {ex.Message}");
            }
        }
        private void BuscarEmpleadoPorDUI(string dui)
        {
            try
            {
                var empleados = (from DataGridViewRow row in dataGridView2.Rows
                                 where row.Cells["Dui"].Value?.ToString() == dui
                                 select row).ToList();

                if (empleados.Any())
                {
                    // Si se encuentra el empleado, seleccionamos su fila
                    dataGridView2.ClearSelection();
                    foreach (var row in empleados)
                    {
                        row.Selected = true;
                        dataGridView2.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún empleado con ese DUI.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar empleado: {ex.Message}");
            }
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            string dui = Txtempleado.Text.Trim();

            if (!string.IsNullOrEmpty(dui))
            {
                BuscarEmpleadoPorDUI(dui);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número de DUI para buscar.");
            }
        }
    }
}