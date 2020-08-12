using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClass> TbClass { get; set; }
        public virtual DbSet<TbDegree> TbDegree { get; set; }
        public virtual DbSet<TbStu> TbStu { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=MUJUN\\MSSQLSERVER01;Initial Catalog=DBClass; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbClass>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__tb_class__7577345E02CE67A2");

                entity.ToTable("tb_class");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasMaxLength(20);

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasColumnName("className")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TbDegree>(entity =>
            {
                entity.HasKey(e => e.DegreeId);

                entity.ToTable("tb_degree");

                entity.Property(e => e.DegreeId).HasColumnName("degreeID");

                entity.Property(e => e.DegreeName)
                    .HasColumnName("degreeName")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TbStu>(entity =>
            {
                entity.HasKey(e => e.StuId)
                    .HasName("PK__tb_stu__AEC9BFAF1D4AFCF5");

                entity.ToTable("tb_stu");

                entity.HasIndex(e => e.StuId)
                    .HasName("IX_tb_stu")
                    .IsUnique();

                entity.Property(e => e.StuId)
                    .HasColumnName("stuID")
                    .HasMaxLength(20);

                entity.Property(e => e.ClassId)
                    .IsRequired()
                    .HasColumnName("classID")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((2018173803))");

                entity.Property(e => e.DegreeId)
                    .HasColumnName("degreeID")
                    .HasDefaultValueSql("((9))");

                entity.Property(e => e.StuAddress)
                    .IsRequired()
                    .HasColumnName("stuAddress")
                    .HasMaxLength(20);

                entity.Property(e => e.StuBirthday)
                    .HasColumnName("stuBirthday")
                    .HasColumnType("date");

                entity.Property(e => e.StuHobby)
                    .IsRequired()
                    .HasColumnName("stuHobby")
                    .HasMaxLength(20);

                entity.Property(e => e.StuImage)
                    .HasColumnName("stuImage")
                    .HasMaxLength(20);

                entity.Property(e => e.StuName)
                    .IsRequired()
                    .HasColumnName("stuName")
                    .HasMaxLength(20);

                entity.Property(e => e.StuPhone)
                    .IsRequired()
                    .HasColumnName("stuPhone")
                    .HasMaxLength(20);

                entity.Property(e => e.StuSex)
                    .HasColumnName("stuSex")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TbStu)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_stu__classID__1367E606");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.TbStu)
                    .HasForeignKey(d => d.DegreeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_stu_tb_stu1");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("tb_user");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UserPwd)
                    .IsRequired()
                    .HasColumnName("userPwd")
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
