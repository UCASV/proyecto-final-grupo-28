using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class VaccinationDBContext : DbContext
    {
        public VaccinationDBContext()
        {
        }

        public VaccinationDBContext(DbContextOptions<VaccinationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<ChronicDisease> ChronicDiseases { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<CitizenxsideEffect> CitizenxsideEffects { get; set; }
        public virtual DbSet<DiseaseType> DiseaseTypes { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<InstitutionType> InstitutionTypes { get; set; }
        public virtual DbSet<LoginInfo> LoginInfos { get; set; }
        public virtual DbSet<SideEffect> SideEffects { get; set; }
        public virtual DbSet<StaffType> StaffTypes { get; set; }
        public virtual DbSet<VacQueue> VacQueues { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=VaccinationDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DuiCitizen)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui_citizen")
                    .IsFixedLength(true);

                entity.Property(e => e.FirstDoseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("first_dose_date");

                entity.Property(e => e.IdStaff)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("id_staff");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("place");

                entity.Property(e => e.SecondDoseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("second_dose_time");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DuiCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENT_CITIZEN");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdStaff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENT_STAFF");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("CABIN");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressCabin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address_cabin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.InCharge)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("in_charge");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ChronicDisease>(entity =>
            {
                entity.ToTable("CHRONIC_DISEASE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChronicDisease1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("chronic_disease");

                entity.Property(e => e.DuiCitizen)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui_citizen")
                    .IsFixedLength(true);

                entity.Property(e => e.IdDiseaseType).HasColumnName("id_disease_type");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.ChronicDiseases)
                    .HasForeignKey(d => d.DuiCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHRONIC_DISEASE_CITIZEN");

                entity.HasOne(d => d.IdDiseaseTypeNavigation)
                    .WithMany(p => p.ChronicDiseases)
                    .HasForeignKey(d => d.IdDiseaseType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISEASE_TYPE");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__CITIZEN__D876F1BEDDEE894E");

                entity.ToTable("CITIZEN");

                entity.Property(e => e.Dui)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui")
                    .IsFixedLength(true);

                entity.Property(e => e.AddressCitizen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address_citizen");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CitizenName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("citizen_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.IdInstitution).HasColumnName("id_institution");

                entity.Property(e => e.IdQueue).HasColumnName("id_queue");

                entity.Property(e => e.IdVaccination).HasColumnName("id_vaccination");

                entity.Property(e => e.Identifier)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("identifier")
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .HasConstraintName("FK_CITIZEN_INSTITUTION");

                entity.HasOne(d => d.IdQueueNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdQueue)
                    .HasConstraintName("FK_CITIZEN_QUEUE");

                entity.HasOne(d => d.IdVaccinationNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdVaccination)
                    .HasConstraintName("FK_CITIZEN_VACCINATION");
            });

            modelBuilder.Entity<CitizenxsideEffect>(entity =>
            {
                entity.HasKey(e => new { e.IdSideEffect, e.DuiCitizen })
                    .HasName("PK_CITXSE");

                entity.ToTable("CITIZENXSIDE_EFFECT");

                entity.Property(e => e.IdSideEffect).HasColumnName("id_side_effect");

                entity.Property(e => e.DuiCitizen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui_citizen")
                    .IsFixedLength(true);

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.CitizenxsideEffects)
                    .HasForeignKey(d => d.DuiCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CIT_SIDE_CITIZEN");

                entity.HasOne(d => d.IdSideEffectNavigation)
                    .WithMany(p => p.CitizenxsideEffects)
                    .HasForeignKey(d => d.IdSideEffect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CIT_SIDE_SIDE_EFFECT");
            });

            modelBuilder.Entity<DiseaseType>(entity =>
            {
                entity.ToTable("DISEASE_TYPE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DiseaseType1)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("disease_type");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("INSTITUTION");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.Institution1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("institution");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Institutions)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INSTITUTION_TYPE");
            });

            modelBuilder.Entity<InstitutionType>(entity =>
            {
                entity.ToTable("INSTITUTION_TYPE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InstType)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("inst_type");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.ToTable("LOGIN_INFO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.IdStaff)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("id_staff");

                entity.Property(e => e.LoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("login_date");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.LoginInfos)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOGIN_INFO_CABIN");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.LoginInfos)
                    .HasForeignKey(d => d.IdStaff)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOGIN_INFO_STAFF");
            });

            modelBuilder.Entity<SideEffect>(entity =>
            {
                entity.ToTable("SIDE_EFFECT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("effect");

                entity.Property(e => e.SeTime).HasColumnName("se_time");
            });

            modelBuilder.Entity<StaffType>(entity =>
            {
                entity.ToTable("STAFF_TYPE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.StaffType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("staff_type");
            });

            modelBuilder.Entity<VacQueue>(entity =>
            {
                entity.ToTable("VAC_QUEUE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.VacQueue1)
                    .HasColumnType("datetime")
                    .HasColumnName("vac_queue");
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.ToTable("VACCINATION");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.VaccinationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("vaccination_date");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("STAFF");

                entity.Property(e => e.Id)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.AddressStaff)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address_staff");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.NameStaff)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_staff");

                entity.Property(e => e.PasswordStaff)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password_staff")
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.UserStaff)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("user_staff")
                    .HasDefaultValueSql("('None')");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STAFF_TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
