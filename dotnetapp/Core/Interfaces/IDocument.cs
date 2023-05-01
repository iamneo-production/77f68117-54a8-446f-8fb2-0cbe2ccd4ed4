using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace dotnetapp.Core.Interfaces
{
    public interface IDocument
    {
        bool UploadFile(IFormFile file);
    }
}
