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
