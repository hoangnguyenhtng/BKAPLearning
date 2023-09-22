using BTL_ConGa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
        [Route("LienHe")]
        [HttpPost]
        public async Task<IActionResult> LienHe([FromBody] Feedback feedback)
        {
            if (HttpContext.Session.GetString("LoaiTaiKhoan") == "LTK02")
            {
                try
                {
                    await db.Feedbacks.AddAsync(feedback);
                    await db.SaveChangesAsync();
                    return Ok(feedback);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return RedirectToAction("Error404", "TrangChu");
            }
        }
    }
}
