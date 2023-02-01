using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ProductsDto : IValidatableObject
    {
        public int Code { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string? Description { get; set; }
        public bool Situation { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public int CodeProvider { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ManufactureDate >= ValidityDate)
            {
                yield return new ValidationResult(
                    $"Data de fabricação {ManufactureDate} não pode ser maior que a data de validade {ValidityDate}.");
            }
        }
    }
}
