using dotnetapp.Core.Interfaces;
using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace dotnetapp.Core
{
    public class DocumentCore : IDocument
    {
        private readonly EducationLoanContext educationLoanContext;
        private readonly ILogger<DocumentCore> logger;
        
        public DocumentCore(EducationLoanContext educationalloancontext, ILogger<DocumentCore> logger)
        {
            this.educationLoanContext = educationalloancontext;
            this.logger = logger;   
        }

        public bool UploadFile(IFormFile file)
        {
            try
            {
                logger.LogInformation("entering try block");
                if (file == null || file.Length == 0)
                {
                    logger.LogError("returning the bad request no file selected !!");
                    return false;
                }

                if (file.Length > 2 * 1024 * 1024)
                {
                    logger.LogError("Returning the message that 2mb or less than that for upload");

                    // return BadRequest("only 2mb or less than that can be uploaded");
                    return false;
                }

                logger.LogInformation("Checking Extension of the file");
                var fileName = file.FileName;

                var extension = Path.GetExtension(fileName);


                var permitableextension = new[] { ".jpg", ".jpeg", ".png", ".pdf" };

                if (!permitableextension.Contains(extension.ToLower()))
                {
                    //return BadRequest("Image or pdf only");
                    return false;
                }

                using (var memorystream = new MemoryStream())
                {
                    file.CopyTo(memorystream);
                    var filedata = memorystream.ToArray();
                    var documentupload = new DocumentModel
                    {
                        DocName = fileName,
                        DocumentUpload = filedata,
                        DocumentType = file.ContentType
                    };

                    educationLoanContext.documentModels?.Add(documentupload);
                    educationLoanContext.SaveChanges();
                }
                // return Ok("Uploaded sucessfully");
                return true;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }   
        }
    }
}
