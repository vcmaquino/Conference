using Conferencia.Aplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conferencia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IUploadExcelService _uploadExcelService;
        public UploadController(IUploadExcelService uploadExcelService)
        {
            _uploadExcelService = uploadExcelService;
        }

        [HttpPost]
        public void ReadExcel([FromForm] IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    _uploadExcelService.ReadExcel(file);
                }
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }
    }
}
