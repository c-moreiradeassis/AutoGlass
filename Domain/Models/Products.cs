using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Products
    {
        [Column("CODE")]
        public int Code { get; set; }
        [Column("CODE_PROVIDER")]
        public int CodeProvider { get; set; }
        [Column("DESCRIPTION")]
        public string? Description { get; set; }
        [Column("SITUATION")]
        public bool Situation { get; set; }
        [Column("MANUFACTURE_DATE")]
        public DateTime ManufactureDate { get; set; }
        [Column("VALIDITY_DATE")]
        public DateTime ValidityDate { get; set; }
        public Providers Providers { get; set; }
    }
}
