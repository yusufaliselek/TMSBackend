using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementSystemBackend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationRole",
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
                    table.PrimaryKey("PK_OrganizationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationRole_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
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
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganizationRole",
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
                    table.PrimaryKey("PK_UserOrganizationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrganizationRole_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrganizationRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationRolePermission",
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
                    table.PrimaryKey("PK_OrganizationRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationRolePermission_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationRolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1656), 0, "Yeni bir organizasyon oluşturma yetkisi", false, "CreateOrganization", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1666), 0 },
                    { 2, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1672), 0, "Organizasyon bilgilerini düzenleme yetkisi", false, "EditOrganization", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1672), 0 },
                    { 3, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1673), 0, "Organizasyon silme yetkisi", false, "DeleteOrganization", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1673), 0 },
                    { 4, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1674), 0, "Organizasyon bilgilerini görüntüleme yetkisi", false, "ViewOrganization", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1675), 0 },
                    { 5, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1676), 0, "Organizasyon içinde yeni rol oluşturma yetkisi", false, "CreateRole", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1676), 0 },
                    { 6, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1678), 0, "Organizasyon içindeki rolleri düzenleme yetkisi", false, "EditRole", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1678), 0 },
                    { 7, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1679), 0, "Organizasyon içindeki rolleri silme yetkisi", false, "DeleteRole", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1679), 0 },
                    { 8, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1680), 0, "Rolleri kullanıcılara atama yetkisi", false, "AssignRole", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1681), 0 },
                    { 9, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1681), 0, "Rolleri görüntüleme yetkisi", false, "ViewRoles", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1682), 0 },
                    { 10, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1683), 0, "Yeni görev oluşturma yetkisi", false, "CreateTask", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1683), 0 },
                    { 11, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1684), 0, "Mevcut görevleri düzenleme yetkisi", false, "EditTask", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1684), 0 },
                    { 12, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1685), 0, "Görev silme yetkisi", false, "DeleteTask", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1686), 0 },
                    { 13, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1686), 0, "Görev bilgilerini görüntüleme yetkisi", false, "ViewTask", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1687), 0 },
                    { 14, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1687), 0, "Görevleri kullanıcılara atama yetkisi", false, "AssignTask", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1688), 0 },
                    { 15, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1688), 0, "Görev durumunu güncelleme yetkisi", false, "UpdateTaskStatus", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1689), 0 },
                    { 16, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1689), 0, "Görev durumu güncellemelerini görüntüleme yetkisi", false, "ViewTaskUpdates", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1690), 0 },
                    { 17, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1690), 0, "Organizasyona kullanıcı ekleme yetkisi", false, "AddUserToOrganization", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1691), 0 },
                    { 18, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1725), 0, "Organizasyondan kullanıcı çıkarma yetkisi", false, "RemoveUserFromOrganization", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1725), 0 },
                    { 19, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1726), 0, "Organizasyon kullanıcılarını görüntüleme yetkisi", false, "ViewOrganizationUsers", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1726), 0 },
                    { 20, new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1727), 0, "İzinleri yönetme yetkisi", false, "ManagePermissions", new DateTime(2024, 12, 6, 16, 47, 23, 994, DateTimeKind.Local).AddTicks(1727), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRole_OrganizationId",
                table: "OrganizationRole",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRolePermission_OrganizationRoleId",
                table: "OrganizationRolePermission",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRolePermission_PermissionId",
                table: "OrganizationRolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizationRole_OrganizationRoleId",
                table: "UserOrganizationRole",
                column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizationRole_UserId",
                table: "UserOrganizationRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationRolePermission");

            migrationBuilder.DropTable(
                name: "UserOrganizationRole");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "OrganizationRole");
        }
    }
}
