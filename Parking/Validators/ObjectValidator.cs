using System.ComponentModel.DataAnnotations;

public class ObjectValidator : IObjectValidator
{
    public void Validate(Object data)
    {
        if(data == null)
        {
            throw new Exception("All mandatory fields must be entered!");
        }
        
        var results = new List<ValidationResult>();
        var context = new ValidationContext(data);
        bool isValid = Validator.TryValidateObject(data, context, results, true);

        if(!isValid)
        {
           foreach(ValidationResult item in results)
           {
                throw new Exception(item.ErrorMessage);
           }
        }
    }
}