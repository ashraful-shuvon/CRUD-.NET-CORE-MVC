using System;
using System.ComponentModel.DataAnnotations;

namespace SweaterProductionOrders.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string SweaterType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
