using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("[action]")]
        public IActionResult UploadFile(List<IFormFile> files)
        {
            if (files.Count == 0)
                return BadRequest("chọn file");
            string directoryPath = Path.Combine(webHostEnvironment.ContentRootPath, "UploadedFiles");
            foreach(var file in files)
            {
                string filePath= Path.Combine(directoryPath, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Ok(files);
        }

    }
}
