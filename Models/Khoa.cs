using System;
using System.Collections.Generic;

namespace NguyenDucChinh_DBFirst.Models;

public partial class Khoa
{
    public int MaKhoa { get; set; }

    public string TenKhoa { get; set; } = null!;

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}
