using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestionHospital.BD
{
    public partial class prueba8Context : DbContext
    {
        public prueba8Context()
        {
        }

        public prueba8Context(DbContextOptions<prueba8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Capacitacion> Capacitacion { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EmpleadoCapacitacion> EmpleadoCapacitacion { get; set; }
        public virtual DbSet<Empleadoxcapacitacion> Empleadoxcapacitacion { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Nomina> Nomina { get; set; }
        public virtual DbSet<Nominaxempleado> Nominaxempleado { get; set; }
        public virtual DbSet<PeriodoPago> PeriodoPago { get; set; }
        public virtual DbSet<RegistroAusencia> RegistroAusencia { get; set; }
        public virtual DbSet<RegistroBonificacion> RegistroBonificacion { get; set; }
        public virtual DbSet<RegistroDeduccion> RegistroDeduccion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoAusencia> TipoAusencia { get; set; }
        public virtual DbSet<TipoTurno> TipoTurno { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vacacion> Vacacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                string connectionString = ConfigurationManager.ConnectionStrings["cadenaCon"].ConnectionString;
                optionsBuilder.UseNpgsql(connectionString); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(e => e.IdAsistencia)
                    .HasName("asistencia_pkey");

                entity.ToTable("asistencia");

                entity.Property(e => e.IdAsistencia).HasColumnName("id_asistencia");

                entity.Property(e => e.AsiEntrada).HasColumnName("asi_entrada");

                entity.Property(e => e.AsiFechaprobacion)
                    .HasColumnName("asi_fechaprobacion")
                    .HasColumnType("date");

                entity.Property(e => e.AsiSalida).HasColumnName("asi_salida");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdTurno).HasColumnName("id_turno");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("asistencia_id_empleado_fkey");

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdTurno)
                    .HasConstraintName("asistencia_id_turno_fkey");
            });

            modelBuilder.Entity<Capacitacion>(entity =>
            {
                entity.HasKey(e => e.IdCapacitacion)
                    .HasName("capacitacion_pkey");

                entity.ToTable("capacitacion");

                entity.Property(e => e.IdCapacitacion).HasColumnName("id_capacitacion");

                entity.Property(e => e.CapDescripcion)
                    .HasColumnName("cap_descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.CapFecha)
                    .HasColumnName("cap_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.CapNombre)
                    .IsRequired()
                    .HasColumnName("cap_nombre")
                    .HasMaxLength(255);
               
                entity.Property(e => e.CapEstado)
             .IsRequired()
             .HasColumnName("cap_estado")
             .HasMaxLength(10);
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("cargo_pkey");

                entity.ToTable("cargo");

                entity.HasIndex(e => e.CarNombre)
                    .HasName("cargo_car_nombre_key")
                    .IsUnique();

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.CarDescripcion)
                    .HasColumnName("car_descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.CarNombre)
                    .IsRequired()
                    .HasColumnName("car_nombre")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("departamento_pkey");

                entity.ToTable("departamento");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.DepDescripcion)
                    .HasColumnName("dep_descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.DepNombre)
                    .IsRequired()
                    .HasColumnName("dep_nombre")
                    .HasMaxLength(255);

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Departamento)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("fk_empleado");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("empleado_pkey");

                entity.ToTable("empleado");

                entity.HasIndex(e => e.EmpDui)
                    .HasName("empleado_emp_dui_key")
                    .IsUnique();

                entity.HasIndex(e => e.EmpEmail)
                    .HasName("empleado_emp_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.EmpTelefono)
                    .HasName("empleado_emp_telefono_key")
                    .IsUnique();

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.EmpApellidos)
                    .IsRequired()
                    .HasColumnName("emp_apellidos")
                    .HasMaxLength(255);

                entity.Property(e => e.EmpDireccion)
                    .HasColumnName("emp_direccion")
                    .HasMaxLength(255);

                entity.Property(e => e.EmpDui)
                    .IsRequired()
                    .HasColumnName("emp_dui")
                    .HasMaxLength(9)
                    .IsFixedLength();

                entity.Property(e => e.EmpEmail)
                    .HasColumnName("emp_email")
                    .HasMaxLength(255);

                entity.Property(e => e.EmpFechanacimiento)
                    .HasColumnName("emp_fechanacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.EmpNombres)
                    .IsRequired()
                    .HasColumnName("emp_nombres")
                    .HasMaxLength(255);

                entity.Property(e => e.EmpSalarioBruto)
                    .HasColumnName("emp_salario_bruto")
                    .HasColumnType("numeric(38,2)");

                entity.Property(e => e.EmpTelefono)
                    .HasColumnName("emp_telefono")
                    .HasMaxLength(255);

                entity.Property(e => e.EmpEstado)
               .IsRequired()
               .HasColumnName("emp_estado")
               .HasMaxLength(10);


                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("empleado_id_cargo_fkey");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("fk_departamento");
            });

            modelBuilder.Entity<EmpleadoCapacitacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("empleado_capacitacion");

                entity.Property(e => e.IdCapacitacion).HasColumnName("id_capacitacion");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.HasOne(d => d.IdCapacitacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCapacitacion)
                    .HasConstraintName("empleado_capacitacion_id_capacitacion_fkey");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("empleado_capacitacion_id_empleado_fkey");
            });

            modelBuilder.Entity<Empleadoxcapacitacion>(entity =>
            {
                // Definir clave primaria compuesta con HasKey()
                entity.HasKey(e => new { e.IdEmpleado, e.IdCapacitacion });

                entity.ToTable("empleadoxcapacitacion");

                entity.Property(e => e.IdCapacitacion).HasColumnName("id_capacitacion");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                // Definición de la relación con Capacitacion
                entity.HasOne(d => d.IdCapacitacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCapacitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkaj96s4r82mgaje92kl7bsdaok");

                // Definición de la relación con Empleado
                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fko1n4qpwgcc7r3nkkvkypyeuf2");
            });


            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("estado_pkey");

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.EstNombre)
                    .IsRequired()
                    .HasColumnName("est_nombre")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.HasKey(e => e.IdNomina)
                    .HasName("nomina_pkey");

                entity.ToTable("nomina");

                entity.Property(e => e.IdNomina).HasColumnName("id_nomina");

                entity.Property(e => e.IdPeriodopago).HasColumnName("id_periodopago");

                entity.HasOne(d => d.IdPeriodopagoNavigation)
                    .WithMany(p => p.Nomina)
                    .HasForeignKey(d => d.IdPeriodopago)
                    .HasConstraintName("nomina_id_periodopago_fkey");
            });

            modelBuilder.Entity<Nominaxempleado>(entity =>
            {
                entity.HasKey(e => new { e.IdNomina, e.IdEmpleado })
                    .HasName("nominaxempleado_pkey");

                entity.ToTable("nominaxempleado");

                entity.Property(e => e.IdNomina).HasColumnName("id_nomina");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.NomBonificaciones)
                    .HasColumnName("nom_bonificaciones")
                    .HasColumnType("numeric(38,2)");

                entity.Property(e => e.NomDeduccionSalarial)
                    .HasColumnName("nom_deduccion_salarial")
                    .HasColumnType("numeric(38,2)");

                entity.Property(e => e.NomDeducciones)
                    .HasColumnName("nom_deducciones")
                    .HasColumnType("numeric(38,2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Nominaxempleado)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nominaxempleado_id_empleado_fkey");

                entity.HasOne(d => d.IdNominaNavigation)
                    .WithMany(p => p.Nominaxempleado)
                    .HasForeignKey(d => d.IdNomina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nominaxempleado_id_nomina_fkey");
            });

            modelBuilder.Entity<PeriodoPago>(entity =>
            {
                entity.HasKey(e => e.IdPeriodopago)
                    .HasName("periodo_pago_pkey");

                entity.ToTable("periodo_pago");

                entity.Property(e => e.IdPeriodopago).HasColumnName("id_periodopago");

                entity.Property(e => e.PerFin)
                    .HasColumnName("per_fin")
                    .HasColumnType("date");

                entity.Property(e => e.PerInicio)
                    .HasColumnName("per_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.PerNombre)
                    .IsRequired()
                    .HasColumnName("per_nombre")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<RegistroAusencia>(entity =>
            {
                entity.HasKey(e => e.IdRegistroausencias)
                    .HasName("registro_ausencia_pkey");

                entity.ToTable("registro_ausencia");

                entity.Property(e => e.IdRegistroausencias).HasColumnName("id_registroausencias");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdTipoausencia).HasColumnName("id_tipoausencia");

                entity.Property(e => e.RegFechafin)
                    .HasColumnName("reg_fechafin")
                    .HasColumnType("date");

                entity.Property(e => e.RegFechainicio)
                    .HasColumnName("reg_fechainicio")
                    .HasColumnType("date");

                entity.Property(e => e.RegFechasolicitud)
                    .HasColumnName("reg_fechasolicitud")
                    .HasColumnType("date");

                entity.Property(e => e.RegJustificacion)
                    .HasColumnName("reg_justificacion")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroAusencia)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("registro_ausencia_id_empleado_fkey");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.RegistroAusencia)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("registro_ausencia_id_estado_fkey");

                entity.HasOne(d => d.IdTipoausenciaNavigation)
                    .WithMany(p => p.RegistroAusencia)
                    .HasForeignKey(d => d.IdTipoausencia)
                    .HasConstraintName("registro_ausencia_id_tipoausencia_fkey");
            });

            modelBuilder.Entity<RegistroBonificacion>(entity =>
            {
                entity.HasKey(e => e.IdRegbonificacion)
                    .HasName("registro_bonificacion_pkey");

                entity.ToTable("registro_bonificacion");

                entity.Property(e => e.IdRegbonificacion).HasColumnName("id_regbonificacion");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.RegDescripcion)
                    .HasColumnName("reg_descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.RegFechaBonificacion)
                    .HasColumnName("reg_fecha_bonificacion")
                    .HasColumnType("date");

                entity.Property(e => e.RegMonto)
                    .HasColumnName("reg_monto")
                    .HasColumnType("numeric(38,2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroBonificacion)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("registro_bonificacion_id_empleado_fkey");
            });

            modelBuilder.Entity<RegistroDeduccion>(entity =>
            {
                entity.HasKey(e => e.IdRegdeduccion)
                    .HasName("registro_deduccion_pkey");

                entity.ToTable("registro_deduccion");

                entity.Property(e => e.IdRegdeduccion).HasColumnName("id_regdeduccion");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdRegistroausencias).HasColumnName("id_registroausencias");

                entity.Property(e => e.RegFechadeduccion)
                    .HasColumnName("reg_fechadeduccion")
                    .HasColumnType("date");

                entity.Property(e => e.RegMonto)
                    .HasColumnName("reg_monto")
                    .HasColumnType("numeric(32,2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroDeduccion)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("registro_deduccion_id_empleado_fkey");

                entity.HasOne(d => d.IdRegistroausenciasNavigation)
                    .WithMany(p => p.RegistroDeduccion)
                    .HasForeignKey(d => d.IdRegistroausencias)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_registro_ausencia");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("rol_pkey");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.RolNombre)
                    .IsRequired()
                    .HasColumnName("rol_nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoAusencia>(entity =>
            {
                entity.HasKey(e => e.IdTipoausencia)
                    .HasName("tipo_ausencia_pkey");

                entity.ToTable("tipo_ausencia");

                entity.Property(e => e.IdTipoausencia).HasColumnName("id_tipoausencia");

                entity.Property(e => e.TipoDescripcion)
                    .HasColumnName("tipo_descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.TipoNombre)
                    .IsRequired()
                    .HasColumnName("tipo_nombre")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TipoTurno>(entity =>
            {
                entity.HasKey(e => e.IdTipoturno)
                    .HasName("tipo_turno_pkey");

                entity.ToTable("tipo_turno");

                entity.Property(e => e.IdTipoturno).HasColumnName("id_tipoturno");

                entity.Property(e => e.TipNombre)
                    .IsRequired()
                    .HasColumnName("tip_nombre")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("turno_pkey");

                entity.ToTable("turno");

                entity.Property(e => e.IdTurno).HasColumnName("id_turno");

                entity.Property(e => e.IdTipoturno).HasColumnName("id_tipoturno");

                entity.Property(e => e.TurFecha)
                    .HasColumnName("tur_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.TurFin)
                    .HasColumnName("tur_fin")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.TurInicio)
                    .HasColumnName("tur_inicio")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.IdTipoturnoNavigation)
                    .WithMany(p => p.Turno)
                    .HasForeignKey(d => d.IdTipoturno)
                    .HasConstraintName("turno_id_tipoturno_fkey");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("usuario_pkey");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UsuEmail)
                    .IsRequired()
                    .HasColumnName("usu_email")
                    .HasMaxLength(100);

                entity.Property(e => e.UsuName)
                    .IsRequired()
                    .HasColumnName("usu_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UsuPassword)
                    .IsRequired()
                    .HasColumnName("usu_password")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("usuario_id_empleado_fkey");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("usuario_id_rol_fkey");
            });

            modelBuilder.Entity<Vacacion>(entity =>
            {
                entity.HasKey(e => e.IdVacacion)
                    .HasName("vacacion_pkey");

                entity.ToTable("vacacion");

                entity.Property(e => e.IdVacacion).HasColumnName("id_vacacion");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");


                entity.Property(e => e.VacFechafin)
                    .HasColumnName("vac_fechafin")
                    .HasColumnType("date");

                entity.Property(e => e.VacFechainicio)
                    .HasColumnName("vac_fechainicio")
                    .HasColumnType("date");

                entity.Property(e => e.VacFechaprobacion)
                    .HasColumnName("vac_fechaprobacion")
                    .HasColumnType("date");

                entity.Property(e => e.VacFechasolicitud)
                    .HasColumnName("vac_fechasolicitud")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Vacacion)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("vacacion_id_empleado_fkey");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Vacacion)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("vacacion_id_estado_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
