using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class MerkType
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MerkTypeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string MerkTypeNaam { get; set; }

        public Merk VoertuigMerk { get; set; }
    }
}
