using Microsoft.AspNetCore.Http;

namespace Conferencia.Aplication.Interface
{
    public interface IUploadExcelService
    {
        void ReadExcel(IFormFile arquivo);
    }
}
