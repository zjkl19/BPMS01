namespace BPMS01Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<bridge> bridge { get; set; }
        public virtual DbSet<contract> contract { get; set; }
        public virtual DbSet<inspection_project> inspection_project { get; set; }
        public virtual DbSet<r_bridge_inspection_staff> r_bridge_inspection_staff { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bridge>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bridge>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<bridge>()
                .Property(e => e.structure_type)
                .HasPrecision(18, 0);

            modelBuilder.Entity<bridge>()
                .HasMany(e => e.inspection_project)
                .WithOptional(e => e.bridge)
                .HasForeignKey(e => e.bridge_id);

            modelBuilder.Entity<contract>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.staff_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.contract_no)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.contract_name)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.contract_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<contract>()
                .Property(e => e.contract_agmt_wk_cnt)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.project_location)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.delegation_client)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.dlg_contactperson)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.dlg_contactperson_phone)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .Property(e => e.accept_way)
                .IsUnicode(false);

            modelBuilder.Entity<contract>()
                .HasMany(e => e.inspection_project)
                .WithOptional(e => e.contract)
                .HasForeignKey(e => e.contract_id);

            modelBuilder.Entity<inspection_project>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<inspection_project>()
                .Property(e => e.contract_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<inspection_project>()
                .Property(e => e.bridge_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<inspection_project>()
                .Property(e => e.bridge_inspection)
                .HasPrecision(18, 0);

            modelBuilder.Entity<inspection_project>()
                .Property(e => e.standard_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<inspection_project>()
                .HasMany(e => e.r_bridge_inspection_staff)
                .WithRequired(e => e.inspection_project)
                .HasForeignKey(e => e.inspection_project_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<r_bridge_inspection_staff>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<r_bridge_inspection_staff>()
                .Property(e => e.inspection_project_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<r_bridge_inspection_staff>()
                .Property(e => e.staff_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.staff_no)
                .HasPrecision(18, 0);

            modelBuilder.Entity<staff>()
                .Property(e => e.staff_password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.staff_name)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.gender)
                .HasPrecision(18, 0);

            modelBuilder.Entity<staff>()
                .Property(e => e.office_phone)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.mobile_phone)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.job_title)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.education)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.contract)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.r_bridge_inspection_staff)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete(false);
        }
    }
}
