using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhieuEVN.Models
{
    public class PhieuTT_TrinhTuTT
    {
        public List<TrinhTuThaoTac> DsTrinhTuThaoTac { get; set; }
        public PhieuTT_TrinhTuTT() { }
        public PhieuTT_TrinhTuTT(PhieuThaoTac ptt)
        {
            DsTrinhTuThaoTac = null;
            MaPhieuThaoTac = ptt.MaPhieuThaoTac;
            TenPhieuThaoTac = ptt.TenPhieuThaoTac;
            NguoiVietPhieu = ptt.NguoiVietPhieu;
            ChucVuVietPhieu = ptt.ChucVuVietPhieu;
            NguoiDuyetPhieu = ptt.NguoiDuyetPhieu;
            ChucVuDuyetPhieu = ptt.ChucVuDuyetPhieu;
            NguoiGiamSat = ptt.NguoiGiamSat;
            ChucVuGiamSat = ptt.ChucVuGiamSat;
            NguoiThaoTac = ptt.NguoiThaoTac;
            ChucVuThaoTac = ptt.ChucVuThaoTac;
            MucDichThaoTac = ptt.MucDichThaoTac;
            TgBatDau = ptt.TgBatDau;
            TgKetThuc = ptt.TgKetThuc;
            DonViDeNghi = ptt.DonViDeNghi;
            DieuKienThucHien = ptt.DieuKienThucHien;
            LuuYKetDay = ptt.LuuYKetDay;
            BienPhapAnToan = ptt.BienPhapAnToan;
            LuuYKhac = ptt.LuuYKhac;
            SuKienBatThuong = ptt.SuKienBatThuong;
            NgayLapPhieu = ptt.NgayLapPhieu;
            NgayThaoTac = ptt.NgayThaoTac;
            TrangThai = ptt.TrangThai;
        }
        public PhieuTT_TrinhTuTT(List<TrinhTuThaoTac> dsTrinhTuThaoTac, string maPhieuThaoTac, string tenPhieuThaoTac, string nguoiVietPhieu, string chucVuVietPhieu, string nguoiDuyetPhieu, string chucVuDuyetPhieu, string nguoiGiamSat, string chucVuGiamSat, string nguoiThaoTac, string chucVuThaoTac, string mucDichThaoTac, DateTime? tgBatDau, DateTime? tgKetThuc, string donViDeNghi, string dieuKienThucHien, string luuYKetDay, string bienPhapAnToan, string luuYKhac, string suKienBatThuong, DateTime? ngayLapPhieu, DateTime? ngayThaoTac, int? trangThai)
        {
            DsTrinhTuThaoTac = dsTrinhTuThaoTac;
            MaPhieuThaoTac = maPhieuThaoTac;
            TenPhieuThaoTac = tenPhieuThaoTac;
            NguoiVietPhieu = nguoiVietPhieu;
            ChucVuVietPhieu = chucVuVietPhieu;
            NguoiDuyetPhieu = nguoiDuyetPhieu;
            ChucVuDuyetPhieu = chucVuDuyetPhieu;
            NguoiGiamSat = nguoiGiamSat;
            ChucVuGiamSat = chucVuGiamSat;
            NguoiThaoTac = nguoiThaoTac;
            ChucVuThaoTac = chucVuThaoTac;
            MucDichThaoTac = mucDichThaoTac;
            TgBatDau = tgBatDau;
            TgKetThuc = tgKetThuc;
            DonViDeNghi = donViDeNghi;
            DieuKienThucHien = dieuKienThucHien;
            LuuYKetDay = luuYKetDay;
            BienPhapAnToan = bienPhapAnToan;
            LuuYKhac = luuYKhac;
            SuKienBatThuong = suKienBatThuong;
            NgayLapPhieu = ngayLapPhieu;
            NgayThaoTac = ngayThaoTac;
            TrangThai = trangThai;
        }

        public string MaPhieuThaoTac { get; set; }
        public string TenPhieuThaoTac { get; set; }
        public string NguoiVietPhieu { get; set; }
        public string ChucVuVietPhieu { get; set; }
        public string NguoiDuyetPhieu { get; set; }
        public string ChucVuDuyetPhieu { get; set; }
        public string NguoiGiamSat { get; set; }
        public string ChucVuGiamSat { get; set; }
        public string NguoiThaoTac { get; set; }
        public string ChucVuThaoTac { get; set; }
        public string MucDichThaoTac { get; set; }
        public Nullable<System.DateTime> TgBatDau { get; set; }
        public Nullable<System.DateTime> TgKetThuc { get; set; }
        public string DonViDeNghi { get; set; }
        public string DieuKienThucHien { get; set; }
        public string LuuYKetDay { get; set; }
        public string BienPhapAnToan { get; set; }
        public string LuuYKhac { get; set; }
        public string SuKienBatThuong { get; set; }
        public Nullable<System.DateTime> NgayLapPhieu { get; set; }
        public Nullable<System.DateTime> NgayThaoTac { get; set; }
        public Nullable<int> TrangThai { get; set; }
    }
}