using GestionHospital.BD;
using GestionHospital.Formularios.Jefedepartamento;
using Microsoft.EntityFrameworkCore;
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
    public partial class Principaljefedepart : Form
    {

        private Size formOriginalSize;
        private Rectangle recBut1, recBut2, recBut3, recBut4, recBut5;
        private Rectangle recPanelPerfil;

        private long idEmpleado;
        private long idDepartamento;
        public Principaljefedepart(long idEmpleado, long idDepartamento)
        {
            InitializeComponent();
            this.Resize += Principaljefes_Resiz;

            formOriginalSize = this.Size;

            recBut1 = new Rectangle(this.BtnAsistencia.Location, this.BtnAsistencia.Size);
            recBut2 = new Rectangle(this.Btncapacitaciones.Location, this.Btncapacitaciones.Size);
            recBut3 = new Rectangle(this.BtnPermisos.Location, this.BtnPermisos.Size);
            recBut4 = new Rectangle(this.Btnequipo.Location, this.Btnequipo.Size);
            recBut5 = new Rectangle(this.BtnVacaciones.Location, this.BtnVacaciones.Size);

            recPanelPerfil = new Rectangle(panelperfil.Location, panelperfil.Size); 

            CenterControls();
            this.idEmpleado = idEmpleado;
            this.idDepartamento = idDepartamento;
        }

        private void Principaljefes_Resiz(object sender, EventArgs e)
        {
           
            resize_Control(panelperfil, recPanelPerfil);

            
            panelBotones.Width = panelperfil.Width; 

            
            panelperfil.Location = new Point((panel1.Width - panelperfil.Width) / 2, panelperfil.Location.Y);
            panelBotones.Location = new Point((panel1.Width - panelBotones.Width) / 2, panelperfil.Location.Y + panelperfil.Height + 10); // 10 es un margen

            
            resize_Control(this.BtnAsistencia, recBut1);
            resize_Control(this.Btncapacitaciones, recBut2);
            resize_Control(this.BtnPermisos, recBut3);
            resize_Control(this.Btnequipo, recBut4);
            resize_Control(this.BtnVacaciones, recBut5);
        }
        private void CargarInformacionEmpleado()
        {
            using (var dbContext = new prueba8Context())
            {
                // Obtener los datos del empleado por su ID
                var empleado = dbContext.Empleado
               .Include(e => e.IdCargoNavigation)  // Asegura que el cargo se cargue
               .FirstOrDefault(e => e.IdEmpleado == idEmpleado);

                if (empleado != null)
                {
                    // Rellenar los campos de información del empleado en el dashboard
                    lblnombre.Text = $"Nombre: {empleado.EmpNombres} {empleado.EmpApellidos}";
                    lblcargo.Text = $"Cargo: {empleado.IdCargoNavigation.CarNombre}";  // Suponiendo que la tabla Cargo tenga un campo "NombreCargo"
                    lbledad.Text = $"Edad: {CalcularEdad(empleado.EmpFechanacimiento).ToString()}";
                    lblemail.Text = $"Email: {empleado.EmpEmail}";
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.");
                }
            }
        }

        //Fecha NacimientoEmpleado
        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
                edad--;
            return edad;
        }

        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Principaljefedepart_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(
               (panel2.Width - label1.Width) / 2,
               (panel2.Height - label1.Height) / 2
           );
            CargarInformacionEmpleado();
        }

        private void BtnAsistencia_Click(object sender, EventArgs e)
        {
            FrmAsistenciajd nuevoFormulario = new FrmAsistenciajd(idDepartamento);
            nuevoFormulario.Show();
        }

        private void Btnequipo_Click(object sender, EventArgs e)
        {
            FrmVerEmpleados nuevoFormulario = new FrmVerEmpleados(idDepartamento);
            nuevoFormulario.Show();
        }

        private void BtnPermisos_Click(object sender, EventArgs e)
        {
            FrmAusenciasjd nuevoFormulario = new FrmAusenciasjd(idEmpleado,idDepartamento);
            nuevoFormulario.Show();
        }

        private void BtnVacaciones_Click(object sender, EventArgs e)
        {
            FrmVacacionesjd nuevoFormulario = new FrmVacacionesjd(idEmpleado,idDepartamento);
            nuevoFormulario.Show();
        }

        private void Btncapacitaciones_Click(object sender, EventArgs e)
        {
            FrmCapacitacionjd nuevoFormulario = new FrmCapacitacionjd(idEmpleado,idDepartamento);
            nuevoFormulario.Show();
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(
                (panel2.Width - label1.Width) / 2,
                (panel2.Height - label1.Height) / 2
            );
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CenterControls()
        {
            SetButtonWidthAndPosition(BtnAsistencia);
            SetButtonWidthAndPosition(Btncapacitaciones);
            SetButtonWidthAndPosition(BtnPermisos);
            SetButtonWidthAndPosition(Btnequipo);
            SetButtonWidthAndPosition(BtnVacaciones);
        }

        private void SetButtonWidthAndPosition(Control btn)
        {
            
            btn.Width = panelperfil.Width;

            
            btn.Location = new Point(
                (panel1.ClientSize.Width - btn.Width) / 2,
                btn.Location.Y
            );
        }

        
        
        
    }
}
