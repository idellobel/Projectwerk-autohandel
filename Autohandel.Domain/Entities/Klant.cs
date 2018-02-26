using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Klant : Persoon
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long KlantId { get; set; }

        [Required]
        public DateTime Klantdatum { get; set; }

        [Required]
        [MaxLength(150)]
        public string KlantNaam { get; set; }

        //[ForeignKey("User")]
        //public long UserId { get; set; }
        //public User User { get; set; }



    }
}