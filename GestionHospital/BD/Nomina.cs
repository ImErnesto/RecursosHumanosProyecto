using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Nomina
    {
        public Nomina()
        {
            Nominaxempleado = new HashSet<Nominaxempleado>();
        }

        public long IdNomina { get; set; }
        public long? IdPeriodopago { get; set; }

        public virtual PeriodoPago IdPeriodopagoNavigation { get; set; }
        public virtual ICollection<Nominaxempleado> Nominaxempleado { get; set; }
    }
}
