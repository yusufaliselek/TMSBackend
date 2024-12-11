### TR
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

### Gereksinimler

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
2. Veritabanını oluşturmak için aşağıdaki komutları kullanın:

#### Docker ile SQL Server Kurulumu

**Mac/Linux:**
```bash
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Password@strong123" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

**Windows:**
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password@strong123" -p 1433:1433 --name mssql --hostname mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

#### EF Migrations Uygulama

```bash
dotnet ef database update
```

### Uygulamayı Çalıştırma

Uygulamayı yerel olarak çalıştırmak için:

```bash
dotnet run
```

API varsayılan olarak `https://localhost:5001` üzerinde çalışır.


## Katkı

1. Depoyu fork’layın.
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/ozellik`).
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik ekle'`).
4. Branch'inizi push edin (`git push origin feature/ozellik`).
5. Bir pull request oluşturun.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır - detaylar için [LICENSE](LICENSE) dosyasına bakınız.


### EN

# TMSBackend
TMSBackend is a task management system developed using .NET 8 Web API. It supports features such as user authentication, role-based permissions, organization management, and task tracking.

## Features

- **User Authentication**: Login and registration with JWT-based tokens.
- **Role-Based Authorization**: Manage roles and permissions for users within an organization.
- **Task Management**: Create, update, delete tasks, and track their status.
- **Organizational Structure**: Manage users, roles, and permissions on an organizational level.

## Technologies

- .NET 8
- Entity Framework Core
- JWT Authentication
- SQL Server (or another supported database)

## Setup

### Requirements

- .NET 8 SDK
- SQL Server (or another supported database)
- Postman or another API testing tool.

### Clone the Repository

```bash
git clone https://github.com/your-username/TMSBackend.git
cd TMSBackend
```

### Database Configuration

1. Update the connection string in the `appsettings.json` file to match your database configuration.
2. Use the following commands to set up the database:

#### Setting up SQL Server with Docker

**Mac/Linux:**
```bash
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Password@strong123" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

**Windows:**
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password@strong123" -p 1433:1433 --name mssql --hostname mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

#### Apply EF Migrations

```bash
dotnet ef database update
```

### Running the Application

Run the application locally:

```bash
dotnet run
```

The API will be available at `https://localhost:5001` by default.

## Contribution

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push your branch (`git push origin feature/your-feature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
