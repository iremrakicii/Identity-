# Kullanıcı Kayıt Sistemi

Bu proje, temel bir kullanıcı kayıt sistemi uygulamasıdır. ASP.NET Core kullanılarak geliştirilmiştir ve kullanıcıların kaydedilmesi, şifrelerin hashlenmesi ve kayıt kontrolü gibi özellikleri içerir.

## Proje Mimarisi

Proje, aşağıdaki katmanlardan oluşmaktadır:

1. **Controllers**: API isteklerini ele alır ve iş mantığını yönetir.
2. **Data**: Veritabanı bağlantısı ve model oluşturma için gerekli DbContext tanımlarını içerir.
3. **Models**: Kullanılan veritabanı tablolarının yapısını tanımlar.
4. **Services**: Parola hashleme ve doğrulama gibi şifreleme ile ilgili işlevleri barındırır.

---

## Kullanım

### 1. Veritabanı Bağlantısı
Projede **Entity Framework Core** kullanılmıştır. Bağlantı ayarlarınızı `AppDbContext` içinde belirtilen `DbContextOptions` üzerinden yapabilirsiniz.

**Örnek:**
```csharp
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```

### 2. Kullanıcı Kaydetme
Bir kullanıcıyı kaydetmek için `POST` isteği ile `/api/User/register` endpoint’ine aşağıdaki formatta bir JSON gönderin:

#### Örnek JSON:
```json
{
  "email": "example@example.com",
  "password": "yourPassword"
}
```

#### Örnek Cevap:
- **Başarılı:**
```json
{
  "message": "User registered successfully."
}
```
- **Hata (Email mevcut):**
```json
"Email already exists."
```

### 3. Parola Hashleme
Parolaların düz metin olarak saklanmaması için `PasswordHasherService` sınıfı kullanılmaktadır. Şifre hashleme işlevi aşağıdaki gibidir:

```csharp
var passwordHasher = new PasswordHasherService();
string hashedPassword = passwordHasher.HashPassword("plainTextPassword");
```

Doğrulama için:
```csharp
bool isPasswordValid = passwordHasher.VerifyPassword("plainTextPassword", "hashedPassword");
```

---

## Proje Dosyaları

### 1. **Controllers/UserController.cs**
- Kullanıcı API isteklerini ele alır.
- Kullanıcı kayıt işlemine izin verir.

### 2. **Data/AppDbContext.cs**
- `Users` adında bir DbSet tanımlar.
- Kullanıcı modelinin veritabanı şemasını oluşturur.

### 3. **Models/User.cs**
- Kullanıcı modeli tanımlanır.
- Email ve Password alanları zorunludur.

### 4. **Services/PasswordHasherService.cs**
- Parola hashleme ve doğrulama işlemleri için bir servis.

---

## Gereksinimler

- **.NET 6 SDK**
- **Entity Framework Core**
- **Microsoft.AspNetCore.Identity**

---

## Kurulum

1. Projeyi klonlayın:
   ```bash
   git clone <repo-url>
   ```

2. Gerekli bağımlılıkları yükleyin:
   ```bash
   dotnet restore
   ```

3. Veritabanınızı ayarlayın ve migrationı çalıştırın:
   ```bash
   dotnet ef database update
   ```

4. Projeyi çalıştırın:
   ```bash
   dotnet run
   ```

---



