# DotnetAuthv2 Docker Kurulumu

Bu proje .NET 9.0 ile geliştirilmiş bir authentication API'sidir ve Docker ile kolayca çalıştırılabilir.

## Gereksinimler

- Docker Desktop
- Docker Compose

## Hızlı Başlangıç

### Yöntem 1: PowerShell Script ile (Önerilen)

```powershell
.\docker-setup.ps1
```

### Yöntem 2: Manuel Kurulum

1. **Konteynerleri başlat:**

   ```bash
   docker-compose up -d --build
   ```

2. **SQL Server'ın başlamasını bekle (yaklaşık 30 saniye)**

3. **Database migration'ları çalıştır:**
   ```bash
   docker-compose exec dotnetauthv2 dotnet ef database update
   ```

## Erişim

- **API**: http://localhost:8080
- **Swagger UI**: http://localhost:8080/swagger
- **SQL Server**: localhost:1433
  - Kullanıcı: `sa`
  - Şifre: `YourStrong!Passw0rd`

## Yararlı Komutlar

### Logları görüntüle

```bash
docker-compose logs -f dotnetauthv2
```

### Konteynerleri durdur

```bash
docker-compose down
```

### Konteynerleri tamamen kaldır (veriler dahil)

```bash
docker-compose down -v
```

### Sadece API'yi yeniden başlat

```bash
docker-compose restart dotnetauthv2
```

## Sorun Giderme

1. **Port zaten kullanılıyor hatası**: 8080 veya 1433 portlarının başka bir uygulama tarafından kullanılmadığından emin olun.

2. **SQL Server bağlantı hatası**: SQL Server'ın tamamen başlamasını bekleyin (yaklaşık 30-60 saniye).

3. **Migration hatası**: SQL Server başladıktan sonra migration komutunu tekrar çalıştırın:
   ```bash
   docker-compose exec dotnetauthv2 dotnet ef database update
   ```

## Yapılandırma

Docker ortamındaki yapılandırma `appsettings.Docker.json` dosyasında bulunmaktadır. Connection string'ler ve diğer ayarlar bu dosyadan okunur.

# PowerShell script ile (en kolay)

.\docker-setup.ps1

# Veya manuel olarak

docker-compose up -d --build

# 30 saniye bekle

docker-compose exec dotnetauthv2 dotnet ef database update
