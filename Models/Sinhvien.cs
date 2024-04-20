using System;
using System.Collections.Generic;

namespace NguyenDucChinh_DBFirst.Models;

public partial class Sinhvien
{
    public int MaSv { get; set; }

    public string TenSv { get; set; } = null!;

    public int Tuoi { get; set; }

    public int? MaLop { get; set; }

    public virtual Lop? MaLopNavigation { get; set; }
}
