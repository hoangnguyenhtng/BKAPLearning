using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using BTL_ConGa.Service.GioHang;
using BTL_ConGa.Service;
using BTL_ConGa.Models.GioHangAPI;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace BTL_ConGa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangAPIController : ControllerBase
    {
        private readonly IGioHangService _gioHangService;
        BtlWebContext db = new BtlWebContext();
        public GioHangAPIController(IGioHangService gioHangService, BtlWebContext db)
        {
            _gioHangService = gioHangService;
            this.db = db;
        }
        // Lấy tất cả món ăn trong giỏ hàng
        [HttpGet("{MaHDB}/{TaiKhoan}")]
        public async Task<IActionResult> getProductFromCart(string MaHDB, string TaiKhoan)
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK02")
            {
                var lstProduct = from product in db.MonAns
                                 join invoiceDetail in db.ChiTietHoaDonBans on product.MaMonAn equals invoiceDetail.MaMonAn
                                 join invoice in db.HoaDonBans on invoiceDetail.MaHoaDon equals invoice.MaHoaDon
                                 join khachHang in db.KhachHangs on invoice.IdkhachHang equals khachHang.IdkhachHang
                                 where invoice.MaHoaDon == MaHDB && invoice.TrangThaiThanhToan == "Chưa thanh toán"
                                 select new
                                 {
                                     invoice.MaVoucher,
                                     PhanTram = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon.Equals(MaHDB)).MaVoucher == "" ?
                                                0 : db.Vouchers.FirstOrDefault(x => x.MaVoucher == invoice.MaVoucher).PhanTram,
                                     product.MaMonAn,
                                     invoice.MaHoaDon,
                                     product.AnhDaiDien,
                                     product.TenMonAn,
                                     product.DonGia,
                                     invoiceDetail.SoLuong,
                                     invoice.TongTien,
                                     ThanhTien = invoiceDetail.SoLuong * product.DonGia
                                 };
                return Ok(lstProduct);
            }
            else
            {
                return RedirectToAction("Error404", "TrangChu");
            }
        }
        //Add thẳng vào hóa đơn
        [Route("invoiceDetailExsits")]
        [HttpPost]
        public async Task<IActionResult> AddToCartExsits([FromBody] ChiTietHoaDonDTO chiTietHoaDonBan)
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK02")
            {
                try
                {
                    await _gioHangService.AddToCartExsits(chiTietHoaDonBan);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {

                return RedirectToAction("Error404", "TrangChu");
            }
        }

        //Add 1 lúc 2 đối tượng: hóa đơn và chi tiết hóa đơn
        [Route("invoiceDetail")]
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] GioHang_HoaDon gioHang_HoaDon)
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK02")
            {
                try
                {
                    await _gioHangService.AddToCart(gioHang_HoaDon);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        //D:\Tai_Lieu_Ki_6\Lập trình web\BTL\Project\BTL_WEB_FINAL (1)\BTL_LTWEB_ChuaCoThien_Thinh\BTL_LTWEB_ChuaCoThien\BTL_LTWEB-main\BTL_LTWEB-main\BTL_ConGa\BTL_ConGa.csproj
        //Cập nhật số luọng khi món đấy có sẵn trong giỏ hàng
        [HttpPut("{maHDB}/{maMonAn}/{quantity}")]
        public async Task<IActionResult> updateQuantity(string maHDB, string maMonAn, int quantity)
        {
            var exsitsProduct = db.ChiTietHoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB
            && x.MaMonAn == maMonAn);
            if (exsitsProduct == null)
                return BadRequest();
            exsitsProduct.SoLuong = exsitsProduct.SoLuong + quantity;
            db.ChiTietHoaDonBans.Update(exsitsProduct);
            await db.SaveChangesAsync();
            return Ok(exsitsProduct);
        }
        //Xóa chi tiết hóa đơn
        [HttpDelete("{maHDB}/{maMonAn}")]
        public async Task<IActionResult> deleteInvoiceDetail(string maHDB, string maMonAn)
        {
            var exsitsProduct = db.ChiTietHoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB
            && x.MaMonAn == maMonAn);
            if (exsitsProduct == null)
                return BadRequest();
            db.ChiTietHoaDonBans.Remove(exsitsProduct);
            //Số lượng to của món ăn đấy
            var bigProduct = db.MonAns.FirstOrDefault(x => x.MaMonAn == maMonAn);
            //Lấy số luongj trong chi tiết hóa đơn
            var productDetail = db.ChiTietHoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB && x.MaMonAn == maMonAn);
            bigProduct.SoLuong = bigProduct.SoLuong + productDetail.SoLuong;
            db.MonAns.Update(bigProduct);
            await db.SaveChangesAsync();
            return Ok(exsitsProduct);
        }

        // Cập nhật số lượng khi bấm nút tăng giảm
        [Route("updateInvoiceDetail")]
        [HttpPut]
        public async Task<IActionResult> updateInvoiceDetail(string maHDB, string maMonAn, int quantity)
        {
            var exsitsProduct = db.ChiTietHoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB
            && x.MaMonAn == maMonAn);
            if (exsitsProduct == null)
                return BadRequest();
            exsitsProduct.SoLuong = quantity;
            db.ChiTietHoaDonBans.Update(exsitsProduct);
            await db.SaveChangesAsync();
            return Ok(exsitsProduct);
        }

        // Cập nhật lại số tiền
        [Route("updateMoney")]
        [HttpPut]
        public async Task<IActionResult> updateInvoiceDetail(string maHDB, double money)
        {
            var exsitsInvoice = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            if (exsitsInvoice == null)
                return BadRequest();
            exsitsInvoice.TongTien = money;
            db.HoaDonBans.Update(exsitsInvoice);
            await db.SaveChangesAsync();
            return Ok(exsitsInvoice);
        }

        //Kiểm tra có hợp lệ không
        [Route("CheckValid")]
        [HttpGet]
        public async Task<IActionResult> checkValid(string maHDB)
        {
            //Lấy số lượng cục to
            //Lấy số lượng hiện tại
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK02")
            {
                var currentProduct = from product in db.MonAns
                                     join invoiceDetail in db.ChiTietHoaDonBans on product.MaMonAn equals invoiceDetail.MaMonAn
                                     where invoiceDetail.MaHoaDon == maHDB
                                     select new
                                     {
                                         product.MaMonAn,
                                         invoiceDetail.MaHoaDon,
                                         invoiceDetail.SoLuong,
                                     };
                var check = (from product in db.MonAns
                             join current in currentProduct on product.MaMonAn equals current.MaMonAn
                             where current.SoLuong > product.SoLuong
                             select new { product.MaMonAn, product.SoLuong, product.TenMonAn }).ToList();

                if (check.Count > 0)
                    return BadRequest(check);
                else
                    return Ok(currentProduct);
            }
            else
            {
                return RedirectToAction("Error404", "TrangChu");
            }
        }

        //Cập nhật số lượng
        [Route("UpdateQuantity")]
        [HttpGet]
        public async Task<IActionResult> UpdateQuantityProduct(string maMonAn, int quantity)
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK02")
            {
                //Lấy số lượng cục to
                var product = db.MonAns.FirstOrDefault(x => x.MaMonAn == maMonAn);
                //Lấy số lượng hiện tại
                product.SoLuong = product.SoLuong - quantity;
                db.MonAns.Update(product);
                await db.SaveChangesAsync();
                return Ok(product);
            }
            else
            {
                return RedirectToAction("Error404", "TrangChu");
            }
        }

        //Cập nhật các thông tin khi đặt hàng thành công
        [Route("orderSuccess")]
        [HttpPut]
        public async Task<IActionResult> orderSuccess(string maHDB, string diaChi, string phone, string nguoiNhan, string ghiChu)
        {
            var hoaDon = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            hoaDon.NgayTao = DateTime.Now;
            hoaDon.DiaChiGiaoHang = diaChi;
            hoaDon.SoDienThoai = phone;
            hoaDon.NguoiNhan = nguoiNhan;
            hoaDon.GhiChu = ghiChu;
            hoaDon.TinhTrangDonHang = "Chờ xác nhận";
            hoaDon.TrangThaiThanhToan = "Đã thanh toán";
            db.HoaDonBans.Update(hoaDon);
            await db.SaveChangesAsync();
            return Ok(hoaDon);
        }

        //Hủy hóa đơn đang chờ xác nhận
        [Route("deleteInvoice")]
        [HttpDelete]
        public async Task<IActionResult> deleteInvoice(string maHDB)
        {
            var invoiceDetail = db.ChiTietHoaDonBans.Where(x => x.MaHoaDon == maHDB).ToList();
            db.ChiTietHoaDonBans.RemoveRange(invoiceDetail);
            await db.SaveChangesAsync();
            var invoice = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            db.HoaDonBans.Remove(invoice);
            await db.SaveChangesAsync();
            return Ok(invoiceDetail);
        }

        [Route("DonHangChoXacNhan")]
        [HttpPut]
        public bool DonHangChoXacNhan(string maHDB)
        {
            var hoadon = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            hoadon.TinhTrangDonHang = "Đã hủy";
            db.SaveChanges();
            return true;
        }

        //áp dụng voucher
        [Route("applyVoucher")]
        [HttpPut]
        public async Task<IActionResult> applyVoucher(string maHDB, string maVoucher)
        {
            var hoaDonBan = db.HoaDonBans.FirstOrDefault(x => x.MaHoaDon == maHDB);
            var applyVoucher = db.Vouchers.FirstOrDefault(x => x.MaVoucher == maVoucher);
            if (applyVoucher != null && applyVoucher.SoLuong > 0 && applyVoucher.NgayKetThuc > DateTime.Now)
            {
                hoaDonBan.MaVoucher = maVoucher;
                applyVoucher.SoLuong -= 1;
                db.Vouchers.Update(applyVoucher);
                db.SaveChanges();
                db.HoaDonBans.Update(hoaDonBan);
                db.SaveChanges();
                var getVoucher = from voucher in db.Vouchers
                                 where voucher.MaVoucher == maVoucher
                                 select new { voucher.PhanTram };
                return Ok(getVoucher.FirstOrDefault());
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
