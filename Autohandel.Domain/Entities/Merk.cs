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

        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "{0} dient een lengte te hebben van 5 tot 200 karakters")]
        public string MerkNaam { get; set; }

        public virtual ICollection<MerkType> MerkTypes { get; set; }

        public virtual ICollection<Voertuig> Voertuigen { get; set; }

    }
}