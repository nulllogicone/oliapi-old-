namespace OliApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OliModel : DbContext
    {
        public OliModel()
            : base("name=OliModel")
        {
        }

        public virtual DbSet<PostIt> PostIt { get; set; }
        public virtual DbSet<TopLab> TopLab { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostIt>()
                .Property(e => e.PostIt1)
                .IsUnicode(false);

            modelBuilder.Entity<PostIt>()
                .Property(e => e.KooK)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PostIt>()
                .Property(e => e.Typ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PostIt>()
                .HasMany(e => e.TopLab)
                .WithRequired(e => e.PostIt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TopLab>()
                .Property(e => e.Lohn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TopLab>()
                .Property(e => e.Typ)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TopLab>()
                .HasMany(e => e.TopLab11)
                .WithOptional(e => e.TopLab2)
                .HasForeignKey(e => e.TopTopLabGuid);
        }
    }
}
