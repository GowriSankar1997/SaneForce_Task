using System.ComponentModel.DataAnnotations;

namespace SaneForce.Services.ProductAPI.Models
{
    public class OrderDetails
    {
        [Required]
        public int Qty { get; set; }
        public double Rate { get; set; }
        [Key]
        public int Code { get; set; }
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
        public double GrossTotal { get; set; }
    }
}
