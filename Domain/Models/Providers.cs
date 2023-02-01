using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Providers
    {
        [Column("CODE")]
        public int Code { get; set; }
        [Column("DESCRIPTION")]
        public string? Description { get; set; }
        [Column("CNPJ")]
        public string? CNPJ { get; set; }
        public List<Products> Products { get; set; }
    }
}
