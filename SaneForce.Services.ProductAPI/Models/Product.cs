using System.ComponentModel.DataAnnotations;

namespace SaneForce.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int Code {  get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }   
    }
}
