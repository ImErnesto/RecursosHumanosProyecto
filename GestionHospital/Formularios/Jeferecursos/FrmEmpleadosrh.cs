using GestionHospital.BD;
using GestionHospital.Validar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionHospital.Formularios.Jeferecursos
{
    public partial class FrmEmpleadosrh : Form
    {
        public FrmEmpleadosrh()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private prueba8Context db = new prueba8Context();

        private void FrmEmpleadosrh_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
               (panel2.Width - label1.Width) / 2,
               (panel2.Height - label1.Height) / 2
           );
            CargarEmpleados();
            CargarCargos();
            CargarDepartamento();
        }


       

        private void CargarCargos()
        {
            // Usar ToList() en lugar de ToListAsync()
            var nombresCargos = db.Cargo
                .Select(c => c.CarNombre)
                .ToList();

            this.comboCargo.DataSource = nombresCargos;
        }


        private void CargarDepartamento()
        {

            var DepNombre = db.Departamento
                .Select(e => e.DepNombre)
                .ToList();

            this.comboDepartamento.DataSource = DepNombre;
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

        private void label9_Click(object sender, EventArgs e)
        {

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

        private void Btnbuscar_Paint(object sender, PaintEventArgs e)
        {
            int radioEsquinas = 20;
            redondearEsquinas(Btnbuscar, radioEsquinas);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int empleadoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEmpleado"].Value);

                  
                    if (string.IsNullOrWhiteSpace(Txtnombre.Text) || string.IsNullOrWhiteSpace(TxtApellidos.Text) ||
                        string.IsNullOrWhiteSpace(TxtDireccion.Text) || string.IsNullOrWhiteSpace(Txtemail.Text) ||
                        string.IsNullOrWhiteSpace(Txttelefono.Text) || string.IsNullOrWhiteSpace(TxtSalario.Text))
                    {
                        MostrarError("Debe llenar todos los campos.");
                        return;
                    }

                    if (!Campos.EsSoloLetras(Txtnombre.Text) || !Campos.EsSoloLetras(TxtApellidos.Text))
                    {
                        MostrarError("El nombre y los apellidos solo deben contener letras.");
                        return;
                    }

                    if (!Campos.EsDUIValido(TxtDUI.Text))
                    {
                        MostrarError("El DUI debe contener exactamente 9 dígitos.");
                        return;
                    }

                    if (!Campos.EsTelefonoValido(Txttelefono.Text))
                    {
                        MostrarError("El teléfono debe contener exactamente 9 dígitos.");
                        return;
                    }

                    if (!Campos.EsEmailValido(Txtemail.Text))
                    {
                        MostrarError("El correo electrónico debe contener un '@'.");
                        return;
                    }

                    if (!Campos.EsSalarioValido(TxtSalario.Text, out decimal salario))
                    {
                        MostrarError("El salario debe ser un número mayor que 0.");
                        return;
                    }

        
                    string nombreCargoSeleccionado = comboCargo.SelectedItem.ToString();
                    string nombreDepartamentoSeleccionado = comboDepartamento.SelectedItem.ToString();

                    var cargo = db.Cargo.FirstOrDefault(c => c.CarNombre == nombreCargoSeleccionado);
                    var departamento = db.Departamento.FirstOrDefault(d => d.DepNombre == nombreDepartamentoSeleccionado);

                    var empleado = db.Empleado.FirstOrDefault(em => em.IdEmpleado == empleadoId);
                    if (empleado == null)
                    {
                        MessageBox.Show("Empleado no encontrado.");
                        return;
                    }


                    empleado.IdCargo = cargo.IdCargo;
                    empleado.IdDepartamento = departamento.IdDepartamento;
                    empleado.EmpNombres = Txtnombre.Text;
                    empleado.EmpApellidos = TxtApellidos.Text;
                    empleado.EmpDui = TxtDUI.Text;
                    empleado.EmpFechanacimiento = dateTimePicker1.Value;
                    empleado.EmpDireccion = TxtDireccion.Text;
                    empleado.EmpTelefono = Txttelefono.Text;
                    empleado.EmpEmail = Txtemail.Text;
                    empleado.EmpSalarioBruto = salario;
                    empleado.EmpEstado = comboEstado.SelectedItem.ToString();

                    db.SaveChanges();
                    MessageBox.Show("Empleado actualizado correctamente.");
                    CargarEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar empleado: {ex.Message}");
            }
        
    }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {

            Txtnombre.Text = string.Empty;
            TxtApellidos.Text = string.Empty;
            TxtDUI.Text = string.Empty;
            Txttelefono.Text = string.Empty;
            TxtSalario.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            Txtemail.Text = string.Empty;
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txtnombre.Text) || string.IsNullOrWhiteSpace(TxtApellidos.Text) ||
                    string.IsNullOrWhiteSpace(TxtDireccion.Text) || string.IsNullOrWhiteSpace(Txtemail.Text) ||
                    string.IsNullOrWhiteSpace(Txttelefono.Text) || string.IsNullOrWhiteSpace(TxtSalario.Text))
                {
                    MostrarError("Debe llenar todos los campos.");
                    return;
                }

                // Validaciones usando la clase Validador
                if (!Campos.EsSoloLetras(Txtnombre.Text) || !Campos.EsSoloLetras(TxtApellidos.Text))
                {
                    MostrarError("El nombre y los apellidos solo deben contener letras.");
                    return;
                }

                if (!Campos.EsDUIValido(TxtDUI.Text))
                {
                    MostrarError("El DUI debe contener exactamente 9 dígitos.");
                    return;
                }

                if (!Campos.EsTelefonoValido(Txttelefono.Text))
                {
                    MostrarError("El teléfono debe tener el formato xxxx-xxxx.");
                    return;
                }

                if (!Campos.EsEmailValido(Txtemail.Text))
                {
                    MostrarError("El correo electrónico debe contener un '@'.");
                    return;
                }

                if (!Campos.EsSalarioValido(TxtSalario.Text, out decimal salario))
                {
                    MostrarError("El salario debe ser un número mayor que 0.");
                    return;
                }

            
                string nombreCargoSeleccionado = comboCargo.SelectedItem?.ToString() ??
                    dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();

                var cargo = db.Cargo.FirstOrDefault(c => c.CarNombre == nombreCargoSeleccionado);

               
                string nombreDepartamentoSeleccionado = comboDepartamento.SelectedItem?.ToString() ??
                    dataGridView1.CurrentRow.Cells["Departamento"].Value.ToString();

                var departamento = db.Departamento.FirstOrDefault(d => d.DepNombre == nombreDepartamentoSeleccionado);

                if (cargo == null || departamento == null)
                {
                    MostrarError("Debe seleccionar un cargo y departamento válidos.");
                    return;
                }

                var nuevoEmpleado = new Empleado
                {
                    IdCargo = cargo.IdCargo,
                    IdDepartamento = departamento.IdDepartamento,
                    EmpNombres = Txtnombre.Text,
                    EmpApellidos = TxtApellidos.Text,
                    EmpDui = TxtDUI.Text,
                    EmpFechanacimiento = dateTimePicker1.Value,
                    EmpDireccion = TxtDireccion.Text,
                    EmpTelefono = Txttelefono.Text,
                    EmpEmail = Txtemail.Text,
                    EmpSalarioBruto = salario,
                    EmpEstado = comboEstado.SelectedItem?.ToString()
                };

                db.Empleado.Add(nuevoEmpleado);
                db.SaveChanges();

                CargarEmpleados();
                MessageBox.Show("Empleado guardado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar empleado: {ex.Message}");
            }

        }



        private void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Validación de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int empleadoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEmpleado"].Value);
                    var empleado = db.Empleado.FirstOrDefault(em => em.IdEmpleado == empleadoId);

                    if (empleado == null)
                    {
                        MessageBox.Show("Empleado no encontrado.");
                        return;
                    }

                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas cambiar el estado de este empleado?",
                                                         "Confirmación de eliminación",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {

                        empleado.EmpEstado = "Inactivo";
                        db.SaveChanges();

                        MessageBox.Show("Empleado inactivado correctamente.");
                        CargarEmpleados();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inactivar empleado: {ex.Message}");
            }
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {

            string criterio = Txtempleado.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterio))
            {
                CargarEmpleados();  
                return;
            }
            if (int.TryParse(criterio, out int idEmpleado))
            {

                CargarEmpleados(idEmpleado);
            }
            else
            {

                CargarEmpleados(criterio: criterio);
            }
        }
        private void CargarEmpleados(int? idEmpleado = null, string criterio = null)
        {
            dataGridView1.SuspendLayout();

            try
            {
                var empleadosQuery = db.Empleado.AsQueryable();

                if (idEmpleado.HasValue)
                {
                    empleadosQuery = empleadosQuery.Where(e => e.IdEmpleado == idEmpleado.Value);
                }

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim().ToLower();
                    var palabras = criterio.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

                    foreach (var palabra in palabras)
                    {
                        string localPalabra = palabra;
                        empleadosQuery = empleadosQuery.Where(e =>
                            e.EmpNombres.ToLower().Contains(localPalabra) ||
                            e.EmpApellidos.ToLower().Contains(localPalabra));
                    }
                }

                var empleados = empleadosQuery
                    .Select(e => new
                    {
                        e.IdEmpleado,
                        CargoNombre = db.Cargo.Where(c => c.IdCargo == e.IdCargo).Select(c => c.CarNombre).FirstOrDefault(),
                        DepartamentoNombre = db.Departamento.Where(d => d.IdDepartamento == e.IdDepartamento).Select(d => d.DepNombre).FirstOrDefault(),
                        e.EmpNombres,
                        e.EmpApellidos,
                        e.EmpDui,
                        e.EmpFechanacimiento,
                        e.EmpDireccion,
                        e.EmpTelefono,
                        e.EmpEmail,
                        e.EmpSalarioBruto,
                        e.EmpEstado
                    })
                    .OrderBy(e => e.IdEmpleado)
                    .ToList();

                dataGridView1.DataSource = empleados;


                dataGridView1.Columns["IdEmpleado"].HeaderText = "ID";
                dataGridView1.Columns["CargoNombre"].HeaderText = "Cargo";
                dataGridView1.Columns["DepartamentoNombre"].HeaderText = "Departamento";
                dataGridView1.Columns["EmpNombres"].HeaderText = "Nombres";
                dataGridView1.Columns["EmpApellidos"].HeaderText = "Apellidos";
                dataGridView1.Columns["EmpDui"].HeaderText = "DUI";
                dataGridView1.Columns["EmpFechanacimiento"].HeaderText = "F.Nacimiento";
                dataGridView1.Columns["EmpDireccion"].HeaderText = "Dirección";
                dataGridView1.Columns["EmpTelefono"].HeaderText = "Teléfono";
                dataGridView1.Columns["EmpEmail"].HeaderText = "Email";
                dataGridView1.Columns["EmpSalarioBruto"].HeaderText = "Salario";
                dataGridView1.Columns["EmpEstado"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}");
            }
            finally
            {
                dataGridView1.ResumeLayout();
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var row = dataGridView1.CurrentRow;
                    Txtnombre.Text = row.Cells["EmpNombres"].Value.ToString();
                    TxtApellidos.Text = row.Cells["EmpApellidos"].Value.ToString();
                    TxtDUI.Text = row.Cells["EmpDui"].Value.ToString();
                    dateTimePicker1.Value = (DateTime)row.Cells["EmpFechanacimiento"].Value;
                    TxtDireccion.Text = row.Cells["EmpDireccion"].Value.ToString();
                    Txttelefono.Text = row.Cells["EmpTelefono"].Value.ToString();
                    Txtemail.Text = row.Cells["EmpEmail"].Value.ToString();
                    TxtSalario.Text = row.Cells["EmpSalarioBruto"].Value.ToString();
                    string Estado = row.Cells["EmpEstado"].Value.ToString();
                    this.comboEstado.Text = Estado;

                    string nombreCargo = row.Cells["CargoNombre"].Value.ToString();
                    string nombreDepartamento = row.Cells["DepartamentoNombre"].Value.ToString();
                    this.comboCargo.Text = nombreCargo;
                    this.comboDepartamento.Text = nombreDepartamento;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar empleado: {ex.Message}");
            }
        }
    }
}
