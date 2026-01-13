# HỆ THỐNG QUẢN LÝ TRƯỜNG HỌC – SCHOOL MANAGEMENT SYSTEM

## THÔNG TIN SINH VIÊN
- **Mã sinh viên:** 1671020192 
- **Họ và tên:** Phạm Đức Long 
- **Môn học:** FIT4016 – .NET Advanced  
- **Bài kiểm tra:** Thực hành 2026  

---

## 📌 MÔ TẢ DỰ ÁN (TIẾNG VIỆT)

Dự án **School Management System** được xây dựng bằng **ASP.NET Core MVC** và **Entity Framework Core**.

Ứng dụng dùng để quản lý:
- **Danh sách Trường học (Schools)**
- **Danh sách Học sinh (Students)**

Mỗi **Trường học** có thể có **nhiều Học sinh** (quan hệ 1 – N).

Trọng tâm của bài làm là **xây dựng đầy đủ các chức năng CRUD cho bảng Students**, sử dụng Entity Framework, validate dữ liệu và xử lý lỗi thân thiện với người dùng.

---

## 🛠 CÔNG NGHỆ SỬ DỤNG

- ASP.NET Core MVC
- Entity Framework Core (Code First)
- SQL Server
- Razor View
- Bootstrap
- C#

---

## 🗄 THIẾT KẾ CƠ SỞ DỮ LIỆU

### Bảng `schools`
| Cột | Kiểu dữ liệu | Mô tả |
|----|-------------|------|
| id | int | Khóa chính, tự tăng |
| name | string | Bắt buộc, không trùng |
| principal | string | Bắt buộc |
| address | string | Bắt buộc |
| created_at | datetime | Ngày tạo |
| updated_at | datetime | Ngày cập nhật |

### Bảng `students`
| Cột | Kiểu dữ liệu | Mô tả |
|----|-------------|------|
| id | int | Khóa chính, tự tăng |
| school_id | int | Khóa ngoại tới schools |
| full_name | string | Bắt buộc |
| student_id | string | Bắt buộc, không trùng |
| email | string | Bắt buộc, không trùng |
| phone | string | Có thể null |
| created_at | datetime | Ngày tạo |
| updated_at | datetime | Ngày cập nhật |

---

## ⚙️ CHỨC NĂNG CHÍNH

### ✅ QUẢN LÝ HỌC SINH (CRUD)

### 1. Thêm mới học sinh (Create)
- Thêm học sinh bằng Entity Framework
- Validate dữ liệu:
  - Họ tên: bắt buộc, 2–100 ký tự
  - Mã sinh viên: bắt buộc, không trùng
  - Email: bắt buộc, đúng định dạng, không trùng
  - Số điện thoại: tùy chọn, 10–11 chữ số
  - Trường học: bắt buộc, tồn tại trong bảng schools
- Hiển thị thông báo lỗi bằng **Tiếng Anh**

### 2. Danh sách học sinh (Read)
- Hiển thị danh sách học sinh dạng bảng
- Hiển thị đúng tên Trường học
- Phân trang (10 học sinh / trang)

### 3. Cập nhật học sinh (Update)
- Cập nhật: Họ tên, Email, Số điện thoại, Trường học
- Validate dữ liệu giống Create
- Thông báo thành công / lỗi bằng Tiếng Anh

### 4. Xóa học sinh (Delete)
- Cho phép xóa học sinh
- Có hộp thoại xác nhận trước khi xóa

---

## 🧪 DỮ LIỆU MẪU

- Tối thiểu **10 Trường học**
- Tối thiểu **20 Học sinh**
- Sinh dữ liệu mẫu bằng Entity Framework

---

