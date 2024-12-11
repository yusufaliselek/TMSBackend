using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.DataAccess.SeedData
{
    public static class PermissionSeed
    {
        public static IEnumerable<Permission> GetPermissions()
        {
            return new List<Permission>
        {
                new Permission { Id = 1, Name = "EditOrganization", Description = "Organizasyon bilgilerini düzenleme yetkisi" },
                new Permission { Id = 2, Name = "DeleteOrganization", Description = "Organizasyon silme yetkisi" },
                new Permission { Id = 3, Name = "ViewOrganization", Description = "Organizasyon bilgilerini görüntüleme yetkisi" },

                // Organizasyon rol izinleri
                new Permission { Id = 4, Name = "CreateRole", Description = "Organizasyon içinde yeni rol oluşturma yetkisi" },
                new Permission { Id = 5, Name = "EditRole", Description = "Organizasyon içindeki rolleri düzenleme yetkisi" },
                new Permission { Id = 6, Name = "DeleteRole", Description = "Organizasyon içindeki rolleri silme yetkisi" },
                new Permission { Id = 7, Name = "AssignRole", Description = "Rolleri kullanıcılara atama yetkisi" },
                new Permission { Id = 8, Name = "ViewRoles", Description = "Rolleri görüntüleme yetkisi" },

                // Görev izinleri
                new Permission { Id = 9, Name = "CreateTask", Description = "Yeni görev oluşturma yetkisi" },
                new Permission { Id = 10, Name = "EditTask", Description = "Mevcut görevleri düzenleme yetkisi" },
                new Permission { Id = 11, Name = "DeleteTask", Description = "Görev silme yetkisi" },
                new Permission { Id = 12, Name = "ViewTask", Description = "Görev bilgilerini görüntüleme yetkisi" },
                new Permission { Id = 13, Name = "AssignTask", Description = "Görevleri kullanıcılara atama yetkisi" },

                // Görev durumu güncelleme izinleri
                new Permission { Id = 14, Name = "UpdateTaskStatus", Description = "Görev durumunu güncelleme yetkisi" },
                new Permission { Id = 15, Name = "ViewTaskUpdates", Description = "Görev durumu güncellemelerini görüntüleme yetkisi" },

                // Kullanıcı-Organizasyon ilişkileri
                new Permission { Id = 16, Name = "AddUserToOrganization", Description = "Organizasyona kullanıcı ekleme yetkisi" },
                new Permission { Id = 17, Name = "RemoveUserFromOrganization", Description = "Organizasyondan kullanıcı çıkarma yetkisi" },
                new Permission { Id = 18, Name = "ViewOrganizationUsers", Description = "Organizasyon kullanıcılarını görüntüleme yetkisi" },

                // Diğer izinler - Daha sonra eklenebilir
                new Permission { Id = 19, Name = "ManagePermissions", Description = "İzinleri yönetme yetkisi" }
        };
        }
    }
}
