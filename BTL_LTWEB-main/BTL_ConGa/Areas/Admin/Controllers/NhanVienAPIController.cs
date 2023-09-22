using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BTL_ConGa.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();

        [HttpGet]
        public IEnumerable<Models.NhanVien> GetAllNhanVien()
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK03")
            {
                var nhanvien = db.NhanViens.ToList();
                return nhanvien;
            }
            else
            {
                HttpContext.Response.Redirect("/TrangChu/Error404");
                return null;
            }
        }
        [HttpGet("{manhanvien}")]
        public IEnumerable<Models.NhanVien> GetNhanVienTheoMa(string manhanvien)
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK03")
            {
                var nhanvien = db.NhanViens.Where(x => x.MaNhanVien == manhanvien).ToList();
                return nhanvien;
            }
            else
            {
                HttpContext.Response.Redirect("/TrangChu/Error404");
                return null;
            }

        }
        [HttpPost]
        [Route("ThemNhanVien")]
        public bool ThemNhanVien(String MaNhanVien, String TenNhanVien, String DiaChi, DateTime NgaySinh, String Email,
            String SoDienThoai, String GioiTinh, string TaiKhoan, string MatKhau)
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK03")
            {
                TaiKhoan taikhoan = new TaiKhoan();
                taikhoan.TaiKhoan1 = TaiKhoan;
                taikhoan.MatKhau = MatKhau;
                taikhoan.MaLoaiTaiKhoan = "LTK01";
                db.TaiKhoans.Add(taikhoan);
                db.SaveChanges();

                Models.NhanVien nhanvien = new Models.NhanVien();
                nhanvien.MaNhanVien = MaNhanVien;
                nhanvien.TenNhanVien = TenNhanVien;
                nhanvien.DiaChi = DiaChi;
                nhanvien.NgaySinh = NgaySinh;
                nhanvien.Email = Email;
                nhanvien.SoDienThoai = SoDienThoai;
                nhanvien.GioiTinh = GioiTinh;
                nhanvien.TaiKhoan = taikhoan.TaiKhoan1;

                db.NhanViens.Add(nhanvien);
                db.SaveChanges();
                return true;
            }
            else
            {
                HttpContext.Response.Redirect("/TrangChu/Error404");
                return false;
            }

        }
    }
}
