using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Cargo
    {
        public Cargo()
        {
            Empleado = new HashSet<Empleado>();
        }

        public long IdCargo { get; set; }
        public string CarNombre { get; set; }
        public string CarDescripcion { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
