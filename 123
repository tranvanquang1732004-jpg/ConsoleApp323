using System.Globalization;
    //, cul
//CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

TinhTienDien();
void TinhTienDien()
{
    Console.WriteLine("\n================ CHƯƠNG TRÌNH TÍNH TIỀN ĐIỆN EVN 2026 ================");

    // 1. Nhập số kWh tiêu thụ
    Console.Write("Nhập số kWh tiêu thụ trong tháng (số nguyên >= 0): ");
    int.TryParse(Console.ReadLine(), out int kwh);
    if (kwh < 0) kwh = 0;

    // Khai báo đơn giá các bậc (năm 2026)
    double dg1 = 1984, dg2 = 2050, dg3 = 2380, dg4 = 2998, dg5 = 3350, dg6 = 3460;
    
    var (b1, b2, b3, b4, b5, b6) = kwh switch
    {
        <= 50  => (kwh, 0, 0, 0, 0, 0),
        <= 100 => (50, kwh - 50, 0, 0, 0, 0),
        <= 200 => (50, 50, kwh - 100, 0, 0, 0),
        <= 300 => (50, 50, 100, kwh - 200, 0, 0),
        <= 400 => (50, 50, 100, 100, kwh - 300, 0),
        _      => (50, 50, 100, 100, 100, kwh - 400)
    };

    // Tính tiền cho từng bậc cụ thể
    double t1 = b1 * dg1;
    double t2 = b2 * dg2;
    double t3 = b3 * dg3;
    double t4 = b4 * dg4;
    double t5 = b5 * dg5;
    double t6 = b6 * dg6;

    // 3. Tính toán các chi phí tổng
    double tongTruocVat = t1 + t2 + t3 + t4 + t5 + t6;
    double thueVat = tongTruocVat * 0.08;
    double tongPhaiTra = tongTruocVat + thueVat;

    // 4. In bảng kê chi tiết từng bậc
   

    // In kết quả tổng hóa đơn
    Console.WriteLine($"Tổng sản lượng tiêu thụ: {kwh} kWh");
    Console.WriteLine($"Tổng tiền trước thuế   : {tongTruocVat.ToString("C0" )}");
    Console.WriteLine($"Thuế VAT (8%)          : {thueVat.ToString("C0")}" );
    Console.WriteLine($"Tổng số tiền phải trả  : {Math.Round(tongPhaiTra).ToString("C0")} (Đã làm tròn)");
    Console.WriteLine("------------------------------------------------------");

    // 5. Hỏi người dùng có muốn tiếp tục hay không (Tính năng lặp lại)
    Console.Write("Bạn có muốn tính tiếp không? (Bấm 'k' để thoát, phím bất kỳ để tiếp tục): ");
    string choices = Console.ReadLine()?.Trim().ToLower();
    
    if (choices != "c")
    {
        TinhTienDien(); 
    }
    else
    {
        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
    }
}



// Đặt cấu hình hiển thị tiền tệ tiếng Việt (đ)
Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo vnCulture = new CultureInfo("vi-VN");

// Chạy chương trình chính thông qua hàm đệ quy
ChayChuongTrinh();

void ChayChuongTrinh()
{
    Console.WriteLine("=== CHƯƠNG TRÌNH TÍNH LƯƠNG NHÂN VIÊN ===");

    // 1. Nhập dữ liệu đầu vào
    Console.Write("Nhập lương cơ bản (triệu đồng): ");
    double lươngCơBảnTriệu = double.Parse(Console.ReadLine() ?? "0");

    Console.Write("Nhập chức vụ (1: NV, 2: Trưởng nhóm, 3: Trưởng phòng, 4: Giám đốc): ");
    int chứcVụSố = int.Parse(Console.ReadLine() ?? "1");

    Console.Write("Nhập số năm thâm niên: ");
    int thâmNiên = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Nhập số giờ làm thêm (OT): ");
    double giờOT = double.Parse(Console.ReadLine() ?? "0");

    // Quy đổi sang đơn vị Đồng tiền Việt Nam
    double lươngCơBản = lươngCơBảnTriệu * 1_000_000;

    // 2. Sử dụng Pattern Matching (C# 9.0) để tính Phụ cấp chức vụ
    double phụCấpChứcVụ = chứcVụSố switch
    {
        1 => 0.5 * 1_000_000,
        2 => 2.0 * 1_000_000,
        3 => 5.0 * 1_000_000,
        4 => 12.0 * 1_000_000,
        _ => 0
    };

    // 3. Sử dụng Pattern Matching với Relational patterns (C# 9.0) tính Phụ cấp thâm niên
    double tỷLệThâmNiên = thâmNiên switch
    {
        < 3 => 0.0,
        >= 3 and <= 5 => 0.05,
        >= 6 and <= 10 => 0.10,
        > 10 => 0.18
    };
    double phụCấpThâmNiên = lươngCơBản * tỷLệThâmNiên;

    // 4. Tính tiền làm thêm giờ (OT) - Giả định 1 tháng làm việc tiêu chuẩn 160 giờ
    double lươngMỗiGiờ = lươngCơBản / 160; 
    double tiềnOT = giờOT switch
    {
        <= 40 => giờOT * lươngMỗiGiờ * 1.5,
        > 40 => (40 * lươngMỗiGiờ * 1.5) + ((giờOT - 40) * lươngMỗiGiờ * 2.0)
    };

    // 5. Tính tổng thu nhập trước khấu trừ
    double tổngThuNhập = lươngCơBản + phụCấpChứcVụ + phụCấpThâmNiên + tiềnOT;

    // 6. Tính các khoản khấu trừ
    double khấuTrừBH = (lươngCơBản + phụCấpChứcVụ) * 0.105;

    // Tính thuế TNCN dựa trên thu nhập chịu thuế (tính bằng triệu đồng để so khớp biểu thuế)
    double tổngThuNhậpTriệu = tổngThuNhập / 1_000_000;
    double tỷLệThuếTNCN = tổngThuNhậpTriệu switch
    {
        < 10 => 0.0,
        >= 10 and <= 20 => 0.05,
        > 20 and <= 35 => 0.10,
        > 35 => 0.15
    };
    double khấuTrừThuế = tổngThuNhập * tỷLệThuếTNCN;

    // 7. Tính lương thực nhận (Làm tròn xuống bằng Math.Floor)
    double lươngThựcNhận = Math.Floor(tổngThuNhập - khấuTrừBH - khấuTrừThuế);

    // 8. Xuất kết quả chi tiết
    Console.WriteLine("\n--- CHI TIẾT BẢNG LƯƠNG ---");
    Console.WriteLine($"Lương cơ bản: {lươngCơBản.ToString("C0", vnCulture)}");
    Console.WriteLine($"Phụ cấp chức vụ: {phụCấpChứcVụ.ToString("C0", vnCulture)}");
    Console.WriteLine($"Phụ cấp thâm niên: {phụCấpThâmNiên.ToString("C0", vnCulture)}");
    Console.WriteLine($"Tiền làm thêm giờ (OT): {tiềnOT.ToString("C0", vnCulture)}");
    Console.WriteLine($"-----------------------------------");
    Console.WriteLine($"Tổng thu nhập trước khấu trừ: {tổngThuNhập.ToString("C0", vnCulture)}");
    Console.WriteLine($"Khấu trừ BHXH + BHYT (10.5%): {khấuTrừBH.ToString("C0", vnCulture)}");
    Console.WriteLine($"Khấu trừ thuế TNCN: {khấuTrừThuế.ToString("C0", vnCulture)}");
    Console.WriteLine($"-----------------------------------");
    Console.WriteLine($"LƯƠNG THỰC NHẬN: {lươngThựcNhận.ToString("C0", vnCulture)}");
    Console.WriteLine("-----------------------------------");

    // 9. Lặp lại không dùng vòng lặp (Sử dụng Đệ Quy)
    Console.Write("\nBạn có muốn tính tiếp cho nhân viên khác không? (Y/N): ");
    string tiếpTục = Console.ReadLine()?.Trim().ToUpper() ?? "N";
    
    if (tiếpTục == "v")
    {
        Console.Clear();
        ChayChuongTrinh(); // Gọi lại chính nó để tạo vòng lặp vô hạn cho đến khi bấm chân N
    }
    else
    {
        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
    }
}

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Bắt đầu lượt tính hóa đơn đầu tiên
TinhHoaDonBigMart();

// Định nghĩa hàm xử lý nghiệp vụ bằng Local Function (Tính năng mạnh mẽ từ C# 7.0+)
void TinhHoaDonBigMart()
{
    try
    {
        Console.Clear();
        Console.WriteLine("=========================================");
        Console.WriteLine("      HỆ THỐNG TÍNH HÓA ĐƠN BIGMART 2026 ");
        Console.WriteLine("=========================================");

        // 1. NHẬP THÔNG TIN KHÁCH HÀNG & HÓA ĐƠN
        Console.Write("Nhập tổng tiền mua hàng (chưa giảm giá): ");
        double tongTienBanDau = double.Parse(Console.ReadLine() ?? "0");
        if (tongTienBanDau < 0) throw new Exception("Số tiền không được âm!");

        Console.WriteLine("Chọn loại thành viên (1: Thường, 2: Silver, 3: Gold, 4: Platinum): ");
        int loaiThanhVien = int.Parse(Console.ReadLine() ?? "1");

        Console.Write("Có sử dụng voucher không? (Y/N): ");
        bool coVoucher = (Console.ReadLine() ?? "").Trim().ToUpper() == "Y";

        Console.Write("Nhập số điểm tích lũy hiện có: ");
        int diemHienCo = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Phương thức thanh toán (1: Tiền mặt, 2: Chuyển khoản/Ví điện tử): ");
        int phuongThucTT = int.Parse(Console.ReadLine() ?? "1");

        // 2. ÁP DỤNG CÁC QUY TẮC GIẢM GIÁ (THEO THỨ TỰ)

        // Bước 2.1: Tính giảm giá Thành viên
        (double tyLeCoBan, double tyLeTren2Tr, double tyLeTren5Tr) = loaiThanhVien switch
        {
            2 => (0.03, 0.04, 0.07), // Silver
            3 => (0.05, 0.06, 0.10), // Gold
            4 => (0.08, 0.07, 0.12), // Platinum
            _ => (0.00, 0.02, 0.05)  // Thường / Khác
        };

        double giamGiaThanhVien = tongTienBanDau * tyLeCoBan;
        if (tongTienBanDau > 5000000)
        {
            giamGiaThanhVien += tongTienBanDau * tyLeTren5Tr;
        }
        else if (tongTienBanDau > 2000000)
        {
            giamGiaThanhVien += tongTienBanDau * tyLeTren2Tr;
        }

        double tienSauThanhVien = tongTienBanDau - giamGiaThanhVien;

        // Bước 2.2: Tính giảm giá Voucher
        double giamGiaVoucher = 0;
        if (coVoucher)
        {
            if (tienSauThanhVien > 3000000)
            {
                giamGiaVoucher = 300000;
            }
            else if (tienSauThanhVien > 1000000)
            {
                giamGiaVoucher = 100000;
            }
        }

        double tienSauVoucher = tienSauThanhVien - giamGiaVoucher;

        // Bước 2.3: Áp dụng Điểm tích lũy (100 điểm = 10k VND)
        int soDiemSuDung = (diemHienCo / 100) * 100; 
        double giamGiaDiem = (soDiemSuDung / 100) * 10000;

        if (giamGiaDiem > tienSauVoucher)
        {
            giamGiaDiem = tienSauVoucher;
            soDiemSuDung = (int)(giamGiaDiem / 10000) * 100;
        }

        double tienSauDiem = tienSauVoucher - giamGiaDiem;

        // Bước 2.4: Tính giảm giá theo Phương thức thanh toán (Chuyển khoản/Ví giảm thêm 0.5%)
        double giamGiaPTTT = 0;
        if (phuongThucTT == 2)
        {
            giamGiaPTTT = tienSauDiem * 0.005;
        }

        double tongTienThanhToanPhaiTra = tienSauDiem - giamGiaPTTT;
        decimal thanhToanCuoiCung = Math.Round((decimal)tongTienThanhToanPhaiTra);

        // 3. TÍNH ĐIỂM TÍCH LŨY MỚI
        int diemTichLuyMoi = (int)(thanhToanCuoiCung / 100000);
        int diemConLaiSauCung = diemHienCo - soDiemSuDung + diemTichLuyMoi;

        // 4. IN KẾT QUẢ HÓA ĐƠN OUT ĐẦU RA
        Console.WriteLine("\n=========================================");
        Console.WriteLine("          HÓA ĐƠN THANH TOÁN             ");
        Console.WriteLine("=========================================");
        Console.WriteLine($"Tổng tiền hàng ban đầu:     {tongTienBanDau:N0} đ");
        Console.WriteLine($"Giảm giá thành viên:       -{Math.Round(giamGiaThanhVien):N0} đ");
        Console.WriteLine($"Giảm giá Voucher:          -{Math.Round(giamGiaVoucher):N0} đ");
        Console.WriteLine($"Khấu trừ điểm tích lũy:    -{Math.Round(giamGiaDiem):N0} đ (Dùng {soDiemSuDung} điểm)");
        Console.WriteLine($"Giảm giá thanh toán (0.5%):-{Math.Round(giamGiaPTTT):N0} đ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"TỔNG TIỀN THỰC THANH TOÁN: {thanhToanCuoiCung:N0} đ");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"Điểm tích lũy cũ:           {diemHienCo} điểm");
        Console.WriteLine($"Điểm tích lũy mới nhận được: +{diemTichLuyMoi} điểm");
        Console.WriteLine($"Tổng điểm tích lũy hiện tại: {diemConLaiSauCung} điểm");
        Console.WriteLine("=========================================");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n[LỖI] Dữ liệu nhập vào không hợp lệ: {ex.Message}");
    }

    // ĐIỀU KIỆN ĐỂ LẶP LẠI (SỬ DỤNG ĐỆ QUY)
    Console.Write("\nBạn có muốn tính hóa đơn tiếp theo không? (Y/N): ");
    string tiepTuc = (Console.ReadLine() ?? "").Trim().ToUpper();
    
    if (tiepTuc == "Y")
    {
        TinhHoaDonBigMart(); // Gọi lại chính nó để chạy lượt mới mà không cần vòng lặp
    }
    else
    {
        Console.WriteLine("\nCảm ơn bạn đã sử dụng phần mềm BigMart 2026. Tạm biệt!");
    }
}

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Kích hoạt lượt tính tiền khách sạn đầu tiên
TinhTienKhachSan();

void TinhTienKhachSan()
{
    try
    {
        Console.Clear();
        Console.WriteLine("==================================================");
        Console.WriteLine("     HỆ THỐNG QUẢN LÝ HÓA ĐƠN KHÁCH SẠN 2026      ");
        Console.WriteLine("==================================================");

        // 1. NHẬP THÔNG TIN CƠ BẢN
        Console.Write("Nhập số ngày lưu trú: ");
        int soNgayO = int.Parse(Console.ReadLine() ?? "0");
        if (soNgayO <= 0) throw new Exception("Số ngày ở phải lớn hơn 0!");

        Console.Write("Nhập số ngày rơi vào cuối tuần (Thứ 6, Thứ 7): ");
        int soNgayCuoiTuan = int.Parse(Console.ReadLine() ?? "0");
        if (soNgayCuoiTuan > soNgayO) throw new Exception("Số ngày cuối tuần không thể lớn hơn tổng số ngày ở!");

        Console.WriteLine("Chọn loại phòng (1: Standard, 2: Deluxe, 3: Suite): ");
        int loaiPhong = int.Parse(Console.ReadLine() ?? "1");

        Console.Write("Nhập số lượng người lớn: ");
        int soNguoiLon = int.Parse(Console.ReadLine() ?? "1");

        Console.Write("Nhập số lượng trẻ em: ");
        int soTreEm = int.Parse(Console.ReadLine() ?? "0");

        // 2. XỬ LÝ LOGIC GIÁ PHÒNG CƠ BẢN & PHỤ THU
        double giaPhongGocTheoNgay = 0;
        if (loaiPhong == 1)      giaPhongGocTheoNgay = 1200000; // Standard
        else if (loaiPhong == 2) giaPhongGocTheoNgay = 2500000; // Deluxe
        else if (loaiPhong == 3) giaPhongGocTheoNgay = 4800000; // Suite
        else throw new Exception("Loại phòng không hợp lệ!");

        // Tính toán số ngày trong tuần và ngày cuối tuần (Cuối tuần tăng 20%)
        int soNgayTrongTuan = soNgayO - soNgayCuoiTuan;
        double tienPhongTrongTuan = soNgayTrongTuan * giaPhongGocTheoNgay;
        double tienPhongCuoiTuan = soNgayCuoiTuan * (giaPhongGocTheoNgay * 1.2);
        double tongTienPhongChuaGiam = tienPhongTrongTuan + tienPhongCuoiTuan;

        // Phụ thu trẻ em (Miễn phí 1 trẻ, từ trẻ thứ 2 phụ thu 30% giá người lớn quy đổi theo ngày)
        double phuThuTreEm = 0;
        if (soTreEm > 1)
        {
            int soTreEmBiPhuThu = soTreEm - 1;
            // Giá người lớn quy đổi cơ bản cho toàn bộ khoảng thời gian ở
            double giaNguoiLonCoBan = tongTienPhongChuaGiam / soNguoiLon; 
            phuThuTreEm = soTreEmBiPhuThu * (giaNguoiLonCoBan * 0.3);
        }

        // Ưu đãi ở dài ngày (Từ ngày thứ 5 trở đi giảm 10% tiền phòng)
        double giamGiaDaiNgay = 0;
        if (soNgayO >= 5)
        {
            // Tính giá phòng trung bình mỗi ngày sau khi đã trộn ngày thường + cuối tuần
            double giaPhongTrungBinhMoiNgay = tongTienPhongChuaGiam / soNgayO;
            int soNgayDuocGiam = soNgayO - 4;
            giamGiaDaiNgay = soNgayDuocGiam * giaPhongTrungBinhMoiNgay * 0.1;
        }

        double tongTienPhongSauCung = tongTienPhongChuaGiam + phuThuTreEm - giamGiaDaiNgay;

        // 3. XỬ LÝ LOGIC DỊCH VỤ ĐI KÈM (IF-ELSE PHỨC TẠP)
        double tienAnSang = 0;
        double tienGiatUi = 0;
        double tienXeDuaDon = 0;
        double tienSpa = 0;

        Console.Write("Khách có dùng dịch vụ thêm không? (Y/N): ");
        if ((Console.ReadLine() ?? "").Trim().ToUpper() == "Y")
        {
            Console.Write("-> Có dùng dịch vụ Ăn sáng không? (Y/N): ");
            if ((Console.ReadLine() ?? "").Trim().ToUpper() == "Y")
            {
                // Ăn sáng tính theo số người (người lớn + trẻ em) nhân số ngày ở
                tienAnSang = (soNguoiLon + soTreEm) * 150000 * soNgayO;
            }

            Console.Write("-> Có dùng dịch vụ Giặt ủi không? (Y/N): ");
            if ((Console.ReadLine() ?? "").Trim().ToUpper() == "Y")
            {
                Console.Write("   Nhập số kg giặt ủi: ");
                double soKg = double.Parse(Console.ReadLine() ?? "0");
                tienGiatUi = soKg * 80000;
            }

            Console.Write("-> Có dùng dịch vụ Xe đưa đón sân bay không? (Y/N): ");
            if ((Console.ReadLine() ?? "").Trim().ToUpper() == "Y")
            {
                Console.Write("   Nhập số lượt xe: ");
                int soLuotXe = int.Parse(Console.ReadLine() ?? "0");
                tienXeDuaDon = soLuotXe * 600000;
            }

            Console.Write("-> Có dùng dịch vụ Spa không? (Y/N): ");
            if ((Console.ReadLine() ?? "").Trim().ToUpper() == "Y")
            {
                Console.Write("   Nhập số lượt Spa: ");
                int soLuotSpa = int.Parse(Console.ReadLine() ?? "0");
                tienSpa = soLuotSpa * 1200000;
            }
        }

        double tongTienDichVu = tienAnSang + tienGiatUi + tienXeDuaDon + tienSpa;
        double tongTienTruocKhuyenMai = tongTienPhongSauCung + tongTienDichVu;

        // 4. ÁP DỤNG CÁC TẦNG KHUYẾN MÃI TRÊN TỔNG HÓA ĐƠN
        double giamGiaKhuyenMai = 0;
        
        // Khuyến mãi 1: Ở từ 7 ngày trở lên giảm thêm 5% tổng hóa đơn
        if (soNgayO >= 7)
        {
            giamGiaKhuyenMai += tongTienTruocKhuyenMai * 0.05;
        }

        // Khuyến mãi 2: Tổng hóa đơn > 30 triệu giảm thêm 3% tổng hóa đơn
        if (tongTienTruocKhuyenMai > 30000000)
        {
            giamGiaKhuyenMai += tongTienTruocKhuyenMai * 0.03;
        }

        double tienSauKhuyenMai = tongTienTruocKhuyenMai - giamGiaKhuyenMai;

        // 5. TÍNH THUẾ VAT (10%) VÀ LÀM TRÒN
        double thueVAT = tienSauKhuyenMai * 0.1;
        decimal tongThanhToanCuoiCung = Math.Round((decimal)(tienSauKhuyenMai + thueVAT));

        // 6. IN HÓA ĐƠN CHI TIẾT
        Console.WriteLine("\n==================================================");
        Console.WriteLine("               HÓA ĐƠN TIỀN PHÒNG                 ");
        Console.WriteLine("==================================================");
        Console.WriteLine($"Số ngày ở: {soNgayO} ngày (Trong tuần: {soNgayTrongTuan} | Cuối tuần: {soNgayCuoiTuan})");
        Console.WriteLine($"Số thành viên: {soNguoiLon} Người lớn | {soTreEm} Trẻ em");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Tên khoản mục                             Thành tiền");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Giá phòng gốc chưa giảm:             {tongTienPhongChuaGiam,13:N0} đ");
        
        if (phuThuTreEm > 0)
            Console.WriteLine($"Phụ thu trẻ em (từ trẻ thứ 2):       {phuThuTreEm,13:N0} đ");
        if (giamGiaDaiNgay > 0)
            Console.WriteLine($"Ưu đãi giảm giá từ ngày thứ 5:       -{giamGiaDaiNgay,12:N0} đ");
        
        Console.WriteLine($"-> Tổng tiền phòng sau cùng:         {tongTienPhongSauCung,13:N0} đ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("CHI TIẾT DỊCH VỤ THÊM:");
        if (tienAnSang > 0)   Console.WriteLine($"- Tiền dịch vụ ăn sáng:              {tienAnSang,13:N0} đ");
        if (tienGiatUi > 0)   Console.WriteLine($"- Tiền dịch vụ giặt ủi:              {tienGiatUi,13:N0} đ");
        if (tienXeDuaDon > 0) Console.WriteLine($"- Tiền xe đưa đón sân bay:           {tienXeDuaDon,13:N0} đ");
        if (tienSpa > 0)      Console.WriteLine($"- Tiền dịch vụ trị liệu Spa:         {tienSpa,13:N0} đ");
        Console.WriteLine($"-> Tổng chi phí dịch vụ:             {tongTienDichVu,13:N0} đ");
        Console.WriteLine("--------------------------------------------------");
        if (giamGiaKhuyenMai > 0)
            Console.WriteLine($"Giảm giá khuyến mãi (HĐ lớn/Dài ngày):-{giamGiaKhuyenMai,12:N0} đ");
        Console.WriteLine($"Thuế giá trị gia tăng (VAT 10%):     {thueVAT,13:N0} đ");
        Console.WriteLine("==================================================");
        Console.WriteLine($"TỔNG TIỀN KHÁCH PHẢI THANH TOÁN:     {tongThanhToanCuoiCung,13:N0} đ");
        Console.WriteLine("==================================================");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n[LỖI HỆ THỐNG]: {ex.Message}");
    }

    // ĐIỀU KIỆN ĐỆ QUY TÍNH LƯỢT ĐẶT PHÒNG TIẾP THEO (KHÔNG DÙNG WHILE)
    Console.Write("\nBạn có muốn tính tiền cho lượt đặt phòng khác không? (Y/N): ");
    string tiepTuc = (Console.ReadLine() ?? "").Trim().ToUpper();

    if (tiepTuc == "Y")
    {
        TinhTienKhachSan(); // Gọi đệ quy
    }
    else
    {
        Console.WriteLine("\nCảm ơn bạn đã sử dụng hệ thống quản lý khách sạn. Tạm biệt!");
    }
}
