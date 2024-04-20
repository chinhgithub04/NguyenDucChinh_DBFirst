using NguyenDucChinh_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NguyenDucChinh_EF_DBFirst.Models
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DbFirstContext())
            {
                // Lấy tất cả sinh viên từ cơ sở dữ liệu thuộc khoa CNTT và có độ tuổi từ 18 đến 20
                var sinhViensCNTT = context.Sinhviens
                    .Where(sv => sv.MaLopNavigation.MaKhoaNavigation.TenKhoa == "CNTT" && sv.Tuoi >= 18 && sv.Tuoi <= 20)
                    .ToList();

                // In ra thông tin của các sinh viên
                foreach (var sinhvien in sinhViensCNTT)
                {
                    Console.WriteLine($"Ma sinh vien: {sinhvien.MaSv}");
                    Console.WriteLine($"Ten sinh vien: {sinhvien.TenSv}");
                    Console.WriteLine($"Tuoi: {sinhvien.Tuoi}");
                    Console.WriteLine($"Ma lop: {sinhvien.MaLop}");
                    Console.WriteLine();
                }
            }
        }
    }
}
