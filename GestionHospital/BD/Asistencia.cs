using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Asistencia
    {
        public long IdAsistencia { get; set; }
        public long? IdEmpleado { get; set; }
        public long? IdTurno { get; set; }
        public DateTime AsiEntrada { get; set; }
        public DateTime? AsiSalida { get; set; }
        public DateTime? AsiFechaprobacion { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Turno IdTurnoNavigation { get; set; }
    }
}
