﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystemBackend.DataAccess;

#nullable disable

namespace TaskManagementSystemBackend.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.OrganizationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationRoles");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.OrganizationRolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationRoleId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationRoleId");

                    b.HasIndex("PermissionId");

                    b.ToTable("OrganizationRolePermissions");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2018),
                            CreatedBy = 0,
                            Description = "Organizasyon bilgilerini düzenleme yetkisi",
                            IsDeleted = false,
                            Name = "EditOrganization",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2034),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2039),
                            CreatedBy = 0,
                            Description = "Organizasyon silme yetkisi",
                            IsDeleted = false,
                            Name = "DeleteOrganization",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2039),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2040),
                            CreatedBy = 0,
                            Description = "Organizasyon bilgilerini görüntüleme yetkisi",
                            IsDeleted = false,
                            Name = "ViewOrganization",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2041),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2042),
                            CreatedBy = 0,
                            Description = "Organizasyon içinde yeni rol oluşturma yetkisi",
                            IsDeleted = false,
                            Name = "CreateRole",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2042),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2043),
                            CreatedBy = 0,
                            Description = "Organizasyon içindeki rolleri düzenleme yetkisi",
                            IsDeleted = false,
                            Name = "EditRole",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2043),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2045),
                            CreatedBy = 0,
                            Description = "Organizasyon içindeki rolleri silme yetkisi",
                            IsDeleted = false,
                            Name = "DeleteRole",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2045),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2046),
                            CreatedBy = 0,
                            Description = "Rolleri kullanıcılara atama yetkisi",
                            IsDeleted = false,
                            Name = "AssignRole",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2046),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2047),
                            CreatedBy = 0,
                            Description = "Rolleri görüntüleme yetkisi",
                            IsDeleted = false,
                            Name = "ViewRoles",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2048),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2048),
                            CreatedBy = 0,
                            Description = "Yeni görev oluşturma yetkisi",
                            IsDeleted = false,
                            Name = "CreateTask",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2049),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2050),
                            CreatedBy = 0,
                            Description = "Mevcut görevleri düzenleme yetkisi",
                            IsDeleted = false,
                            Name = "EditTask",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2050),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2051),
                            CreatedBy = 0,
                            Description = "Görev silme yetkisi",
                            IsDeleted = false,
                            Name = "DeleteTask",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2052),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2052),
                            CreatedBy = 0,
                            Description = "Görev bilgilerini görüntüleme yetkisi",
                            IsDeleted = false,
                            Name = "ViewTask",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2053),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2054),
                            CreatedBy = 0,
                            Description = "Görevleri kullanıcılara atama yetkisi",
                            IsDeleted = false,
                            Name = "AssignTask",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2054),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2055),
                            CreatedBy = 0,
                            Description = "Görev durumunu güncelleme yetkisi",
                            IsDeleted = false,
                            Name = "UpdateTaskStatus",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2055),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2056),
                            CreatedBy = 0,
                            Description = "Görev durumu güncellemelerini görüntüleme yetkisi",
                            IsDeleted = false,
                            Name = "ViewTaskUpdates",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2056),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2057),
                            CreatedBy = 0,
                            Description = "Organizasyona kullanıcı ekleme yetkisi",
                            IsDeleted = false,
                            Name = "AddUserToOrganization",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2057),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2058),
                            CreatedBy = 0,
                            Description = "Organizasyondan kullanıcı çıkarma yetkisi",
                            IsDeleted = false,
                            Name = "RemoveUserFromOrganization",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2058),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2059),
                            CreatedBy = 0,
                            Description = "Organizasyon kullanıcılarını görüntüleme yetkisi",
                            IsDeleted = false,
                            Name = "ViewOrganizationUsers",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2060),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2061),
                            CreatedBy = 0,
                            Description = "İzinleri yönetme yetkisi",
                            IsDeleted = false,
                            Name = "ManagePermissions",
                            UpdatedAt = new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2061),
                            UpdatedBy = 0
                        });
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.TaskBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.TaskUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NewStatus")
                        .HasColumnType("int");

                    b.Property<int>("OldStatus")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaskUpdates");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AccessTokenExpiration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RefreshedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.UserOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOrganizations");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.UserOrganizationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationRoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrganizationRoles");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.Organization", b =>
                {
                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.User", null)
                        .WithMany("Organizations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.OrganizationRole", b =>
                {
                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.Organization", "Organization")
                        .WithMany("Roles")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.OrganizationRolePermission", b =>
                {
                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.OrganizationRole", "OrganizationRole")
                        .WithMany("OrganizationRolePermissions")
                        .HasForeignKey("OrganizationRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.Permission", "Permission")
                        .WithMany("OrganizationRolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationRole");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.TaskBase", b =>
                {
                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.Token", b =>
                {
                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.UserOrganizationRole", b =>
                {
                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.OrganizationRole", "OrganizationRole")
                        .WithMany("UserOrganizationRoles")
                        .HasForeignKey("OrganizationRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystemBackend.DataAccess.Entities.User", "User")
                        .WithMany("UserOrganizationRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.Organization", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.OrganizationRole", b =>
                {
                    b.Navigation("OrganizationRolePermissions");

                    b.Navigation("UserOrganizationRoles");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.Permission", b =>
                {
                    b.Navigation("OrganizationRolePermissions");
                });

            modelBuilder.Entity("TaskManagementSystemBackend.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Organizations");

                    b.Navigation("UserOrganizationRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
