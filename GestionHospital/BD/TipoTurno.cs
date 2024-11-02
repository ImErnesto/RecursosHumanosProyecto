using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class TipoTurno
    {
        public TipoTurno()
        {
            Turno = new HashSet<Turno>();
        }

        public long IdTipoturno { get; set; }
        public string TipNombre { get; set; }

        public virtual ICollection<Turno> Turno { get; set; }
    }
}
