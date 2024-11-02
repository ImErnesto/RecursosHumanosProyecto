using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Capacitacion
    {
        public long IdCapacitacion { get; set; }
        public string CapNombre { get; set; }
        public string CapDescripcion { get; set; }
        public DateTime CapFecha { get; set; }

        public string CapEstado { get; set; }
    }
}
