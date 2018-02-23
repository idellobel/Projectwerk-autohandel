using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autohandel.Domain.Entities
{
    public class CategorieOnderdelen
    {
        [Key]
        public int OnderdelenCategorieId { get; set; }
        public string OnderdelenCategorienaam { get; set; }
        public int? ParentId { get; set; }
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