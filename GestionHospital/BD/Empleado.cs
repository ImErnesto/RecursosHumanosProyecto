using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class Empleado
    {
        public Empleado()
        {
            Asistencia = new HashSet<Asistencia>();
            Departamento = new HashSet<Departamento>();
            Nominaxempleado = new HashSet<Nominaxempleado>();
            RegistroAusencia = new HashSet<RegistroAusencia>();
            RegistroBonificacion = new HashSet<RegistroBonificacion>();
            RegistroDeduccion = new HashSet<RegistroDeduccion>();
            Usuario = new HashSet<Usuario>();
            Vacacion = new HashSet<Vacacion>();
        }

        public long IdEmpleado { get; set; }
        public long? IdCargo { get; set; }
        public long? IdDepartamento { get; set; }
        public string EmpNombres { get; set; }
        public string EmpApellidos { get; set; }
        public string EmpDui { get; set; }
        public DateTime EmpFechanacimiento { get; set; }
        public string EmpDireccion { get; set; }
        public string EmpTelefono { get; set; }
        public string EmpEmail { get; set; }
        public decimal? EmpSalarioBruto { get; set; }

        public string EmpEstado { get; set; }
        public virtual Cargo IdCargoNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Departamento> Departamento { get; set; }
        public virtual ICollection<Nominaxempleado> Nominaxempleado { get; set; }
        public virtual ICollection<RegistroAusencia> RegistroAusencia { get; set; }
        public virtual ICollection<RegistroBonificacion> RegistroBonificacion { get; set; }
        public virtual ICollection<RegistroDeduccion> RegistroDeduccion { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vacacion> Vacacion { get; set; }
    }
}
