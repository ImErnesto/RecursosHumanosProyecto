﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class EmpleadoCapacitacion
    {
        public long? IdCapacitacion { get; set; }
        public long? IdEmpleado { get; set; }

        public virtual Capacitacion IdCapacitacionNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
