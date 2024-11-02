using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Turno
    {
        public Turno()
        {
            Asistencia = new HashSet<Asistencia>();
        }

        public long IdTurno { get; set; }
        public long? IdTipoturno { get; set; }
        public DateTime TurFecha { get; set; }
        public TimeSpan TurInicio { get; set; }
        public TimeSpan TurFin { get; set; }

        public virtual TipoTurno IdTipoturnoNavigation { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
    }
}
