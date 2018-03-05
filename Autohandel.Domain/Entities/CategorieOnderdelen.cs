using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class CategorieOnderdelen
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OnderdelenCategorieId { get; set; }

        [Required(ErrorMessage = "Vul een {0} in.")]
        [Display(Name = "OnderdelenCategorie")]
        public string OnderdelenCategorienaam { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "Hoofdcategorie")]
        public virtual CategorieOnderdelen Parent { get; set; }
        public virtual ICollection<CategorieOnderdelen> Children { get; set; }
        public virtual ICollection<OnderdelenProducten> Products { get; set; }

        //public Categorie()
        //{
        //    this.SubCategories = new HashSet<Categorie>();
        //    this.Products = new HashSet<Product>();
        //}
    }
}