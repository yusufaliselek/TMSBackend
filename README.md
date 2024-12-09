TR
# TMSBackend

TMSBackend, .NET 8 Web API kullanılarak geliştirilmiş bir görev yönetim sistemidir. Kullanıcı kimlik doğrulama, rol tabanlı izinler, organizasyon yönetimi ve görev takibi gibi özellikleri destekler.

## Özellikler

- **Kullanıcı Kimlik Doğrulama**: JWT tabanlı token ile kullanıcı girişi ve kaydı.
- **Rol Tabanlı Yetkilendirme**: Organizasyon içinde kullanıcılar için roller ve izinler yönetilebilir.
- **Görev Yönetimi**: Görev oluşturma, güncelleme, silme ve durum takibi.
- **Organizasyon Yapısı**: Kullanıcılar, roller ve izinler organizasyon bazında yönetilebilir.

## Teknolojiler

- .NET 8
- Entity Framework Core
- JWT Kimlik Doğrulama
- SQL Server (veya desteklenen başka bir veritabanı)

## Kurulum

### Prerequisites

- .NET 8 SDK
- SQL Server (veya başka bir desteklenen veritabanı)
- Postman veya API testi için başka bir araç.

### Depoyu Klonlayın

```bash
git clone https://github.com/your-username/TMSBackend.git
cd TMSBackend
```

### Veritabanı Yapılandırması

1. `appsettings.json` dosyasındaki bağlantı dizesini veritabanınıza göre güncelleyin.
2. Veritabanını oluşturmak için aşağıdaki komutu çalıştırın:
3. For Mac: docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Password@strong123" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
4. For Windows: docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password@strong123" -p 1433:1433 --name mssql --hostname mssql -d mcr.microsoft.com/mssql/server:2022-latest

```bash
dotnet ef database update
```

### Uygulamayı Çalıştırma

Uygulamayı yerel olarak çalıştırmak için:

```bash
dotnet run
```

API varsayılan olarak `https://localhost:5001` üzerinde çalışacaktır.

### API Endpoints

- **POST** `/api/auth/login` - Kullanıcı girişi ve JWT token alma.
- **POST** `/api/auth/register` - Yeni kullanıcı kaydı.
- **POST** `/api/auth/refresh` - JWT token yenileme.
- **GET** `/api/tasks` - Tüm görevleri listeleme.
- **POST** `/api/tasks` - Yeni görev oluşturma.
- **PUT** `/api/tasks/{taskId}` - Mevcut bir görevi güncelleme.
- **DELETE** `/api/tasks/{taskId}` - Görev silme.

### Seed Data

Projede test amaçlı bazı roller ve izinler ile önceden tanımlanmış seed data bulunmaktadır.

## Katkı

1. Depoyu fork’layın.
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/ozellik`).
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik ekle'`).
4. Dalınızı push edin (`git push origin feature/ozellik`).
5. Bir pull request oluşturun.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır - detaylar için [LICENSE](LICENSE) dosyasına bakınız.
---
EN
# TMSBackend

TMSBackend is a task management system backend developed using .NET 8 Web API. It supports user authentication, role-based permissions, organization management, and task tracking features.

## Features

- **User Authentication**: User login and registration with JWT token.
- **Role-Based Authorization**: Manage roles and permissions for users within an organization.
- **Task Management**: Create, update, delete tasks, and track their status.
- **Organizational Structure**: Manage users, roles, and permissions within an organization.

## Technologies

- .NET 8
- Entity Framework Core
- JWT Authentication
- SQL Server (or another supported database)

## Setup

### Prerequisites

- .NET 8 SDK
- SQL Server (or another supported database)
- Postman or any API testing tool.

### Clone the Repository

```bash
git clone https://github.com/your-username/TMSBackend.git
cd TMSBackend
```

### Database Setup

1. Update the connection string in `appsettings.json` to your database.
2. Run the following command to apply the database migrations:

```bash
dotnet ef database update
```

### Running the Application

Run the application locally:

```bash
dotnet run
```

The API will be hosted at `https://localhost:5001` by default.

### API Endpoints

- **POST** `/api/auth/login` - User login and JWT token generation.
- **POST** `/api/auth/register` - User registration.
- **POST** `/api/auth/refresh` - JWT token refresh.
- **GET** `/api/tasks` - Get all tasks.
- **POST** `/api/tasks` - Create a new task.
- **PUT** `/api/tasks/{taskId}` - Update an existing task.
- **DELETE** `/api/tasks/{taskId}` - Delete a task.

### Seed Data

The project includes predefined seed data for roles and permissions for testing purposes.

## Contribution

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
