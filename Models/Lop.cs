using System;
using System.Collections.Generic;

namespace NguyenDucChinh_DBFirst.Models;

public partial class Lop
{
    public int MaLop { get; set; }

    public string TenLop { get; set; } = null!;

    public int? MaKhoa { get; set; }

    public virtual Khoa? MaKhoaNavigation { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
