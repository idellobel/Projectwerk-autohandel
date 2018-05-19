using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }


        public int OrderId { get; set; }

        public string ArtikelNummer { get; set; }

        public int Aantal { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "De {0} is vereist")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Prijs { get; set; }

        public virtual OnderdelenProducten Product { get; set; }

        public virtual Order Order { get; set; }

        public virtual Faktuur Faktuur { get; set; }
    }
}
