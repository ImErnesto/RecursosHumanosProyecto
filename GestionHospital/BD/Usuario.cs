using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Usuario
    {
        public long IdUsuario { get; set; }
        public long? IdRol { get; set; }
        public long? IdEmpleado { get; set; }
        public string UsuName { get; set; }
        public string UsuEmail { get; set; }
        public string UsuPassword { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
