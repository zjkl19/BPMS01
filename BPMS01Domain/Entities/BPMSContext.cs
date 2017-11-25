namespace BPMS01Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /*
    public class MyDbInitializer:IDatabaseInitializer<BPMSContext>
    {
        public void InitializeDatabase(BPMSContext context)
        {
            context.Database.CreateIfNotExists();

        }
    }
    */

    public partial class BPMSContext : DbContext
    {
        public BPMSContext()
            : base("name=BPMSContext")
        {
        }

        public virtual DbSet<bridge> bridge { get; set; }
        public virtual DbSet<contract> contract { get; set; }
        public virtual DbSet<inspection_project> inspection_project { get; set; }
        public virtual DbSet<r_inspection_project_staff> r_inspection_project_staff { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<bridge>()
                .HasMany(e => e.inspection_project)
                .WithRequired(e => e.bridge)
                .HasForeignKey(e => e.bridge_id);

            modelBuilder.Entity<contract>()
                .Property(e => e.no)
                .IsFixedLength();

            modelBuilder.Entity<contract>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<contract>()
                .HasMany(e => e.inspection_project)
                .WithRequired(e => e.contract)
                .HasForeignKey(e => e.contract_id);

            modelBuilder.Entity<inspection_project>()
                .Property(e => e.standard_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<inspection_project>()
                .HasMany(e => e.r_inspection_project_staff)
                .WithRequired(e => e.inspection_project)
                .HasForeignKey(e => e.inspection_project_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<staff>()
                .HasMany(e => e.contract)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.r_inspection_project_staff)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete(false);
        }

       
    }
}