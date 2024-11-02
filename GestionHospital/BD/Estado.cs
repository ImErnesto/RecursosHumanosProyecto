using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Estado
    {
        public Estado()
        {
            RegistroAusencia = new HashSet<RegistroAusencia>();
            Vacacion = new HashSet<Vacacion>();
        }

        public long IdEstado { get; set; }
        public string EstNombre { get; set; }

        public virtual ICollection<RegistroAusencia> RegistroAusencia { get; set; }
        public virtual ICollection<Vacacion> Vacacion { get; set; }
    }
}
