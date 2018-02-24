using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class VoertuigCategorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VoertuigCatId { get; set; }

        [Required]
        [MaxLength(150)]
        public string VoertuigCategorieNaam { get; set; }

    }
}
