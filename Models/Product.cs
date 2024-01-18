using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace E_Commerces.Models;
[Table("Products")]
public class Product{
    [Key]
    public int Id {get;set;}
    [Required]
    [StringLength(100)]
    [Column(TypeName = "Nvarchar(100)")]
    [Display(Name = "Product's Name")]
    public String ? ProductName {get;set;}
    [Required]
     public double ImportedPrice {get;set;}
    [Required]
    public double RetailPrice {get;set;}

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DefaultValue(true)]
    public DateTime CreationTime {get;set;} = DateTime.Now;
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category ? Category {get;set;}
}