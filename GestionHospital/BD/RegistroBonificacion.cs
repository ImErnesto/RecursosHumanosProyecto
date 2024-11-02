using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class RegistroBonificacion
    {
        public long IdRegbonificacion { get; set; }
        public long? IdEmpleado { get; set; }
        public DateTime? RegFechaBonificacion { get; set; }
        public string RegDescripcion { get; set; }
        public decimal? RegMonto { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
