using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment1;

        public UploadFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment1 = webHostEnvironment;
        }

        [HttpPost]
        public async Task<string> post([FromForm] UploadFile upload)
        {
            try
            {
                if (upload.image.Length >= 0)
                {
                    string path = _webHostEnvironment1.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + upload.image.FileName))
                    {
                        upload.image.CopyTo(fileStream);
                        fileStream.Flush();
                        return "upload done"; 
                    }
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet("{fileName}.png")]
        public async Task<IActionResult> Get(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment1.WebRootPath, "upload", fileName + ".png");

            if (System.IO.File.Exists(path))
            {
                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(path);
                return File(fileBytes, "image/png");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
