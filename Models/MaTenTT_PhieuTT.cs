using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhieuEVN.Models
{
    public class MaTenTT_PhieuTT
    {
        public MaTenTT_PhieuTT(string maPhieuThaoTac, string tenPhieuThaoTac, int? trangThai)
        {
            MaPhieuThaoTac = maPhieuThaoTac;
            TenPhieuThaoTac = tenPhieuThaoTac;
            TrangThai = trangThai;
        }
        public MaTenTT_PhieuTT() { }
        public string MaPhieuThaoTac { get; set; }
        public string TenPhieuThaoTac { get; set; }
        public Nullable<int> TrangThai { get; set; }
    }
}