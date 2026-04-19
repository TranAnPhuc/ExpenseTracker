# Lộ trình học tập & Ôn tập (PEMSApi)

## 0. Nền tảng hệ thống (Cậu đã tự thực hiện)
- **Môi trường:** Ubuntu, .NET 8 SDK.
- **Database:** Kết nối PostgreSQL thông qua `Npgsql.EntityFrameworkCore.PostgreSQL`.
- **Migrations:** Quản lý cấu trúc Database bằng EF Core Migrations (`dotnet ef migrations`).
- **Security:** Triển khai JWT Bearer Authentication để bảo vệ API. Cấu hình Key, Issuer, Audience trong `appsettings.json`.

## 1. Căn bản C# & Kiểu dữ liệu
- **Decimal:** Luôn dùng hậu tố `m` cho số thực (ví dụ: `100.5m`) để đảm bảo độ chính xác trong tiền tệ.
- **Parse:** Chuyển đổi từ `string` sang các kiểu dữ liệu khác dùng `decimal.Parse()` hoặc `int.Parse()`.

## 2. Lập trình hướng đối tượng (OOP) & Entity Framework
- **Inheritance (Kế thừa):** Dùng `BaseEntity` để tránh lặp code cho các thuộc tính chung (`Id`, `CreatedAt`).
- **Navigation Properties:** Truy cập dữ liệu liên quan thông qua Object (ví dụ: `t.Category.Name`). Dùng toán tử `?` để tránh lỗi Null Reference.

## 3. Tư duy Clean Code & Kiến trúc (Architecture)
- **DTO (Data Transfer Object):** 
    - Không trả về Entity gốc của Database.
    - Dùng DTO để bảo mật và tối ưu dữ liệu gửi đi.
- **Service Layer:** 
    - Controller chỉ điều hướng (Routing).
    - Service xử lý logic nghiệp vụ (Business Logic).
- **Dependency Injection (DI):** 
    - Đăng ký service trong `Program.cs` (`AddScoped`, `AddTransient`, `AddSingleton`).
    - Sử dụng thông qua **Constructor Injection**.

## 4. LINQ to Entities (Truy vấn dữ liệu)
- **Thứ tự thực hiện (Rất quan trọng):**
    1. **Nguồn:** `_context.Transactions`
    2. **Join bảng:** `.Include()`
    3. **Lọc/Sắp xếp:** `.Where()`, `.OrderByDescending()`
    4. **Phân trang:** `.Skip()`, `.Take()`
    5. **Ánh xạ:** `.Select(t => new Dto { ... })`
    6. **Thực thi:** `.ToListAsync()`

## 5. Generic & Reusability
- Sử dụng `PagedResponseDto<T>` để chuẩn hóa cấu trúc phản hồi cho mọi danh sách có phân trang.

---
*Ghi chú của Amelia: Một lập trình viên giỏi không chỉ biết viết code, mà phải biết tại sao mình viết như thế. Đừng copy-paste mù quáng.*
