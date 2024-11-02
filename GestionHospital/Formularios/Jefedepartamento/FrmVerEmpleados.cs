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
    public partial class FrmVerEmpleados : Form
    {
        private long idDepartamento;
        public FrmVerEmpleados(long idDepartamento)
        {
            InitializeComponent();
            this.idDepartamento = idDepartamento;
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

        private void FrmVerEmpleados_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
               (panel2.Width - label1.Width) / 2,
               (panel2.Height - label1.Height) / 2
           );
            CargarEmpleadosDepartamento(idDepartamento);
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
        private void CargarEmpleadosDepartamento(long idDepartamento)
        {
            using (var dbContext = new prueba8Context())
            {
                var empleados = dbContext.Empleado
                    .Where(e => e.IdDepartamento == idDepartamento)
                    .Select(e => new
                    {
                        e.IdEmpleado,
                        Nombres= e.EmpNombres,
                        Apellidos=e.EmpApellidos,
                        Dui=e.EmpDui,
                        Cargo = e.IdCargoNavigation.CarNombre,
                        Email=e.EmpEmail,
                        Telefono=e.EmpTelefono,
                        Direccion= e.EmpDireccion,
                        FechaDeNacimiento =e.EmpFechanacimiento,
                       
                    })
                    .ToList();

                dataGridView1.DataSource = empleados;
            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(
            (panel2.Width - label1.Width) / 2,
            (panel2.Height - label1.Height) / 2
        );
        }
    }
}
