# ✿ LUNA SPA & AI CLINIC - HỆ THỐNG QUẢN LÝ VẬN HÀNH SPA TÍCH HỢP AI

> **Hệ thống chuyển đổi số toàn diện cho Spa & Viện thẩm mỹ da liễu công nghệ cao** với 4 phân hệ Frontend & Backend chuyên biệt cho từng vai trò (**Admin**, **Bác sĩ**, **Kỹ thuật viên/Nhân viên**, **Khách hàng VIP**) và hệ thống Trí tuệ Nhân tạo (AI) chẩn đoán hình ảnh quang phổ da, thiết kế phác đồ và hỗ trợ tư vấn 24/7.

---

## 📑 MỤC LỤC
1. [Giới Thiệu Tổng Quan](#-giới-thiệu-tổng-quan)
2. [Kiến Trúc 4 Phân Hệ Độc Lập](#-kiến-trúc-4-phân-hệ-độc-lập-frontend--backend)
3. [Các Module Trí Tuệ Nhân Tạo (AI) Đột Phá](#-các-module-trí-tuệ-nhân-tạo-ai-đột-phá)
4. [Tài Khoản Demo Đăng Nhập 4 Vai Trò](#-tài-khoản-demo-đăng-nhập-4-vai-trò)
5. [Công Nghệ Sử Dụng (Tech Stack)](#-công-nghệ-sử-dụng-tech-stack)
6. [Cấu Trúc Thư Mục Dự Án](#-cấu-trúc-thư-mục-dự-án)
7. [Hướng Dẫn Cài Đặt & Chạy Ứng Dụng](#-hướng-dẫn-cài-đặt--chạy-ứng-dụng)
8. [Cấu Hình Môi Trường (.env)](#-cấu-hình-môi-trường-env)
9. [Bảo Mật & Tính Năng Nổi Bật Khác](#-bảo-mật--tính-năng-nổi-bật-khác)

---

## 🌟 GIỚI THIỆU TỔNG QUAN

**Luna Spa & AI Clinic** là nền tảng quản trị và chăm sóc sắc đẹp thế hệ mới, giải quyết triệt để bài toán rời rạc giữa các bộ phận trong phòng khám da liễu / spa:
- **Tách biệt hoàn toàn giao diện & nghiệp vụ** của từng vị trí: Lãnh đạo điều hành, Bác sĩ điều trị, Nhân viên tiếp đón/kỹ thuật viên và Khách hàng sử dụng dịch vụ.
- **Ứng dụng AI đa tầng**: Tự động phân tích hình ảnh quang phổ làn da, phát hiện sớm các tổn thương sắc tố sâu, thiết kế thông số bước sóng laser và trợ lý ảo giải đáp thắc mắc 24/7.

---

## 🏛️ KIẾN TRÚC 4 PHÂN HỆ ĐỘC LẬP (FRONTEND & BACKEND)

Mỗi vai trò sở hữu Controller Backend riêng, tập dữ liệu chuyên trách và giao diện Frontend chuyên biệt:

```
┌────────────────────────────────────────────────────────────────────────┐
│                     LUNA SPA & AI CLINIC SYSTEM                        │
├───────────────────┬───────────────────┬────────────────┬───────────────┤
│    1. ADMIN       │    2. BÁC SĨ      │ 3. NHÂN VIÊN   │ 4. KHÁCH HÀNG │
│ (Ban Điều Hành)   │(Chuyên Khoa Da)   │ (KTV & Lễ Tân) │ (Hội Viên VIP)│
├───────────────────┼───────────────────┼────────────────┼───────────────┤
│ • P&L Tài chính   │ • Quét da AI      │ • Trạng thái   │ • Thẻ VIP Club│
│ • Quản trị kho    │ • Phác đồ Laser   │   buồng phòng  │ • Đặt lịch hẹn│
│ • Quản lý nhân sự │ • Bệnh án điện tử │ • Check-in KTV │ • Nhật ký da  │
│ • Kiểm toán AI    │ • Kê toa mỹ phẩm  │ • Thu ngân POS │ • Toa tại nhà │
└───────────────────┴───────────────────┴────────────────┴───────────────┘
```

### 1. Phân Hệ Admin (Ban Giám Đốc & Quản Trị Hệ Thống)
* **Backend:** `AdminController.cs`, `ReportsController.cs`, `EmployeesController.cs`, `ServicesController.cs`, `InventoryController.cs`, `InvoicesController.cs`
* **Frontend:** `Views/Admin/Dashboard.cshtml`, `Views/Reports/`, `Views/Inventory/`, `Views/Invoices/`
* **Chức năng chính:**
  - **Bảng điều khiển tài chính P&L thời gian thực:** Doanh thu tháng, tỷ suất lợi nhuận (60.1%), tỷ lệ lấp đầy buồng phòng (92%).
  - **Quản lý danh mục dịch vụ & thiết bị:** Thiết lập đơn giá liệu trình Laser Pico, Trẻ hóa Hifu, Aqua Detox.
  - **Quản trị nhân sự & ca trực:** Phân bổ đội ngũ bác sĩ CKI và kỹ thuật viên trị liệu.
  - **Kho dược mỹ phẩm & tiêu hao:** Tự động cảnh báo tồn kho tối thiểu, hạn sử dụng serum, gel lạnh.
  - **Audit Log & Báo cáo AI:** Thống kê khách hàng tái khám, phát hiện gian lận và tối ưu doanh số.

---

### 2. Phân Hệ Bác Sĩ (Chuyên Khoa Da Liễu & Thẩm Mỹ Công Nghệ Cao)
* **Backend:** `DoctorController.cs` (`AiDiagnosis`, `Treatments`, `Patients`, `SavePrescription`)
* **Frontend:** `Views/Doctor/Dashboard.cshtml`, `Views/Doctor/AiDiagnosis.cshtml`, `Views/Doctor/Treatments.cshtml`, `Views/Doctor/Patients.cshtml`
* **Chức năng chính:**
  - **Bàn làm việc lâm sàng:** Danh sách bệnh nhân hẹn khám trong ngày, cảnh báo da nhạy cảm từ AI.
  - **Studio Chẩn đoán hình ảnh quang phổ AI:** Phân tích 5 chỉ số lâm sàng (Melanin sắc tố, Tổn thương UV, Mật độ Collagen, Bã nhờn, Vi khuẩn P.Acnes) theo thời gian thực.
  - **Bộ điều chỉnh thông số Laser & Năng lượng:** Tính toán mức năng lượng xung Pico (J/cm²), bước sóng (1064nm / 532nm) và độ rộng xung phù hợp với từng phân loại da Fitzpatrick.
  - **Bệnh án điện tử (EHR):** Lưu trữ lịch sử can thiệp thủ thuật, hình ảnh trước/sau điều trị và chỉ định tái khám.
  - **Kê toa dược mỹ phẩm y khoa:** Kê đơn routine dưỡng da tại nhà ký số điện tử.

---

### 3. Phân Hệ Nhân Viên (Kỹ Thuật Viên & Lễ Tân Tác Nghiệp)
* **Backend:** [StaffController.cs](file:///d:/Giao%20di%E1%BB%87n%20spa/Controllers/StaffController.cs) (`Dashboard`, `CheckIn`, `Appointments`, `POS`, `Supplies`, `QuickCheckIn`, `UpdateBedStatus`, `CompleteTask`, `ProcessPOSOrder`, `RequestSupply`)
* **Frontend:**
  - `Views/Staff/Dashboard.cshtml`: Bản đồ buồng phòng & giường điều trị thời gian thực (Interactive Floor Plan) có đồng hồ đếm ngược tiến trình và nút chuyển đổi trạng thái giường (Sẵn sàng / Đang phục vụ / Đang vô trùng).
  - `Views/Staff/CheckIn.cshtml`: Trạm tiếp đón khách hàng, chọn buồng giường còn trống, ghi nhận tình trạng da ban đầu và check-in 1-click.
  - `Views/Staff/Appointments.cshtml`: Danh sách ca phục vụ theo timeline, bảng kiểm tra quy trình kỹ thuật 4 bước (Protocol Checklist) và nút hoàn tất ca kèm tính hoa hồng dịch vụ.
  - `Views/Staff/POS.cshtml`: Trạm thu ngân POS & bán lẻ mỹ phẩm tại quầy, chiết khấu 10% thẻ VIP, tự động tạo mã VietQR kèm số tiền và nội dung chuyển khoản tức thời.
  - `Views/Staff/Supplies.cshtml`: Quản lý vật tư tiêu hao buồng phòng (Gel siêu âm, Mặt nạ tế bào gốc, Serum HA B5, Khăn ấm) và gửi phiếu xin cấp thêm từ kho tổng.

---

### 4. Phân Hệ Khách Hàng (Cổng Hội Viên VIP Cá Nhân)
* **Backend:** [CustomerPortalController.cs](file:///d:/Giao%20di%E1%BB%87n%20spa/Controllers/CustomerPortalController.cs) (`Index`, `Appointments`, `History`, `MyPrescriptions`, `Vouchers`, `BookOnline`, `CancelAppointment`, `ToggleHabit`, `RedeemPoints`, `SubmitReview`)
* **Frontend:**
  - `Views/CustomerPortal/Index.cshtml`: Thẻ hội viên VIP số (Diamond Member Card) hiệu ứng Glassmorphism sang trọng, mã QR thẻ thành viên dùng để quét Check-in tại quầy, số dư điểm thưởng Luna Point hoàn tiền 10%.
  - `Views/CustomerPortal/Appointments.cshtml`: Quản lý vé hẹn điện tử (E-Ticket), đặt lịch hẹn trực tuyến 24/7 chọn Bác sĩ phụ trách, hỗ trợ xin dời lịch hoặc hủy hẹn.
  - `Views/CustomerPortal/History.cshtml`: **Interactive Before/After Image Slider** (thanh trượt kéo qua kéo lại so sánh hình ảnh da thực tế Trước vs Sau 3 buổi điều trị) và biểu đồ tiến bộ 5 chỉ số quang phổ da AI (Melanin, Độ ẩm, Collagen, Sebum, P.acnes).
  - `Views/CustomerPortal/MyPrescriptions.cshtml`: Đơn toa mỹ phẩm tại nhà (Routine Sáng / Tối) do Bác sĩ CKI kê đơn kèm tính năng **Skincare Habit Tracker** (đánh dấu vào từng bước thoa kem hàng ngày để duy trì thói quen).
  - `Views/CustomerPortal/Vouchers.cshtml`: Ví voucher ưu đãi (Voucher sinh nhật 20%, tặng buổi Aqua Detox) và trung tâm đổi điểm tích lũy lấy quà tặng/dịch vụ miễn phí.

---

## 🤖 CÁC MODULE TRÍ TUỆ NHÂN TẠO (AI) ĐỘT PHÁ

1. **AI Spectral Skin Scanner (Chẩn đoán quang phổ vi điểm):**
   - Đánh giá định lượng 5 thông số da quan trọng trên thang đo chuẩn hóa quốc tế.
   - Nhận diện tầng nám (thượng bì vs trung bì) giúp bác sĩ không bắn nhầm bước sóng laser.
2. **AI Clinical Protocol Generator (Thiết kế phác đồ cá nhân hóa):**
   - Dựa trên chỉ số da và cơ địa, AI đề xuất số buổi điều trị, tần suất giãn cách và công nghệ phối hợp (Laser Pico kết hợp HA đa tầng hoặc Hifu).
3. **Luna 24/7 Virtual Beauty Consultant (Chatbot AI Thẩm Mỹ):**
   - Widget chat thông minh hiển thị toàn hệ thống, giải đáp thắc mắc về giá dịch vụ, cách chăm sóc da sau can thiệp laser và hướng dẫn đặt hẹn.
4. **AI Financial & Stock Auditor (Kiểm toán thông minh):**
   - Tự động đối soát giữa lượng khách làm dịch vụ và định mức mỹ phẩm tiêu hao xuất kho, ngăn chặn thất thoát.

---

## 🔑 TÀI KHOẢN DEMO ĐĂNG NHẬP 4 VAI TRÒ

Hệ thống tích hợp sẵn các nút **"Đăng Nhập Nhanh 1-Click"** ngay tại hộp thoại Đăng nhập để ban giám khảo / giảng viên trải nghiệm mượt mà không cần gõ phím:

| STT | Vai Trò | Email Đăng Nhập | Mật Khẩu Mẫu | Đường Dẫn Cổng Riêng | Chức Năng Nổi Bật |
| :---: | :--- | :--- | :--- | :--- | :--- |
| **1** | **Admin (Quản Trị Tối Cao)** | `admin@lunaspa.vn` | `AdminSecure@2026!` | [`/Admin/Dashboard`](http://localhost:5000/Admin/Dashboard) | Quản lý toàn diện P&L, KPI, Nhân sự, Kho hàng, Hóa đơn |
| **2** | **Bác Sĩ Da Liễu (Doctor)** | `bacsi.yen@lunaspa.vn` | `DoctorSecure@2026!` | [`/Doctor/Dashboard`](http://localhost:5000/Doctor/Dashboard) | Studio soi da AI 5 chỉ số, phác đồ Laser, bệnh án điện tử EHR |
| **3** | **Kỹ Thuật Viên / Lễ Tân (Staff)**| `ktv.trang@lunaspa.vn` | `StaffSecure@2026!` | [`/Staff/Dashboard`](http://localhost:5000/Staff/Dashboard) | Sơ đồ buồng phòng, Check-in tiếp đón, Thu ngân POS |
| **4** | **Khách Hàng VIP (Customer)** | `khachhang@gmail.com` | `Customer@2026!` | [`/CustomerPortal/Index`](http://localhost:5000/CustomerPortal/Index) | Thẻ VIP Club, nhật ký Before/After AI, đặt lịch trực tuyến |

*(Lưu ý: Mật khẩu mặc định đơn giản `123456` cũng được chấp nhận cho mục đích kiểm thử nhanh).*

---

## 💻 CÔNG NGHỆ SỬ DỤNG (TECH STACK)

* **Backend:**
  - **Framework:** ASP.NET Core 8.0 MVC (C# 12)
  - **Kiến trúc:** Controller - View - Model tách biệt, RESTful API endpoints
  - **Xác thực:** Role-based Session Authentication & Claims Authorization
  - **Quản lý cấu hình:** `DotNetEnv` nạp biến môi trường từ tệp `.env`
* **Frontend:**
  - **Giao diện:** HTML5 Semantic + Vanilla CSS3 Design System tối tân (Custom Properties, Glassmorphism, Smooth Micro-animations)
  - **Thư viện bổ trợ:** Bootstrap 5.3 (Grid & Responsive utilities), FontAwesome 6 Pro icons
  - **Trực quan hóa:** Chart.js (Biểu đồ quang phổ da & tài chính)
* **Bảo mật & Trải nghiệm:**
  - Password Visibility Eye Toggle (Mắt xem mật khẩu cả Đăng nhập & Đăng ký)
  - Profile Management Studio (Tự chỉnh sửa họ tên, avatar màu, chuyên môn, số điện thoại)
  - Toast Notification System (Luna Floating Toast thông báo tức thời)

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```bash
d:\Giao diện spa\
├── Controllers/
│   ├── AccountController.cs         # Đăng nhập, Đăng ký, Đăng xuất, Cập nhật Profile, Phân quyền 4 Role
│   ├── AdminController.cs           # Phân hệ Quản trị Admin: Dashboard, P&L, KPIs
│   ├── DoctorController.cs          # Phân hệ Bác sĩ: AI Diagnosis, Treatments, EHR Patients, Prescription
│   ├── StaffController.cs           # Phân hệ Nhân viên: Dashboard buồng phòng, CheckIn, Ca trực, POS
│   ├── CustomerPortalController.cs  # Phân hệ Khách hàng: Thẻ VIP, Lịch hẹn, Nhật ký AI, Toa thuốc
│   ├── HomeController.cs            # Trang chủ Landing Page, Giới thiệu công nghệ AI
│   ├── AIController.cs              # Trợ lý AI và phòng thí nghiệm quang phổ da
│   ├── AppointmentsController.cs    # Quản trị lịch hẹn tổng thể
│   ├── CustomersController.cs       # Quản trị cơ sở dữ liệu khách hàng
│   ├── EmployeesController.cs       # Quản trị hồ sơ bác sĩ & nhân viên
│   ├── InventoryController.cs       # Quản lý kho dược mỹ phẩm & định mức
│   ├── InvoicesController.cs        # Hóa đơn thanh toán & doanh thu
│   ├── ReportsController.cs         # Báo cáo tài chính & hiệu suất
│   └── ServicesController.cs        # Quản lý bảng giá & dịch vụ spa
├── Models/
│   ├── AuthViewModel.cs             # Models định danh: UserAccount, Login, Register, Profile
│   └── ...                          # Các Data Models nghiệp vụ
├── Views/
│   ├── Admin/                       # Giao diện riêng Quản trị viên
│   │   └── Dashboard.cshtml
│   ├── Doctor/                      # Giao diện riêng Bác sĩ chuyên khoa
│   │   ├── Dashboard.cshtml         # Bàn làm việc bác sĩ
│   │   ├── AiDiagnosis.cshtml       # Studio chẩn đoán hình ảnh da AI 5 chỉ số
│   │   ├── Treatments.cshtml        # Thư viện phác đồ Laser Pico, Hifu
│   │   └── Patients.cshtml          # Bệnh án điện tử EHR
│   ├── Staff/                       # Giao diện riêng Kỹ thuật viên & Lễ tân
│   │   ├── Dashboard.cshtml         # Sơ đồ buồng phòng & giường điều trị
│   │   ├── CheckIn.cshtml           # Trạm tiếp đón & gán phòng khách
│   │   ├── Appointments.cshtml      # Lịch phân ca KTV
│   │   └── POS.cshtml               # Máy thu ngân bán lẻ mỹ phẩm tại quầy
│   ├── CustomerPortal/              # Giao diện riêng Khách hàng VIP
│   │   ├── Index.cshtml             # Cổng hội viên VIP Luna Club
│   │   ├── Appointments.cshtml      # Quản lý lịch hẹn & Đặt lịch online
│   │   ├── History.cshtml           # Nhật ký Before/After AI so sánh da
│   │   └── MyPrescriptions.cshtml   # Toa skincare y khoa tại nhà
│   ├── Home/
│   │   └── Index.cshtml             # Landing page công khai với AI Showcase & Booking
│   ├── Shared/
│   │   ├── _Layout.cshtml           # Sidebar & Header phân quyền động theo Role, Modal Auth, Profile
│   │   └── ...
│   └── ...
├── wwwroot/
│   ├── css/
│   │   ├── site.css                 # Hệ thống CSS Design System cốt lõi
│   │   └── ...
│   ├── js/                          # Javascript tương tác giao diện
│   └── images/                      # Hình ảnh thực tế liệu trình & thiết bị AI
├── .env                             # Cấu hình môi trường hoạt động
├── .env.example                     # Mẫu cấu hình tham khảo
├── Program.cs                       # Khởi tạo máy chủ ASP.NET Core & Middleware
└── README.md                        # Tài liệu hướng dẫn dự án (File này)
```

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT & CHẠY ỨNG DỤNG

### Bước 1: Yêu cầu môi trường
* Đã cài đặt **.NET 8.0 SDK** (kiểm tra bằng lệnh `dotnet --version`).
* Trình duyệt web hiện đại (Google Chrome, Microsoft Edge, Firefox).

### Bước 2: Chuẩn bị tệp cấu hình `.env`
Đảm bảo tệp `.env` đã tồn tại tại thư mục gốc của dự án. Nếu chưa có, tạo bản sao từ `.env.example`:
```powershell
Copy-Item .env.example .env
```

### Bước 3: Phục hồi dependencies & Biên dịch mã nguồn
Mở PowerShell tại thư mục dự án `d:\Giao diện spa` và chạy:
```powershell
# Tải các gói thư viện NuGet
dotnet restore

# Biên dịch dự án
dotnet build
```

### Bước 4: Khởi chạy ứng dụng
```powershell
dotnet run
```

Sau khi ứng dụng khởi chạy thành công, console sẽ hiển thị:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7001
```

Mở trình duyệt và truy cập: **`http://localhost:5000`** hoặc **`https://localhost:7001`**.

---

## ⚙️ CẤU HÌNH MÔI TRƯỜNG (.ENV)

Hệ thống quản lý biến môi trường an toàn qua tệp `.env`:

```ini
# Cấu hình Cổng máy chủ
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=http://localhost:5000;https://localhost:7001

# Khóa bí mật Session
SESSION_SECRET_KEY=LunaBeautySpaAIClinic_SuperSecretKey_2026_SecureRandomBytes!
SESSION_IDLE_TIMEOUT_MINUTES=120

# Cấu hình Mô hình Trí tuệ Nhân tạo (AI)
AI_ENGINE_ENABLED=true
AI_MODEL_PROVIDER=LunaSpectralAnalysisEngine
AI_DEFAULT_CONFIDENCE_THRESHOLD=0.88
AI_MAX_TOKENS=4096

# Cấu hình Cơ sở dữ liệu
DATABASE_TYPE=InMemory
# CONNECTION_STRING=Server=localhost;Database=LunaSpaDb;Trusted_Connection=True;TrustServerCertificate=True;

# Cấu hình bảo mật Admin
ADMIN_REGISTRATION_PASSCODE=LUNASPA2026
```

---

## 🛡️ BẢO MẬT & TÍNH NĂNG NỔI BẬT KHÁC

1. **Phân Quyền Tuyệt Đối:**
   - Ngăn chặn khách hàng truy cập trái phép vào dữ liệu doanh thu hay sổ sách kế toán.
   - Bác sĩ chỉ xem và thao tác trên hồ sơ bệnh án và phân tích lâm sàng.
   - Kỹ thuật viên tập trung vào quản lý buồng phòng và ca phục vụ.
2. **Mắt Xem Mật Khẩu (Password Toggle):**
   - Hỗ trợ xem / ẩn mật khẩu bằng icon mắt `👁️ / 🙈` cho tất cả các ô nhập mật khẩu đăng nhập và đăng ký.
3. **Chỉnh Sửa Hồ Sơ Cá Nhân (Self-Profile Studio):**
   - Bất kỳ thành viên nào sau khi đăng nhập đều có thể bấm vào Avatar góc trên hoặc Sidebar để cập nhật họ tên, số điện thoại, đổi màu nền đại diện hoặc cập nhật chuyên môn công tác.
4. **Trợ Lý Chatbot AI Nổi 24/7 (Luna AI Floating Widget):**
   - Luôn sẵn sàng ở góc màn hình để hỗ trợ giải đáp quy trình dịch vụ và gợi ý kiến thức chăm sóc sắc đẹp.

---

## 📞 LIÊN HỆ & BẢN QUYỀN

* **Dự Án:** Hệ Thống Quản Lý Spa & Phòng Khám Chăm Sóc Sắc Đẹp Tích Hợp AI (Luna Spa & AI Clinic)
* **Phiên Bản:** v2.5.0 - Professional Multi-Role Architecture
* **Bản Quyền:** © 2026 Luna Beauty & Clinic. All rights reserved.
