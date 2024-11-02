using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class TipoAusencia
    {
        public TipoAusencia()
        {
            RegistroAusencia = new HashSet<RegistroAusencia>();
        }

        public long IdTipoausencia { get; set; }
        public string TipoNombre { get; set; }
        public string TipoDescripcion { get; set; }

        public virtual ICollection<RegistroAusencia> RegistroAusencia { get; set; }
    }
}
