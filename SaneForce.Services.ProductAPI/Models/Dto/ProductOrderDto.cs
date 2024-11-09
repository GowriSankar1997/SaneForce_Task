using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace SaneForce.Services.ProductAPI.Models.Dto
{
    public class ProductOrderDto
    {
        public int Qty { get; set; }
        public double Rate { get; set; }
        public int Code { get; set; }
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
        public double GrossTotal { get; set; }

    }
}
