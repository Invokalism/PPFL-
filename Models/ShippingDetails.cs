using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ListReport1._3.Models
{
    public class ShippingDetails
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "JO. NO.")]
        public string? JobNo { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "TRADE")]
        public string? Trade { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "HBL NO.")]
        public string? HblNo { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "MBL NO.")]
        public string? MblNo { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "ATA")]
        public string? Ata { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "POL/POD")]
        public string? PolPod { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "SHIPPER/CONSIGNEE")]
        public string? Shipper { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "VESSEL")]
        public string? Vessel { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "COMMODITY")]
        public string? Commodity { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "TUES (FCL/LCL)")]
        public string? Teus { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "VOLUME")]
        public string? Volume { get; set; }


        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "MEAS.")]
        public string? Measurement { get; set; }

        public int? Flag { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "PAYABLE TO AGENT")]
        public string? AgentName { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "INVOICE NO.")]
        public string? AgentInvoiceNo { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "AMOUNT")]
        public decimal? AgentAmount { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "DATE ISSUED")]
        public string? AgentDateIssued { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "DATE PAID")]
        public string? AgentDatePaid { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "PAYABLE TO (SL/CONSOL")]
        public string? SlPayable { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "INVOICE NO.")]
        public string? SlInvoiceNo { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "AMOUNT")]
        public decimal? SlAmount { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "DATE ISSUED")]
        public string? SlDateIssued { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "DATE PAID")]
        public string? SlDatePaid { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "SL NO")]
        public string? SlNum { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "AMOUNT")]
        public decimal? SlNumAmount { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "EWT")]
        public decimal? Ewt { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "TOTAL (NET OF EWT)")]
        public decimal? EwtTotal { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "DM NO (PHP)")]
        public string? DmPhp { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        public decimal? DmPhpAmount { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "DM NO (USD)")]
        public string? DmUsd { get; set; }

        [DataType(DataType.Currency)] 
        [Display(Name = "Amount")]
        public decimal? DmUsdAmount { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "REVENUE")]
        public decimal? Revenue { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "PROFIT FROM")]
        public string? ProfitFrom { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "AMOUNT")]
        public decimal? ProfitAmount { get; set; }





    }
}
