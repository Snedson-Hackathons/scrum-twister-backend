using Microsoft.EntityFrameworkCore;
using Scrum_Twister.Core.Interfaces;
using Scrum_Twister.Core.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_Twister.Infrastructure.EfcInfrastructure
{
    public partial class ScrumTwisterContext : DbContext, IScrumTwisterContext
    {
        public ScrumTwisterContext()
        {
        }

        public ScrumTwisterContext(DbContextOptions<ScrumTwisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avatar> Avatars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Avatar>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
