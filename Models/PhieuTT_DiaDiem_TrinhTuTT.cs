using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhieuEVN.Models
{
    public class PhieuTT_DiaDiemTT_TrinhTuTT
    {
        public List<DiaDiemThaoTac> DsDiaDiemThaoTac { get ; set ; }
        public List<TrinhTuThaoTac> DsTrinhTuThaoTac { get; set; }
        public PhieuThaoTac PhieuThaoTac { get; set; }
    }
}