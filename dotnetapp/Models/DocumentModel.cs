using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class DocumentModel
    {
        [Key]
        public int DocumentId { get; set; }

<<<<<<< HEAD
        public string DocumentType { get; set; }

        public byte[] DocumentUpload { get; set; }

        public string DocName { get; set; }
=======
        public string? DocumentType { get; set; }

        public byte[]? DocumentUpload { get; set; }

        public string? DocName { get; set; }
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a

    }
}
