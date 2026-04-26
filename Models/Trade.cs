using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ListReport1._3.Models
{
    public class Trade
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string? TradeName { get; set; }
    }
}
 