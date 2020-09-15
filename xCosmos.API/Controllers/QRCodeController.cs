using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using xCosmos.API.Models;

namespace xCosmos.API.Controllers
{
    /// <summary>
    /// 二维码
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Generated([FromBody] GenerateQRCodeRequest model)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(model.Content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            using (var ms = new System.IO.MemoryStream())
            {
                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var imgUrl = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
                return Ok(imgUrl);
            }
        }
    }
}
