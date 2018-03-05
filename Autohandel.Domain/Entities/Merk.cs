using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Merk
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MerkId { get; set; }

        [Required]
        [MaxLength(150)]
        public string MerkNaam { get; set; }

        public ICollection<MerkType> MerkTypes { get; set; }

    }
}