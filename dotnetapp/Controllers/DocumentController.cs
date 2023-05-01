using dotnetapp.Core.Interfaces;
using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DocumentController : ControllerBase
    {
        private readonly IDocument document;
        
        public DocumentController(IDocument document)
        {
            this.document = document;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var res = document.UploadFile(file);
                return Ok($"File uploaded successfully.. {res}");
            }
            catch (Exception)
            {

                throw;
            }

        }
           
    }
}
