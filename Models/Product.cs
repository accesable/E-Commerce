using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerces.Models;
[Table("Products")]
public class Product{
    [Key]
    public int Id {get;set;}
    [Required]
    [StringLength(100)]
    [Column(TypeName = "Nvarchat(100)")]
    [Display(Name = "Product's Name")]
    [Range(5, 100, ErrorMessage = "Product's Name must be above 5 letters and below 100 letters !")]
    public String ? ProductName {get;set;}
    public double ImportedPrice {get;set;}
    public double RetailPrice {get;set;}

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime CreationTime {get;set;}
}