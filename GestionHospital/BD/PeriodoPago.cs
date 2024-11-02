using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class PeriodoPago
    {
        public PeriodoPago()
        {
            Nomina = new HashSet<Nomina>();
        }

        public long IdPeriodopago { get; set; }
        public string PerNombre { get; set; }
        public DateTime PerInicio { get; set; }
        public DateTime PerFin { get; set; }

        public virtual ICollection<Nomina> Nomina { get; set; }
    }
}
