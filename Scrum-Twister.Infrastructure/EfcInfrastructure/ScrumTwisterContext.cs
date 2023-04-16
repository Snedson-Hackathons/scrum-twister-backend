using Microsoft.EntityFrameworkCore;
using Scrum_Twister.Core.Interfaces;
using Scrum_Twister.Core.Models.DbModels;

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

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Avatar> Avatars { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionStatus> SessionStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ActivityBlob)
                    .HasColumnType("jsonb")
                    .HasColumnName("activity_blob");

                entity.Property(e => e.ActivityType).HasColumnName("activity_type");

                entity.Property(e => e.Subtitle).HasColumnName("subtitle");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Avatar>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ActivityAnswered).HasColumnName("activity_answered");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.AvatarId).HasColumnName("avatar_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("activity_id_fkey");

                entity.HasOne(d => d.Avatar)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.AvatarId)
                    .HasConstraintName("avatar_id_fkey");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("session_id_fkey");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasIndex(e => e.InviteCode, "invite_code_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.InviteCode).HasColumnName("invite_code");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("status_id_fkey");
            });

            modelBuilder.Entity<SessionStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, 0L, null, null, null);

                entity.Property(e => e.StatusTitle).HasColumnName("status_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
