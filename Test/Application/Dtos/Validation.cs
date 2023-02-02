using System.ComponentModel.DataAnnotations;

namespace Test.Applcation.Dtos
{
    public class Validation
    {
        public IList<ValidationResult> ValidationProperties(object model)
        {
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            Validator.TryValidateObject(model, validationContext, result, validateAllProperties: true);

            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            return result;
        }
    }
}
