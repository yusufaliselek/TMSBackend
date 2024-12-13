using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementSystemBackend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    OldStatus = table.Column<int>(type: "int", nullable: false),
                    NewStatus = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUpdates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationRoles_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationRolePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationRoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationRolePermissions_OrganizationRoles_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "OrganizationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationRolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganizationRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrganizationRoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganizationRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrganizationRoles_OrganizationRoles_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "OrganizationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrganizationRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2018), 0, "Organizasyon bilgilerini düzenleme yetkisi", false, "EditOrganization", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2034), 0 },
                    { 2, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2039), 0, "Organizasyon silme yetkisi", false, "DeleteOrganization", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2039), 0 },
                    { 3, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2040), 0, "Organizasyon bilgilerini görüntüleme yetkisi", false, "ViewOrganization", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2041), 0 },
                    { 4, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2042), 0, "Organizasyon içinde yeni rol oluşturma yetkisi", false, "CreateRole", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2042), 0 },
                    { 5, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2043), 0, "Organizasyon içindeki rolleri düzenleme yetkisi", false, "EditRole", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2043), 0 },
                    { 6, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2045), 0, "Organizasyon içindeki rolleri silme yetkisi", false, "DeleteRole", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2045), 0 },
                    { 7, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2046), 0, "Rolleri kullanıcılara atama yetkisi", false, "AssignRole", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2046), 0 },
                    { 8, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2047), 0, "Rolleri görüntüleme yetkisi", false, "ViewRoles", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2048), 0 },
                    { 9, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2048), 0, "Yeni görev oluşturma yetkisi", false, "CreateTask", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2049), 0 },
                    { 10, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2050), 0, "Mevcut görevleri düzenleme yetkisi", false, "EditTask", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2050), 0 },
                    { 11, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2051), 0, "Görev silme yetkisi", false, "DeleteTask", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2052), 0 },
                    { 12, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2052), 0, "Görev bilgilerini görüntüleme yetkisi", false, "ViewTask", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2053), 0 },
                    { 13, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2054), 0, "Görevleri kullanıcılara atama yetkisi", false, "AssignTask", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2054), 0 },
                    { 14, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2055), 0, "Görev durumunu güncelleme yetkisi", false, "UpdateTaskStatus", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2055), 0 },
                    { 15, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2056), 0, "Görev durumu güncellemelerini görüntüleme yetkisi", false, "ViewTaskUpdates", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2056), 0 },
                    { 16, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2057), 0, "Organizasyona kullanıcı ekleme yetkisi", false, "AddUserToOrganization", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2057), 0 },
                    { 17, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2058), 0, "Organizasyondan kullanıcı çıkarma yetkisi", false, "RemoveUserFromOrganization", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2058), 0 },
                    { 18, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2059), 0, "Organizasyon kullanıcılarını görüntüleme yetkisi", false, "ViewOrganizationUsers", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2060), 0 },
                    { 19, new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2061), 0, "İzinleri yönetme yetkisi", false, "ManagePermissions", new DateTime(2024, 12, 13, 20, 11, 57, 909, DateTimeKind.Local).AddTicks(2061), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRolePermissions_OrganizationRoleId",
                table: "OrganizationRolePermissions",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRolePermissions_PermissionId",
                table: "OrganizationRolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRoles_OrganizationId",
                table: "OrganizationRoles",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizationRoles_OrganizationRoleId",
                table: "UserOrganizationRoles",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizationRoles_UserId",
                table: "UserOrganizationRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationRolePermissions");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskUpdates");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserOrganizationRoles");

            migrationBuilder.DropTable(
                name: "UserOrganizations");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "OrganizationRoles");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
