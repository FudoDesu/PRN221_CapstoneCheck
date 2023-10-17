using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class CapstoneProjectCheckContext : DbContext
    {
        public CapstoneProjectCheckContext()
        {
        }

        public CapstoneProjectCheckContext(DbContextOptions<CapstoneProjectCheckContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mentor> Mentors { get; set; } = null!;
        public virtual DbSet<MentorTopic> MentorTopics { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGroup> StudentGroups { get; set; } = null!;
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        public string GetConnectionString()
        {
            string connectionString = null;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.json", true, true)
                .Build();
            connectionString = config["ConnectionStrings:DefaultConnection"];
            return connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString()); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.ToTable("Mentor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MentorTopic>(entity =>
            {
                entity.ToTable("MentorTopic");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.MentorId).HasColumnName("MentorID");

                entity.Property(e => e.SubMentorId).HasColumnName("SubMentorID");

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.MentorTopicMentors)
                    .HasForeignKey(d => d.MentorId)
                    .HasConstraintName("FK__MentorTop__Mento__33D4B598");

                entity.HasOne(d => d.SubMentor)
                    .WithMany(p => p.MentorTopicSubMentors)
                    .HasForeignKey(d => d.SubMentorId)
                    .HasConstraintName("FK__MentorTop__SubMe__34C8D9D1");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.MentorTopics)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__MentorTop__Topic__35BCFE0A");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Student__GroupID__36B12243");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Student__Semeste__46E78A0C");
            });

            modelBuilder.Entity<StudentGroup>(entity =>
            {
                entity.ToTable("StudentGroup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.LeaderId).HasColumnName("LeaderID");

                entity.Property(e => e.TopicId).HasColumnName("TopicID");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.StudentGroups)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__StudentGr__Topic__4316F928");
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.ToTable("StudentSubject");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentSu__Stude__440B1D61");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__StudentSu__Subje__44FF419A");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
