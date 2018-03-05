using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Garantie
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GarantieId { get; set; }

        [Required]
        public DateTime Vervaldatum { get; set; }

        
        public Faktuur Faktuur { get; set; }

        [ForeignKey("Faktuur")]
        public long FaktuurId { get; set; }


    }
}