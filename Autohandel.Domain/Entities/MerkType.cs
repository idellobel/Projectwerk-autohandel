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

        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(75, MinimumLength = 2, ErrorMessage = "{0} dient een lengte te hebben van 2 tot 75 karakters")]
        public string MerkTypeNaam { get; set; }

        [ForeignKey("Merk")]
        public long MerkId { get; set; }
        public virtual Merk VoertuigMerk { get; set; }

        public virtual ICollection<Voertuig> Voertuigen { get; set; }

    }
}
