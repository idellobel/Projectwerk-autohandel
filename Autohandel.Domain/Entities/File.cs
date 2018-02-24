using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public string Artikelnummer { get; set; }

        public virtual OnderdelenProducten OnderdelenProducten { get; set; }
    }

    /// <summary>
    /// FileType-enumeratie voor bestandstypes

    /// </summary>
    public enum FileType

    {
        Afbeelding = 1
    }
}