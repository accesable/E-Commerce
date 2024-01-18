using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerces.Models;
public class Category{
    [Key]
    public int Id {get;set;}
    [Required]
    [StringLength(100)]
    public string ? Name {get;set;}

    public virtual ICollection<Product> ? Products {get;set;}

}