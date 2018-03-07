using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class Specificaties
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecificatieId { get; set; }

        //Specificaties
        //Oa Dakdragers
        [MaxLength(75)]
        public string Materie { get; set; }
        public Kleur Kleur { get; set; }
        [MaxLength(75)]
        public string GarantieTermijn { get; set; }
        [MaxLength(75)]
        public string Goedkeuring { get; set; }
        public int Breedte { get; set; }
        public int MaxBelading { get; set; }

        //Oa Dakkoffers
        public int Inhoud { get; set; }
        public int Lengte { get; set; }

        public string Opening { get; set; }
        public int Hoogte { get; set; }
        public int Gewicht { get; set; }
        public string Vergrendeling { get; set; }
        public string Montageset { get; set; }
        public bool CityCrash { get; set; }

        //Oa Fietsdragers
        public int AantalFietsen { get; set; }
        [MaxLength(75)]
        public string Fietstypes { get; set; }
        [MaxLength(75)]
        public string StekkerAansluiting { get; set; }
        public string WaaromKeuze { get; set; }
        public bool Mistlicht { get; set; }
        public Kantelfunctie Kantelfunctie { get; set; }
        public bool Inklapbaar { get; set; }

        //Oa Filters
        public int Dikte { get; set; }
        public int Buitendiameter { get; set; }
        public int Binnendiameter { get; set; }
        [MaxLength(75)]
        public string Schroefdraad { get; set; }
        [MaxLength(75)]
        public string Type { get; set; }
        public string Mengbaar { get; set; }
        [MaxLength(50)]
        public string Geur { get; set; }
        [MaxLength(150)]
        public string MinimaleTemperatuur { get; set; }

        //Oa Tapijten
        [MaxLength(75)]
        public string Mat { get; set; }
        [MaxLength(75)]
        public string Flappen { get; set; }

        //Oa Trekhaak
        public int MaxVertikaleLast { get; set; }
        public int Aanhangwagengewicht { get; set; }

        //Oa Wieldoppen
        public string Formaat { get; set; }

        //Oa Winterbanden
        public string Draagvermogen { get; set; }
        public string SnelheidIndex { get; set; }
        public string Rolgeluid { get; set; }
    }
}
