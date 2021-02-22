using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AzureApp
{
    public partial class ChallengeDatabaseContext : DbContext
    {
        public ChallengeDatabaseContext()
        {
        }

        public ChallengeDatabaseContext(DbContextOptions<ChallengeDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<DescriptionConsumer> DescriptionConsumers { get; set; }
        public virtual DbSet<EnrolledInChallenge> EnrolledInChallenges { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=challenge-server.database.windows.net;Initial Catalog=ChallengeDatabase;User ID=challengeadmin;Password=v9ZE4HxBYZVyJ5p5;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Challenge>(entity =>
            {
                entity.ToTable("Challenge");

                entity.Property(e => e.ChallengeId).HasColumnName("challenge_id");

                entity.Property(e => e.BeginningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("beginning_date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.NumberOfDays).HasColumnName("number_of_days");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Challenges)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Challenge__owner__6477ECF3");
            });

            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Consumer__B9BE370F33A0AA23");

                entity.ToTable("Consumer");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("lastName");

                entity.Property(e => e.LinkProfilePhoto)
                    .HasMaxLength(100)
                    .HasColumnName("linkProfilePhoto");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => e.CredentialsId)
                    .HasName("PK__Credenti__1F8DEEB005A921A2");

                entity.Property(e => e.CredentialsId).HasColumnName("credentials_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("password");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Credentials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Credentia__user___619B8048");
            });

            modelBuilder.Entity<DescriptionConsumer>(entity =>
            {
                entity.HasKey(e => e.DescriptionId)
                    .HasName("PK__Descript__DF380AEAEBA1AB59");

                entity.ToTable("Description_consumer");

                entity.Property(e => e.DescriptionId).HasColumnName("description_id");

                entity.Property(e => e.ChallengesCreated).HasColumnName("challenges_created");

                entity.Property(e => e.ChallengesFinished).HasColumnName("challenges_finished");

                entity.Property(e => e.ChallengesInUse).HasColumnName("challenges_in_use");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.DescriptionConsumers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Descripti__id_us__5EBF139D");
            });

            modelBuilder.Entity<EnrolledInChallenge>(entity =>
            {
                entity.HasKey(e => e.EnrollingId)
                    .HasName("PK__Enrolled__B78C71AFCFDAB27E");

                entity.ToTable("Enrolled_in_Challenge");

                entity.Property(e => e.EnrollingId).HasColumnName("enrolling_id");

                entity.Property(e => e.ChallengeId).HasColumnName("challenge_id");

                entity.Property(e => e.NumberDays).HasColumnName("number_days");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Challenge)
                    .WithMany(p => p.EnrolledInChallenges)
                    .HasForeignKey(d => d.ChallengeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrolled___chall__693CA210");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.EnrolledInChallenges)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrolled___statu__6B24EA82");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EnrolledInChallenges)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrolled___user___6A30C649");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
