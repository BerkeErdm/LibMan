using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibMan1._2.Models.DB
{
    public partial class LibManContext : DbContext
    {
        public LibManContext()
        {
        }

        public LibManContext(DbContextOptions<LibManContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TableAdminInfo> TableAdminInfo { get; set; }
        public virtual DbSet<TableBookInfo> TableBookInfo { get; set; }
        public virtual DbSet<TableUserInfo> TableUserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableAdminInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Table_AdminInfo");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Table_AdminInfo_Table_UserInfo");
            });

            modelBuilder.Entity<TableBookInfo>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("Table_BookInfo");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.BookName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.BookSummary)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Categories)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Imagee)
                .HasMaxLength(100)
                .IsFixedLength();

                entity.Property(e => e.ReadingStatus)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TableUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Table_UserInfo");

                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.SurName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PhotoPath)
                .HasMaxLength(50)
                .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}