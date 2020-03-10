using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreTest.Models
{
    public partial class db_electricity_networkContext : DbContext
    {
        public db_electricity_networkContext()
        {
        }

        public db_electricity_networkContext(DbContextOptions<db_electricity_networkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TLog> TLog { get; set; }
        public virtual DbSet<TPower> TPower { get; set; }
        public virtual DbSet<TRolePower> TRolePower { get; set; }
        public virtual DbSet<TRoleinfo> TRoleinfo { get; set; }
        public virtual DbSet<TUserRole> TUserRole { get; set; }
        public virtual DbSet<TUserinfo> TUserinfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=123456;database=db_electricity_network");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TLog>(entity =>
            {
                entity.ToTable("t_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Log)
                    .HasColumnName("log")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Module)
                    .HasColumnName("module")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OperatorIdcard)
                    .HasColumnName("operator_idcard")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.OperatorName)
                    .HasColumnName("operator_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OperatorRole)
                    .HasColumnName("operator_role")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TPower>(entity =>
            {
                entity.ToTable("t_power");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.PowerInterface)
                    .IsRequired()
                    .HasColumnName("power_interface")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PowerName)
                    .IsRequired()
                    .HasColumnName("power_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TRolePower>(entity =>
            {
                entity.ToTable("t_role_power");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.PowerId)
                    .HasColumnName("power_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TRoleinfo>(entity =>
            {
                entity.ToTable("t_roleinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleNameCn)
                    .IsRequired()
                    .HasColumnName("role_name_cn")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.RoleNameEn)
                    .IsRequired()
                    .HasColumnName("role_name_en")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TUserRole>(entity =>
            {
                entity.ToTable("t_user_role");

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_id");

                entity.HasIndex(e => e.UserIdcard)
                    .HasName("fk_user_idcard");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserIdcard)
                    .IsRequired()
                    .HasColumnName("user_idcard")
                    .HasColumnType("char(36)");
            });

            modelBuilder.Entity<TUserinfo>(entity =>
            {
                entity.ToTable("t_userinfo");

                entity.HasIndex(e => e.Idcard)
                    .HasName("uk_idcard")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(32)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Idcard)
                    .IsRequired()
                    .HasColumnName("idcard")
                    .HasColumnType("char(18)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("enum('男','女')")
                    .HasDefaultValueSql("'男'");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''");
            });
        }
    }
}
