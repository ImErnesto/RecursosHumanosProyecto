using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionHospital.BD;
using GestionHospital.Formularios.Empleados;
using Microsoft.EntityFrameworkCore;

namespace GestionHospital.Formularios.Login
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form_Resized);
        }

        private void Form_Resized(object sender, EventArgs e)
        {
            centrarelementos();
        }

        private void centrarelementos()
        {
            int desplazamientoVertical = -40; 
            int espacioControles = 20;  
            int espacioGrande = 30;     
            int alturaTotal = logobd.Height + labellogin.Height + TxtUsuario.Height + paneluser.Height +
                Txtpassword.Height + panelpassword.Height + Btnlogin.Height + labelSalir.Height
                + (espacioControles * 7) + espacioGrande; 

            
            int inicioY = (panel1.Height - alturaTotal) / 2 + desplazamientoVertical;
            logobd.Location = new Point((panel1.Width - logobd.Width) / 2, inicioY);
            labellogin.Location = new Point((panel1.Width - labellogin.Width) / 2, logobd.Bottom + espacioControles);

            
            int posicionXUsuario = (panel1.Width - (logouser.Width + TxtUsuario.Width + 10)) / 2; 
            logouser.Location = new Point(posicionXUsuario, labellogin.Bottom + espacioControles);
            TxtUsuario.Location = new Point(logouser.Right + 10, logouser.Top + (logouser.Height - TxtUsuario.Height) / 2);
            paneluser.Location = new Point((panel1.Width - paneluser.Width) / 2, TxtUsuario.Bottom + espacioControles);

            
            int posicionXPassword = (panel1.Width - (picpassword.Width + Txtpassword.Width + 10)) / 2;
            picpassword.Location = new Point(posicionXPassword, paneluser.Bottom + espacioGrande); 
            Txtpassword.Location = new Point(picpassword.Right + 10, picpassword.Top + (picpassword.Height - Txtpassword.Height) / 2);
            panelpassword.Location = new Point((panel1.Width - panelpassword.Width) / 2, Txtpassword.Bottom + espacioControles);
            Btnlogin.Location = new Point((panel1.Width - Btnlogin.Width) / 2, panelpassword.Bottom + espacioGrande); 
            labelSalir.Location = new Point((panel1.Width - labelSalir.Width) / 2, Btnlogin.Bottom + espacioControles);
        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        this.Close();
        }

        private void Frmlogin_Load(object sender, EventArgs e)
        {
            TxtUsuario.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principalempleados nuevoFormulario = new Principalempleados(315); 
            nuevoFormulario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principaljefedepart nuevoFormulario = new Principaljefedepart(316,4); 
            nuevoFormulario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Principalrh nuevoFormulario = new Principalrh(317); 
            nuevoFormulario.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsuario.Text;
            string password = Txtpassword.Text;

            try
            {
                using (var dbContext = new prueba8Context())
                {
                    string hashedPassword = HashPasswordSHA512(password);
                    // Validar las credenciales
                    // Validar las credenciales y cargar la navegación de Rol
                    var usuario = dbContext.Usuario
                        .Include(u => u.IdRolNavigation)  // Incluir la relación de Rol
                        .FirstOrDefault(u => u.UsuName == username && u.UsuPassword == hashedPassword);


                    if (usuario != null)
                    {
                        // Obtener el empleado y su departamento
                       
                        var empleado = dbContext.Empleado.FirstOrDefault(ee => ee.IdEmpleado == usuario.IdEmpleado);

                        long idEmpleado = empleado.IdEmpleado;
                        long idDepartamento = empleado.IdDepartamento ?? 0; // Manejar el caso de un departamento null

                        // Obtener el rol del usuario (asociado al empleado)
                        string rolUsuario = usuario.IdRolNavigation.RolNombre;

                        // Redirigir al dashboard adecuado según el rol del usuario
                        switch (rolUsuario)
                        {
                            case "Empleado":
                                MostrarDashboardEmpleado(idEmpleado, idDepartamento);
                                break;

                            case "JefeDepartamento":
                                MostrarDashboardJefeDepartamento(idEmpleado, idDepartamento);
                                break;

                            case "JefeRecursosHumanos":
                                MostrarDashboardRecursosHumanos(idEmpleado);
                                break;

                            default:
                                MessageBox.Show("Rol de usuario no reconocido.");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}");
            }
        }


        private string HashPasswordSHA512(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha512.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        //Metodos para cada dashboard

        //Empleado
        private void MostrarDashboardEmpleado(long idEmpleado, long idDepartamento)
        {
            Principalempleados dashboardEmpleado = new Principalempleados(idEmpleado);  // Pasar los IDs
            dashboardEmpleado.Show();  // Mostrar el dashboard del empleado normal
            //this.Hide();  // Ocultar el formulario de login
        }

        //JefeDepartamento
        private void MostrarDashboardJefeDepartamento(long idEmpleado, long idDepartamento)
        {
            Principaljefedepart dashboardJefe = new Principaljefedepart(idEmpleado, idDepartamento);  // Pasar los IDs
            dashboardJefe.Show();  // Mostrar el dashboard del jefe de departamento
           // this.Hide();  // Ocultar el formulario de login
        }

        //Jefe Recursos Humanos
        private void MostrarDashboardRecursosHumanos(long idEmpleado)
        {
            Principalrh dashboardRH = new Principalrh(idEmpleado);  // Pasar los IDs
            dashboardRH.Show();  // Mostrar el dashboard del jefe de recursos humanos
            //this.Hide();  // Ocultar el formulario de login
        }

    }
}
