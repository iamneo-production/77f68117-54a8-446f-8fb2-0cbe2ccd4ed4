using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class DocumentModel
    {
        [Key]
        public int DocumentId { get; set; }

        public string? DocumentType { get; set; }

        public byte[]? DocumentUpload { get; set; }

        public string? DocName { get; set; }

    }
}
